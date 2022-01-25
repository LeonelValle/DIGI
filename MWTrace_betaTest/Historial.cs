using System;
using System.Data;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Historial : Form
    {
        readonly ModeloOrden modeloorden = new ModeloOrden();
        //DataSet res = new DataSet();
        DataView filtro;

        public Historial()
        {
            InitializeComponent();
        }

        private void Historial_Load(object sender, EventArgs e)
        {

            try
            {
                this.filtro = modeloorden.Leer_Datos("select TOP 100 mo.Serialnumber, mo.scanmac, mo.scanimei, o.orden, e.ensamble ,mo.fecharegistro, c.caja, mo.turno, o.rev, op.numeroempleado, fechaCambio from tb_Historial mo join tb_Orden o on mo.id_orden = o.id_orden join tb_caja c on mo.id_caja = c.id_caja join tb_Ensamble e on o.id_ensamble = e.id_ensamble join tb_Operador op on o.id_operador = op.id_operador", "tb_Historial.id_modeloOrden, tb_Historial.scanmac, tb_Historial.scanimei , tb_Historial.fecharegistro, tb_Historial.id_orden,  tb_Historial.fechaCambio, tb_Orden.orden, tb_caja.caja, tb_Ensamble.ensamble, tb_Operador.operador");
                this.dg_buscar.DataSource = filtro;
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("No se encontro la base de datos");
                MessageBox.Show(ex.ToString());
            }
        }

        private void Txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.txt_buscar.Text.Split(' ');

            foreach (string palabra in palabra_busqueda)
            {
                if (cb_filtro.Text == "Serial Number")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(Serialnumber LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (Serialnumber LIKE '%" + palabra + "%')";
                }

                if (cb_filtro.Text == "Scan Mac")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(scanmac LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (scanmac LIKE '%" + palabra + "%')";
                }

                if (cb_filtro.Text == "Scan IMEI")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(scanimei LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (scanimei LIKE '%" + palabra + "%')";
                }

                if (cb_filtro.Text == "Orden")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(orden, System.String) LIKE '%{0}%'", palabra);
                    else
                        salida_datos += " AND (orden LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Caja")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(caja, System.String) LIKE '{0}'", palabra);
                    else
                        salida_datos += " AND (caja LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Fecha Registro")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(fecharegistro, System.String) LIKE '%{0}%'", palabra);
                    else
                        salida_datos += " AND (fecharegistro LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Ensamble")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(Ensamble, System.String) LIKE '%{0}%'", palabra);
                    else
                        salida_datos += " AND (Ensamble LIKE % '" + palabra + " %')";
                }
                this.filtro.RowFilter = salida_datos;
            }
        }
    }
}
