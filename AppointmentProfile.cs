using AlvioScheduler.DbCall;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlvioScheduler
{
    public partial class AppointmentProfile : Form
    {
        public static AppointmentProfile instance;
        public string passedUsername;
        public int passedUserId;

        public AppointmentProfile()
        {
            InitializeComponent();
            instance = this;

            AppointmentProfileDatePicker.MinDate = DateTime.Today;
            AppointmentProfileStartTimePicker.CustomFormat = "hh:mm tt";
            AppointmentProfileEndTimePicker.CustomFormat = "hh:mm tt";

            Record record = new Record();
            BindingList<CustomerLimitedView> availableCustomers = record.RetrieveAllCustomers();
            BindingList<UserLimitedView> availableUsers = record.RetrieveAllUsers();
            
            DataTable tempDataTable = new DataTable();
            tempDataTable.Columns.Add("Customer ID", typeof(int));
            tempDataTable.Columns.Add("Customer Name", typeof(string));

                foreach (CustomerLimitedView customer in availableCustomers)
                {
                    tempDataTable.Rows.Add(customer.CustomerID, $"ID: {customer.CustomerID} -- {customer.CustomerName}");
                }

                AppointmentProfileCustomerComboBox.DataSource = tempDataTable;
                AppointmentProfileCustomerComboBox.DisplayMember = "Customer Name";
                AppointmentProfileCustomerComboBox.ValueMember = "Customer ID";


            DataTable tempUserTable = new DataTable();
            tempUserTable.Columns.Add("User ID", typeof(int));
            tempUserTable.Columns.Add("UserName", typeof(string));

                foreach (UserLimitedView user in availableUsers)
                {
                    tempUserTable.Rows.Add(user.userId, $"ID: {user.userId} -- {user.userName}");
                }

                AppointmentProfileUserComboBox.DataSource = tempUserTable;
                AppointmentProfileUserComboBox.DisplayMember = "UserName";
                AppointmentProfileUserComboBox.ValueMember = "User ID";

            BindingList<AppointmentLimitedView> previousAppointmentTypes = record.RetrieveAllAppointments();
            foreach (AppointmentLimitedView appointment in previousAppointmentTypes)
            {
                if (!AppointmentProfileTypeComboBox.Items.Contains(appointment.Type))
                {
                    AppointmentProfileTypeComboBox.Items.Add(appointment.Type);
                }   
            }
        }

        private void AppointmentProfile_Load(object sender, EventArgs e)
        {
            CustomerProfileAddBtn.Enabled = false;
        }
       
        private void AppointmentProfileTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(AppointmentProfileTypeComboBox.Text))
            {
                AppointmentProfileTypeComboBox.BackColor = Color.White;
                CustomerProfileAddBtn.Enabled = true;
                return;
            }

            if (String.IsNullOrEmpty(AppointmentProfileTypeComboBox.Text))
            {
                AppointmentProfileTypeComboBox.BackColor = Color.Salmon; 
                CustomerProfileAddBtn.Enabled = false;
                return;
            }
        }

        private void AppointmentProfileCancelBtn_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        private void CustomerProfileAddBtn_Click(object sender, EventArgs e)
        {
            string concatenatedDateTimeStart = $"{AppointmentProfileDatePicker.Value.ToString("yyyy-MM-dd")} " +
                $"{AppointmentProfileStartTimePicker.Value.ToString("hh:mm tt")}";
            string concatenatedDateTimeEnd = $"{AppointmentProfileDatePicker.Value.ToString("yyyy-MM-dd")} " +
                $"{AppointmentProfileEndTimePicker.Value.ToString("hh:mm tt")}";
            DateTime selectedDate = AppointmentProfileDatePicker.Value; 
            DateTime selectedStartTime = DateTime.Parse(concatenatedDateTimeStart);
            DateTime selectedEndTime = DateTime.Parse(concatenatedDateTimeEnd);

            if (selectedDate.DayOfWeek == DayOfWeek.Saturday
                || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Weekend appointments are not available at this time. Please select a day during the week.");
                return;
            }

            string userTimeZone = TimeZone.CurrentTimeZone.StandardName;
            switch (userTimeZone)
            {
                case "Pacific Standard Time":
                    if (selectedStartTime.TimeOfDay < DateTime.Today.AddHours(8).AddHours(-3).TimeOfDay
                        || selectedStartTime.TimeOfDay > DateTime.Today.AddHours(17).AddHours(-3).TimeOfDay)
                    {
                        MessageBox.Show("Appointments must be scheduled between 8 AM and 5 PM ET.");
                        return;
                    }
                    break;
                case "Mountain Standard Time":
                    if (selectedStartTime.TimeOfDay < DateTime.Today.AddHours(8).AddHours(-2).TimeOfDay
                        || selectedStartTime.TimeOfDay > DateTime.Today.AddHours(17).AddHours(-2).TimeOfDay)
                    {
                        MessageBox.Show("Appointments must be scheduled between 8 AM and 5 PM ET.");
                        return;
                    }
                    break;
                case "Central Standard Time":
                    if (selectedStartTime.TimeOfDay < DateTime.Today.AddHours(8).AddHours(-1).TimeOfDay
                        || selectedStartTime.TimeOfDay > DateTime.Today.AddHours(17).AddHours(-1).TimeOfDay)
                    {
                        MessageBox.Show("Appointments must be scheduled between 8 AM and 5 PM ET.");
                        return;
                    }
                    break;
                case "Eastern Standard Time":
                    if (selectedStartTime.TimeOfDay < DateTime.Today.AddHours(8).TimeOfDay
                        || selectedStartTime.TimeOfDay > DateTime.Today.AddHours(17).TimeOfDay)
                    {
                        MessageBox.Show("Appointments must be scheduled between 8 AM and 5 PM ET.");
                        return;
                    }
                    break;
                case "Coordinated Universal Time":
                    if (selectedStartTime.TimeOfDay < DateTime.Today.AddHours(8).AddHours(4).TimeOfDay
                        || selectedStartTime.TimeOfDay > DateTime.Today.AddHours(17).AddHours(4).TimeOfDay)
                    {
                        MessageBox.Show("Appointments must be scheduled between 8 AM and 5 PM ET.");
                        return;
                    }
                    break;
            }

            Record record = new Record();
            BindingList<AppointmentLimitedView> tempAppointmentCollection = record.RetrieveAllAppointments();
            var result = tempAppointmentCollection
                .Where(x => x.UserId == ((DataRowView)AppointmentProfileUserComboBox.SelectedItem)
                .Row
                .Field<int>("User ID")
                );

            if (!result.Any())
            {
                MessageBox.Show("Error. Could not retrieve appointment records.");
                return;
            }
            
            foreach (AppointmentLimitedView item in result)
            {
                DateTime existingStartTime = DateTime.Parse($"{item.Start}");
                DateTime existingEndTime = DateTime.Parse($"{item.End}");

                if (selectedDate.Date == existingStartTime.Date)
                {
                    // 4
                    if (selectedStartTime.TimeOfDay < existingStartTime.TimeOfDay && selectedEndTime.TimeOfDay > existingEndTime.TimeOfDay)
                    {
                        MessageBox.Show("The selected consultant already has an existing appointment in the selected timeslot.");
                        return;
                    }
                    
                    // 3
                    if (selectedStartTime.TimeOfDay > existingStartTime.TimeOfDay && selectedEndTime.TimeOfDay < existingEndTime.TimeOfDay)
                    {
                        MessageBox.Show("The selected consultant already has an existing appointment in the selected timeslot.");
                        return;
                    }

                    //2
                    if ((selectedStartTime.TimeOfDay < existingStartTime.TimeOfDay && selectedEndTime.TimeOfDay > existingStartTime.TimeOfDay) 
                        || (selectedStartTime.TimeOfDay > existingStartTime.TimeOfDay && selectedStartTime.TimeOfDay < existingEndTime.TimeOfDay
                            && existingEndTime.TimeOfDay > existingEndTime.TimeOfDay))
                    {
                        MessageBox.Show("The selected consultant already has an existing appointment in the selected timeslot.");
                        return;
                    }
                }
            }

            Appointment appointment = new Appointment();
            appointment.customerId = ((DataRowView)AppointmentProfileCustomerComboBox.SelectedItem).Row.Field<int>("Customer ID");
            appointment.userId = ((DataRowView)AppointmentProfileUserComboBox.SelectedItem).Row.Field<int>("User ID");
            appointment.title = "not needed";
            appointment.description = "not needed";
            appointment.location = "not needed";
            appointment.contact = "not needed";
            appointment.type = AppointmentProfileTypeComboBox.Text;
            appointment.url = "not needed";
            appointment.start = TimeZoneInfo.ConvertTimeToUtc(selectedStartTime).ToString("yyyy-MM-dd HH:mm:ss");
            appointment.end = TimeZoneInfo.ConvertTimeToUtc(selectedEndTime).ToString("yyyy-MM-dd HH:mm:ss");
            appointment.createDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            appointment.createdBy = passedUsername;
            appointment.lastUpdate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            appointment.lastUpdateBy = passedUsername;
            record.Create(appointment);
            
            BindingList<AppointmentLimitedView> newList = new BindingList<AppointmentLimitedView>();
            newList = record.RetrieveAllAppointments();
            Home.instance.AppointmentDataGridView.DataSource = newList;
            
            instance.Close();
        }
        
    }
}

