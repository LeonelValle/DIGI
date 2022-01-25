using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Retrabajo : Form
    {
        private readonly Caja caja = new Caja();
        private readonly ModeloOrden modeloorden = new ModeloOrden();
        private readonly ModeloOrdenCaja modeloordenCaja = new ModeloOrdenCaja();
        private readonly ConfiguracionSistema cs = new ConfiguracionSistema();

        public Retrabajo()
        {
            InitializeComponent();
        }

        private void Retrabajo_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowHeadersVisible = false; // set it to false if not needed
            this.dataGridView1.VirtualMode = true;
            try
            {
                lbl_user.Text = cs.Usuario;
                if (cs.Usuario == "admins")
                    btn_borrar.Visible = true;
                //dataGridView1.DataSource = modeloorden.LlenarDG("select distinct TOP 1000 mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja order by mo.id_modeloOrden asc").Tables[0];
                //this.dataGridView1.Columns[0].Visible = false;
                //this.dataGridView1.Columns[1].Visible = false;

                //cb_caja.DataSource = caja.LlenarComboBox("select * from tb_caja");
                //cb_caja.DisplayMember = "caja";
                //cb_caja.ValueMember = "id_caja";
                //cb_caja.SelectedItem = null;
            }
            catch { MessageBox.Show("no se encontro la base de datos!", "ERROR!"); }
        }

        private void FillCBCajas()
        {
            try
            {
                cb_caja.DataSource = caja.LlenarComboBox("select * from tb_caja");
                cb_caja.DisplayMember = "caja";
                cb_caja.ValueMember = "id_caja";
                cb_caja.SelectedItem = null;
            }
            catch { MessageBox.Show("no se encontro la base de datos!", "ERROR!"); }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            //try
            //{

            //IF PARA VALIDAR QUE NO ESTEN VACIOS LOS CAMPOS
            if (!(string.IsNullOrEmpty(txt_id.Text)) && !(string.IsNullOrEmpty(txt_id.Text)) && !(string.IsNullOrEmpty(txt_problema.Text)))
            {
                modeloorden.Crud("update tb_ModeloOrden set scanmac = '" + txt_sacanmodem.Text + "' , scanimei = '" + txt_scansim.Text + "' , Serialnumber = '" + txt_serialnumber.Text + "' , revision = '" + txt_revision.Text + "' , Problema = '" + txt_problema.Text + "' , id_caja = '" + cb_caja.SelectedValue + "' where id_modeloOrden = '" + txt_id.Text + "'");
                //modeloordenCaja.Crud("update tb_ModeloOrdenCaja set scanmacCaja = '" + txt_macCaja.Text + "' , scanimeiCaja = '" + txt_imeiCaja.Text + "' , SerialNumberCaja = '" + txt_serialCaja.Text + "' , id_caja = '" + cb_caja.SelectedValue + "' where id_mocaja = '" + txt_idCaja.Text + "'");
                //Retrabajo_Load(sender, e);
                Search();
            }
            else
            { MessageBox.Show("No dejes ningun campo vacio!", "ERROR!"); }
          
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // if (cell != null)
                txt_id.Text = row.Cells["ID"].Value.ToString();
                // txt_idCaja.Text = row.Cells["IdCaja"].Value.ToString();
            }

            try
            {
                SqlDataReader leer = modeloorden.Leer("Select * from tb_ModeloOrden, tb_Orden where tb_ModeloOrden.id_orden = tb_Orden.id_orden and id_modeloOrden = '" + txt_id.Text + "'");

                FillCBCajas();
                //if (leer.Read() == true && leerCaja.Read() == true)
                if (leer.Read() == true)
                {
                    txt_sacanmodem.Text = leer["scanmac"].ToString();
                    txt_scansim.Text = leer["scanimei"].ToString();
                    txt_serialnumber.Text = leer["Serialnumber"].ToString();
                    txt_revision.Text = leer["revision"].ToString();

                    caja.Id_caja = int.Parse(leer["id_caja"].ToString());
                    //cb_caja.SelectedItem = ReturnValueCaja("select caja from tb_caja where id_caja = " + caja.Id_caja);
                    cb_caja.SelectedIndex = cb_caja.FindString(ReturnValueCaja("select caja from tb_caja where id_caja = " + caja.Id_caja));

                }
                else
                {
                    txt_sacanmodem.Text = "";
                    txt_scansim.Text = "";
                    txt_serialnumber.Text = "";

                }


                modeloorden.Cerrar();
            }
            catch (System.InvalidOperationException)
            {
                modeloorden.Cerrar();
                //throw;
            }
        }



        private void Btn_go_Click(object sender, EventArgs e)
        {
            if (!(txt_buscar.Text == ""))
                Search();
            else
                MessageBox.Show("Campo vacio!", "ERROR!");
        }

        private void Btn_recargar_Click(object sender, EventArgs e)
        {
            Retrabajo_Load(sender, e);
        }

        public string ReturnValueCaja(string comando)
        {
            string yourValue = "";

            SqlCommand cmd = new SqlCommand(comando, modeloorden.Con1);
            modeloorden.Cerrar();
            modeloorden.Abrir();
            yourValue = cmd.ExecuteScalar().ToString();
            return yourValue;
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            //try
            //{
            modeloorden.Crud("update tb_ModeloOrden set problema = '" + txt_problema.Text + "' where id_modeloOrden = " + txt_id.Text);
            modeloorden.Crud(comando: "delete tb_ModeloOrden where id_modeloOrden = '" + txt_id.Text + "'");
            // modeloorden.Crud(comando: "delete tb_ModeloOrdenCaja where id_mocaja = " + txt_idCaja.Text);
            //Retrabajo_Load(sender,e);
            Search();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Error al borrar!");
            //}
        }

        private void Search()
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.txt_buscar.Text.Split(' ');

            foreach (string palabra in palabra_busqueda)
            {
                if (cb_orden.Text == "Serial Number")
                {
                    if (modeloorden.Existe("select COUNT(*) from tb_modeloOrden where serialNumber = '" + txt_buscar.Text + "'"))
                    {
                        int id_modelorden = int.Parse(modeloorden.ReturnID("select id_modeloOrden from tb_ModeloOrden where serialNumber = '" + txt_buscar.Text + "'"));
                        salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_modeloOrden = " + id_modelorden + " order by mo.id_modeloOrden asc";
                    }

                    //else
                    //{
                    //    int id_mo = int.Parse(modeloorden.ReturnID("select id_mocaja from tb_ModeloOrdenCaja where SerialNumberCaja = '" + txt_buscar.Text + "'"));

                    //    salida_datos = "select mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja where moc.id_mocaja = '" + id_mo + "' order by mo.id_modeloOrden asc";
                    //}


                }
                if (cb_orden.Text == "MAC Address")
                {

                    if (modeloorden.Existe("select COUNT(*) from tb_modeloOrden where scanmac = '" + txt_buscar.Text + "'"))
                    {
                        int id_modelorden = int.Parse(modeloorden.ReturnID("select id_modeloOrden from tb_ModeloOrden where scanmac = '" + txt_buscar.Text + "'"));
                        salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_modeloOrden = '" + id_modelorden + "' order by mo.id_modeloOrden asc";
                    }
                    //else
                    //{
                    //    int id_mo = int.Parse(modeloorden.ReturnID("select id_mocaja from tb_ModeloOrdenCaja where scanmacCaja = '" + txt_buscar.Text + "'"));

                    //    salida_datos = "select mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja where moc.id_mocaja = '" + id_mo + "' order by mo.id_modeloOrden asc";
                    //}
                }


                if (cb_orden.Text == "IMEI Number")
                {
                    if (modeloorden.Existe("select COUNT(*) from tb_modeloOrden where scanimei = '" + txt_buscar.Text + "'"))
                    {
                        int id_modelorden = int.Parse(modeloorden.ReturnID("select id_modeloOrden from tb_ModeloOrden where scanimei = '" + txt_buscar.Text + "'"));
                        salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_modeloOrden = '" + id_modelorden + "' order by mo.id_modeloOrden asc";
                        //salida_datos = "select distinct mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, mo.qr, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, moc.qrCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja where mo.scanimei = '" + txt_buscar.Text + "' OR moc.scanimeiCaja = '" + txt_buscar.Text + "' order by mo.id_modeloOrden asc";
                    }
                    //else
                    //{
                    //    int id_mo = int.Parse(modeloorden.ReturnID("select id_mocaja from tb_ModeloOrdenCaja where scanimeiCaja = '" + txt_buscar.Text + "'"));

                    //    salida_datos = "select mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja where moc.id_mocaja = '" + id_mo + "' order by mo.id_modeloOrden asc";
                    //}
                }


                if (cb_orden.Text == "Orden")
                    salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where o.orden = '" + txt_buscar.Text + "' order by mo.id_modeloOrden asc";
                //{

                //    int id_orden = int.Parse(modeloorden.ReturnValue("select id_orden from tb_Orden where orden = " + txt_buscar.Text));
                //    salida_datos = "select distinct mo.id_modeloOrden as ID, moc.id_mocaja as IdCaja, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, moc.SerialNumberCaja, moc.scanmacCaja, moc.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_ModeloOrdenCaja moc on o.id_orden = moc.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja and c.id_caja = moc.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden and u.id_mocaja = moc.id_mocaja where o.id_orden = '" + id_orden + "' order by mo.id_modeloOrden asc";
                //}

                if (cb_orden.Text == "Caja")
                    salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where c.caja = '" + txt_buscar.Text + "' order by mo.id_modeloOrden asc";

                if (cb_orden.Text == "Ensamble")
                    salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where e.ensamble = '" + txt_buscar.Text + "' order by mo.id_modeloOrden asc";


                //this.filtro.RowFilter = salida_datos;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView1.RowHeadersVisible = false; // set it to false if not needed
                this.dataGridView1.VirtualMode = true;
                if (salida_datos != "")
                {
                    dataGridView1.DataSource = modeloorden.LlenarDG(salida_datos).Tables[0];
                    this.dataGridView1.Columns[0].Visible = false;
                    //this.dataGridView1.Columns[1].Visible = false;
                }
            }
        }

    }
}
