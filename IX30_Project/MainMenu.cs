using System;
using System.Linq;
using System.Windows.Forms;

namespace IX30_Project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }


        private void btn_WO_Click(object sender, EventArgs e)
        {
            CreateWO no = new CreateWO();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(CreateWO))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }
    }
}
