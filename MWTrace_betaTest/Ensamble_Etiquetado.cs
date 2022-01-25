using DIGITrace;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Ensamble_Etiquetado : Form
    {
        private readonly Conexion con = new Conexion();
        private readonly Orden orden = new Orden();
        private readonly ModeloOrden modeloorden = new ModeloOrden();
        readonly Operador operador = new Operador();
        private readonly ModeloOrdenCaja modeloOrdenCaja = new ModeloOrdenCaja();
        private readonly UnionMoCaja unionMoCaja = new UnionMoCaja();
        private readonly Caja caja = new Caja();
        private readonly Error error = new Error();
        private readonly Ensamble ensamble = new Ensamble();


        Test test = new Test();

        int contadorRegistrados = 0;
        int contadorRegistradosCaja = 0;
        int TopRegistradosCaja = 0;
        //private readonly DataSet ds = new DataSet();

        public Ensamble_Etiquetado()
        {
            InitializeComponent();
        }

        private void Ensamble_Etiquetado_Load(object sender, EventArgs e)
        {
            LoadForm();

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            string turno = int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) >= 5 && int.Parse(DateTime.Now.TimeOfDay.ToString("hh")) <= 16 ? "1er" : "2do";

            //IF PARA SABER SI LOS TEXTBOX ESTAN VACIOS
            if (ValidarTextboxVacios() == true)
            {
                //IF PARA SABER SI YA SE LLENARON TODOS LOS REGISTROS Y GUSRDAR LA FECHA
                if (int.Parse(lbl_registrados.Text) < orden.Cantidad)
                {
                    ////Validar que no se puedan 
                    if (txt_caja.Enabled == false || txt_imei.Enabled == false || txt_mac.Enabled == false || txt_serial.Enabled == true)
                    {
                        if (txt_caja.Enabled == true || ensamble.Tested != "Cold Chain" || CheckTest() == 1)
                        {

                            if (txt_mac.Enabled == false || txt_mac.TextLength == 12 && txt_mac.Text.Substring(0, 3) == "000" || txt_mac.TextLength == 12 && txt_mac.Text.Substring(0, 2) == "00")
                            {

                                if (txt_imei.Enabled == false || txt_imei.TextLength == 15 && txt_imei.Text.Substring(0, 2) == "35")
                                {

                                    if (txt_imei.Enabled == false || !(modeloorden.Existe("select COUNT(*) from tb_ModeloOrden where scanimei = '" + txt_imei.Text + "' and scanimei != ''")))
                                    {

                                        if (txt_mac.Enabled == false || !(modeloorden.Existe("select COUNT(*) from tb_ModeloOrden where scanmac = '" + txt_mac.Text + "' and scanmac != ''")))
                                        {

                                            if (txt_serial.Enabled == false || !(modeloorden.Existe("select COUNT(*) from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text + "' and Serialnumber != ''")))
                                            {

                                                if (txt_partnumber.Text.Trim() == lbl_ensamble.Text.Trim() || txt_partnumber.Enabled == false)
                                                {

                                                    if (ValidarEnsamble() == true)
                                                    {
                                                        if (txt_caja.Enabled == true)
                                                        {
                                                            if (txt_caja.TextLength == 14 && txt_caja.Text.Substring(0, 2) == "MW")
                                                            {

                                                                if (!(caja.Existe("select COUNT(*) from tb_caja where caja = '" + txt_caja.Text + "'")))
                                                                {
                                                                    caja.Id_caja = int.Parse(caja.ReturnID("insert into tb_caja(caja,Modelo) values('" + txt_caja.Text.ToUpper().Trim() + "' , '" + txt_modeloCaja.Text.ToUpper().Trim() + "'); SELECT SCOPE_IDENTITY();"));
                                                                    orden.Crud("update tb_Orden set id_caja = '" + caja.Id_caja + "' where id_orden = '" + orden.Id_orden + "'");
                                                                    txt_caja.Enabled = false;
                                                                    txt_modeloCaja.Enabled = false;
                                                                    txt_UnidadesCaja.Enabled = false;

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("La caja ya existe!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    caja.Id_caja = 0;
                                                                    txt_caja.Enabled = true;
                                                                    txt_modeloCaja.Enabled = true;
                                                                    txt_UnidadesCaja.Enabled = true;

                                                                }
                                                                txt_caja.Text = "";
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Error de formato en la Caja!", "ERROR DE CAJA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                caja.Id_caja = 0;
                                                                txt_caja.Enabled = true;
                                                                txt_modeloCaja.Enabled = true;
                                                                txt_UnidadesCaja.Enabled = true;
                                                                txt_caja.Text = "";
                                                                txt_caja.Focus();
                                                            }

                                                        }
                                                        else if (contadorRegistradosCaja <= TopRegistradosCaja)
                                                        {
                                                            if (true)
                                                            {

                                                            }

                                                            modeloorden.Crud("INSERT INTO tb_ModeloOrden(Serialnumber, scanmac, scanimei, id_orden, fecharegistro, turno, revision, partnumber, id_caja) VALUES('" + txt_serial.Text.ToUpper() + "', '" + txt_mac.Text.ToUpper() + "', '" + txt_imei.Text.ToUpper() + "', '" + orden.Id_orden + "' , '" + DateTime.Now + "', '" + turno + "', '" + txt_revision.Text.ToUpper() + "', '" + txt_partnumber.Text.ToUpper() + "', " + caja.Id_caja + ");");

                                                            contadorRegistrados++;
                                                            lbl_registrados.Text = contadorRegistrados.ToString();

                                                            TextboxToEmpty();
                                                            txt_caja.Text = "";
                                                            txt_imei.Focus();
                                                            txt_imei.Select();
                                                            this.ActiveControl = txt_imei;

                                                        }
                                                        else
                                                        {
                                                            txt_caja.Enabled = true;
                                                            txt_modeloCaja.Enabled = true;
                                                            txt_UnidadesCaja.Enabled = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("ERROR!", "ERROR!");
                                                        Password();
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("El Part Number no coiciden!", "ERROR!");
                                                    Password();
                                                    TextboxToEmpty();
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show("El SERIAL NUMBER ya existe", "ERROR!");
                                                Password();
                                                TextboxToEmpty();
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("El MAC ADDRESS ya existe", "ERROR!");
                                            Password();
                                            TextboxToEmpty();
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("El IMEI NUMBER ya existe", "ERROR!");
                                        Password();
                                        TextboxToEmpty();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error de formato en IMEI!", "ERROR DE IMEI!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Error de formato en MAC!", "ERROR DE MAC!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("FAIL TEST!", "FAIL!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //Password();
                            modeloorden.Crud("insert into Log_ShippingTest values('" + txt_serial.Text + "','" + DateTime.Now + "','" + operador.Id_operador + "')");
                            TextboxToEmpty();
                        }
                    }
                    else
                    {
                        MessageBox.Show("FAIL!", "FAIL!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Password();
                        //modeloorden.Crud("insert into Log_ShippingTest values('" + txt_serial.Text + "','" + DateTime.Now + "','" + operador.Id_operador + "')");
                        TextboxToEmpty();
                    }

                }
                else
                {
                    MessageBox.Show("Se han llenado todos los registros!");
                    orden.Crud("update tb_Orden set fechacierre = '" + DateTime.Now + "' where id_orden = " + orden.Id_orden);
                    this.Close();
                    //TextboxToDisable();
                }

                Ensamble_Etiquetado_Load(sender, e);
            }
            else
            {
                MessageBox.Show("No dejes ningun campo vacio!", "ERROR!");
            }

        }


        private void Button1_Enter(object sender, EventArgs e) =>
            SendKeys.Send("{ENTER}");

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Find last visible row
            DataGridViewRow row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).Last();
            // scroll to last row if necessary
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.IndexOf(row);
            // select row
            row.Selected = true;
        }

        private void Txt_revision_TextChanged(object sender, EventArgs e) => orden.Crud("update tb_Orden set rev = '" + txt_revision.Text + "' where id_orden = " + orden.Id_orden);

        private void TextboxToEmpty()
        {
            txt_imei.Text = "";
            txt_serial.Text = "";
            txt_mac.Text = "";

            txt_partnumber.Text = "";

        }
        private void TextboxToDisable()
        {
            txt_serial.Enabled = false;
            txt_imei.Enabled = false;
            txt_mac.Enabled = false;
            txt_partnumber.Enabled = false;

        }
        private void CargarSetup()
        {
            txt_serial.Enabled = bool.Parse(orden.ReturnValue("select serialnumber from tb_SetUp where id_orden = " + orden.Id_orden));
            txt_imei.Enabled = bool.Parse(orden.ReturnValue("select imei from tb_SetUp where id_orden = " + orden.Id_orden));
            txt_mac.Enabled = bool.Parse(orden.ReturnValue("select mac from tb_SetUp where id_orden = " + orden.Id_orden));
            txt_partnumber.Enabled = bool.Parse(orden.ReturnValue("select partnumber from tb_SetUp where id_orden = " + orden.Id_orden));
        }
        private void TextboxToNA()
        {
            txt_imei.Text = txt_imei.Enabled == false ? "N/A" : "";
            txt_mac.Text = txt_mac.Enabled == false ? "N/A" : "";
            txt_partnumber.Text = txt_partnumber.Enabled == false ? "N/A" : "";
            txt_serial.Text = txt_serial.Enabled == false ? "N/A" : "";
        }
        private void Tap_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && txt_imei.Text != "")
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private bool ValidarEnsamble()
        {
            if (txt_imei.Text == lbl_ensamble.Text.Trim() ||
               txt_mac.Text == lbl_ensamble.Text.Trim() ||
               txt_serial.Text == lbl_ensamble.Text.Trim())
            {
                return false;
            }

            return true;
        }

        private bool ValidarTextboxVacios()
        {


            if (txt_imei.Enabled == true && (string.IsNullOrEmpty(txt_imei.Text)))
            {
                txt_imei.Focus();
                return false;
            }

            if (txt_mac.Enabled == true && (string.IsNullOrEmpty(txt_mac.Text)))
            {
                txt_mac.Focus();
                return false;
            }

            if (txt_serial.Enabled == true && string.IsNullOrEmpty(txt_serial.Text))
            {
                txt_serial.Focus();
                return false;
            }

            if (txt_partnumber.Enabled == true && (string.IsNullOrEmpty(txt_partnumber.Text)))
            {
                txt_partnumber.Focus();
                return false;
            }

            if (txt_caja.Enabled == true && (string.IsNullOrEmpty(txt_caja.Text)))
            {
                txt_caja.Focus();
                return false;
            }
            if (txt_modeloCaja.Enabled == true && (string.IsNullOrEmpty(txt_modeloCaja.Text)))
            {
                txt_modeloCaja.Focus();
                return false;
            }


            return true;
        }

        private void Txt_UnidadesCaja_TextChanged(object sender, EventArgs e)
        {
            //update tb_Orden set PiezaCaja = where id_orden =
            orden.Crud("update tb_Orden set PiezaCaja = '" + txt_UnidadesCaja.Text + "' where id_orden = " + orden.Id_orden);
        }

        private void Btn_nuevaCaja_Click(object sender, EventArgs e)
        {
            txt_caja.Enabled = true;
            txt_modeloCaja.Enabled = true;
            //TextboxToDisable();
            int contadorCajas = int.Parse(txt_UnidadesCaja.Text);
            orden.Crud("update tb_Orden set PiezaCaja = '" + lbl_countCaja.Text + "' where id_orden = " + orden.Id_orden);
            //Ensamble_Etiquetado_Load(sender, e);
            caja.Id_caja = 0;
            LoadForm();
            orden.Crud("update tb_Orden set PiezaCaja = '" + contadorCajas + "' where id_orden = " + orden.Id_orden);
        }

        private void Password()
        {

            Form pass;
            if ((pass = IsFormAlreadyOpen(typeof(Error))) == null)
            {
                error.ShowDialog(this);
            }

            else
            {
                pass.WindowState = FormWindowState.Normal;
                pass.BringToFront();
            }
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }
        /// <summary>
        /// Metodo para paver si paso las preubas 
        /// 0 = N/A
        /// 1 = PASS
        /// 2 = FAIL
        /// </summary>
        /// <returns></returns>
        private int CheckTest()
        {
            int passed = 0;

            test.Rf = test.ReturnValue("select TOP 1 status from Test_RF where Serialnumber ='" + txt_serial.Text + "' order by id_rf desc");
            test.Current = test.ReturnValue("select TOP 1 status from Test_Current where Serialnumber ='" + txt_serial.Text + "' order by id_current desc");
            test.Nist = test.ReturnValue("select TOP 1 status from Test_Nist where Serialnumber ='" + txt_serial.Text + "' order by id_nist desc");
            test.Coldsoak = test.ReturnValue("select TOP 1 status from Test_coldsoak where Serialnumber ='" + txt_serial.Text + "' order by id_coldsoak desc");

            if (test.Rf == "Passed")
                passed = 1;
            else
                passed = 2;

            if (test.Current == "Passed" || test.Current == "PASS")
                passed = 1;
            else
                passed = 2;

            if (test.Nist == "Passed")
                passed = 1;
            else
                passed = 2;

            if (test.Coldsoak == "PASS" || test.Coldsoak == "Passed" || test.Coldsoak == "Pass - Level 1" || test.Coldsoak == "Pass - Level 2" || test.Coldsoak == "Pass - Level 3" || test.Coldsoak == "Pass - Level 4" || test.Coldsoak == "Pass - Level 5")
                passed = 1;
            else
                passed = 2;



            return passed;
        }


        private void LoadForm()
        {
            orden.Id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden = '" + orden.Ordenes + "'"));

            ensamble.Tested = ensamble.ReturnValue("select tested from tb_Orden o join tb_Ensamble e on o.id_ensamble = e.id_ensamble where o.id_orden = '" + orden.Id_orden + "'");

            if (ensamble.Tested == "Cold Chain")
            {
                ensamble.Test = true;
                ensamble.Ensambles = ensamble.ReturnValue("select ensamble from tb_Orden o join tb_Ensamble e on o.id_ensamble = e.id_ensamble where o.id_orden = '" + orden.Id_orden + "'");
            }

            operador.Id_operador = int.Parse(operador.ReturnID("select id_operador from tb_Operador where numeroempleado = '" + operador.Numeroempleado + "'"));

            lbl_serial.Text = orden.Ordenes.ToString();

            lbl_numeroempleado.Text = operador.Numeroempleado.ToString();

            lbl_registrados.Text = modeloorden.ReturnValue("select COUNT(*) from tb_ModeloOrden where id_orden = " + orden.Id_orden);

            txt_revision.Text = orden.ReturnValue(comando: "select rev from tb_Orden where id_orden = " + orden.Id_orden);

            txt_UnidadesCaja.Text = orden.ReturnValue(comando: "select PiezaCaja from tb_Orden where id_orden = " + orden.Id_orden);

            TopRegistradosCaja = int.Parse(orden.ReturnValue(comando: "select PiezaCaja from tb_Orden where id_orden = " + orden.Id_orden));

            orden.Cantidad = int.Parse(orden.ReturnValue("select cantidad from tb_Orden where id_orden = " + orden.Id_orden));



            //if (txt_caja.Enabled == true && caja.Id_caja != 0)
            caja.Id_caja = int.Parse(caja.ReturnValue("select id_caja from tb_Orden where id_orden = '" + orden.Id_orden + "'"));


            lbl_ensamble.Text = modeloorden.ReturnValue("select Modelo from tb_caja where id_caja = '" + caja.Id_caja + "'");

            contadorRegistradosCaja = int.Parse(modeloorden.ReturnValue("select COUNT(*) from tb_ModeloOrden where id_caja = '" + caja.Id_caja + "'"));

            lbl_countCaja.Text = contadorRegistradosCaja.ToString();

            if (int.Parse(lbl_registrados.Text) < orden.Cantidad)
            {
                #region setup de los textbox
                //IF PARA SABER SI SE REALIZO EL SETUP DE LA ORDEN
                if (modeloorden.Existe("select COUNT(*) from tb_SetUp where id_orden = " + orden.Id_orden + ""))
                {
                    CargarSetup();
                    if (contadorRegistradosCaja >= TopRegistradosCaja || caja.Id_caja <= 0)
                    {
                        txt_caja.Enabled = true;
                        txt_modeloCaja.Enabled = true;
                        txt_UnidadesCaja.Enabled = true;
                        TextboxToDisable();
                    }
                    else
                    {
                        txt_caja.Enabled = false;
                        txt_modeloCaja.Enabled = false;
                        txt_UnidadesCaja.Enabled = false;
                    }

                }
                else
                {
                    TextboxToDisable();
                    txt_caja.Enabled = false;
                    txt_modeloCaja.Enabled = false;
                    txt_UnidadesCaja.Enabled = false;
                }


                if (txt_imei.Enabled == false && txt_mac.Enabled == false && txt_serial.Enabled == false && txt_partnumber.Enabled == false && txt_caja.Enabled == false)
                {
                    MessageBox.Show("Favor de realizar el SetUp para la Orden: " + orden.Ordenes);
                    button1.Enabled = false;
                    dataGridView1.Enabled = false;
                    txt_revision.Enabled = false;
                    txt_modeloCaja.Enabled = false;
                    btn_nuevaCaja.Enabled = false;
                }



                TextboxToNA();

                #endregion

            }
            else
            {
                MessageBox.Show("Se han llenado todos los registros!");
                orden.Crud("update tb_Orden set fechacierre = '" + DateTime.Now + "' where id_orden = " + orden.Id_orden);
                //this.Close();
                TextboxToDisable();
                txt_caja.Enabled = false;
                txt_modeloCaja.Enabled = false;
            }
            try
            {

                //dataGridView1.DataSource = con.LlenarDG("select distinct mo.id_modeloOrden, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, mo.ICCID,mo.SerialNumberCaja, mo.scanmacCaja, mo.scanimeiCaja, mo.ICCIDCaja,o.orden, mo.fecharegistro, c.caja,mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador join tbUnion_MoCaja u on u.id_modeloOrden = mo.id_modeloOrden where o.id_orden = " + orden.Id_orden + " order by mo.id_modeloOrden asc").Tables[0];
                dataGridView1.DataSource = con.LlenarDG("select mo.id_modeloOrden, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei,o.orden, mo.fecharegistro, c.caja,mo.turno from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja where o.id_orden = " + orden.Id_orden + " order by mo.id_modeloOrden asc").Tables[0];
                this.dataGridView1.Columns[0].Visible = false;


            }
            catch { MessageBox.Show("ERROR FATAL!", "no se encontro la base de datos!"); }


            txt_imei.Focus();
            this.ActiveControl = txt_imei;
        }
    }
}