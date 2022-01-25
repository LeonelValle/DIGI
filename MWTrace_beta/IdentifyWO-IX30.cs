using MWTrace_beta;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DIGITrace
{
    public partial class IdentifyWO_IX30 : Form
    {
        Conexion con = new Conexion();
        Orden orden = new Orden();
        public IdentifyWO_IX30()
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
                orden.Ordenes = txt_serial.Text;
                if (txt_serial.Text == "")
                    throw new Exception();

                SqlCommand cmd = new SqlCommand("select o.orden from tb_Orden o join tb_Ensamble e on o.id_ensamble = e.id_ensamble where e.tested = 'IX30' and orden = '" + orden.Ordenes + "'", con.Con1);
                con.Abrir();
                cmd.ExecuteNonQuery();
                string regreso = cmd.ExecuteScalar().ToString();
                if (regreso != "0")
                {
                    this.Close();
                    //Ensamble_Etiquetado ee = new Ensamble_Etiquetado();
                    IdentifyEmpliyee_IX30 setup = new IdentifyEmpliyee_IX30();
                    //setup.Show();

                    Form sp;

                    if ((sp = IsFormAlreadyOpen(typeof(IdentifyEmpliyee_IX30))) == null)
                    {
                        setup.ShowDialog(this);
                        this.Close();
                    }

                    else
                    {
                        sp.WindowState = FormWindowState.Normal;
                        sp.BringToFront();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro");
                    txt_serial.Text = "";
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
                MessageBox.Show("Inserte una orden");
            }
        }

        private void txt_serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_aceptar_Click(this, new EventArgs());
            }
        }
    }
}
