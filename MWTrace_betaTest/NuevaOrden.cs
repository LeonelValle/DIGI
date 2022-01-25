using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class NuevaOrden : Form
    {
        readonly Conexion con = new Conexion();
        readonly Orden orden = new Orden();
        private readonly ConfiguracionSistema cs = new ConfiguracionSistema();
        readonly Ensamble ensamble = new Ensamble();
        readonly DateTime fecha = DateTime.Now;
        public NuevaOrden()
        {
            InitializeComponent();
        }
        private void NuevaOrden_Load(object sender, EventArgs e)
        {

            cb_operador.DataSource = con.LlenarComboBox("select * from tb_Operador");
            cb_operador.DisplayMember = "numeroempleado";
            cb_operador.ValueMember = "id_operador";

            cb_ensamble.DataSource = ensamble.LlenarComboBox("select * from tb_Ensamble");
            cb_ensamble.DisplayMember = "ensamble";
            cb_ensamble.ValueMember = "id_ensamble";

            lbl_fecha.Text = fecha.ToString("MM/dd/yyyy");


            this.cb_operador.SelectedItem = null;
            this.cb_ensamble.SelectedItem = null;

            try
            {
                //dataGridView1.DataSource = con.LlenarDG("select orden,fechaOrden from tb_Orden where FechaCierre IS NULL or Restantes != 0").Tables[0];
                dataGridView1.DataSource = con.LlenarDG("select orden,FechaOrden from tb_orden o where FechaCierre is null or Restantes != 0").Tables[0];

            }
            catch { MessageBox.Show("ERROR!", "no se encontro la base de datos!"); }
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se obtinen el consecutivo y la nomclatura de la base de datos de la tabla ConfiguracionSistema
                //Insercion en la tabla tb_Orden
                if (!orden.Existe("select COUNT(*) from tb_Orden where orden = '" + txt_orden.Text + "'"))
                {
                    orden.Crud("insert into tb_orden (orden, cantidad, fechaOrden, id_operador, id_ensamble ,rev, PiezaCaja) values('" + txt_orden.Text + "' , " + txt_cantidad.Text + " , '" + fecha.ToString("MM/dd/yyyy") + "' , " + cb_operador.SelectedValue + " , " + cb_ensamble.SelectedValue + ", '" + txt_revision.Text.ToUpper() + "','" + txt_UnidadCaja.Text + "')");
                    ///CAMBIAR///
                    //cs.Crud("update ConfiguracionSistema set PiezaCaja = " + txt_UnidadCaja.Text + " where id_cs = 3");
                    MessageBox.Show("Nueva orden registrada!");

                    NuevaOrden_Load(sender, e);
                    txt_cantidad.Text = "";
                    txt_orden.Text = "";
                    txt_revision.Text = "";
                    txt_UnidadCaja.Text = "";
                }
                else { MessageBox.Show("Esta orden ya existe!", "ERROR!"); }

            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.ToString());
                //MessageBox.Show("ERROR!", "ERROR!");
            }
            catch (Exception)
            {
                MessageBox.Show("Llena la info!", "ERROR!");
            }

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.Show();
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Find last visible row
            DataGridViewRow row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).Last();
            // scroll to last row if necessary
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.IndexOf(row);
            // select row
            row.Selected = true;
        }
    }
}
