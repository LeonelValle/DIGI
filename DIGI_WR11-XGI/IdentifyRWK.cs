using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DIGI_WR11_XGI
{
    public partial class IdentifyRWK : Form
    {
        Operador operador = new Operador();
        Conexion con = new Conexion();


        public IdentifyRWK()
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
                operador.Idemp = Convert.ToInt32(txt_empleado.Text);
                if (txt_empleado.Text == "")
                    throw new Exception();

                int regreso = int.Parse(operador.ReturnValue("select id_user from tb_User where idemp = " + txt_empleado.Text));

                if (regreso > 0)
                {
                    operador.Id_user = regreso;
                    //orden.Crud("update tb_Orden set id_user = " + regreso + " where orden = " + orden.wo);
                    Scaning ee = new Scaning();
                    //ee.Show();

                    Form enet;

                    if ((enet = IsFormAlreadyOpen(typeof(Scaning))) == null)
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
                MessageBox.Show("Insert an Id!");
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
