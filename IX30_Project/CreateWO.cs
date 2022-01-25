using System;
using System.Windows.Forms;

namespace IX30_Project
{
    public partial class CreateWO : Form
    {
        PN pn = new PN();
        WorkOrder wo = new WorkOrder();

        public CreateWO()
        {
            InitializeComponent();
        }

        private void CreateWO_Load(object sender, EventArgs e)
        {


            cb_PN.DataSource = pn.LlenarComboBox("select id_pn, pn from pn");
            cb_PN.DisplayMember = "pn";
            cb_PN.ValueMember = "id_pn";
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Qty.Text) && !string.IsNullOrEmpty(txt_WO.Text) && !string.IsNullOrEmpty(txt_Rev.Text) && cb_PN.SelectedIndex != -1)
            {
                if (!wo.Existe("select * from WorkOrder where wo = '" + txt_WO.Text + "'"))
                {
                    wo.Crud("insert into WorkOrder(wo, qty, rev, regWO, id_pn) values('" + txt_WO.Text + "','" + txt_Qty.Text + "','" + txt_Rev.Text + "','" + DateTime.Now + "','" + cb_PN.SelectedValue + "')");
                    MessageBox.Show("WO Saved!");
                    CreateWO_Load(sender, e);
                    //ClearTextboxes();
                    cb_PN.SelectedIndex = -1;
                }
                else
                    MessageBox.Show("WO already exist!");
            }
            else
                MessageBox.Show("Fill all data!");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
