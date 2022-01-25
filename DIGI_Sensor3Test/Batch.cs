using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DIGI_Sensor3test
{
    public partial class Batch : Form
    {
        RF rf = new RF();


        public Batch()
        {
            InitializeComponent();
        }


        private void btn_Paste_Click(object sender, EventArgs e)
        {
            //dataGridView1

            //string a = DateTime.Now.ToString();
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows.Clear();

                if (dataGridView1.ColumnCount > 0)
                    dataGridView1.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView1.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView1.Rows.Add();
                    int myRowIndex = dataGridView1.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGridView1.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            //DateTime regdate = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //regdate.ToString("yyyy-mm-DD hh:mm:ss.fff");

            if (comboBox1.Text == "RF")
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    //DateTime regdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value.ToString());

                    //string buscar = regdate.ToString("yyyy-mm-DD hh:mm:ss.fff");
                    //rf.Crud("insert into Test_RF(Partnumber, Lotnumber, Serialnumber, Datestarted, status, RegDate) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + buscar + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + DateTime.Now + "')");
                    rf.Crud("insert into Test_RF(Partnumber, Lotnumber, Serialnumber, Datestarted, status, RegDate) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value.ToString()) + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + DateTime.Now + "')");
                }
            }
            if (comboBox1.Text == "Current")
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    rf.Crud("insert into Test_Current(Serialnumber, Median,status,Datestarted, Script, RegDate) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value.ToString()) + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + DateTime.Now + "')");
                //rf.Crud("insert into Test_Current(Partnumber, Lotnumber, Serialnumber, Datestarted, status) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "')");
            }
            if (comboBox1.Text == "NIST")
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    rf.Crud("insert into Test_Nist(Partnumber, Lotnumber, Serialnumber, Datestarted, status, RegDate) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value) + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + DateTime.Now + "')");
            }
            if (comboBox1.Text == "ColdSoak")
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    rf.Crud("insert into Test_coldsoak(Serialnumber, Sensor, Datestarted, status, RegDate) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value) + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + DateTime.Now + "')");
                //rf.Crud("insert into Test_coldsoak(Partnumber, Lotnumber, Serialnumber, Datestarted, status) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "')");
            }
            MessageBox.Show("UPLOAD DATA");
        }

        private void btn_Claer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.Columns.Add("PartNumber", "PartNumber");
                dataGridView1.Columns.Add("LotNumber", "LotNumber");
                dataGridView1.Columns.Add("SerialNumber", "SerialNumber");
                dataGridView1.Columns.Add("DateStarted", "DateStarted");
                dataGridView1.Columns.Add("Status", "Status");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.Columns.Add("SerialNumber", "SerialNumber");
                dataGridView1.Columns.Add("Median", "Median");
                dataGridView1.Columns.Add("Status", "Status");
                dataGridView1.Columns.Add("DateStarted", "DateStarted");
                dataGridView1.Columns.Add("Script", "ScriptVersion");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.Columns.Add("PartNumber", "PartNumber");
                dataGridView1.Columns.Add("LotNumber", "LotNumber");
                dataGridView1.Columns.Add("SerialNumber", "SerialNumber");
                dataGridView1.Columns.Add("DateStarted", "DateStarted");
                dataGridView1.Columns.Add("Status", "Status");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.Columns.Add("SerialNumber", "SerialNumber");
                dataGridView1.Columns.Add("SensorType", "SensorType");
                dataGridView1.Columns.Add("DateStarted", "DateStarted");
                dataGridView1.Columns.Add("Status", "Status");
            }
        }

        private void Batch_Load(object sender, EventArgs e)
        {

        }
    }
}
