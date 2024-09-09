using System;
using System.ComponentModel;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlvioScheduler.DbCall;
using AlvioScheduler.model;
using AlvioScheduler.Model;

namespace AlvioScheduler
{
    public partial class Home : Form
    {
        public static Home instance;
        public string savedUsername;
        public int savedUserId;
        public DateTime selectedDate; 

        public BindingList<CustomerLimitedView> customerData;
        public BindingList<AppointmentLimitedView> appointmentData; 

        public Home()
        {
            InitializeComponent();
            instance = this;
            HomeAlertPanel.Visible = false;

            Record record = new Record();
            customerData = record.RetrieveAllCustomers();
            appointmentData = record.RetrieveAllAppointments();

            CustomerDataGridView.DataSource = customerData; 
            CustomerDataGridView.AllowUserToAddRows = false;
            CustomerDataGridView.ReadOnly = true;
            CustomerDataGridView.MultiSelect = false;

            AppointmentDataGridView.DataSource = appointmentData;
            AppointmentDataGridView.AllowUserToAddRows = false;
            AppointmentDataGridView.ReadOnly = true;
            AppointmentDataGridView.MultiSelect = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CustomerDataGridView.ClearSelection();
            AppointmentDataGridView.ClearSelection(); 
            HomeUsernameLabel.Text = $"Hi, {savedUsername}";

            var upcomingAppts = appointmentData.Where(x => x.UserId == savedUserId);

            foreach (var appt in upcomingAppts)
            {
                DateTime apptTime = DateTime.Parse(appt.Start);
                DateTime reminderWindow = DateTime.Now;
                TimeSpan ts = TimeSpan.Parse("0:15:00");
                if (DateTime.Today.Date == appt.Date)
                {
                    if (reminderWindow.TimeOfDay < apptTime.TimeOfDay 
                        && reminderWindow.Add(ts).TimeOfDay >= apptTime.TimeOfDay)
                    {
                        string formattedTime = apptTime.ToString("t");
                        HomeAlertPanel.Visible = true;
                        HomeAlertPanelLabel.Text = $"Reminder: You have an appoint with {appt.CustomerName} " +
                            $"today at {formattedTime}.";
                        HomeAlertPanelLabel.Location = new System.Drawing.Point(x: 109, y: 8);
                    }
                }
            }
            DateTimeTracker();
        }

        private async void DateTimeTracker()
        {
            HomeDateTimeLabel.Text = DateTime.Now.ToString();
            await Task.Delay(1000);
            DateTimeTracker();
        }

        private void HomeAlertPanelBtn_Click(object sender, EventArgs e)
        {
            HomeAlertPanel.Visible = false;
        }

        private void HomeCreateReportLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report report = new Report();
            report.Show();
        }

        private void HomeLogoutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            instance.Close();
            Login login = new Login();
            login.Show();
        }

        private void HomeExitAppBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void HomeCreateCustomerLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile();
            customerProfile.passedUsername = savedUsername;
            customerProfile.Show();
        }

        private void HomeCustomerProfileBtn_Click(object sender, EventArgs e)
        {
            if (CustomerDataGridView.CurrentRow == null || !CustomerDataGridView.CurrentRow.Selected)
            {
                MessageBox.Show("No row is selected. Please select a row first.");
                return; 
            }
            else
            {
                EditCustomerProfile profile = new EditCustomerProfile();
                profile.passedUsername = savedUsername;
                profile.searchID = (int)CustomerDataGridView.CurrentRow.Cells[0].Value;
                profile.searchIDIndex = (int)CustomerDataGridView.CurrentRow.Index;
                profile.Show();
            }
        }

        private void HomeCreateAppointmentLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppointmentProfile appointmentDetails = new AppointmentProfile();
            appointmentDetails.passedUsername = savedUsername;
            appointmentDetails.passedUserId = savedUserId;
            appointmentDetails.Show();
        }

        private void HomeAppointmentProfileBtn_Click(object sender, EventArgs e)
        {
            if (AppointmentDataGridView.CurrentRow == null || !AppointmentDataGridView.CurrentRow.Selected)
            {
                MessageBox.Show("No row is selected. Please select a row first.");
                return;
            }

            if ((DateTime)AppointmentDataGridView.CurrentRow.Cells[1].Value < DateTime.Today )
            {
                MessageBox.Show("Cannot edit past appointments. Please select a current or future appointment.");
                return;
            }

            EditAppointmentProfile details = new EditAppointmentProfile();
            details.passedAppointment = (AppointmentLimitedView)AppointmentDataGridView.CurrentRow.DataBoundItem;
            details.passedUsername = savedUsername;
            details.Show();
        }

        private void AllAppointmentViewBtn_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            appointmentData = record.RetrieveAllAppointments();
            AppointmentDataGridView.DataSource = appointmentData;
        }

        private void DayAppointmentViewBtn_Click(object sender, EventArgs e)
        {
            DatePopUp datePopUp = new DatePopUp();

            var result = datePopUp.ShowDialog();
            if (result != DialogResult.OK)
            {
                MessageBox.Show("Please select a date to see this view.");
            }
            selectedDate = datePopUp.DatePopUpSelection.Value.Date;

            List<AppointmentLimitedView> tempList = new List<AppointmentLimitedView>();
            foreach (AppointmentLimitedView item in appointmentData)
            {
                tempList.Add(item);
            }

            // This lambda ensures that only dates matching the selected date are returned. 
            tempList = tempList.FindAll((AppointmentLimitedView aplv) => aplv.Date == selectedDate);
            AppointmentDataGridView.DataSource = tempList;
        }

        private void WeekAppointmentViewBtn_Click(object sender, EventArgs e)
        {
            List<AppointmentLimitedView> tempList = new List<AppointmentLimitedView>();
            foreach (AppointmentLimitedView item in appointmentData)
            {
                tempList.Add(item);
            }

            // This lambda ensures that only dates within a week of the current date are returned. 
            tempList = tempList.FindAll( (AppointmentLimitedView aplv) => aplv.Date >= DateTime.Today && aplv.Date <= DateTime.Today.AddDays(7));
            AppointmentDataGridView.DataSource = tempList;
        }

        private void MonthAppointmentViewBtn_Click(object sender, EventArgs e)
        {
            List<AppointmentLimitedView> tempList = new List<AppointmentLimitedView>();
            foreach (AppointmentLimitedView item in appointmentData)
            {
                tempList.Add(item);
            }

            // This lambda ensures that only dates within a month of the current date are returned. 
            tempList = tempList.FindAll( (AppointmentLimitedView aplv) => aplv.Date >= DateTime.Today && aplv.Date <= DateTime.Today.AddMonths(1));
            AppointmentDataGridView.DataSource = tempList;
        }
    }
}
