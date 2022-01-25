using System;
using System.Reflection;
using System.Windows.Forms;

namespace DIGI_Sensor
{
    public partial class BatteryCheck : Form
    {
        Battery battery = new Battery();
        Operador operador = new Operador();
        Ensamble ensamble = new Ensamble();
        public BatteryCheck()
        {
            InitializeComponent();
        }

        private void BatteryCheck_Load(object sender, EventArgs e)
        {
            operador.Id_operador = int.Parse(operador.ReturnID("select id_operador from tb_Operador where numeroempleado = '" + operador.Numeroempleado + "'"));

            if (battery.Ensamble == "SMART-SENSOR")
            {
                pictureBox2.Image = DIGI_Sensor.Properties.Resources.smart_sensor;
                pictureBox1.Image = DIGI_Sensor.Properties.Resources._55001872_09;
            }
            else if (battery.Ensamble == "SMART-REPEATER")
            {
                pictureBox2.Image = DIGI_Sensor.Properties.Resources.smart_repeater;
                pictureBox1.Image = DIGI_Sensor.Properties.Resources._55001872_05;
            }
            else if (battery.Ensamble == "TEMP-SENSOR")
            {
                pictureBox2.Image = DIGI_Sensor.Properties.Resources.temp_sensor;
                pictureBox1.Image = DIGI_Sensor.Properties.Resources._55001872_08;
            }
            else if (battery.Ensamble == "SMART-HUMIDITY")
            {
                pictureBox2.Image = DIGI_Sensor.Properties.Resources.smart_humidity;
                pictureBox1.Image = DIGI_Sensor.Properties.Resources._55001872_07;
            }
            else if (battery.Ensamble == "SMART-LOGGER")
            {
                pictureBox2.Image = DIGI_Sensor.Properties.Resources.smart_logger;
                pictureBox1.Image = DIGI_Sensor.Properties.Resources._55001872_09;
            }

        }

        private void btn_Compare_Click(object sender, EventArgs e)
        {
            if (txt_SN.Text.Trim() == txt_SN2.Text.Trim())
            {
                pb_SN.Image = DIGI_Sensor.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
                btn_Submit.Focus();
            }
            else
                pb_SN.Image = DIGI_Sensor.Properties.Resources.images__1_;

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string newData = txt_Data.Text.Trim().Replace("Busy, please wait...", "");

            if (txt_Data.Text.Substring(0, 1) == "D" && txt_SN.Text.Substring(0, 1) == "D" && txt_SN2.Text.Substring(0, 1) == "D")
            {
                if (!string.IsNullOrEmpty(txt_SN.Text.Trim()) && !string.IsNullOrEmpty(txt_SN2.Text.Trim()) && !string.IsNullOrEmpty(txt_Data.Text.Trim()) && txt_SN.Text.Trim() == txt_SN2.Text.Trim())
                {
                    //battery.Crud("insert into tb_Batterys(sn, dateReg, Data, id_operador, id_ensamble) values('" + txt_SN2.Text.Trim() + "','" + DateTime.Now + "','" + txt_Data.Text.Trim() + "','" + operador.Id_operador + "','" + ensamble.Id_ensamble + "')");
                    battery.Crud("insert into tb_Batterys(sn, dateReg, Data, id_operador, id_ensamble) values('" + txt_SN2.Text.Trim() + "','" + DateTime.Now + "','" + newData.Trim() + "','" + operador.Id_operador + "','" + ensamble.Id_ensamble + "')"); ;
                    MessageBox.Show("Saved!");
                    txt_Data.Text = "";
                    txt_SN.Text = "";
                    txt_SN2.Text = "";
                    txt_SN.Focus();
                }
                else
                    MessageBox.Show("Error Data!");
            }
            else
                MessageBox.Show("Error Format!");



        }


        private void txt_SN2_Leave(object sender, EventArgs e)
        {
            if (txt_SN.Text.Trim() == txt_SN2.Text.Trim() && !string.IsNullOrEmpty(txt_SN.Text.Trim()) && !string.IsNullOrEmpty(txt_SN2.Text.Trim()))
            {
                pb_SN.Image = DIGI_Sensor.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
                //btn_Submit.Focus();
                webBrowser1.Focus();
            }
            else
            {
                pb_SN.Image = DIGI_Sensor.Properties.Resources.images__1_;
                webBrowser1.Focus();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_Battery rb = new Report_Battery();
            rb.Show();
        }

        private void txt_SN_Leave(object sender, EventArgs e)
        {
            txt_SN2.Text = "";
        }

        private void txt_SN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SN2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Data.Text = "";
            txt_SN.Text = "";
            txt_SN2.Text = "";
        }
    }
}
