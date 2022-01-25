using System;
using System.Windows.Forms;

namespace DIGI_Sensor3test
{
    public partial class Check_Test : Form
    {
        RF rf = new RF();
        Current current = new Current();
        Nist nist = new Nist();
        Test test = new Test();
        Operador operador = new Operador();

        public Check_Test()
        {
            InitializeComponent();
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            rf.Status = rf.ReturnValue("select TOP 1 status from Test_RF where Serialnumber ='" + txt_Serialnumber.Text + "' order by id_rf desc");
            current.Status = current.ReturnValue("select TOP 1 status from Test_Current where Serialnumber ='" + txt_Serialnumber.Text + "' order by id_current desc");
            nist.Status = nist.ReturnValue("select TOP 1 status from Test_Nist where Serialnumber ='" + txt_Serialnumber.Text + "' order by id_nist desc");
            //coldSoak.Status = coldSoak.ReturnValue("select TOP 1 status from Test_coldsoak where Serialnumber ='" + txt_Serialnumber.Text + "' order by Datestarted,RegDate desc");

            #region if para ver si pasaron las pruebas
            if (rf.Status == "Passed")
            {
                pb_rf.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
                rf.Rf = true;
            }
            else
            {
                pb_rf.Image = DIGI_Sensor3test.Properties.Resources.images__1_;
                rf.Rf = false;
            }
            if (current.Status == "Passed" || current.Status == "PASS")
            {
                pb_current.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
                current.CURRENT1 = true;
            }
            else
            {
                pb_current.Image = DIGI_Sensor3test.Properties.Resources.images__1_;
                current.CURRENT1 = false;
            }
            if (nist.Status == "Passed")
            {
                pb_nist.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
                nist.Nists = true;
            }
            else
            {
                pb_nist.Image = DIGI_Sensor3test.Properties.Resources.images__1_;
                nist.Nists = false;

            }

            #endregion

            #region if para cambiar las imagenes y mostrar los mensajes de alerta
            if (rf.Rf == true && current.CURRENT1 == true && nist.Nists == true)
            {
                txt_Serialnumber.Text = "";
                txt_Serialnumber.Focus();
            }
            else if (rf.Rf != true)
            {
                MessageBox.Show("Falla de RF", "Falla", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (current.CURRENT1 != true)
            {
                MessageBox.Show("Falla de Current", "Falla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nist.Nists != true)
            {
                MessageBox.Show("Falla de NIST", "Falla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (coldSoak.COLDSOAK1 != true)
            //{
            //    GetStatus();
            //    MessageBox.Show("Falla de Cold Soak /n Failed Type: " + coldSoak.Status, "Falla", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}

            #endregion


            if (rf.Rf == false || current.CURRENT1 == false || nist.Nists == false)
            {
                //test.Crud("insert into Log_Test values('Fail', '" + txt_Serialnumber.Text + "','" + DateTime.Now + "','" + operador.Id_operador + "')");
                test.Crud("insert into Log_Test(RF, Curr, Nist, sn, TestDate, id_nemploy) values('" + rf.Status + "','" + current.Status + "','" + nist.Status + "','" + txt_Serialnumber.Text + "','" + DateTime.Now + "','" + operador.Id_operador + "')");

            }
            else
            {
                test.Crud("insert into Log_Test(RF, Curr, Nist, sn, TestDate, id_nemploy) values('" + rf.Status + "','" + current.Status + "','" + nist.Status + "','" + txt_Serialnumber.Text + "','" + DateTime.Now + "','" + operador.Id_operador + "')");
            }

        }

        private void GetStatus()
        {
            //coldSoak.Status = coldSoak.ReturnValue("select status from Test_coldsoak where Serialnumber = '" + txt_Serialnumber.Text + "'");
        }


        private void Check_Test_Load(object sender, EventArgs e)
        {
            operador.Id_operador = int.Parse(operador.ReturnID("select id_operador from tb_Operador where numeroempleado = '" + operador.Numeroempleado + "'"));

            pb_rf.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
            pb_nist.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
            pb_current.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
            //pb_coldsoak.Image = DIGI_Sensor3test.Properties.Resources._69_692608_transparent_answer_icon_png_check_pass_icon_png;
        }

        private void btn_Check_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void btn_Check_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
