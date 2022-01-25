using System;
using System.Windows.Forms;

namespace DIGI_Sensor
{
    public partial class CheckingBox : Form
    {
        Caja caja = new Caja();
        Test test = new Test();
        public CheckingBox()
        {
            InitializeComponent();
        }

        private void CheckingBox_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Box.Text) || !string.IsNullOrEmpty(txt_CompareBox.Text) || !string.IsNullOrEmpty(txt_SN.Text))
            {

                if (txt_Box.Enabled == true || CheckTest() == 1 || CheckTest() == 0)
                {

                    if (txt_Box.Enabled == true)
                    {
                        //txt_Box.Enabled = true;

                        txt_Box.Enabled = false;
                        txt_SN.Enabled = true;
                        txt_SN.Focus();
                    }
                    else if (txt_Box.Enabled == false)
                    {
                        txt_Box.Enabled = false;
                        txt_SN.Focus();

                        caja.Cajas = caja.ReturnValue("select caja from tb_caja c join tb_ModeloOrden mo on mo.id_caja = c.id_caja where mo.Serialnumber = '" + txt_SN.Text + "'");
                        txt_CompareBox.Text = caja.Cajas;
                    }

                    if (!string.IsNullOrEmpty(txt_CompareBox.Text))
                    {
                        if (txt_Box.Text.Trim() == txt_CompareBox.Text.Trim())
                        {
                            caja.Crud("update tb_ModeloOrden set VerifyBox = 1 where Serialnumber = '" + txt_SN.Text.Trim() + "'");
                            pb_Box.Image = DIGI_Sensor.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
                            txt_SN.Focus();
                        }
                        else
                        {
                            pb_Box.Image = DIGI_Sensor.Properties.Resources.images__1_;
                            MessageBox.Show("Box not match!", "FAIL!");
                        }

                    }
                }
                else
                {
                    txt_SN.Focus();
                    txt_SN.SelectAll();
                    MessageBox.Show("Fail Test!!!", "FAIL!");
                }
            }
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

            test.Rf = test.ReturnValue("select TOP 1 status from Test_RF where Serialnumber ='" + txt_SN.Text + "' order by id_rf desc");
            test.Current = test.ReturnValue("select TOP 1 status from Test_Current where Serialnumber ='" + txt_SN.Text + "' order by id_current desc");
            test.Nist = test.ReturnValue("select TOP 1 status from Test_Nist where Serialnumber ='" + txt_SN.Text + "' order by id_nist desc");
            test.Coldsoak = test.ReturnValue("select TOP 1 status from Test_coldsoak where Serialnumber ='" + txt_SN.Text + "' order by id_coldsoak desc");

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

        private void btn_NewBox_Click(object sender, EventArgs e)
        {
            txt_CompareBox.Text = "";
            txt_SN.Text = "";
            txt_SN.Enabled = false;
            txt_Box.Text = "";
            txt_Box.Enabled = true;
            txt_Box.Focus();
        }

        private void btn_Submit_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }
    }
}
