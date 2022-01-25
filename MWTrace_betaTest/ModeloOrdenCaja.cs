namespace MWTrace_beta
{
    class ModeloOrdenCaja : Conexion
    {
        int id_moCaja;
        string serialnumberCaja;
        string scanmacCaja;
        string scanimeiCaja;
        int id_caja;

        public int Id_moCaja { get => id_moCaja; set => id_moCaja = value; }
        public string SerialnumberCaja { get => serialnumberCaja; set => serialnumberCaja = value; }
        public string ScanmacCaja { get => scanmacCaja; set => scanmacCaja = value; }
        public string ScanimeiCaja { get => scanimeiCaja; set => scanimeiCaja = value; }
        public int Id_caja { get => id_caja; set => id_caja = value; }
    }
}
