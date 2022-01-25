using System;
using System.Windows.Forms;

namespace DIGI_WR11_XGI
{
    public partial class Scaning : Form
    {
        WorkOrder wo = new WorkOrder();
        Scan scan = new Scan();
        Operador user = new Operador();
        PN pn = new PN();
        SerialNumber sn = new SerialNumber();

        public Scaning()
        {
            InitializeComponent();
        }
        private void Scaning_Load(object sender, EventArgs e)
        {

            //lbl_Employ.Text = user.ReturnValue("select idemp from tb_User where id_user = '" + user.Id_user + "'");
            lbl_Employ.Text = user.Idemp.ToString();
            user.Id_user = int.Parse(user.ReturnID("select id_user from tb_User where idemp ='" + user.Idemp + "'"));
            lbl_WO.Text = user.ReturnValue("select wo from tb_WO where id_wo = '" + wo.Id_wo + "'");
            lbl_Records.Text = scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'");
            lbl_ensamble.Text = wo.ReturnValue("select pn.pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where wo.id_wo = " + wo.Id_wo);

            txt_ScanTablero.Focus();

            wo.rev = wo.ReturnValue("select rev from tb_WO where id_wo = '" + wo.Id_wo + "'");

            if (int.Parse(scan.ReturnValue("select count(*) from tb_Scan where id_wo = '" + wo.Id_wo + "'")) >= int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "'")))
            {
                txt_ScanTablero.Enabled = false;
                MessageBox.Show("WO COMPLETED!");
            }

            //pn.Tested = pn.ReturnValue("select pn.pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where wo.id_wo = '" + wo.Id_wo + "'");

            dg_Scan.DataSource = scan.LlenarDG("select mac as 'MAC', pcb as 'PCBA IMEI', sn as 'Serial Number', dateReg, pn.pn, wo.rev from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where wo.id_wo = '" + wo.Id_wo + "'").Tables[0];

            gb_EtiquetaCaja.Visible = false;
            gb_EtiquetaSuelta.Visible = false;
            gb_EtiquetaCover.Visible = true;
            gb_PCBA.Visible = true;
            btn_Submit2.Visible = false;

            if (lbl_ensamble.Text.Substring(0, 3) == "XGI")
            {
                //Todos los Textbox de MAC seran usados como EUI64.
                pn.identify = bool.Parse(pn.ReturnValue("select pn.identify from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where wo.id_wo = " + wo.Id_wo));
                lbl_macCaja.Text = "SCAN EUI64";
                lbl_macCover.Text = "SCAN EUI64";
                lbl_macSuelta.Text = "SCAN EUI64";

                if (pn.identify == true)
                {

                    txt_ScanSN.Visible = false;
                    lbl_snPCBA.Visible = false;
                }
                else
                {
                    txt_eui64.Visible = true;
                    lbl_eui64.Visible = true;
                    txt_MACSuelta.Visible = true;
                    lbl_macCover.Visible = true;
                    txt_MACEtiqueta.Visible = true;
                    lbl_macSuelta.Visible = true;

                    txt_IMEIEtiqueta.Visible = false;
                    lbl_imeiEtiqueta.Visible = false;

                    txt_ScanTablero.Visible = false;
                    lbl_imeiPCBA.Visible = false;

                    txt_MACCaja.Visible = false;
                    lbl_macCaja.Visible = false;

                    txt_ScanSN.Visible = false;
                    lbl_snPCBA.Visible = false;

                    txt_IMEISuelta.Visible = false;
                    txt_IMEICaja.Visible = false;
                    lbl_imeiCajas.Visible = false;
                    lbl_imeiSuelta.Visible = false;
                }

                dg_Scan.DataSource = scan.LlenarDG("select eui64 as 'EUI64',pcb as 'PCBA IMEI', sn as 'Serial Number', dateReg, pn.pn, wo.rev from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where wo.id_wo = '" + wo.Id_wo + "'").Tables[0];

            }
            else
            {
                txt_eui64.Visible = false;
                lbl_eui64.Visible = false;
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txt_ScanSN.Text.Trim()) || !string.IsNullOrEmpty(txt_ScanTablero.Text.Trim()) || !string.IsNullOrEmpty(txt_eui64.Text.Trim()) || !string.IsNullOrEmpty(txt_IMEIEtiqueta.Text.Trim()) ||
                !string.IsNullOrEmpty(txt_MACEtiqueta.Text.Trim()) || !string.IsNullOrEmpty(txt_SNEtiqueta.Text.Trim()))
            {
                if (lbl_ensamble.Text.Substring(0, 4) != "WR11" || txt_ScanTablero.Text.Substring(0, 2) == "35" && Check1WR11() == true)
                {
                    if (lbl_ensamble.Text.Substring(0, 3) != "XGI" || txt_eui64.Text.Substring(0, 2) == "00" && Check1XGI() == true)
                    {
                        if (lbl_ensamble.Text.Substring(0, 4) != "WR11" || !scan.Existe("select count(*) from tb_Scan where sn = '" + txt_ScanSN.Text.Trim() + "'") && !scan.Existe("select count(*) from tb_Scan where pcb = '" + txt_ScanTablero.Text.Trim() + "'") && !scan.Existe("select count(*) from tb_Scan where mac = '" + txt_MACEtiqueta.Text.Trim() + "'"))
                        {
                            if (lbl_ensamble.Text.Substring(0, 3) != "XGI" || !scan.Existe("select count(*) from tb_Scan where sn = '" + txt_SNEtiqueta.Text.Trim() + "'") && !scan.Existe("select count(*) from tb_Scan where eui64 = '" + txt_eui64.Text.Trim() + "'"))
                            {


                                gb_EtiquetaCaja.Visible = true;
                                gb_EtiquetaSuelta.Visible = true;
                                gb_EtiquetaCover.Visible = false;
                                gb_PCBA.Visible = false;
                                btn_Submit.Visible = false;
                                btn_Submit2.Visible = true;

                                MessageBox.Show("Cierre la Pieza y Coloque la Etiqueta de Cover.");

                            }
                            else
                            {
                                //XG1
                                MessageBox.Show("This unit already exist!");
                            }

                        }
                        else
                        {
                            //WR11
                            MessageBox.Show("This unit already exist!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Check Scannig!");
                        txt_ScanTablero.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Check Scannig!");
                }


            }
            else
            {
                MessageBox.Show("Empty field!");
            }


        }


        private bool ValidateOldSmart()
        {
            bool old = true;
            int n;
            string sn = txt_ScanTablero.Text.Trim().Substring(1, txt_ScanTablero.Text.Trim().Length - 1);
            bool isNumeric = int.TryParse(sn, out n);
            //txt_serial.Text.Trim().Length-1;
            if (isNumeric == true)
            {
                if (int.Parse(txt_ScanTablero.Text.Trim().Substring(1, txt_ScanTablero.Text.Trim().Length - 1)) >= 340000)
                {
                    old = false;
                }
            }
            else
                MessageBox.Show("Error de formato!");

            return old;
        }

        private void btn_Submit_Enter(object sender, EventArgs e) => SendKeys.Send("{ENTER}");


        private bool Check1WR11()
        {
            bool isValid = true;


            if (txt_ScanSN.Text.Trim().Substring(txt_ScanSN.Text.Trim().LastIndexOf('A') + 1) != txt_SNEtiqueta.Text.Trim())
            {
                isValid = false;
            }

            if (txt_ScanTablero.Text.Trim().Substring(0, 15) != txt_IMEIEtiqueta.Text.Trim())
            {
                isValid = false;

            }

            if (string.IsNullOrEmpty(txt_MACEtiqueta.Text.Trim()))
            {
                isValid = false;
            }



            return isValid;
        }

        private bool Check2WR11()
        {
            //pasar todo temporal(cambiar)
            bool isValid = true;



            if (txt_IMEISuelta.Text.Trim() != txt_IMEICaja.Text.Trim() || txt_ScanTablero.Text.Trim().Substring(0, 15) != txt_IMEISuelta.Text.Trim() || txt_ScanTablero.Text.Trim().Substring(0, 15) != txt_IMEICaja.Text.Trim())
            {
                isValid = false;
            }

            if (txt_MACSuelta.Text.Trim() != txt_MACCaja.Text.Trim() || txt_MACEtiqueta.Text.Trim() != txt_MACSuelta.Text.Trim() || txt_MACEtiqueta.Text.Trim() != txt_MACCaja.Text.Trim())
            {
                isValid = false;
            }
            if (txt_SNSuelta.Text.Trim() != txt_SNCaja.Text.Trim() || txt_ScanSN.Text.Trim().Substring(txt_ScanSN.Text.Trim().LastIndexOf('A') + 1) != txt_SNSuelta.Text.Trim() || txt_ScanSN.Text.Trim().Substring(txt_ScanSN.Text.Trim().LastIndexOf('A') + 1) != txt_SNCaja.Text.Trim())
            {
                isValid = false;
            }


            return isValid;
        }

        private bool Check1XGI()
        {
            bool isValid = true;



            if (txt_eui64.Text.Trim() != txt_MACEtiqueta.Text.Trim())
            {
                isValid = false;
            }
            if (string.IsNullOrEmpty(txt_SNEtiqueta.Text.Trim()))
            {
                isValid = false;
            }

            if (pn.identify == true)
            {
                if (txt_ScanTablero.Text.Trim().Substring(0, 15) != txt_IMEIEtiqueta.Text.Trim())
                {
                    isValid = false;

                }
            }

            return isValid;
        }

        private bool Check2XGI()
        {
            bool isValid = true;



            if (txt_SNSuelta.Text.Trim() != txt_SNCaja.Text.Trim() || txt_SNEtiqueta.Text.Trim() != txt_SNSuelta.Text.Trim() || txt_SNEtiqueta.Text.Trim() != txt_SNCaja.Text.Trim())
            {
                isValid = false;
            }
            if (txt_eui64.Text.Trim() != txt_MACEtiqueta.Text.Trim() || txt_eui64.Text.Trim() != txt_MACSuelta.Text.Trim())
            {
                isValid = false;
            }


            if (pn.identify == true)
            {
                if (txt_IMEISuelta.Text.Trim() != txt_IMEICaja.Text.Trim() || txt_ScanTablero.Text.Trim().Substring(0, 15) != txt_IMEISuelta.Text.Trim() || txt_ScanTablero.Text.Trim().Substring(0, 15) != txt_IMEICaja.Text.Trim())
                {
                    isValid = false;
                }

            }

            return isValid;
        }


        private void dg_Scan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //this.dg_Scan.Rows[e.RowIndex].Selected = true;
            //dg_Scan.CurrentCell = dg_Scan.Rows[e.RowIndex].Cells[0];

            dg_Scan.ClearSelection();//If you want

            int nRowIndex = dg_Scan.Rows.Count - 1;
            int nColumnIndex = 3;

            dg_Scan.Rows[nRowIndex].Selected = true;
            dg_Scan.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            dg_Scan.FirstDisplayedScrollingRowIndex = nRowIndex;

        }

        private void btn_Submit2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txt_IMEICaja.Text.Trim()) || !string.IsNullOrEmpty(txt_IMEISuelta.Text.Trim()) || !string.IsNullOrEmpty(txt_MACCaja.Text.Trim()) || !string.IsNullOrEmpty(txt_MACSuelta.Text.Trim()) ||
                !string.IsNullOrEmpty(txt_SNCaja.Text.Trim()) || !string.IsNullOrEmpty(txt_SNSuelta.Text.Trim()))
            {

                if (lbl_ensamble.Text.Substring(0, 4) != "WR11" || txt_ScanTablero.Text.Substring(0, 2) == "35")// && Check2WR11() == true)
                {
                    if (lbl_ensamble.Text.Substring(0, 3) != "XGI" || txt_eui64.Text.Substring(0, 2) == "00" && Check2XGI() == true)
                    {

                        if ("1P" + lbl_ensamble.Text + "  " + wo.rev == txt_PN.Text.Trim() ||lbl_ensamble.Text == txt_PN.Text.Trim())
                        {

                            if (lbl_ensamble.Text.Substring(0, 4) == "WR11")
                            {
                                scan.Crud("insert into tb_Scan(sn,dateReg, id_wo, id_user,pcb, mac) values('" + txt_ScanSN.Text.Trim() + "','" + DateTime.Now + "','" + wo.Id_wo + "','" + user.Id_user + "','" + txt_ScanTablero.Text.Trim() + "','" + txt_MACEtiqueta.Text.Trim() + "')"); ;

                            }
                            else

                                scan.Crud("insert into tb_Scan(sn,dateReg, id_wo, id_user,pcb, eui64) values('" + txt_SNEtiqueta.Text.Trim() + "','" + DateTime.Now + "','" + wo.Id_wo + "','" + user.Id_user + "','" + txt_ScanTablero.Text.Trim() + "','" + txt_eui64.Text.Trim() + "')"); ;


                            ClearTextBoxes();
                            btn_Submit.Visible = true;




                            Scaning_Load(sender, e);
                            txt_ScanTablero.Focus();
                            txt_eui64.Focus();

                        }
                        else
                            MessageBox.Show("Check Part N# Scan!");


                    }
                    else
                    {
                        MessageBox.Show("Check Scannig!");
                        txt_ScanTablero.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Check Scannig!");
                }
            }
            else
                MessageBox.Show("Empty fields!");
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
    }
}
