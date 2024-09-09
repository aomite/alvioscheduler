using System;
using System.Windows.Forms;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using MySql.Data.MySqlClient;

namespace AlvioScheduler.DbCall
{
    public partial class Record
    {
        public int Create(Country country, out int countryid)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            try
            {
                string sql = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES ('{country.country}', '{country.createDate}', '{country.createdBy}', " +
                    $"'{country.lastUpdate}', '{country.lastUpdateBy}')"; 

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();
                countryid = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                countryid = 0;
            }
            myConn.CloseConnection();
            return countryid; 
        }

        public int Create(City city, out int cityid)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection(); 
            
            try
            {
                string sql = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES ('{city.city}', {city.countryId}, '{city.createDate}', '{city.createdBy}', " +
                    $"'{city.lastUpdate}', '{city.lastUpdateBy}')";

                Console.WriteLine(sql); 

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();
                cityid = (int)cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cityid = 0;
            }
            myConn.CloseConnection();
            return cityid; 
        }

        public int Create(Address address, out int addressid)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            try
            {
                string sql = "INSERT INTO address (address, address2, cityId, " +
                    "postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES ('{address.address}', '{address.address2}', {address.cityId}, '{address.postalCode}', " +
                    $"'{address.phone}', '{address.createDate}', '{address.createdBy}', '{address.lastUpdate}', " +
                    $"'{address.lastUpdateBy}')";

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();
                addressid = (int)cmd.LastInsertedId; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                addressid = 0;
            }
            myConn.CloseConnection();
            return addressid; 
        }

        public void Create(Customer customer)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            try
            {
                string sql = "INSERT INTO " +
                    "customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES ('{customer.customerName}', {customer.addressId}, '{customer.active}', '{customer.createDate}', " +
                    $"'{customer.createdBy}', '{customer.lastUpdate}', '{customer.lastUpdateBy}' )";

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Customer successfully created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.CloseConnection();
        }

        public void Create(Appointment appointment)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            try
            {
                string sql = "INSERT INTO appointment (" +
                    "customerId, userId, title, description, location, contact, " +
                    "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES ('{appointment.customerId}', {appointment.userId}, '{appointment.title}', '{appointment.description}', " +
                    $"'{appointment.location}', '{appointment.contact}', '{appointment.type}', " +
                    $"'{appointment.url}', '{appointment.start}', '{appointment.end}', '{appointment.createDate}', " +
                    $"'{appointment.createdBy}', '{appointment.lastUpdate}', '{appointment.lastUpdateBy}' )";

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Appointment successfully created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.CloseConnection();
        }
    }
}