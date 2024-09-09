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
    public partial class CustomerProfile : Form
    {
        public static CustomerProfile instance;
        public string passedUsername; 

        public CustomerProfile()
        {
            InitializeComponent();
            instance = this;
            CustomerProfileAddBtn.Enabled = false;
        }

        private void CustomerProfileCancelBtn_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        private void CustomerProfileAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Country country = new Country();
                City city = new City();
                Address address = new Address();
                Customer customer = new Customer();
                
                Record record = new Record();

                country.country = CustomerProfileCountryNameTextBox.Text.Trim();
                country.createDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                country.createdBy = $"{passedUsername}";
                country.lastUpdate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                country.lastUpdateBy = $"{passedUsername}";
                int retrievedCountryId = record.Create(country, out int countryresult);


                city.city = CustomerProfileCityNameTextBox.Text.Trim();
                city.countryId = retrievedCountryId;
                city.createDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                city.createdBy = $"{passedUsername}";
                city.lastUpdate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                city.lastUpdateBy = $"{passedUsername}";
                int retrievedCityId = record.Create(city, out int cityidresult);


                address.address = CustomerProfileCustomerAddressOneTextBox.Text.Trim();
                address.address2 = CustomerProfileCustomerAddressTwoTextBox.Text.Trim();
                address.cityId = retrievedCityId;
                address.postalCode = CustomerProfileZipcodeTextBox.Text;
                address.phone = CustomerProfilePhoneNumberTextBox.Text;
                address.createDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                address.createdBy = $"{passedUsername}";
                address.lastUpdate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                address.lastUpdateBy = $"{passedUsername}";
                int retrievedAddressId = record.Create(address, out int addressidresult);


                customer.customerName = CustomerProfileCustomerNameTextBox.Text.Trim();
                customer.addressId = retrievedAddressId; 
                customer.active = 0; 
                customer.createDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                customer.createdBy = $"{passedUsername}";
                customer.lastUpdate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                customer.lastUpdateBy = $"{passedUsername}";
                record.Create(customer);

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

        private void CustomerProfilePhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            string shortPattern = @"^\d{3}-\d{4}$";
            string longPattern = @"^\d{3}-\d{3}-\d{4}$";

            Regex defaultRegex = new Regex(shortPattern);
            Regex extendedRegex = new Regex(longPattern); 

            if (String.IsNullOrWhiteSpace(CustomerProfilePhoneNumberTextBox.Text)) 
            {
                CustomerProfilePhoneNumberTextBox.BackColor = Color.Salmon;
            }

            if (defaultRegex.IsMatch(CustomerProfilePhoneNumberTextBox.Text) ||
                    extendedRegex.IsMatch(CustomerProfilePhoneNumberTextBox.Text))
            {
                CustomerProfilePhoneNumberTextBox.BackColor = Color.White;
            }
            else
            {
                CustomerProfilePhoneNumberTextBox.BackColor = Color.Salmon;
            }
            CustomerProfileAddBtn.Enabled = EnableAddBtn();
        }

        private void CustomerProfileZipcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            string zipcodePattern = @"^\d{5}$";

            Regex regex = new Regex(zipcodePattern);

            if (String.IsNullOrWhiteSpace(CustomerProfileZipcodeTextBox.Text))
            {
                CustomerProfileZipcodeTextBox.BackColor = Color.Salmon;
            }

            if (regex.IsMatch(CustomerProfileZipcodeTextBox.Text)) 
            {
                CustomerProfileZipcodeTextBox.BackColor = Color.White;
            }
            else
            {
                CustomerProfileZipcodeTextBox.BackColor= Color.Salmon;
            }
            CustomerProfileAddBtn.Enabled = EnableAddBtn();
        }

        private void CustomerProfileCustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CustomerProfileCustomerNameTextBox.Text) ||
                int.TryParse(CustomerProfileCustomerNameTextBox.Text, out int number))
            {
                CustomerProfileCustomerNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                CustomerProfileCustomerNameTextBox.BackColor = Color.White;
            }
            CustomerProfileAddBtn.Enabled = EnableAddBtn();
        }

        private void CustomerProfileCustomerAddressOneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CustomerProfileCustomerAddressOneTextBox.Text))
            {
                CustomerProfileCustomerAddressOneTextBox.BackColor = Color.Salmon;
            }
            else
            {
                CustomerProfileCustomerAddressOneTextBox.BackColor= Color.White;
            }
            CustomerProfileAddBtn.Enabled = EnableAddBtn();
        }

        private void CustomerProfileCityNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CustomerProfileCityNameTextBox.Text))
            {
                CustomerProfileCityNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                CustomerProfileCityNameTextBox.BackColor = Color.White;
            }
            CustomerProfileAddBtn.Enabled = EnableAddBtn();
        }

        private void CustomerProfileCountryNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CustomerProfileCountryNameTextBox.Text))
            {
                CustomerProfileCountryNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                CustomerProfileCountryNameTextBox.BackColor = Color.White;
            }
            CustomerProfileAddBtn.Enabled = EnableAddBtn();
        }

        private bool EnableAddBtn()
        {
            return (CustomerProfileCustomerNameTextBox.BackColor == Color.White
                && CustomerProfileCustomerAddressOneTextBox.BackColor == Color.White
                && CustomerProfileZipcodeTextBox.BackColor == Color.White
                && CustomerProfilePhoneNumberTextBox.BackColor == Color.White
                && CustomerProfileCityNameTextBox.BackColor == Color.White
                && CustomerProfileCountryNameTextBox.BackColor == Color.White);
        }


    }
}
