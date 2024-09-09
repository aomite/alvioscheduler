using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing; 
using AlvioScheduler.DbCall;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using System.ComponentModel;

namespace AlvioScheduler
{
    public partial class EditCustomerProfile : Form
    {
        public static EditCustomerProfile instance;
        public int searchID;
        public int searchIDIndex; 
        public string passedUsername;
        public int deletionID;
        public CustomerDetailedView tempCustomerDetails = new CustomerDetailedView();

        public EditCustomerProfile()
        {
            InitializeComponent();
            instance = this;
            EditCustomerProfileUpdateBtn.Enabled = false;
        }

        private void EditCustomerProfile_Load(object sender, EventArgs e)
        {
            Record record = new Record();
            CustomerDetailedView customerDetails = record.Retrieve(searchID);

            EditCustomerProfileCustomerNameTextBox.Text = customerDetails.CustomerName;
            EditCustomerProfileCustomerAddressOneTextBox.Text = customerDetails.Address;
            EditCustomerProfileCustomerAddressTwoTextBox.Text = customerDetails.Address2;
            EditCustomerProfileZipcodeTextBox.Text = customerDetails.Zipcode;
            EditCustomerProfilePhoneNumberTextBox.Text = customerDetails.PhoneNum;
            EditCustomerProfileCityNameTextBox.Text = customerDetails.CityName;
            EditCustomerProfileCountryNameTextBox.Text = customerDetails.CountryName;

            deletionID = customerDetails.CustomerId;
            tempCustomerDetails.CustomerId = customerDetails.CustomerId;
            tempCustomerDetails.AddressId = customerDetails.AddressId;
            tempCustomerDetails.CityId = customerDetails.CityId;
            tempCustomerDetails.CountryId = customerDetails.CountryId;
        }

        private void EditCustomerProfileCancelBtn_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        private void EditCustomerProfileUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tempCustomerDetails.CustomerName = EditCustomerProfileCustomerNameTextBox.Text.Trim();
                tempCustomerDetails.Address = EditCustomerProfileCustomerAddressOneTextBox.Text.Trim();
                tempCustomerDetails.Address2 = EditCustomerProfileCustomerAddressTwoTextBox.Text.Trim();
                tempCustomerDetails.Zipcode = EditCustomerProfileZipcodeTextBox.Text;
                tempCustomerDetails.PhoneNum = EditCustomerProfilePhoneNumberTextBox.Text;
                tempCustomerDetails.CityName = EditCustomerProfileCityNameTextBox.Text.Trim();
                tempCustomerDetails.CountryName = EditCustomerProfileCountryNameTextBox.Text.Trim();

                Record record = new Record();

                record.Update(tempCustomerDetails.CountryId, tempCustomerDetails.CountryName, tempCustomerDetails.CityId, 
                   tempCustomerDetails.CityName, tempCustomerDetails.AddressId, tempCustomerDetails.Address,
                   tempCustomerDetails.Address2, tempCustomerDetails.Zipcode, tempCustomerDetails.PhoneNum,
                   tempCustomerDetails.CustomerId, tempCustomerDetails.CustomerName, passedUsername
                );

                BindingList<CustomerLimitedView> newList = new BindingList<CustomerLimitedView>();
                newList = record.RetrieveAllCustomers();
                Home.instance.CustomerDataGridView.DataSource = newList; 
                instance.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditCustomerProfilePhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            string shortPattern = @"^\d{3}-\d{4}$";
            string longPattern = @"^\d{3}-\d{3}-\d{4}$";

            Regex defaultRegex = new Regex(shortPattern);
            Regex extendedRegex = new Regex(longPattern); 

            if (String.IsNullOrWhiteSpace(EditCustomerProfilePhoneNumberTextBox.Text)) 
            {
                EditCustomerProfilePhoneNumberTextBox.BackColor = Color.Salmon;
            }

            if (defaultRegex.IsMatch(EditCustomerProfilePhoneNumberTextBox.Text) ||
                    extendedRegex.IsMatch(EditCustomerProfilePhoneNumberTextBox.Text))
            {
                EditCustomerProfilePhoneNumberTextBox.BackColor = Color.White;
            }
            else
            {
                EditCustomerProfilePhoneNumberTextBox.BackColor = Color.Salmon;
            }
            EditCustomerProfileUpdateBtn.Enabled = EnableAddBtn();
        }

        private void EditCustomerProfileZipcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            string zipcodePattern = @"^\d{5}$";

            Regex regex = new Regex(zipcodePattern);

            if (String.IsNullOrWhiteSpace(EditCustomerProfileZipcodeTextBox.Text))
            {
                EditCustomerProfileZipcodeTextBox.BackColor = Color.Salmon;
            }

            if (regex.IsMatch(EditCustomerProfileZipcodeTextBox.Text)) 
            {
                EditCustomerProfileZipcodeTextBox.BackColor = Color.White;
            }
            else
            {
                EditCustomerProfileZipcodeTextBox.BackColor= Color.Salmon;
            }
            EditCustomerProfileUpdateBtn.Enabled = EnableAddBtn();
        }

        private void EditCustomerProfileCustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EditCustomerProfileCustomerNameTextBox.Text) ||
                int.TryParse(EditCustomerProfileCustomerNameTextBox.Text, out int number))
            {
                EditCustomerProfileCustomerNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                EditCustomerProfileCustomerNameTextBox.BackColor = Color.White;
            }
            EditCustomerProfileUpdateBtn.Enabled = EnableAddBtn();
        }

        private void EditCustomerProfileCustomerAddressOneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EditCustomerProfileCustomerAddressOneTextBox.Text))
            {
                EditCustomerProfileCustomerAddressOneTextBox.BackColor = Color.Salmon;
            }
            else
            {
                EditCustomerProfileCustomerAddressOneTextBox.BackColor= Color.White;
            }
            EditCustomerProfileUpdateBtn.Enabled = EnableAddBtn();
        }

        private void EditCustomerProfileCityNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EditCustomerProfileCityNameTextBox.Text))
            {
                EditCustomerProfileCityNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                EditCustomerProfileCityNameTextBox.BackColor = Color.White;
            }
            EditCustomerProfileUpdateBtn.Enabled = EnableAddBtn();
        }

        private void EditCustomerProfileCountryNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EditCustomerProfileCountryNameTextBox.Text))
            {
                EditCustomerProfileCountryNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                EditCustomerProfileCountryNameTextBox.BackColor = Color.White;
            }
            EditCustomerProfileUpdateBtn.Enabled = EnableAddBtn();
        }

        private bool EnableAddBtn()
        {
            return (EditCustomerProfileCustomerNameTextBox.BackColor == Color.White
                && EditCustomerProfileCustomerAddressOneTextBox.BackColor == Color.White
                && EditCustomerProfileZipcodeTextBox.BackColor == Color.White
                && EditCustomerProfilePhoneNumberTextBox.BackColor == Color.White
                && EditCustomerProfileCityNameTextBox.BackColor == Color.White
                && EditCustomerProfileCountryNameTextBox.BackColor == Color.White);
        }

        private void EditCustomerProfileDeleteBtn_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            bool isDeleted = record.Delete(deletionID);
            if (isDeleted)
            {
                //Home.instance.customerData.RemoveAt(searchIDIndex);
                BindingList<CustomerLimitedView> newList = record.RetrieveAllCustomers();
                Home.instance.CustomerDataGridView.DataSource = newList; 
                this.Close();
            }
        }
    }
}
