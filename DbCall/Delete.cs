using System;
using System.Windows.Forms;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using MySql.Data.MySqlClient;

namespace AlvioScheduler.DbCall
{
    public partial class Record
    {
        public bool Delete(int cId)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();
            bool isDeleted = false;

            try
            {
                string sql = "select city.cityId, rto.customerId, rto.addressId FROM city " +
                "Inner Join " +
                    "( SELECT customerId, address.addressId, address.cityId From customer " +
                        "INNER JOIN address ON customer.addressId = address.addressId " +
                        $"WHERE customerId = {cId} " +
                     ") as rto " +
                "Where city.cityId = rto.cityId";

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                MySqlDataReader result = cmd.ExecuteReader();

                int cityIDToDelete = 0;
                int addressIDToDelete = 0;
                int customerIDToDelete = 0;

                if (result == null)
                {
                    MessageBox.Show("Error. Failed to retrieve necessary data from the database.");
                    myConn.CloseConnection();
                }

                while (result.Read())
                {
                        cityIDToDelete = (int)result[0];
                        customerIDToDelete = (int)result[1];
                        addressIDToDelete = (int)result[2];
                }
                result.Close();

                string sqlTwo = $"Delete FROM appointment WHERE customerId = {customerIDToDelete}";
                MySqlCommand cmdTwo = new MySqlCommand(sqlTwo, DBConnection.conn);
                cmdTwo.ExecuteNonQuery();

                string sqlThree = $"Delete FROM customer WHERE customerId = {customerIDToDelete}";
                MySqlCommand cmdThree = new MySqlCommand(sqlThree, DBConnection.conn);
                cmdThree.ExecuteNonQuery();

                string sqlFour = $"Delete FROM address WHERE addressId = {addressIDToDelete}";
                MySqlCommand cmdFour = new MySqlCommand(sqlFour, DBConnection.conn);
                cmdFour.ExecuteNonQuery();

                string sqlFive = $"Delete FROM city WHERE cityId = {cityIDToDelete}";
                MySqlCommand cmdFive = new MySqlCommand(sqlFive, DBConnection.conn);
                cmdFive.ExecuteNonQuery();

                MessageBox.Show("Customer successfully deleted.");
                isDeleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isDeleted = false;
            }
            myConn.CloseConnection();
            return isDeleted;
        }

        public void Delete(AppointmentLimitedView appointmentLV)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            try
            {
                string sql = $"DELETE FROM appointment WHERE appointmentId = {appointmentLV.AppointmentId}";

                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                object result = cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment successfully deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.CloseConnection();
            }
        }
    }
}
