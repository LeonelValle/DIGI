using MWTrace_beta;
using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace DIGITrace
{
    public partial class Scan_IX30 : Form
    {
        Orden wo = new Orden();
        Ensamble pn = new Ensamble();
        Device device = new Device();
        Caja box = new Caja();
        Config config = new Config();
        Operador operador = new Operador();

        public Scan_IX30()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_serial.Text.Trim()))
            {
                if (device.Existe("select count(*) from device where serialno = '" + txt_serial.Text.Trim() + "'"))
                {
                    device.id_device = int.Parse(device.ReturnID("select id_device from device where serialno = '" + txt_serial.Text.Trim() + "'"));

                    if (!device.Existe("select count(*) from ix30 where id_device = " + device.id_device))
                    {

                        device.Crud("insert into ix30 (dateScan, id_device, id_wo, id_box) values('" + DateTime.Now + "','" + device.id_device + "','" + wo.Id_orden + "','" + box.Id_caja + "')");

                        box.Oldid = box.Id_caja;


                        BoxPacking();

                        txt_serial.Text = "";
                        txt_serial.Focus();

                        IX30_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Already Scan!");
                        txt_serial.Text = "";
                        txt_serial.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Not Exist!");
                    txt_serial.Text = "";
                    txt_serial.Focus();
                }
            }
            else
                MessageBox.Show("Empty field!");
        }

        private void IX30_Load(object sender, EventArgs e)
        {
            string constring = config.Con1.ConnectionString;


            wo.Id_orden = int.Parse(wo.ReturnID("select id_orden from tb_Orden where orden ='" + wo.Ordenes + "'"));

            pn.Id_ensamble = int.Parse(pn.ReturnID("select e.id_ensamble from tb_Ensamble e join tb_Orden o on e.id_ensamble = o.id_ensamble where o.id_orden = '" + wo.Id_orden + "'"));

            config.BoxTop = int.Parse(config.ReturnValue("select boxTop from config where id_pn = '" + pn.Id_ensamble + "'"));


            lbl_ensamble.Text = pn.ReturnValue("select ensamble from tb_Ensamble where id_ensamble = " + pn.Id_ensamble);
            lbl_numeroempleado.Text = operador.ReturnValue("select numeroempleado from tb_Operador where id_operador = " + operador.Id_operador);
            lbl_wo.Text = wo.ReturnValue("select orden from tb_Orden where id_orden = " + wo.Id_orden);

            BoxPacking();

            dataGridView1.DataSource = device.LlenarDG("select device.serialno, device.macaddress1, device.imei, box.box from ix30 join device on ix30.id_device = device.id_device join tb_Orden o on o.id_orden = ix30.id_wo join box on box.id_box = ix30.id_box where o.id_orden = " + wo.Id_orden).Tables[0];

            //GetCustomers();
            //PrintBox();
        }

        private void BoxPacking()
        {
            //config.BoxTop = int.Parse(config.ReturnValue("select boxTop from config where id_pn = '" + pn.Id_ensamble + "'"));
            box.Id_caja = int.Parse(wo.ReturnID("select id_box from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
            box.Count = int.Parse(device.ReturnValue("select count(*) from ix30 where id_box = '" + box.Id_caja + "'"));


            if (box.Id_caja == 0)
            {
                box.Cajas = int.Parse(box.ReturnValue("select countBox from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
                box.Cajas = (box.Cajas + 1);
                box.Crud("update tb_Orden set countBox = '" + box.Cajas + "' where id_orden = '" + wo.Id_orden + "'");
                box.Cajas = int.Parse(box.ReturnValue("select countBox from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
                box.Id_caja = int.Parse(box.ReturnID("insert into box (box) values ('" + box.Cajas + "'); SELECT SCOPE_IDENTITY();"));
                wo.Crud("update tb_Orden set id_box = '" + box.Id_caja + "' where id_orden = " + wo.Id_orden);
                box.Parcial = false;

            }
            if (box.Count == config.BoxTop)
            {
                this.btn_Submit.Enabled = false;
                box.Cajas = int.Parse(box.ReturnValue("select countBox from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
                box.Cajas = (box.Cajas + 1);
                box.Crud("update tb_Orden set countBox = '" + box.Cajas + "' where id_orden = '" + wo.Id_orden + "'");
                box.Cajas = int.Parse(box.ReturnValue("select countBox from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
                box.Id_caja = int.Parse(box.ReturnID("insert into box (box) values ('" + box.Cajas + "'); SELECT SCOPE_IDENTITY();"));
                wo.Crud("update tb_Orden set id_box = '" + box.Id_caja + "' where id_orden = " + wo.Id_orden);
                box.Parcial = false;
                try
                {
                    Thread threadInput = new Thread(DisplayData);
                    threadInput.Start();

                    //SerialNumber_Load(sender, e);
                    //txt_Qty.Text = "";
                }
                catch (Exception ex)
                {

                    DisplayError(ex);
                }
            }
        }


        private void PrintBox()
        {

            using (Engine engine = new Engine())
            {
                engine.Start();
                LabelFormatDocument format = engine.Documents.Open(@"\\192.168.1.4\bartender_labels$\IX30\95022739.btw");


                format.PrintSetup.PrinterName = @"Zebra ZT420 (300 dpi)";
                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";


                format.PrintSetup.NumberOfSerializedLabels = 1;



                format.SubStrings["SN1"].Value = GetCustomers()[0].serialno;
                format.SubStrings["IMEI1"].Value = GetCustomers()[0].imei;
                format.SubStrings["MAC1"].Value = GetCustomers()[0].macaddress1;

                format.SubStrings["SN2"].Value = GetCustomers()[1].serialno;
                format.SubStrings["IMEI2"].Value = GetCustomers()[1].imei;
                format.SubStrings["MAC2"].Value = GetCustomers()[1].macaddress1;

                format.SubStrings["SN3"].Value = GetCustomers()[2].serialno;
                format.SubStrings["IMEI3"].Value = GetCustomers()[2].imei;
                format.SubStrings["MAC3"].Value = GetCustomers()[2].macaddress1;

                format.SubStrings["SN4"].Value = GetCustomers()[3].serialno;
                format.SubStrings["IMEI4"].Value = GetCustomers()[3].imei;
                format.SubStrings["MAC4"].Value = GetCustomers()[3].macaddress1;

                format.SubStrings["SN5"].Value = GetCustomers()[4].serialno;
                format.SubStrings["IMEI5"].Value = GetCustomers()[4].imei;
                format.SubStrings["MAC5"].Value = GetCustomers()[4].macaddress1;


                format.Print();


                engine.Stop();



            }
            btn_Submit.Invoke((Action)delegate
            {
                btn_Submit.Enabled = true;
            });
        }

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show("The below error occurred while processing the request: \n\r \n\r" + ex.Message);
        }
        private void DisplayData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(4000);


            PrintBox();

            SetLoading(false);
        }

        private List<Device> GetCustomers()
        {

            using (SqlCommand cmd = new SqlCommand("select device.serialno, device.macaddress1, device.imei from ix30 join device on ix30.id_device = device.id_device where ix30.id_box = " + box.Oldid, config.Con1))
            {
                List<Device> customers = new List<Device>();
                cmd.CommandType = CommandType.Text;
                config.Abrir();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new Device
                        {
                            serialno = sdr["serialno"].ToString(),
                            macaddress1 = sdr["macaddress1"].ToString(),
                            imei = sdr["imei"].ToString().Substring(0, 15)
                        });
                    }
                    for (int i = 0; i < (5 - (sdr.FieldCount - 1)); i++)
                    {
                        customers.Add(new Device
                        {
                            serialno = "",
                            macaddress1 = "",
                            imei = ""
                        });
                    }

                }
                config.Cerrar();
                return customers;
            }

        }

        private void btn_PrintParcial_Click(object sender, EventArgs e)
        {
            box.Oldid = box.Id_caja;
            try
            {
                Thread threadInput = new Thread(DisplayData);
                threadInput.Start();

                //SerialNumber_Load(sender, e);
                //txt_Qty.Text = "";
            }
            catch (Exception ex)
            {

                DisplayError(ex);
            }
            this.btn_Submit.Enabled = false;
            box.Cajas = int.Parse(box.ReturnValue("select countBox from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
            box.Cajas = (box.Cajas + 1);
            box.Crud("update tb_Orden set countBox = '" + box.Cajas + "' where id_orden = '" + wo.Id_orden + "'");
            box.Cajas = int.Parse(box.ReturnValue("select countBox from tb_Orden where id_orden = '" + wo.Id_orden + "'"));
            box.Id_caja = int.Parse(box.ReturnID("insert into box (box) values ('" + box.Cajas + "'); SELECT SCOPE_IDENTITY();"));
            wo.Crud("update tb_Orden set id_box = '" + box.Id_caja + "' where id_orden = " + wo.Id_orden);
            box.Parcial = false;
        }
    }
}
