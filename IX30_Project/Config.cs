namespace IX30_Project
{
    class Config : Conexion
    {
        public int id_config { get; set; }
        public string mfgCode { get; set; }
        public int begSerial { get; set; }
        public int endSerial { get; set; }
        public string ww { get; set; }
        public string yy { get; set; }
        public string macHead { get; set; }
        public string macStart { get; set; }
        public string macEnd { get; set; }
        public int increment { get; set; }
        public int consecutive { get; set; }
    }
}
