using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Especial : Form
    {
        private readonly Caja caja = new Caja();
        public Especial()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            caja.Crud("update tb_ModeloOrden set = Serialnumber = '" + txt_partnumber.Text + "',  ");
        }

        private void Especial_Load(object sender, EventArgs e)
        {

            cb_ensamble.DataSource = caja.LlenarComboBox("select * from tb_caja");
            cb_ensamble.DisplayMember = "caja";
            cb_ensamble.ValueMember = "id_caja";
            //cb_ensamble.ValueMember = caja.LlenarComboBox("select * from tb_caja").Columns[0].ToString();
            //cb_ensamble.DisplayMember = caja.LlenarComboBox("select * from tb_caja").Columns[1].ToString();

            this.cb_ensamble.SelectedItem = null;

            cb_ensamble.AutoCompleteCustomSource = LoadAutoComplete();
            cb_ensamble.AutoCompleteMode = AutoCompleteMode.Suggest;
            cb_ensamble.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        public AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = caja.LlenarComboBox("select * from tb_caja");

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["caja"]));
            }

            return stringCol;
        }

        private void Cb_ensamble_Click(object sender, EventArgs e)
        {

        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (cb_ensamble.SelectedItem != null)
            {

                try
                {
                    SqlDataReader leer = caja.Leer("Select * from tb_ModeloOrden where id_caja = " + cb_ensamble.SelectedValue);

                    if (leer.Read() == true)
                    {
                        txt_imei.Text = leer["scanimei"].ToString();
                        txt_mac.Text = leer["scanmac"].ToString();
                        txt_iccid.Text = leer["iccid"].ToString();
                        txt_partnumber.Text = leer["partnumber"].ToString();
                        txt_serial.Text = leer["Serialnumber"].ToString();

                    }

                    else
                    {
                        txt_serial.Text = "";
                        txt_partnumber.Text = "";
                        txt_iccid.Text = "";
                        txt_imei.Text = "";
                        txt_mac.Text = "";

                    }

                    caja.Cerrar();
                }
                catch (System.InvalidOperationException)
                {
                    caja.Cerrar();
                    throw;
                }
            }
        }
    }
}
