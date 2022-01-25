using System;

namespace DIGI_Sensor
{
    class Test : Conexion
    {
        public int id_test { get; set; }
        public string pass { get; set; }
        public string sn { get; set; }
        public DateTime TestDate { get; set; }
        public int id_nemploy { get; set; }

        string rf;
        string current;
        string coldsoak;
        string nist;
        static bool selected;

        public string Rf { get => rf; set => rf = value; }
        public string Current { get => current; set => current = value; }
        public string Coldsoak { get => coldsoak; set => coldsoak = value; }
        public string Nist { get => nist; set => nist = value; }
        public bool Selected { get => selected; set => selected = value; }
    }
}
