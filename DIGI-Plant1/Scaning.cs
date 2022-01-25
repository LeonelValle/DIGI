using System;
using System.Windows.Forms;

namespace DIGI_Plant1
{
    public partial class Scaning : Form
    {
        WorkOrder wo = new WorkOrder();
        Scan scan = new Scan();
        User user = new User();
        PN pn = new PN();
        public Scaning()
        {
            InitializeComponent();
        }
        private void Scaning_Load(object sender, EventArgs e)
        {
            dg_Scan.DataSource = scan.LlenarDG("select sn, dateReg, pn.pn, wo.rev from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where wo.id_wo = '" + wo.Id_wo + "'").Tables[0];

            lbl_Employ.Text = user.ReturnValue("select idemp from tb_User where id_user = '" + user.Id_user + "'");
            lbl_WO.Text = user.ReturnValue("select wo from tb_WO where id_wo = '" + wo.Id_wo + "'");
            lbl_Records.Text = scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'");

            txt_Scan.Focus();

            if (int.Parse(scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'")) >= int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "'")))
            {
                txt_Scan.Enabled = false;
                MessageBox.Show("WO COMPLETED!");
            }

            pn.Tested = pn.ReturnValue("select pn.pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where wo.id_wo = '" + wo.Id_wo + "'");

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (pn.Tested != "55001872-XXR" || ValidateOldSmart() == false)
            {
                if (int.Parse(scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'")) >= int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "'")))
                {
                    txt_Scan.Enabled = false;
                    MessageBox.Show("WO COMPLETED!");
                }
                else
                {
                    if (!string.IsNullOrEmpty(txt_Scan.Text))
                    {
                        if (!scan.Existe("select count(*) from tb_Scan where sn = '" + txt_Scan.Text + "'"))
                        {
                            scan.Crud("insert into tb_Scan values('" + txt_Scan.Text.Trim() + "','" + DateTime.Now + "','" + wo.Id_wo + "','" + user.Id_user + "')"); ;
                            txt_Scan.Text = "";
                            txt_Scan.Focus();
                            Scaning_Load(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("This unit already exist!");
                            txt_Scan.Text = "";
                            txt_Scan.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insert an unit!");
                        txt_Scan.Focus();
                    }
                }

            }
            else
            {
                MessageBox.Show("El Serial es menor a D347XXX !","Error!");
                txt_Scan.Text = "";
                txt_Scan.Focus();
            }
        }

        private bool ValidateOldSmart()
        {
            bool old = true;
            int n;
            string sn = txt_Scan.Text.Trim().Substring(1, txt_Scan.Text.Trim().Length - 1);
            bool isNumeric = int.TryParse(sn, out n);
            //txt_serial.Text.Trim().Length-1;
            if (isNumeric == true)
            {
                if (int.Parse(txt_Scan.Text.Trim().Substring(1, txt_Scan.Text.Trim().Length - 1)) >= 340000)
                {
                    old = false;
                }
            }
            else
                MessageBox.Show("Error de formato!");

            return old;
        }

        private void btn_Submit_Enter(object sender, EventArgs e) =>
            SendKeys.Send("{ENTER}");

    }
}
