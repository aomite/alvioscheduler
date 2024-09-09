using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using AlvioScheduler.model;
using AlvioScheduler.Model;
using MySql.Data.MySqlClient;

namespace AlvioScheduler.DbCall
{
    public partial class Record
    {
        public void Update(int countryid, string countryname, int cityid, string cityname, int addressid, 
            string addressone, string addresstwo, string zipcode, string phonenum, int customerid, 
            string customername, string user)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            string lastupdate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); 
            string lastUpdateby = user; 

            try
            {
                string sql = $"UPDATE country SET country = '{countryname}', lastUpdate = '{lastupdate}', lastUpdateBy = '{lastUpdateby}' " +
                    $"WHERE countryId = {countryid}";
                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();

                string sqlTwo = $"UPDATE city SET city =' {cityname}', lastUpdate = '{lastupdate}', lastUpdateBy = '{lastUpdateby}' " +
                    $"WHERE cityId = {cityid}";
                MySqlCommand cmdTwo = new MySqlCommand(sqlTwo, DBConnection.conn);
                cmdTwo.ExecuteNonQuery();

                string sqlThree = $"UPDATE address SET address = '{addressone}', address2 = '{addresstwo}', " +
                    $"postalcode='{zipcode}', phone = '{phonenum}', lastUpdate = '{lastupdate}', lastUpdateBy = '{lastUpdateby}' " +
                    $"WHERE addressid = {addressid}";
                MySqlCommand cmdThree = new MySqlCommand(sqlThree, DBConnection.conn);
                cmdThree.ExecuteNonQuery();

                string sqlFour = $"UPDATE customer SET customerName = '{customername}', lastUpdate = '{lastupdate}', " +
                    $"lastUpdateBy = '{lastUpdateby}' WHERE customerid = {customerid}";
                MySqlCommand cmdFour = new MySqlCommand(sqlFour, DBConnection.conn);
                cmdFour.ExecuteNonQuery();
               
                MessageBox.Show("Customer update successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConn.CloseConnection();
            }
        }

        public void Update(AppointmentLimitedView appointment, string currentUser)
        {
            DBConnection myConn = new DBConnection();
            myConn.CreateConnection();

            try
            {
                string sql = "UPDATE customer SET active = 1 " +
                    $"Where customerId = {appointment.CustomerId}";
                MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
                cmd.ExecuteNonQuery();

                string sqlTwo = $"UPDATE appointment SET type = '{appointment.Type}', start = '{appointment.Start}', " +
                    $"end = '{appointment.End}', lastUpdate = '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}', " +
                    $"lastUpdateBy = '{currentUser}' " +
                    $"WHERE appointmentId = {appointment.AppointmentId}";
                MySqlCommand cmdTwo = new MySqlCommand(sqlTwo, DBConnection.conn);
                cmdTwo.ExecuteNonQuery();

                MessageBox.Show("Appointment update successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConn.CloseConnection();
            }
        }
    }
}
