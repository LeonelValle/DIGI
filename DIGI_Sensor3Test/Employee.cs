using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DIGI_Sensor3test
{
    public partial class Employee : Form
    {
        readonly Conexion con = new Conexion();
        readonly Operador operador = new Operador();
        public Employee()
        {
            InitializeComponent();
        }
        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                operador.Numeroempleado = Convert.ToInt32(txt_empleado.Text);
                if (txt_empleado.Text == "")
                    throw new Exception();

                int regreso = int.Parse(operador.ReturnValue("select id_operador from tb_operador where numeroempleado = " + txt_empleado.Text));

                if (regreso > 0)
                {
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
                else
                {
                    MessageBox.Show("No se encontro");
                    txt_empleado.Text = "";
                }

                con.Cerrar();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No existe ese registro", "ERROR!");
                con.Cerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Inserte un Operador!");
            }
        }

        private void txt_empleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_aceptar_Click(this, new EventArgs());
            }
        }
    }
}
