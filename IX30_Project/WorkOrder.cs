using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IX30_Project
{
    class WorkOrder : Conexion
    {
        public int id_wo { get; set; }
        public string wo { get; set; }
        public int qty { get; set; }
        public string rev { get; set; }
        public DateTime regWO { get; set; }
        public int id_pn { get; set; }
    }
}
