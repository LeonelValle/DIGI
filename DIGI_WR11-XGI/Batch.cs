using System;
using System.Windows.Forms;

namespace DIGI_WR11_XGI
{
    public partial class Batch : Form
    {

        public Batch()
        {
            InitializeComponent();
        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {
            try
            {
                // Getting Text from Clip board
                string s = Clipboard.GetText();
                //Parsing criteria: New Line
                string[] lines = s.Split('\n');
                foreach (string ln in lines)
                {
                    listBox1.Items.Add(ln.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int count = 0;
            SerialNumber mo = new SerialNumber();
            foreach (var item in listBox1.Items)
            {
                //mo.Crud("delete tb_ModeloOrden where " + cb_option.Text + " = '" + item + "'");
                mo.Crud("delete tb_Scan where pcb = '" + item + "'");
                count++;
            }
            MessageBox.Show("ROWS DELETED " + count);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Batch_Load(object sender, EventArgs e)
        {

        }
    }
}
