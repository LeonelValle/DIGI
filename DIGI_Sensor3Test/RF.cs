using System;

namespace DIGI_Sensor3test
{
    class RF : Conexion
    {
        int id_rf;
        string partnumber;
        string lotnumber;
        string serialnumber;
        DateTime datestarted;
        string status;

        bool rf;



        public int Id_rf { get => id_rf; set => id_rf = value; }
        public string Partnumber { get => partnumber; set => partnumber = value; }
        public string Lotnumber { get => lotnumber; set => lotnumber = value; }
        public string Serialnumber { get => serialnumber; set => serialnumber = value; }
        public DateTime Datestarted { get => datestarted; set => datestarted = value; }
        public string Status { get => status; set => status = value; }
        public bool Rf { get => rf; set => rf = value; }
    }
}
