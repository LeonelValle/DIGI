using System;

namespace DIGI_Plant1
{
    class Scan : Conexion
    {
        public int id_scan { get; set; }
        public string sn { get; set; }
        public DateTime dateReg { get; set; }
        public int id_wo { get; set; }
    }
}
