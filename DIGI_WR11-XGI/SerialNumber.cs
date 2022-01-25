namespace DIGI_WR11_XGI
{
    class SerialNumber : Conexion
    {
        int subassy;
        int pcb;
        char mod;
        string serial;

        public int Subassy { get => subassy; set => subassy = value; }
        public int Pcb { get => pcb; set => pcb = value; }
        public char Mod { get => mod; set => mod = value; }
        public string Serial { get => serial; set => serial = value; }
    }
}
