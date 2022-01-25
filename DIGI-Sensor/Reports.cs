using System;
using System.Text;
using System.Windows.Forms;

namespace DIGI_Sensor
{
    public partial class Reports : Form
    {
        RF rf = new RF();
        Current curr = new Current();
        Nist nist = new Nist();
        ColdSoak cold = new ColdSoak();

        public Reports()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && cb_Type.Text == "")
            {
                OneSelection();
            }
            else
            {
                //OneSelection();
                TwoSelection();
            }
        }

        private void TwoSelection()
        {
            if (comboBox1.Text == "RF")
            {
                if (cb_Type.Text == "Serial Number")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_RF where Serialnumber ='" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Lot Number")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_RF where Lotnumber ='" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Part number")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_RF where Partnumber ='" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Date Started")
                {
                    DateTime fecha = Convert.ToDateTime(txt_Search.Text);
                    string buscar = fecha.ToString("yyyy-MM-dd");
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_RF where CONVERT(varchar(255), Datestarted,126) LIKE '%" + buscar + "%'").Tables[0];
                }
                else if (cb_Type.Text == "Status")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_RF where status ='" + txt_Search.Text + "'").Tables[0];
            }
            else if (comboBox1.Text == "Current")
            {
                if (cb_Type.Text == "Serial Number")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Median, Datestarted, Script, status from Test_Current where Serialnumber = '" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Median")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Median, Datestarted, Script, status from Test_Current where Mediam = '" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Script")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Median, Datestarted, Script, status from Test_Current where Script = '" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Date Started")
                {
                    DateTime fecha = Convert.ToDateTime(txt_Search.Text);
                    string buscar = fecha.ToString("yyyy-MM-dd");
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Median, Datestarted, Script, status from Test_Current where CONVERT(varchar(255), Datestarted,126) LIKE '%" + buscar + "%'").Tables[0];
                }
                else if (cb_Type.Text == "Status")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Median, Datestarted, Script, status from Test_Current where status = '" + txt_Search.Text + "'").Tables[0];
            }
            else if (comboBox1.Text == "NIST")
            {
                if (cb_Type.Text == "Serial Number")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist where Serialnumber ='" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Lot Number")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist where Lotnumber ='" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Part number")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist where Partnumber ='" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Date Started")
                {
                    DateTime fecha = Convert.ToDateTime(txt_Search.Text);
                    string buscar = fecha.ToString("yyyy-MM-dd");
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist where CONVERT(varchar(255), Datestarted,126) LIKE '%" + buscar + "%'").Tables[0];
                }
                else if (cb_Type.Text == "Status")
                    dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist where status ='" + txt_Search.Text + "'").Tables[0];
                //dataGridView1.DataSource = nist.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist").Tables[0];
            }
            else if (comboBox1.Text == "ColdSoak")
            {
                if (cb_Type.Text == "Serial Number")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Sensor,Datestarted, status from Test_coldsoak where Serialnumber = '" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "SensorType")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Sensor,Datestarted, status from Test_coldsoak where Sensor = '" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "status")
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Sensor,Datestarted, status from Test_coldsoak where status = '" + txt_Search.Text + "'").Tables[0];
                else if (cb_Type.Text == "Date Started")
                {
                    DateTime fecha = Convert.ToDateTime(txt_Search.Text);
                    string buscar = fecha.ToString("yyyy-MM-dd");
                    dataGridView1.DataSource = curr.LlenarDG("select Serialnumber, Sensor,Datestarted, status from Test_coldsoak where CONVERT(varchar(255), Datestarted,126) LIKE '%" + buscar + "%'").Tables[0];
                    //CONVERT(varchar(255), Datestarted,126) LIKE '%" + buscar + "%'
                }



                //dataGridView1.DataSource = cold.LlenarDG("select Serialnumber, Sensor,Datestarted, status from Test_coldsoak").Tables[0];
            }
        }

        private void OneSelection()
        {
            if (comboBox1.Text == "RF")
            {
                dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_RF").Tables[0];
            }
            else if (comboBox1.Text == "Current")
            {
                dataGridView1.DataSource = rf.LlenarDG("select Median, Script, Serialnumber, Datestarted, status from Test_Current").Tables[0];
            }
            else if (comboBox1.Text == "NIST")
            {
                dataGridView1.DataSource = rf.LlenarDG("select Partnumber, Lotnumber, Serialnumber, Datestarted, status from Test_Nist").Tables[0];
            }
            else if (comboBox1.Text == "ColdSoak")
            {
                dataGridView1.DataSource = rf.LlenarDG("select Serialnumber, Datestarted, status, Sensor from Test_coldsoak").Tables[0];
            }
        }

        private void SaveToCSV(DataGridView DGV)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog
            {
                Filter = "Fichero CSV (*.csv)|*.csv",
                FileName = "",
                Title = "Exportar a CSV"
            };
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvMemoria = new StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 0; i < DGV.Columns.Count; i++)
                {
                    if (i == DGV.Columns.Count - 1)
                    {
                        csvMemoria.Append(String.Format("\"{0}\"",
                            DGV.Columns[i].HeaderText));
                    }
                    else
                    {
                        csvMemoria.Append(String.Format("\"{0}\",",
                            DGV.Columns[i].HeaderText));
                    }
                }

                csvMemoria.AppendLine();


                for (int m = 0; m < DGV.Rows.Count; m++)
                {
                    for (int n = 0; n < DGV.Columns.Count; n++)
                    {
                        //si es la última columna no poner el ;
                        if (n == DGV.Columns.Count - 1)
                        {
                            csvMemoria.Append(String.Format("\"{0}\"", DGV.Rows[m].Cells[n].Value, @"\d+"));
                        }
                        else
                        {
                            csvMemoria.Append(String.Format("\"{0}\",", DGV.Rows[m].Cells[n].Value, @"\d+"));
                        }

                    }
                    csvMemoria.AppendLine();
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(dlGuardar.FileName, false, System.Text.Encoding.Default);
                sw.Write(csvMemoria.ToString());
                sw.Close();
            }
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                SaveToCSV(dataGridView1);

            else
                MessageBox.Show("Realize una busqueda", "ERROR!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Type.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {

                cb_Type.Items.Add("Serial Number");
                cb_Type.Items.Add("Lot Number");
                cb_Type.Items.Add("Part Number");
                cb_Type.Items.Add("Date Started");
                cb_Type.Items.Add("status");
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                cb_Type.Items.Add("Serial Number");
                cb_Type.Items.Add("Median");
                cb_Type.Items.Add("Script");
                cb_Type.Items.Add("Date Started");
                cb_Type.Items.Add("status");
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                cb_Type.Items.Add("Serial Number");
                cb_Type.Items.Add("Lot Number");
                cb_Type.Items.Add("Part Number");
                cb_Type.Items.Add("Date Started");
                cb_Type.Items.Add("status");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                cb_Type.Items.Add("Serial Number");
                cb_Type.Items.Add("Sensor");
                cb_Type.Items.Add("Date Started");
                cb_Type.Items.Add("status");
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
        }
    }
}
