using DIGITrace;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }
        private void NuevaOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaOrden no = new NuevaOrden();

            Form NuevaOrden;
            if ((NuevaOrden = IsFormAlreadyOpen(typeof(NuevaOrden))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                NuevaOrden.WindowState = FormWindowState.Normal;
                NuevaOrden.BringToFront();
            }
        }

        private void EnsambleEEtiquetadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialNumber sn = new SerialNumber();

            Form SerialNumber;

            if ((SerialNumber = IsFormAlreadyOpen(typeof(SerialNumber))) == null)
            {
                sn.ShowDialog(this);
            }

            else
            {
                SerialNumber.WindowState = FormWindowState.Normal;
                SerialNumber.BringToFront();
            }
        }

        private void RetrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Password ps = new Password();

            Form Password;

            if ((Password = IsFormAlreadyOpen(typeof(Password))) == null)
            {
                ps.ShowDialog(this);
            }

            else
            {
                Password.WindowState = FormWindowState.Normal;
                Password.BringToFront();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Orden orden = new Orden();
            //dataGridView1.DataSource = orden.LlenarDG("select * from tb_Orden").Tables[0]; 
        }

        private void BusquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda b = new Busqueda();

            Form Busqueda;

            if ((Busqueda = IsFormAlreadyOpen(typeof(Busqueda))) == null)
            {
                b.ShowDialog(this);
            }

            else
            {
                Busqueda.WindowState = FormWindowState.Normal;
                Busqueda.BringToFront();
            }
        }

        private void MantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimiento mant = new Mantenimiento();

            Form manto;

            if ((manto = IsFormAlreadyOpen(typeof(Mantenimiento))) == null)
            {
                mant.ShowDialog(this);
            }

            else
            {
                manto.WindowState = FormWindowState.Normal;
                manto.BringToFront();
            }
        }

        private void HistorialCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Historial h = new Historial();

            Form hs;

            if ((hs = IsFormAlreadyOpen(typeof(Historial))) == null)
            {
                h.ShowDialog(this);
            }

            else
            {
                hs.WindowState = FormWindowState.Normal;
                hs.BringToFront();
            }
        }

        private void SetupEmpaqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdentificarOrden identificarorden = new IdentificarOrden();

            Form io;

            if ((io = IsFormAlreadyOpen(typeof(IdentificarOrden))) == null)
            {
                identificarorden.ShowDialog(this);
            }

            else
            {
                io.WindowState = FormWindowState.Normal;
                io.BringToFront();
            }
        }

        private void ShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shipping shipping = new Shipping();

            shipping.Show();
            //Form s;

            //if ((s = IsFormAlreadyOpen(typeof(Shipping))) == null)
            //{
            //    shipping.ShowDialog(this);
            //}

            //else
            //{
            //    s.WindowState = FormWindowState.Normal;
            //    s.BringToFront();
            //}
        }


        private void EstatusOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estatus status = new Estatus();

            Form st;

            if ((st = IsFormAlreadyOpen(typeof(Estatus))) == null)
            {
                status.ShowDialog(this);
            }

            else
            {
                st.WindowState = FormWindowState.Normal;
                st.BringToFront();
            }
        }

        private void iX30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdentifyWO_IX30 status = new IdentifyWO_IX30();

            Form st;

            if ((st = IsFormAlreadyOpen(typeof(IdentifyWO_IX30))) == null)
            {
                status.ShowDialog(this);
            }

            else
            {
                st.WindowState = FormWindowState.Normal;
                st.BringToFront();
            }
        }
    }
}
