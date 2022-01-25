using System;

namespace DIGI_Sensor3test
{
    class Nist : Conexion
    {

        int id_nist;
        string partnumber;
        string lotnumber;
        string serialnumber;
        DateTime datestarted;
        string status;

        bool nist;

        public string Partnumber { get => partnumber; set => partnumber = value; }
        public string Lotnumber { get => lotnumber; set => lotnumber = value; }
        public string Serialnumber { get => serialnumber; set => serialnumber = value; }
        public DateTime Datestarted { get => datestarted; set => datestarted = value; }
        public string Status { get => status; set => status = value; }
        public int Id_nist { get => id_nist; set => id_nist = value; }
        public bool Nists { get => nist; set => nist = value; }
    }
}
