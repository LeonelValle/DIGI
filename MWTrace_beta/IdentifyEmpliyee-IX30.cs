using MWTrace_beta;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DIGITrace
{
    public partial class IdentifyEmpliyee_IX30 : Form
    {
        readonly Conexion con = new Conexion();
        readonly Operador operador = new Operador();
        readonly Orden orden = new Orden();

        public IdentifyEmpliyee_IX30()
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
                    orden.Crud("update tb_Orden set id_operador = " + regreso + " where orden = '" + orden.Ordenes + "'");
                    operador.Id_operador = regreso;
                    Scan_IX30 ee = new Scan_IX30();
                    //ee.Show();

                    Form enet;

                    if ((enet = IsFormAlreadyOpen(typeof(Scan_IX30))) == null)
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

        private void btn_aceptar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
