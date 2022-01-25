using System;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class SetUps : Form
    {
        SetUp setup = new SetUp();
        Orden orden = new Orden();
        public SetUps()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!orden.Existe("select COUNT(*) from tb_SetUp where id_orden = '" + orden.Id_orden + "'"))
            {
                //setup.Crud("insert into tb_SetUp (serialnumber, serialnumberCaja, mac, macCaja, imei, imeiCaja, partnumber, partnumberCaja, iccid, iccidCaja, id_orden) values('" + txt_serial.Enabled + "','" + txt_serialCaja.Enabled + "','" + txt_mac.Enabled + "','" + txt_macCaja.Enabled + "','" + txt_imei.Enabled + "','" + txt_imeiCaja.Enabled + "','" + txt_parnumber.Enabled + "','" + txt_partnumberCaja.Enabled + "','" + txt_iccid.Enabled + "','" + txt_iccidCaja.Enabled + "'," + orden.Id_orden + ")");
                setup.Crud("insert into tb_SetUp (serialnumber, mac, imei, partnumber, id_orden) values('" + txt_serial.Enabled + "','" + txt_mac.Enabled + "','" + txt_imei.Enabled + "','" + txt_parnumber.Enabled + "','" + orden.Id_orden + "')");
                MessageBox.Show("Setup Realizado");
            }
            else
            {
                setup.Crud("update tb_SetUp set serialnumber = '" + txt_serial.Enabled + "', mac = '" + txt_mac.Enabled + "' , imei = '" + txt_imei.Enabled + "' , partnumber = '" + txt_parnumber.Enabled + "' where id_orden = " + orden.Id_orden);
                //setup.Crud("update tb_SetUp set serialnumber = '" + txt_serial.Enabled + "', serialnumberCaja = 'False', mac = '" + txt_mac.Enabled + "' , macCaja = 'False' , imei = '" + txt_imei.Enabled + "' , imeiCaja = 'False' , qr = '" + txt_qr.Enabled + "' , qrCaja = 'False' , partnumber = '" + txt_parnumber.Enabled + "' , partnumberCaja = 'False' , iccid = '" + txt_iccid.Enabled + "' , iccidCaja = 'False' where id_orden = " + orden.Id_orden);
                MessageBox.Show("Setup Actualizado");
            }
            SetUps_Load(sender, e);
        }

        private void SetUps_Load(object sender, EventArgs e)
        {
            orden.Id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden = '" + orden.Ordenes + "'"));
            lbl_orden.Text = orden.Ordenes.ToString();
            //Temp();

            if (!orden.Existe("select COUNT(*) from tb_SetUp where id_orden = '" + orden.Id_orden + "'"))
                lbl_Tipo.Text = "Nueva Orden";
            else
                lbl_Tipo.Text = "Modificar Orden";


        }


        private void Ckb_imieU_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_imieU.Checked == true)
                txt_imei.Enabled = false;
            if (ckb_imieU.Checked == false)
                txt_imei.Enabled = true;
        }

        private void Ckb_macU_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_macU.Checked == true)
                txt_mac.Enabled = false;
            if (ckb_macU.Checked == false)
                txt_mac.Enabled = true;
        }

        private void Ckb_serialU_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_serialU.Checked == true)
                txt_serial.Enabled = false;
            if (ckb_serialU.Checked == false)
                txt_serial.Enabled = true;
        }



        private void Ckb_partnumberU_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_partnumberU.Checked == true)
                txt_parnumber.Enabled = false;
            if (ckb_partnumberU.Checked == false)
                txt_parnumber.Enabled = true;
        }

    }
}
