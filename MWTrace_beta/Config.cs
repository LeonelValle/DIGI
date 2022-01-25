namespace MWTrace_beta
{
    class Config : Conexion
    {
        int id_config;
        string code;
        string revision;
        int increment;
        int consecutive_hexadeciamal;
        int consecutive_serial;
        string macHead;
        int boxTop;

        public int Id_config { get => id_config; set => id_config = value; }
        public string Code { get => code; set => code = value; }
        public string Revision { get => revision; set => revision = value; }
        public int Increment { get => increment; set => increment = value; }
        public int Consecutive_hexadeciamal { get => consecutive_hexadeciamal; set => consecutive_hexadeciamal = value; }
        public int Consecutive_serial { get => consecutive_serial; set => consecutive_serial = value; }
        public string MacHead { get => macHead; set => macHead = value; }
        public int BoxTop { get => boxTop; set => boxTop = value; }
    }
}
