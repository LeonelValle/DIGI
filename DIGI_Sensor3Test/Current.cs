using System;

namespace DIGI_Sensor3test
{
    class Current : Conexion
    {
        int id_current;
        string partnumber;
        string lotnumber;
        string serialnumber;
        DateTime datestarted;
        string status;

        bool CURRENT;

        public int Id_current { get => id_current; set => id_current = value; }
        public string Partnumber { get => partnumber; set => partnumber = value; }
        public string Lotnumber { get => lotnumber; set => lotnumber = value; }
        public string Serialnumber { get => serialnumber; set => serialnumber = value; }
        public DateTime Datestarted { get => datestarted; set => datestarted = value; }
        public string Status { get => status; set => status = value; }
        public bool CURRENT1 { get => CURRENT; set => CURRENT = value; }
    }
}
