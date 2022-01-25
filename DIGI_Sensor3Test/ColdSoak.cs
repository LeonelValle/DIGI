using System;

namespace DIGI_Sensor3test
{
    class ColdSoak : Conexion
    {
        int id_coldsoak;
        string partnumber;
        string lotnumber;
        string serialnumber;
        DateTime datestarted;
        string status;

        bool COLDSOAK;

        public string Partnumber { get => partnumber; set => partnumber = value; }
        public string Lotnumber { get => lotnumber; set => lotnumber = value; }
        public string Serialnumber { get => serialnumber; set => serialnumber = value; }
        public DateTime Datestarted { get => datestarted; set => datestarted = value; }
        public string Status { get => status; set => status = value; }
        public int Id_coldsoak { get => id_coldsoak; set => id_coldsoak = value; }
        public bool COLDSOAK1 { get => COLDSOAK; set => COLDSOAK = value; }
    }
}
