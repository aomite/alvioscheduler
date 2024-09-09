using AlvioScheduler.DbCall;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AlvioScheduler
{
    public partial class Report : Form
    {
        public static Report instance;

        public BindingList<string> reportTypes = new BindingList<string>() {" ", "Number of Appointment Types", 
            "Upcoming Appointments (by Consultant)", "Upcoming Appoinments (by Customer)"};
        
        public BindingList<string> months = new BindingList<string>() {" ", "January", "February", "March", "April", "May", 
            "June", "July", "August", "September", "October", "November", "December"};

        BindingList<CustomerLimitedView> availableCustomers;
        BindingList<UserLimitedView> availableUsers;

        public Report()
        {
            InitializeComponent();
            instance = this;

            Record record = new Record();
            availableCustomers = record.RetrieveAllCustomers();
            availableUsers = record.RetrieveAllUsers();

            DataTable tempDataTable = new DataTable();
            tempDataTable.Columns.Add("Customer ID", typeof(int));
            tempDataTable.Columns.Add("Customer Name", typeof(string));

            foreach (CustomerLimitedView customer in availableCustomers)
            {
                tempDataTable.Rows.Add(customer.CustomerID, $"ID: {customer.CustomerID} -- {customer.CustomerName}");
            }

            ReportCustomerComboBox.DataSource = tempDataTable;
            ReportCustomerComboBox.DisplayMember = "Customer Name";
            ReportCustomerComboBox.ValueMember = "Customer ID";


            DataTable tempUserTable = new DataTable();
            tempUserTable.Columns.Add("User ID", typeof(int));
            tempUserTable.Columns.Add("UserName", typeof(string));

            foreach (UserLimitedView user in availableUsers)
            {
                tempUserTable.Rows.Add(user.userId, $"ID: {user.userId} -- {user.userName}");
            }

            ReportUserComboBox.DataSource = tempUserTable;
            ReportUserComboBox.DisplayMember = "UserName";
            ReportUserComboBox.ValueMember = "User ID";

            ReportTypeComboBox.DataSource = reportTypes;
            ReportMonthComboBox.DataSource = months;
        }

        private void CancelReportBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ReportTypeComboBox.SelectedIndex)
            {
                case 1:
                {
                    ReportMonthComboBox.Enabled = true;
                    ReportUserComboBox.Enabled = false;
                    ReportCustomerComboBox.Enabled = false;
                    break;
                }

                case 2:
                {
                    ReportMonthComboBox.Enabled = false;
                    ReportUserComboBox.Enabled = true;
                    ReportCustomerComboBox.Enabled = false;
                    break;
                }

                case 3:
                {
                    ReportMonthComboBox.Enabled = false;
                    ReportUserComboBox.Enabled = false;
                    ReportCustomerComboBox.Enabled = true;
                    break;
                }

                default:
                {
                    ReportMonthComboBox.Enabled = false;
                    ReportUserComboBox.Enabled = false;
                    ReportCustomerComboBox.Enabled = false;
                    break;
                }
            }
        }

        private void CreateReportBtn_Click(object sender, EventArgs e)
        {
            switch (ReportTypeComboBox.SelectedIndex)
            {
                case 1:
                {
                    Record record = new Record();
                    BindingList<AppointmentLimitedView> tempUserAppointmentCollection = record.RetrieveAllAppointments();

                    if (ReportMonthComboBox.Text == null || ReportTypeComboBox.SelectedIndex == 0)
                    {
                        MessageBox.Show("No month selected. Please select a month for this report type.");
                        return; 
                    }

                    int selectedMonth = ReportMonthComboBox.SelectedIndex;

                    // Lambda: Retrieves the count for each appointment type. 
                    var result = tempUserAppointmentCollection
                            .Where(x => x.Date.Month == selectedMonth)
                            .GroupBy(x => x.Type, x => new { Key = x.Type, Count = x.Type.Count() });
                        
                    string messageResults = "";

                    foreach (var item in result)
                    {
                        messageResults += $"{item.Key}: ";
                        messageResults += $"{item.Count()} \n";
                    }

                    MessageBox.Show("Appointment Type: Count \n" + $"{messageResults}");
                    break;
                }

                case 2:
                {
                    Record record = new Record();
                    BindingList<AppointmentLimitedView> tempUserAppointmentCollection = record.RetrieveAllAppointments();
                    int selectedUserId = ((DataRowView)ReportUserComboBox.SelectedItem).Row.Field<int>("User ID");

                    // Lambda: Retrieves the count of upcoming appointments for the selected user.
                    int result = tempUserAppointmentCollection
                        .Where(x => x.UserId == selectedUserId && x.Date >= DateTime.Now)
                        .Count();

                    MessageBox.Show($"Selected user has {result} upcoming appointments.");
                    break;
                }

                case 3:
                {
                    Record record = new Record();
                    BindingList<AppointmentLimitedView> tempUserAppointmentCollection= record.RetrieveAllAppointments();
                    int selectedCustomerId = ((DataRowView)ReportCustomerComboBox.SelectedItem).Row.Field<int>("Customer ID");

                    // Lambda: Retrieves the count of upcoming appointments for the selected customer.
                    int result = tempUserAppointmentCollection
                        .Where(x => x.CustomerId == selectedCustomerId && x.Date >= DateTime.Now)
                        .Count();
                    
                    MessageBox.Show($"Selected customer has {result} upcoming appointments.");
                    break;
                }

                default:
                {
                    MessageBox.Show("Please select a valid report type.");
                    break; 
                }
            }
        }


    }
}
