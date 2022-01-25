using System;
using System.Windows.Forms;

namespace DIGITrace
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "123456")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Password incorrecto", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(this, new EventArgs());
            }
        }

        private void Error_Load(object sender, EventArgs e)
        {
            txt_password.Focus();
            this.ActiveControl = txt_password;
            txt_password.Text = "";
        }
    }
}
