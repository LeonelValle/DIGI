using System;

namespace IX30_Project
{
    class SerialNumber : Conexion
    {
        string model;
        char mfg;
        int consecutive;
        string ww;
        string yy;
        string dd;

        public SerialNumber()
        {

        }

        public SerialNumber(string MD, char MFG, int CONS, string WW, string YY, string DD)
        {
            model = MD;
            mfg = MFG;
            consecutive = CONS;
            ww = WW;
            yy = YY;
            dd = DD;
        }

        public string Model { get => model; set => model = value; }
        public char Mfg { get => mfg; set => mfg = value; }
        public int Consecutive { get => consecutive; set => consecutive = value; }
        public string Ww { get => ww; set => ww = value; }
        public string Yy { get => yy; set => yy = value; }
        public string Dd { get => dd; set => dd = value; }
    }
}
