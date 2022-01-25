using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Shipping : Form
    {
        private readonly Conexion con = new Conexion();
        private readonly ModeloOrden modeloOrden = new ModeloOrden();
        private readonly Caja caja = new Caja();

        public Shipping()
        {
            InitializeComponent();
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txt_caja.Text)))
            {
                if (modeloOrden.Existe("select COUNT(*) from tb_caja where caja = '" + txt_caja.Text + "' and caja != '' "))
                {
                    if (!modeloOrden.Existe("select COUNT(*) from tb_Shipping where caja = '" + txt_caja.Text.Trim() + "' and caja != '' "))
                    {
                        modeloOrden.Id_caja = int.Parse(caja.ReturnID("select id_caja from tb_caja where caja = '" + txt_caja.Text.Trim() + "'"));

                        //EjecutarSP(id_caja);
                        EjecutarSPTest(modeloOrden.Id_caja);

                        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                        dataGridView1.RowHeadersVisible = false; // set it to false if not needed
                        this.dataGridView1.VirtualMode = true;

                        //dataGridView1.DataSource = modeloOrden.LlenarDG("select ensamble as Assambly, serialnumber as SerialNumber, mac as MAC_Address, imei as IMEI_Number, serialnumberCaja as Box_SerialNumber, macCaja as Box_MACAddress, imeiCaja as Box_IMEINumber, orden as WorkOrder, fecharegistro as Date_Register, shipping_date = GETDATE() ,caja as BoxID, turno as Shift, revision as Revision, numeroempleado as EMP_IDNUMBER from tb_Shipping").Tables[0];
                        FillDataGridView();
                        //dataGridView1.DataSource = EjecutarSPTest(id_caja);

                        labelCount();
                        txt_caja.Text = "";
                        this.txt_caja.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Esta caja ya ha sido insertada!", "ERROR!");
                        txt_caja.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("La caja que se inserto no existe!", "ERROR!");
                    txt_caja.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Inserte una caja!", "ERROR!");
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EjecutarSP()
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_CrearTabla", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
            }
        }
        private void EjecutarSPCerrar()
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_BorrarTabla", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
            }
        }
        private void EjecutarSP(int id_caja)
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_InsertarTabla", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_caja", id_caja);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
            }
        }

        private void EjecutarSPTest(int id_caja)
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_CrearTablaTest", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_caja", id_caja);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
            }

            //MW1908270131
        }

        private void Shipping_Load(object sender, EventArgs e)
        {

            EjecutarSPCerrar();
            EjecutarSP();

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowHeadersVisible = false; // set it to false if not needed
            this.dataGridView1.VirtualMode = true;
            //dataGridView1.DataSource = modeloOrden.LlenarDG("select ensamble as Assambly, serialnumber, mac as MAC_Address, imei as IMEI_Number, qr as QR, serialnumberCaja as Box_SerialNumber, macCaja as Box_MACAddress, imeiCaja as Box_IMEINumber, qrCaja as Box_QR, orden as WorkOrder, fecharegistro as Date_Register, shipping_date as Date_Shipping,caja as BoxID, turno as Shift, revision as Revision, numeroempleado as EMP_IDNUMBER from tb_Shipping").Tables[0];

        }

        private void Btn_generar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
                SaveToCSV(dataGridView1);
            else
                MessageBox.Show("Realize una busqueda", "ERROR!");
        }

        private void SaveToCSV(DataGridView DGV)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog();
            dlGuardar.Filter = "Fichero CSV (*.csv)|*.csv";
            dlGuardar.FileName = DateTime.Now.ToString();
            dlGuardar.Title = "Exportar a CSV";
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvMemoria = new StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 0; i < DGV.Columns.Count; i++)
                {
                    if (i == DGV.Columns.Count - 1)
                    {
                        csvMemoria.Append(String.Format("\"{0}\"", DGV.Columns[i].HeaderText));
                    }
                    else
                    {
                        csvMemoria.Append(String.Format("\"{0}\",", DGV.Columns[i].HeaderText));
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
                            csvMemoria.Append(String.Format("\"{0}\"", DGV.Rows[m].Cells[n].Value));
                        }
                        else
                        {
                            csvMemoria.Append(String.Format("\"{0}\",", DGV.Rows[m].Cells[n].Value));
                        }
                    }
                    csvMemoria.AppendLine();
                }

                System.IO.StreamWriter sw = new System.IO.StreamWriter(dlGuardar.FileName, false, System.Text.Encoding.Default);
                sw.Write(csvMemoria.ToString());
                sw.Close();
            }
        }
        private void Btn_agregar_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            EjecutarSPCerrar();
            EjecutarSP();
            labelCount();
        }

        private void labelCount()
        {
            lbl_registros.Text = modeloOrden.ReturnValue("select COUNT(*) from tb_Shipping");
            lbl_regAdd.Text = modeloOrden.ReturnValue("select COUNT(*) from tb_ModeloOrden where id_caja = " + modeloOrden.Id_caja);
            lbl_cajas.Text = modeloOrden.ReturnValue("select  COUNT(distinct caja) from tb_Shipping");
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            modeloOrden.Crud("delete tb_Shipping where caja = '" + txt_caja.Text + "'");
            FillDataGridView();
            labelCount();
            txt_caja.Text = "";
            lbl_regAdd.Text = "0";
        }

        private void FillDataGridView()
        {
            //dataGridView1.DataSource = modeloOrden.LlenarDG("select ensamble as Assambly, serialnumber as SerialNumber, mac as MAC_Address, imei as IMEI_Number, serialnumberCaja as Box_SerialNumber, macCaja as Box_MACAddress, imeiCaja as Box_IMEINumber, orden as WorkOrder, fecharegistro as Date_Register, shipping_date = GETDATE() ,caja as BoxID, turno as Shift, revision as Revision, numeroempleado as EMP_IDNUMBER from tb_Shipping").Tables[0];
            dataGridView1.DataSource = modeloOrden.LlenarDG("select ensamble as Assambly, serialnumber as SerialNumber, mac as MAC_Address, imei as IMEI_Number, orden as WorkOrder, shipping_date = GETDATE() ,caja as BoxID, revision as Revision from tb_Shipping").Tables[0];


        }

        private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value) != "Passed" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value) != "Passed" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value) != "Passed" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value) != "Passed")
            //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;

        }
    }
}
