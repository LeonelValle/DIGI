using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Seagull.BarTender.Print;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IX30_Project
{
    public partial class Generate : Form
    {
        //string password = "", salt = "", version = "";
        string hexValue1 = "", hexValue2 = "";
        int consecutive1 = 0, consecutive2 = 0;
        Config config = new Config();
        Device device = new Device();
        PN pn = new PN();

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = device.LlenarDG("select * from device").Tables[0];
            cb_pn.DataSource = pn.LlenarComboBox("select id_ensamble, ensamble from tb_Ensamble where tested = 'IX30'");
            cb_pn.DisplayMember = "ensamble";
            cb_pn.ValueMember = "id_ensamble";
            cb_pn.SelectedIndex = -1;

            //device.imei = "356052100054940";
            //pn.Sku = "ASB-IX30-00P7-00";
            pn.ShortSku = "";

        }

        public Generate()
        {
            InitializeComponent();
        }

        public int Asc(string String)
        {
            if (String == null || String.Length == 0)
                throw new ArgumentException(Utils.GetResourceString("Argument_LengthGTZero1", new string[1]
                {
      "String"
                }));
            return Strings.Asc(String[0]);
        }

        private string WeekNumber()
        {

            var d = DateTime.Now;
            CultureInfo cul = CultureInfo.CurrentCulture;


            int weekNum = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);
            weekNum--;

            return weekNum.ToString().PadLeft(2, '0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_pn.Text != "")
            {
                if (!string.IsNullOrEmpty(txt_IMEI.Text.Trim()))
                {

                    device.imei = txt_IMEI.Text;
                    BuildSerialNomber();
                    BuildMacAddress();
                    BuilDeviceID();

                    SendInfoToEncode();

                    BuildQR();


                    device.Crud("insert into device values('" + device.serialno + "','" + device.mac1 + "','" + device.macaddress1 + "','" + device.mac2 + "','" + device.macaddress2 + "','" + device.deviceID + "','" + device.password + "','" + device.salt + "','" + device.version + "','" + device.qr + "','" + device.imei + "','" + cb_pn.SelectedValue + "')");

                    //textBox1.Text = device.macaddress1;
                    //textBox2.Text = device.macaddress2;

                    dataGridView1.DataSource = device.LlenarDG("select * from device").Tables[0];

                    Printlabel();

                    txt_IMEI.Text = "";
                }
                else
                {
                    MessageBox.Show("Scan IMEI module");
                    lbl.Focus();
                }
            }
            else
            {
                MessageBox.Show("Select a Part N#");
            }
        }


        private void ReturnConsecutiveHex()
        {

            //consecutive1 = int.Parse(config.ReturnValue("select hex_consecutive from config where id_pn = '" + cb_pn.SelectedValue + "'"));
            consecutive1 = int.Parse(config.ReturnValue("SELECT hex_consecutive FROM ConfiguracionSistema where id_cs = 4"));
            consecutive2 = consecutive1 + 1;

            config.Crud("update ConfiguracionSistema set hex_consecutive = '" + (consecutive2 + 1) + "' where id_cs = 4");

            // Convert integer 182 as a hex in a string variable
            hexValue1 = string.Format("{0:0000}", consecutive1.ToString("X"));
            hexValue2 = string.Format("{0:0000}", consecutive2.ToString("X"));


        }

        private void GetFromEncode(string info)
        {

            string[] strings = Regex.Split(info, Environment.NewLine);

            device.salt = strings[1].Substring(6).Trim();
            device.version = strings[2].Substring(8).Trim();
            device.password = strings[3].Substring(9).Trim();

        }

        private void SendInfoToEncode()
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = @"C:\Users\leonel.valle\Desktop\Labels_IX30\96016761 Rev B(1)\encode.exe",
                    FileName = @"\\mex-app-001\MEI_Apps\IX30_Setup\96016761 Rev B(1)\encode.exe",
                    Arguments = device.deviceID,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadToEnd();

                GetFromEncode(line);
                // do something with line
                //textBox1.Text = password + "\r\n" + salt + "\r\n" + version;
            }
        }

        private void BuildMacAddress()
        {
            ReturnConsecutiveHex();
            //config.macHead = config.ReturnValue("select macHead from config where id_pn = '" + cb_pn.SelectedValue + "'");
            config.macHead = config.ReturnValue("SELECT macHead FROM ConfiguracionSistema where id_cs = 4");
            device.mac1 = config.macHead + hexValue1.PadLeft(4, '0');
            device.mac2 = config.macHead + hexValue2.PadLeft(4, '0');

            var regex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
            var replace = "$1:$2:$3:$4:$5:$6";
            var mc1 = Regex.Replace(device.mac1, regex, replace);
            var mc2 = Regex.Replace(device.mac2, regex, replace);

            device.macaddress1 = mc1;
            device.macaddress2 = mc2;

        }

        private void BuildSerialNomber()
        {

            device.serialno = pn.ReturnValue("select code from config where id_pn = '" + cb_pn.SelectedValue + "'") + config.ReturnValue("select consecutivo from ConfiguracionSistema where id_cs = 4").PadLeft(4, '0') + DateTime.Now.ToString(WeekNumber() + "yy") + "00";


            int checksum = 0;


            for (int i = 1; i <= device.serialno.Length; i++)
                checksum = ((checksum * 10) + (Asc(Strings.Mid(device.serialno, i, 1)) - 48)) % 97;
            checksum = 98 - checksum;


            device.serialno = device.serialno.Substring(0, device.serialno.Length - 2);
            device.serialno = device.serialno + checksum.ToString().PadLeft(2, '0');

            //config.Crud("update config set serial_consecutive = '" + (int.Parse(config.ReturnValue("select serial_consecutive from config where id_pn = '" + cb_pn.SelectedValue + "'")) + 1) + "' where id_pn = '" + cb_pn.SelectedValue + "'");
            config.Crud("update ConfiguracionSistema set consecutivo = '" + (int.Parse(config.ReturnValue("select consecutivo from ConfiguracionSistema where id_cs = 4")) + 1) + "' where id_cs = 4");
        }


        private void BuilDeviceID()
        {
            //var regex = "(.{8})(.{8})(.{8})(.{8})";
            //var replace = "$1-$2-$3-$4";
            device.deviceID = "0000000000000000" + Strings.Mid(device.mac1, 1, 6) + "FFFF" + Strings.Mid(device.mac1, 7, 6).PadLeft(6, '0');

            //device.deviceID = Regex.Replace(device.deviceID, regex, replace);

        }

        private void cb_pn_SelectedIndexChanged(object sender, EventArgs e)
        {
            pn.ShortSku = pn.ReturnValue("select descripcion from tb_Ensamble where id_ensamble = " + cb_pn.SelectedValue);
            pn.Revision = pn.ReturnValue("select revision from config where id_pn = " + cb_pn.SelectedValue);
            //pn.Asb = pn.ReturnValue("select asb from pn where id_pn = " + cb_pn.SelectedValue);
            pn.Asb = "ASB";


            pn.Sku = pn.Asb + "-" + pn.ShortSku + "-" + pn.Revision;

        }

        private void link_reprint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reprint re = new Reprint();
            re.Show();
        }

        private void BuildQR()
        {
            pn.Pn = pn.ReturnValue("select ensamble from tb_Ensamble where id_ensamble = '" + cb_pn.SelectedValue + "'");
            pn.Description = pn.ReturnValue("select descripcion from tb_Ensamble where id_ensamble = '" + cb_pn.SelectedValue + "'");
            //device.qr = "Digi IX30" + pn.Description + ";" + device.deviceID + ";" + device.password + ";" + device.serialno + ";" + pn.Pn;
            device.qr = "Digi " + pn.ReturnValue("select model from config where id_pn = '" + cb_pn.SelectedValue + "'") + ";" + device.deviceID + ";" + device.password + ";" + device.serialno + ";" + pn.Pn + device.ReturnValue("select rev from config where id_pn = '" + cb_pn.SelectedValue + "'");



            //textBox1.Text = device.qr;
        }

        private void Printlabel()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                LabelFormatDocument format = engine.ActiveDocument;

                if (cb_pn.Text == "50002069")
                {
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\IX30\IX30-00P7.btw");
                    pn.Pn += "-01-02";
                    pn.ShortSku = pn.ReturnValue("select descripcion from tb_Ensamble where id_ensamble = " + cb_pn.SelectedValue) + pn.ReturnValue("select sku_rev from config where id_pn = " + cb_pn.SelectedValue);

                    //pn.ShortSku += "-00";
                }
                else
                {
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\IX30\IX30-00G4.btw");
                    pn.Pn += "-01-03";
                    //pn.ShortSku += "-01";
                    pn.ShortSku = pn.ReturnValue("select descripcion from tb_Ensamble where id_ensamble = " + cb_pn.SelectedValue) + pn.ReturnValue("select sku_rev from config where id_pn = " + cb_pn.SelectedValue);

                }


                //format.PrintSetup.PrinterName = @"Zebra ZT420";

                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";


                format.SubStrings["IMEI"].Value = device.imei.Substring(0, 15);
                format.SubStrings["MAC"].Value = device.macaddress1;
                format.SubStrings["PASSWORD"].Value = device.password;
                format.SubStrings["PN"].Value = pn.Pn;
                format.SubStrings["QR"].Value = device.qr;
                format.SubStrings["SKU"].Value = pn.ShortSku;
                format.SubStrings["SN"].Value = device.serialno;

                format.Print();


                engine.Stop();

            }
        }
    }
}
