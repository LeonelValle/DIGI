using System;

namespace DIGI_Sensor
{
    class Battery : Conexion
    {
        int id_battery;
        string sn;
        DateTime dateReg;
        bool tested;
        static string ensamble;

        public int Id_battery { get => id_battery; set => id_battery = value; }
        public string Sn { get => sn; set => sn = value; }
        public DateTime DateReg { get => dateReg; set => dateReg = value; }
        public bool Tested { get => tested; set => tested = value; }
        public string Ensamble { get => ensamble; set => ensamble = value; }
    }
}
