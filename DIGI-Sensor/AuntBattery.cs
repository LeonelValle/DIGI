using System;
using System.Linq;
using System.Windows.Forms;

namespace DIGI_Sensor
{
    public partial class AuntBattery : Form
    {
        readonly Conexion con = new Conexion();
        readonly Operador operador = new Operador();
        readonly Ensamble ensamble = new Ensamble();
        Battery battery = new Battery();

        public AuntBattery()
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

                if (regreso > 0 && (int)cb_Modelo.SelectedValue != 0)
                {
                    //orden.Crud("update tb_Orden set id_operador = " + regreso + " where orden = '" + orden.Ordenes + "'");
                    BatteryCheck ee = new BatteryCheck();

                    //ee.Show();
                    battery.Ensamble = cb_Modelo.Text;
                    ensamble.Id_ensamble = (int)cb_Modelo.SelectedValue;
                    Form enet;

                    if ((enet = IsFormAlreadyOpen(typeof(BatteryCheck))) == null)
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
                    MessageBox.Show("No se encontro!");
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

        private void AuntBattery_Load(object sender, EventArgs e)
        {
            cb_Modelo.DataSource = ensamble.LlenarComboBox("select * from tb_Ensamble where tested is not null");
            cb_Modelo.DisplayMember = "ensamble";
            cb_Modelo.ValueMember = "id_ensamble";
            this.cb_Modelo.SelectedItem = null;
        }
    }
}
