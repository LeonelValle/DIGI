using System;
using System.Text;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Busqueda : Form
    {
        readonly ModeloOrden modeloorden = new ModeloOrden();
        //private readonly DataSet res = new DataSet();

        public Busqueda()
        {
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            dg_buscar.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dg_buscar.RowHeadersVisible = false; // set it to false if not needed
            this.dg_buscar.VirtualMode = true;

        }

        private void Btn_generar_Click(object sender, EventArgs e)
        {
            if (dg_buscar.Rows.Count != 0)
                SaveToCSV(dg_buscar);

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
                for (int i = 1; i < DGV.Columns.Count; i++)
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
                    for (int n = 1; n < DGV.Columns.Count; n++)
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

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            string salida_datos = "";
            _ = this.txt_buscar.Text.Split(' ');

            try
            {

                if (cb_filtro.Text == "Serial Number")
                {
                    if (modeloorden.Existe("select COUNT(*) from tb_modeloOrden where serialNumber = '" + txt_buscar.Text + "'"))
                    {
                        int id_modelorden = int.Parse(modeloorden.ReturnID("select id_modeloOrden from tb_ModeloOrden where serialNumber = '" + txt_buscar.Text + "'"));
                        salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei,  o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_modeloOrden = '" + id_modelorden + "' order by mo.id_modeloOrden asc";
                    }
                }
                if (cb_filtro.Text == "MAC Address")
                {

                    if (modeloorden.Existe("select COUNT(*) from tb_modeloOrden where scanmac = '" + txt_buscar.Text + "'"))
                    {
                        int id_modelorden = int.Parse(modeloorden.ReturnID("select id_modeloOrden from tb_ModeloOrden where scanmac = '" + txt_buscar.Text + "'"));
                        salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_modeloOrden = '" + id_modelorden + "' order by mo.id_modeloOrden asc";
                    }
                }


                if (cb_filtro.Text == "IMEI Number")
                {
                    if (modeloorden.Existe("select COUNT(*) from tb_modeloOrden where scanimei = '" + txt_buscar.Text + "'"))
                    {
                        int id_modelorden = int.Parse(modeloorden.ReturnID("select id_modeloOrden from tb_ModeloOrden where scanimei = '" + txt_buscar.Text + "'"));
                        salida_datos = "select mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_modeloOrden = '" + id_modelorden + "' order by mo.id_modeloOrden asc";
                    }
                }

                if (cb_filtro.Text == "Orden")
                {

                    int id_orden = int.Parse(modeloorden.ReturnValue("select id_orden from tb_Orden where orden = '" + txt_buscar.Text + "'"));
                    salida_datos = "select distinct mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where o.id_orden = " + id_orden + " order by mo.id_modeloOrden asc";
                }

                if (cb_filtro.Text == "Caja")
                {
                    int id_caja = int.Parse(modeloorden.ReturnValue("select id_caja from tb_caja where caja = '" + txt_buscar.Text + "'"));
                    salida_datos = "select distinct mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.id_caja = " + id_caja + " order by mo.id_modeloOrden asc";

                }

                if (cb_filtro.Text == "Ensamble")
                {
                    salida_datos = "select distinct mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where mo.partnumber = '" + txt_buscar.Text + "' order by mo.id_modeloOrden asc";
                }

                if (cb_filtro.Text == "Fecha Registro")
                {
                    DateTime fecha = Convert.ToDateTime(txt_buscar.Text);
                    string buscar = fecha.ToString("yyyy-MM-dd");
                    salida_datos = "select distinct mo.id_modeloOrden as ID, e.ensamble, mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, mo.fecharegistro, c.caja, mo.turno, mo.revision, op.numeroempleado from tb_ModeloOrden mo join tb_Orden o on o.id_orden = mo.id_orden join tb_Ensamble e on e.id_ensamble = o.id_ensamble join tb_caja c on c.id_caja = mo.id_caja join tb_Operador op on op.id_operador = o.id_operador where CONVERT(varchar(255),mo.fecharegistro,126) LIKE '%" + buscar + "%' order by mo.id_modeloOrden asc";
                }

                dg_buscar.DataSource = modeloorden.LlenarDG(salida_datos).Tables[0];
                this.dg_buscar.Columns[0].Visible = false;

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Format Error!","Error");
                //throw;
            }catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Not Found!","Error");
                //throw;
            }
        }
    }
}
