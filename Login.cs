using AlvioScheduler.DbCall;
using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace AlvioScheduler
{
    public partial class Login : Form
    {
        public static Login instance;
        public int myuserid; 

        public Login()
        {
            InitializeComponent();
            instance = this; 
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            {
                UsernameLabel.Text = "Username";
                PasswordLabel.Text = "Password";
                LoginBtn.Text = "Login";
                LoginExitBtn.Text = "Exit";
            }
            else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
            {
                UsernameLabel.Text = "Nombre de usuario";
                UsernameLabel.Location = new System.Drawing.Point(x: 255, y: 385);
                PasswordLabel.Text = "Contraseña";
                PasswordLabel.Location = new System.Drawing.Point(x: 255, y: 470);
                LoginBtn.Text = "Iniciar";
                LoginExitBtn.Text = "Atrás";
            }

            TimeZoneLabel.Text = $"{RegionInfo.CurrentRegion.Name} - {TimeZone.CurrentTimeZone.StandardName}";
            TimeZoneLabel.Location = new System.Drawing.Point(x: 356, y: 630); 
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string userName = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            Record record = new Record();

            if(record.Retrieve(userName, password))
            {
                string path = Path.Combine(Environment.CurrentDirectory, "../../Logs/Login_History.txt");
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine($"Successful login for User:{userName} at {DateTime.Now}.");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"Successful login for user:{userName} at {DateTime.Now}.");
                    }
                }

                Home home = new Home();
                home.savedUsername = userName;
                home.savedUserId = myuserid;
                home.Show();
                this.Hide();
            }
            else
            {
                string path = Path.Combine(Environment.CurrentDirectory, "../../Logs/Login_History.txt");
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine($"Unsuccessful login attempt for user:{userName} at {DateTime.Now}.");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"Unsuccessful login attempt for user:{userName} at {DateTime.Now}.");
                    }
                }

                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
                {
                    MessageBox.Show("The Username and Password do not match. Please try again.");
                }
                else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
                {
                    MessageBox.Show("El nombre de usuario y la contraseña no coinciden. Inténtalo de nuevo.");
                }
            }
        }

        private void LoginExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
