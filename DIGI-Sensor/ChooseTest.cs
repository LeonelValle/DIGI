using System;
using System.Linq;
using System.Windows.Forms;

namespace DIGI_Sensor
{
    public partial class ChooseTest : Form
    {
        Test test = new Test();
        public ChooseTest()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void ChooseTest_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (btn_3.Checked == true)
            {
                test.Selected = true;
            }
            else if (btn_all.Checked == true)
            {
                test.Selected = false;
            }



            //orden.Crud("update tb_Orden set id_operador = " + regreso + " where orden = '" + orden.Ordenes + "'");
            Check_Test ee = new Check_Test();
            //ee.Show();

            Form enet;

            if ((enet = IsFormAlreadyOpen(typeof(Check_Test))) == null)
            {
                ee.ShowDialog(this);
                this.Close();
            }

            else
            {
                enet.WindowState = FormWindowState.Normal;
                enet.BringToFront();
            }

        }
    }
}
