using System;
using System.Windows.Forms;

namespace AlvioScheduler
{
    public partial class DatePopUp : Form
    {
        public static DatePopUp instance; 

        public DatePopUp()
        {
            InitializeComponent();
            instance = this;
        }

        private void DatePopUpCancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            instance.Close();
        }

        private void DatePopUpConfirmBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            instance.Close();
        }
    }
}
