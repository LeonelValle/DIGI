using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IX30_Project
{
    public partial class Reprint : Form
    {
        Device device = new Device();
        PN pn = new PN();


        public Reprint()
        {
            InitializeComponent();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow row in this.dg_Reprint.Rows)
            {
                // if a cell has never choosed so it is null 
                if ((row.Cells[0].Value) == null)
                    continue;

                if (((bool)row.Cells[0].Value == true))
                {

                    list.Add(row.Cells[2].Value.ToString());


                    device.id_device = int.Parse(row.Cells[1].Value.ToString());
                    device.serialno = row.Cells[2].Value.ToString();
                    device.macaddress1 = row.Cells[3].Value.ToString();
                    device.deviceID = row.Cells[4].Value.ToString();
                    device.password = row.Cells[5].Value.ToString();
                    device.qr = row.Cells[6].Value.ToString();
                    device.imei = row.Cells[7].Value.ToString();
                    pn.Pn = row.Cells[8].Value.ToString();
                    pn.Sku = row.Cells[9].Value.ToString();
                    DefaultPrinter();
                }
            }
            MessageBox.Show("Printed!");
        }

        private void DefaultPrinter()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                LabelFormatDocument format = engine.ActiveDocument;

                if (pn.Sku == "IX30-00P7")
                {
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\IX30\IX30-00P7.btw");
                    pn.Pn += "-01-02";
                    pn.Sku += "-0";
                }
                else
                {
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\IX30\IX30-00G4.btw");
                    pn.Pn += "-01-03";
                    pn.Sku += "-1";
                }


                format.PrintSetup.PrinterName = @"Zebra ZT420";

                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";


                format.SubStrings["IMEI"].Value = device.imei.Substring(0, 15);
                format.SubStrings["MAC"].Value = device.macaddress1;
                format.SubStrings["PASSWORD"].Value = device.password;
                format.SubStrings["PN"].Value = pn.Pn;
                format.SubStrings["QR"].Value = device.qr;
                format.SubStrings["SKU"].Value = pn.Sku;
                format.SubStrings["SN"].Value = device.serialno;

                format.Print();


                engine.Stop();

            }
        }

        private void Reprint_Load(object sender, EventArgs e)
        {
            dg_Reprint.DataSource = device.LlenarDG("select id_device, serialno, macaddress1, deviceID, password, qr, imei, tb_Ensamble.ensamble, tb_Ensamble.descripcion from device join tb_Ensamble on tb_Ensamble.id_ensamble = device.id_pn").Tables[0];
        }
    }
}
