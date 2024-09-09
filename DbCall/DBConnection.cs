using MySql.Data.MySqlClient;

namespace AlvioScheduler.DbCall
{
    public class DBConnection
    {
        public const string connStr = "<private connection string>";
        public static MySqlConnection conn = new MySqlConnection(connStr);

        public void CreateConnection() => conn.Open();

        public void CloseConnection() => conn.Close();
    }
}
