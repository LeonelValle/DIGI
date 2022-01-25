using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DIGI_WR11_XGI
{
    public partial class Retrabajo : Form
    {
        Scan scan = new Scan();
        public Retrabajo()
        {
            InitializeComponent();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (scan.Existe("select count(*) from tb_Scan where id_scan = " + scan.id_scan))
            {
                if (scan.id_scan != 0)
                {
                    scan.Crud("delete tb_Scan where id_scan = " + scan.id_scan);
                    Search();
                    MessageBox.Show("DONE!");
                }
                else
                    MessageBox.Show("No se encontro!", "ERROR!");

            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //if (!(string.IsNullOrEmpty(txt_etiqueta.Text)) && !(string.IsNullOrEmpty(txt_serialnumber.Text)) && !(string.IsNullOrEmpty(txt_tablero.Text)) && !(string.IsNullOrEmpty(txt_problema.Text)))
            //{
            if (scan.id_scan != 0)
            {
                scan.Crud("update tb_Scan set pcb = '" + txt_tablero.Text + "' , mac = '" + txt_etiqueta.Text + "' , sn = '" + txt_serialnumber.Text + "' , problema = '" + txt_problema.Text + "' where id_scan = '" + scan.id_scan + "'");
                Search();
                MessageBox.Show("DONE!");

            }
            else
                MessageBox.Show("No se encontro!", "ERROR!");
            //}
            //else
            //{ MessageBox.Show("No dejes ningun campo vacio!", "ERROR!"); }
        }

        private void Retrabajo_Load(object sender, EventArgs e)
        {

        }

        private void Search()
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.txt_buscar.Text.Split(' ');

            foreach (string palabra in palabra_busqueda)
            {
                if (cb_orden.Text == "Serial Number")
                {
                    if (scan.Existe("select count(*) from tb_Scan where sn = '" + txt_buscar.Text + "'"))
                    {
                        scan.id_scan = int.Parse(scan.ReturnID("select id_scan from tb_Scan where sn = '" + txt_buscar.Text + "'"));
                        salida_datos = "select sc.id_scan, sc.sn, sc.mac, sc.pcb, pn.pn,wo.wo from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where sc.id_scan = " + scan.id_scan + " order by sc.id_scan asc";
                    }
                    else
                        MessageBox.Show("No se encontro!");

                }
                if (cb_orden.Text == "Etiqueta")
                {

                    if (scan.Existe("select count(*) from tb_Scan where pcb = '" + txt_buscar.Text + "'"))
                    {
                        scan.id_scan = int.Parse(scan.ReturnID("select id_scan from tb_Scan where sn = '" + txt_buscar.Text + "'"));
                        salida_datos = "select sc.id_scan, sc.sn, sc.mac, sc.pcb, pn.pn,wo.wo from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where sc.id_scan = '" + scan.id_scan + "' order by sc.id_scan asc";
                    }
                    else
                        MessageBox.Show("No se encontro!");
                }


                if (cb_orden.Text == "Tablero")
                {
                    if (scan.Existe("select count(*) from tb_Scan where mac = '" + txt_buscar.Text + "'"))
                    {
                        scan.id_scan = int.Parse(scan.ReturnID("select id_scan from tb_Scan where sn = '" + txt_buscar.Text + "'"));
                        salida_datos = "select sc.id_scan, sc.sn, sc.mac, sc.pcb, pn.pn,wo.wo from tb_Scan sc join tb_WO wo on sc.id_wo = wo.id_wo join tb_PN pn on pn.id_pn = wo.id_pn where sc.id_scan = '" + scan.id_scan + "' order by sc.id_scan asc";
                    }
                    else
                        MessageBox.Show("No se encontro!");
                }

                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView1.RowHeadersVisible = false; // set it to false if not needed
                this.dataGridView1.VirtualMode = true;
                if (salida_datos != "")
                {
                    dataGridView1.DataSource = scan.LlenarDG(salida_datos).Tables[0];
                    FillData();
                    this.dataGridView1.Columns[0].Visible = false;
                    //this.dataGridView1.Columns[0].Visible = false;
                }
            }
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void FillData()
        {
            try
            {
                SqlDataReader leer = scan.Leer("select * from tb_Scan where id_scan = '" + scan.id_scan + "'");

                //if (leer.Read() == true && leerCaja.Read() == true)
                if (leer.Read() == true)
                {
                    txt_etiqueta.Text = leer["pcb"].ToString();
                    txt_tablero.Text = leer["mac"].ToString();
                    txt_serialnumber.Text = leer["sn"].ToString();


                }
                else
                {
                    txt_etiqueta.Text = "";
                    txt_tablero.Text = "";
                    txt_serialnumber.Text = "";

                }


                scan.Cerrar();
            }
            catch (System.InvalidOperationException)
            {
                scan.Cerrar();
                //throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // if (cell != null)
                scan.id_scan = int.Parse(row.Cells["id_scan"].Value.ToString());
                // txt_idCaja.Text = row.Cells["IdCaja"].Value.ToString();
            }

            try
            {
                SqlDataReader leer = scan.Leer("select * from tb_Scan where id_scan = '" + scan.id_scan + "'");

                //FillCBCajas();
                //if (leer.Read() == true && leerCaja.Read() == true)
                if (leer.Read() == true)
                {
                    txt_etiqueta.Text = leer["pcb"].ToString();
                    txt_tablero.Text = leer["mac"].ToString();
                    txt_serialnumber.Text = leer["sn"].ToString();


                }
                else
                {
                    txt_etiqueta.Text = "";
                    txt_tablero.Text = "";
                    txt_serialnumber.Text = "";

                }




                scan.Cerrar();
            }
            catch (System.InvalidOperationException)
            {
                scan.Cerrar();
                //throw;
            }
        }
    }
}
