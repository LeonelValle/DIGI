using MWTrace_beta;
using System;
using System.Data;
using System.Windows.Forms;

namespace DIGITrace
{
    public partial class Estatus : Form
    {
        private readonly Orden orden = new Orden();
        public Estatus()
        {
            InitializeComponent();
        }

        private void Estatus_Load(object sender, EventArgs e)
        {
            EjecutarSP(0);
            try
            {

                dv_ordenes.DataSource = orden.LlenarDG("select orden, e.ensamble,FechaOrden,cantidad, Restantes from tb_orden o, tb_Ensamble e where FechaCierre is null and Restantes != 0 and o.id_ensamble = e.id_ensamble").Tables[0];
                dataGridView1.DataSource = orden.LlenarDG("select orden, e.ensamble,FechaOrden,cantidad, Restantes from tb_orden o, tb_Ensamble e where Restantes = 0 and o.id_ensamble = e.id_ensamble").Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void EjecutarSP(int id_orden)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_EstatusOrdenes", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_orden", id_orden);

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
    }
}
