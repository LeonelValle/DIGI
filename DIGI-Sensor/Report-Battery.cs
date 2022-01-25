using System;
using System.Text;
using System.Windows.Forms;

namespace DIGI_Sensor
{
    public partial class Report_Battery : Form
    {
        Battery bt = new Battery();
        public Report_Battery()
        {
            InitializeComponent();
        }

        private void Report_Battery_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = bt.LlenarDG("select sn as 'SerialNumber', dateReg, data from tb_Batterys").Tables[0];
            dataGridView1.DataSource = bt.LlenarDG("SELECT sn, CONVERT(VARCHAR(10),dateReg,111) as DatePart, convert(varchar(15), dateReg, 108) TimePart, Data, op.numeroempleado from tb_Batterys bat left join tb_Operador op on bat.id_operador = op.id_operador").Tables[0];

        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                SaveToCSV(dataGridView1);

            else
                MessageBox.Show("Realize una busqueda", "ERROR!");
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

    }
}
