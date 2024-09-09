using AlvioScheduler.DbCall;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlvioScheduler
{
    public partial class EditAppointmentProfile : Form
    {
        public static EditAppointmentProfile instance;
        public string passedUsername;
        public AppointmentLimitedView passedAppointment;

        public EditAppointmentProfile()
        {
            InitializeComponent();
            instance = this;

            EditAppointmentProfileDatePicker.MinDate = DateTime.Today;
            EditAppointmentProfileStartTimePicker.CustomFormat = "hh:mm tt";
            EditAppointmentProfileEndTimePicker.CustomFormat = "hh:mm tt";

            Record record = new Record();

            BindingList<AppointmentLimitedView> previousAppointmentTypes = record.RetrieveAllAppointments();
            foreach (AppointmentLimitedView appointment in previousAppointmentTypes)
            {
                if (!EditAppointmentProfileTypeComboBox.Items.Contains(appointment.Type))
                {
                    EditAppointmentProfileTypeComboBox.Items.Add(appointment.Type);
                }   
            }
        }

        public void EditAppointmentProfile_Load(object sender, EventArgs e)
        {
            EditAppointmentProfileCustomerTextBox.Text = passedAppointment.CustomerName;
            EditAppointmentProfileConsultantTextBox.Text = passedAppointment.UserName;
            EditAppointmentProfileDatePicker.Value = passedAppointment.Date;
            EditAppointmentProfileStartTimePicker.Text = passedAppointment.Start;
            EditAppointmentProfileEndTimePicker.Text = passedAppointment.End;
            EditAppointmentProfileTypeComboBox.Text = passedAppointment.Type;
        }

        private void EditAppointmentProfileCancelBtn_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        private void EditCustomerProfileUpdateBtn_Click(object sender, EventArgs e)
        {
            string concatenatedDateTimeStart = $"{EditAppointmentProfileDatePicker.Value.ToString("yyyy-MM-dd")} " +
                $"{EditAppointmentProfileStartTimePicker.Value.ToString("hh:mm tt")}";
            string concatenatedDateTimeEnd = $"{EditAppointmentProfileDatePicker.Value.ToString("yyyy-MM-dd")} " +
                $"{EditAppointmentProfileEndTimePicker.Value.ToString("hh:mm tt")}";
            DateTime selectedStartTime = DateTime.Parse(concatenatedDateTimeStart);
            DateTime selectedEndTime = DateTime.Parse(concatenatedDateTimeEnd);

            passedAppointment.Start = TimeZoneInfo.ConvertTimeToUtc(selectedStartTime).ToString("yyyy-MM-dd HH:mm:ss");
            passedAppointment.End = TimeZoneInfo.ConvertTimeToUtc(selectedEndTime).ToString("yyyy-MM-dd HH:mm:ss");
            passedAppointment.Type = EditAppointmentProfileTypeComboBox.Text;

            Record record = new Record();
            record.Update(passedAppointment, passedUsername);

            BindingList<AppointmentLimitedView> newList = new BindingList<AppointmentLimitedView>();
            newList = record.RetrieveAllAppointments();
            Home.instance.AppointmentDataGridView.DataSource = newList;
            instance.Close();
        }

        private void EditCustomerProfileDeleteBtn_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            record.Delete(passedAppointment);

            BindingList<AppointmentLimitedView> newList = new BindingList<AppointmentLimitedView>();
            newList = record.RetrieveAllAppointments();
            Home.instance.AppointmentDataGridView.DataSource = newList;
            instance.Close();
        }
    }
}
