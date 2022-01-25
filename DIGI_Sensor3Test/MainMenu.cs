using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DIGI_Sensor3test
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

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            Employee no = new Employee();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(Employee))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            Batch no = new Batch();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(Batch))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            Reports no = new Reports();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(Reports))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
