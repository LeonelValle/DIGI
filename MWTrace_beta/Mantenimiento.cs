using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Mantenimiento : Form
    {
        public Mantenimiento()
        {
            InitializeComponent();
        }

        //
        private readonly Operador operador = new Operador();
        private readonly Ensamble ensamble = new Ensamble();
        private readonly Orden orden = new Orden();
        private readonly ModeloOrden modeloOrden = new ModeloOrden();
        private readonly ModeloOrdenCaja modeloOrdenCaja = new ModeloOrdenCaja();
        private readonly Caja caja = new Caja();

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            #region Llenar los ComboBox

            cb_ensambleBajas.DataSource = ensamble.LlenarComboBox("select * from  tb_Ensamble");
            cb_ensambleBajas.DisplayMember = "ensamble";
            cb_ensambleBajas.ValueMember = "id_ensamble";
            this.cb_ensambleBajas.SelectedItem = null;

            cb_ensambleCambiar.DataSource = ensamble.LlenarComboBox("select * from  tb_Ensamble");
            cb_ensambleCambiar.DisplayMember = "ensamble";
            cb_ensambleCambiar.ValueMember = "id_ensamble";
            this.cb_ensambleCambiar.SelectedItem = null;

            cb_NempladoBajas.DataSource = operador.LlenarComboBox("select * from tb_Operador");
            cb_NempladoBajas.DisplayMember = "numeroempleado";
            cb_NempladoBajas.ValueMember = "id_operador";
            this.cb_NempladoBajas.SelectedItem = null;

            cb_NempleadoCambiar.DataSource = operador.LlenarComboBox("select * from tb_Operador");
            cb_NempleadoCambiar.DisplayMember = "numeroempleado";
            cb_NempleadoCambiar.ValueMember = "id_operador";
            this.cb_NempleadoCambiar.SelectedItem = null;

            cb_ActualizarOrden.DataSource = operador.LlenarComboBox("select id_orden, orden from tb_Orden");
            cb_ActualizarOrden.DisplayMember = "orden";
            cb_ActualizarOrden.ValueMember = "id_orden";
            this.cb_ActualizarOrden.SelectedItem = null;

            //cb_CajaOrden.DataSource = operador.LlenarComboBox("select * from tb_Orden");
            //cb_CajaOrden.DisplayMember = "orden";
            //cb_CajaOrden.ValueMember = "id_orden";
            //this.cb_CajaOrden.SelectedItem = null;

            cb_ensambleOrden.DataSource = ensamble.LlenarComboBox("select * from  tb_Ensamble");
            cb_ensambleOrden.DisplayMember = "ensamble";
            cb_ensambleOrden.ValueMember = "id_ensamble";
            this.cb_ensambleOrden.SelectedItem = null;



            #endregion

            try
            {
                dg_Operador.DataSource = operador.LlenarDG("select nombre, numeroempleado from tb_Operador").Tables[0];
                //dataGridView4.DataSource = con.LlenarDG("select conexion from ConfiguracionSistema where id_cs = 7").Tables[0];
                dg_ensamble.DataSource = ensamble.LlenarDG("select ensamble from tb_Ensamble").Tables[0];

                gv_ordenes.DataSource = orden.LlenarDG("select o.orden, o.cantidad, e.ensamble from tb_Orden o, tb_Ensamble e where o.id_ensamble = e.id_ensamble").Tables[0];

                cb_caja.DataSource = ensamble.LlenarComboBox("select * from  tb_caja");
                cb_caja.DisplayMember = "caja";
                cb_caja.ValueMember = "id_caja";
                this.cb_caja.SelectedItem = null;

                cb_caja.AutoCompleteCustomSource = LoadAutoComplete();
                cb_caja.AutoCompleteMode = AutoCompleteMode.Suggest;
                cb_caja.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch { MessageBox.Show("ERROR!", "no se encontro la base de datos!"); }


        }

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = caja.LlenarComboBox("select caja from tb_caja");

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["caja"]));
            }

            return stringCol;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //pcb.Id_pcb = int.Parse(pcb.returnValue("insert into tb_pcb values('" + txt_pcb.Text + "') SELECT @@IDENTITY as ID"));
            if (!(string.IsNullOrEmpty(txt_ensamble.Text)))
            {
                ensamble.Crud("insert into tb_ensamble (ensamble) values('" + txt_ensamble.Text + "')");
                txt_ensamble.Text = "";
                Mantenimiento_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Llenar toda la informacion!", "ERROR!");
            }
        }

        private void Btn_guardar_operador_Click(object sender, EventArgs e)
        {
            try
            {
                operador.Crud("insert into tb_Operador values('" + txt_nombre.Text + "', " + txt_nEmpledo.Text + ")");
                Mantenimiento_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Inserte el nombre y el numero de empleado");
            }
        }


        private void Btn_borrarPCB_Click(object sender, EventArgs e)
        {
            if (cb_ensambleBajas.SelectedItem != null)
            {
                ensamble.Crud("delete from tb_Ensamble where id_ensamble = " + cb_ensambleBajas.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Seleccione un ensamble para borrar", "ERROR!");

        }

        private void Btn_cambiarPCB_Click(object sender, EventArgs e)
        {
            if (cb_ensambleCambiar.SelectedItem != null && !(string.IsNullOrEmpty(txt_nuevoEnsamble.Text)))
            {
                ensamble.Crud("update tb_Ensamble set ensamble = '" + txt_nuevoEnsamble.Text + "' where id_ensamble = " + cb_ensambleCambiar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");

        }

        private void Btn_empleadoCambiar_Click(object sender, EventArgs e)
        {
            if (cb_NempleadoCambiar.SelectedItem != null && !(string.IsNullOrEmpty(txt_nombreCambiar.Text)) && !(string.IsNullOrEmpty(txt_NempleadoCambiar.Text)))
            {
                operador.Crud("update tb_Operador set nombre = '" + txt_nombreCambiar.Text + "', numeroempleado = " + txt_NempleadoCambiar.Text + " where id_operador = " + cb_NempleadoCambiar.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Llene todos los campos!", "ERROR!");
        }

        private void Btn_empleadoBorrar_Click(object sender, EventArgs e)
        {
            if (cb_NempladoBajas.SelectedItem != null)
            {
                operador.Crud("delete from tb_Operador where id_operador = " + cb_NempladoBajas.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            else
                MessageBox.Show("Seleccione un Operador para borrar", "ERROR!");
        }

        public void CambiarDatosServer(string localhost, string user, string pass)
        {
            String cadenaNueva = "Data Source=" + localhost + "\\SQLEXPRESS;Initial Catalog=DIGITrace;user id=" + user + ";password=" + pass + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //abrimos la configuración de nuestro proyecto
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //hacemos la modificacion de la cadena de conexion (ServerDb es el atributo que tengo en app.config) 
            config.ConnectionStrings.ConnectionStrings["ServerDb"].ConnectionString = cadenaNueva;
            //Cambiamos el modo de guardado
            config.Save(ConfigurationSaveMode.Modified, true);
            // modificamos el guardado 
            //Properties.Settings.Default.Save();
            //Podemos revisar en la consola que configuraciones quedaron despues del comando
            //aqui en adelante es opcional        
            ConnectionStringSettingsCollection settings =
            ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
        }


        private void Btn_cancel_Click(object sender, EventArgs e)
        {

        }

        private void CboServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_localhost_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                orden.Crud("update tb_Orden set orden = '" + txt_orden.Text + "', id_ensamble = " + cb_ensambleOrden.SelectedValue + " , cantidad = " + txt_cantidad.Text + " where id_orden = " + cb_ActualizarOrden.SelectedValue);
                Mantenimiento_Load(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Cb_ActualizarOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ActualizarOrden.SelectedItem != null)
            {

                try
                {
                    SqlDataReader leer = orden.Leer("Select * from tb_Orden where id_orden = " + cb_ActualizarOrden.SelectedValue);

                    if (leer.Read() == true)
                    {
                        txt_orden.Text = leer["orden"].ToString();
                        txt_cantidad.Text = leer["cantidad"].ToString();
                        cb_ensambleOrden.SelectedValue = leer["id_ensamble"].ToString();
                    }

                    else
                    {
                        txt_cantidad.Text = "";
                        txt_orden.Text = "";
                        cb_ActualizarOrden.SelectedItem = null;
                    }

                    orden.Cerrar();
                }
                catch (System.InvalidOperationException)
                {
                    orden.Cerrar();
                    throw;
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (cb_caja.SelectedItem != null)
            {

                try
                {
                    caja.Id_caja = int.Parse(cb_caja.SelectedValue.ToString());

                    orden.Cerrar();
                }
                catch (System.InvalidOperationException)
                {
                    orden.Cerrar();
                    throw;
                }
            }
            Mantenimiento_Load(sender, e);
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            //if (!caja.Existe("select count(*) from tb_Orden where id_caja = '" + caja.Id_caja + "'"))
            caja.Crud("update tb_Orden set id_caja = NULL where id_caja = '" + caja.Id_caja + "'");
            caja.Crud("delete tb_ModeloOrden where id_caja = " + caja.Id_caja);
            caja.Crud("delete tb_ModeloOrdenCaja where id_caja = " + caja.Id_caja);
            caja.Crud("delete tb_caja where id_caja = " + caja.Id_caja);
            Mantenimiento_Load(sender, e);
        }

        private void TabPage6_Click(object sender, EventArgs e)
        {

        }

        private void cb_caja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_caja.SelectedIndex > 0)
                caja.Id_caja = int.Parse(cb_caja.SelectedValue.ToString());
            //gv_caja.DataSource = orden.LlenarDG("select * from tb_ModeloOrden where id_caja = " + caja.Id_caja).Tables[0];
            gv_caja.DataSource = orden.LlenarDG("select e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, mo.SerialNumberCaja, mo.scanmacCaja, mo.scanimeiCaja, o.orden, mo.fecharegistro, c.caja, c.Estatus, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_caja = " + caja.Id_caja + " order by mo.id_modeloOrden asc").Tables[0];
            this.gv_caja.Columns[0].Visible = false;

            cb_CajaOrden.DataSource = operador.LlenarComboBox("select * from tb_Orden");
            cb_CajaOrden.DisplayMember = "orden";
            cb_CajaOrden.ValueMember = "id_orden";
            this.cb_CajaOrden.SelectedItem = null;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                modeloOrden.Crud("update tb_ModeloOrden set id_orden = " + cb_CajaOrden.SelectedValue + " where id_caja = " + cb_caja.SelectedValue);

                modeloOrdenCaja.Crud("update tb_ModeloOrdenCaja set id_orden = " + cb_CajaOrden.SelectedValue + " where id_caja = " + cb_caja.SelectedValue);
                /*
                update tb_ModeloOrden set id_orden = 180 where id_caja = 1404
                update tb_ModeloOrdenCaja set id_orden = 180 where id_caja = 1404
                */
                Mantenimiento_Load(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("ERROR!", "WARNING");
            }
        }

        private void btn_SaveSN_Click(object sender, EventArgs e)
        {
            try
            {
                if ((modeloOrden.Existe("select COUNT(*) from tb_ModeloOrden where Serialnumber = '" + txt_serailNumber.Text + "'")) ||
                    (modeloOrden.Existe("select COUNT(*) from tb_ModeloOrdenCaja where SerialnumberCaja = '" + txt_serailNumber.Text + "'")))
                {
                    modeloOrden.Crud("delete tb_ModeloOrden where Serialnumber = '" + txt_serailNumber.Text + "'");
                    modeloOrden.Crud("delete tb_ModeloOrdenCaja where SerialnumberCaja = '" + txt_serailNumber.Text + "'");
                    MessageBox.Show("Registros Borrados");
                    txt_serailNumber.Text = "";
                }
                else
                    MessageBox.Show("Registros no encontrados");

            }
            catch (Exception)
            {

                MessageBox.Show("Inserte un Serial Number");
            }
        }

        private void btn_saveIMEI_Click(object sender, EventArgs e)
        {
            try
            {
                if ((modeloOrden.Existe("select COUNT(*) from tb_ModeloOrden where scanimei = '" + txt_IMEINumber.Text + "'")) ||
                    (modeloOrden.Existe("select COUNT(*) from tb_ModeloOrdenCaja where scanimeiCaja = '" + txt_IMEINumber.Text + "'")))
                {
                    modeloOrden.Crud("delete tb_ModeloOrden where scanimei = '" + txt_IMEINumber.Text + "'");
                    modeloOrden.Crud("delete tb_ModeloOrdenCaja where scanimeiCaja = '" + txt_IMEINumber.Text + "'");
                    MessageBox.Show("Registros Borrados");
                    txt_IMEINumber.Text = "";
                }
                else
                    MessageBox.Show("Registros no encontrados");

            }
            catch (Exception)
            {

                MessageBox.Show("Inserte un IMEI Number");
            }
        }

        private void btn_saveMAC_Click(object sender, EventArgs e)
        {
            try
            {
                if ((modeloOrden.Existe("select COUNT(*) from tb_ModeloOrden where scanmac = '" + txt_MACAddress.Text + "'")) ||
                    (modeloOrden.Existe("select COUNT(*) from tb_ModeloOrdenCaja where scanmacCaja = '" + txt_MACAddress.Text + "'")))
                {
                    modeloOrden.Crud("delete tb_ModeloOrden where scanmac = '" + txt_MACAddress.Text + "'");
                    modeloOrden.Crud("delete tb_ModeloOrdenCaja where scanmacCaja = '" + txt_MACAddress.Text + "'");
                    MessageBox.Show("Registros Borrados");
                    txt_MACAddress.Text = "";
                }
                else
                    MessageBox.Show("Registros no encontrados");

            }
            catch (Exception)
            {

                MessageBox.Show("Inserte un MAC Number");
            }
        }
    }
}
