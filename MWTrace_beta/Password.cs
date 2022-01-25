using DIGITrace;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Password : Form
    {
        ConfiguracionSistema cs = new ConfiguracionSistema();
        public Password()
        {
            InitializeComponent();
        }
        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "adminmei")
            {
                Batch batch = new Batch();
                batch.Show();
            }
            else if (txt_password.Text == "adminmw" || txt_password.Text == "admins")
            {
                Retrabajo r = new Retrabajo();


                cs.Usuario = txt_password.Text;
                //r.Show();
                Form rework;

                if ((rework = IsFormAlreadyOpen(typeof(Retrabajo))) == null)
                {
                    r.ShowDialog(this);
                    this.Close();
                }

                else
                {
                    rework.WindowState = FormWindowState.Normal;
                    rework.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Password incorrecto", "Error!");
            }
        }

        private void Button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(this, new EventArgs());
            }
        }

        private void Password_Load(object sender, EventArgs e)
        {

        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(this, new EventArgs());
            }
        }
    }
}
