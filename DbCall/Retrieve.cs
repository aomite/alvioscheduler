using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using MySql.Data.MySqlClient;

namespace AlvioScheduler.DbCall
{
    public partial class Record
    {
        public CustomerDetailedView Retrieve(int customerID)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();
            int searchID = customerID; 

            try
            {

                string sql = "SELECT customerId, customerName, addressId, address, address2, postalCode, phone, " +
                    "cityId, city, country.countryId, country.country " +
                    "FROM country INNER JOIN " +
                            "(select customerId, customerName, addressId, address, address2, postalCode, phone, " +
                                "city.cityId, city.city, city.countryId " +
                                "FROM city Inner Join " +
                                    "(select customerId, customerName, address.addressId, address, address2, " +
                                        "address.cityId, address.postalCode, address.phone " +
                                        "From customer INNER JOIN address " +
                                        "ON customer.addressId = address.addressId " +
                                        $"WHERE customerId = {searchID} " +
                                    ") as rto " +
                                "Where city.cityId = rto.cityId " +
                            ") as rtt " +
                        "WHERE country.countryId = rtt.countryId";

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn); 
                MySqlDataReader result = cmd.ExecuteReader();

                if (result == null)
                {
                    MessageBox.Show("Error. Failed to retrieve customer data from the database.");
                    myConn.CloseConnection();
                    return null;
                }
                else
                {
                    CustomerDetailedView customerDetails = new CustomerDetailedView();
                    while (result.Read())
                    {
                        customerDetails.CustomerId = (int)result[0];
                        customerDetails.CustomerName = (string)result[1];
                        customerDetails.AddressId = (int)result[2];
                        customerDetails.Address = (string)result[3];
                        customerDetails.Address2 = (string)result[4];
                        customerDetails.Zipcode = (string)result[5];
                        customerDetails.PhoneNum = (string)result[6];
                        customerDetails.CityId = (int)result[7];
                        customerDetails.CityName = (string)result[8];
                        customerDetails.CountryId = (int)result[9];
                        customerDetails.CountryName = (string)result[10];
                    }
                    result.Close();
                    myConn.CloseConnection();
                    return customerDetails;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myConn.CloseConnection();
                return null; 
            }
        }

        public bool Retrieve(string myUserName, string userPassword)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            string sql = $"SELECT userId, userName, password FROM user WHERE userName = \"{myUserName}\" ";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader result = cmd.ExecuteReader();

            if (result == null)
            {
                MessageBox.Show("Error. User not found");
                myConn.CloseConnection();
                return false;
            }
            else
            {
                while (result.Read())
                {
                    if ((string)result[1] == myUserName && (string)result[2] == userPassword)
                    {
                        Login.instance.myuserid = (int)result[0];
                        result.Close();
                        myConn.CloseConnection();
                        return true; 
                    }
                }
                result.Close();
                myConn.CloseConnection();
                return false;
            }
        }

        public BindingList<CustomerLimitedView> RetrieveAllCustomers()
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            string sql = "Select customerId, customerName FROM customer"; 
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader result = cmd.ExecuteReader();

            if (result == null)
            {
                MessageBox.Show("Failed to load the customer database.");
                myConn.CloseConnection();
                return null; 
            }
            else
            {
                BindingList<CustomerLimitedView> customerList = new BindingList<CustomerLimitedView>();
                while (result.Read())
                {
                    customerList.Add( new CustomerLimitedView { CustomerID = (int)result[0] , CustomerName = (string)result[1]} );
                }
                result.Close();
                myConn.CloseConnection();
                return customerList; 
            }
        }

        public BindingList<AppointmentLimitedView> RetrieveAllAppointments()
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            string sql = "Select tj1.appointmentId, tj1.start, tj1.end, tj1.userId, tj1.userName, " +
                "customer.customerId, customer.customerName, tj1.type " +
                "FROM customer INNER JOIN " +
                    "(Select appointmentId, customerId, start, end, appointment.userId, " +
                        "user.userName, appointment.type " +
                        "FROM appointment " +
                        "INNER JOIN user " +
                        "ON appointment.userID = user.userID) as tj1 " +
                "WHERE customer.customerID = tj1.customerId";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader result = cmd.ExecuteReader();

            if (result == null)
            {
                MessageBox.Show("Failed to load the necessary information.");
                myConn.CloseConnection();
                return null;
            }
            else
            {
                BindingList<AppointmentLimitedView> appointmentList = new BindingList<AppointmentLimitedView>();
                while (result.Read())
                {
                    DateTime dtConverter = DateTime.Parse(result[1].ToString());
                    DateTime dtConverter2 = DateTime.Parse(result[2].ToString());

                    appointmentList.Add(new AppointmentLimitedView {
                        AppointmentId = (int)result[0],
                        Date = dtConverter.Date,
                        Start = TimeZoneInfo.ConvertTimeFromUtc(dtConverter, TimeZoneInfo.Local).ToString("yyyy-MM-dd hh:mm tt"),
                        End = TimeZoneInfo.ConvertTimeFromUtc(dtConverter2, TimeZoneInfo.Local).ToString("yyyy-MM-dd hh:mm tt"),
                        UserId = (int)result[3],
                        UserName = (string)result[4],
                        CustomerId = (int)result[5],
                        CustomerName = (string)result[6],
                        Type = (string)result[7]
                    }); 
                }
                result.Close();
                myConn.CloseConnection();
                return appointmentList;
            }
        }

        public BindingList<UserLimitedView> RetrieveAllUsers()
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            string sql = "Select userId, userName FROM user";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader result = cmd.ExecuteReader();

            if (result == null)
            {
                MessageBox.Show("Failed to load users information.");
                myConn.CloseConnection();
                return null;
            }
            else
            {
                BindingList<UserLimitedView> userList = new BindingList<UserLimitedView>();
                while (result.Read())
                {
                    userList.Add(new UserLimitedView { userId = (int)result[0], userName = (string)result[1] });
                }
                result.Close();
                myConn.CloseConnection();
                return userList;
            }
        }
    }
}
