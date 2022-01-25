using System;

namespace DIGI_WR11_XGI
{
    class Scan : Conexion
    {
        public int id_scan { get; set; }
        public string sn { get; set; }
        public DateTime dateReg { get; set; }
        public int id_wo { get; set; }
    }
}
