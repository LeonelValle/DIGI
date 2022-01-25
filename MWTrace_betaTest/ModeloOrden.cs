namespace MWTrace_beta
{
    class ModeloOrden : Conexion
    {
        int id_modeloOrden;
        string scanmac;
        string scanimei;
        string serialnumber;
        int id_Orden;
        bool checkeded;
        int id_caja;
        string fecharegistro;
        string turno;
        string revision;

        public int Id_modeloOrden { get => id_modeloOrden; set => id_modeloOrden = value; }
        public string Scanmac { get => scanmac; set => scanmac = value; }
        public string Scanimei { get => scanimei; set => scanimei = value; }
        public string Serialnumber { get => serialnumber; set => serialnumber = value; }
        public int Id_Orden { get => id_Orden; set => id_Orden = value; }
        public bool Checkeded { get => checkeded; set => checkeded = value; }
        public int Id_caja { get => id_caja; set => id_caja = value; }
        public string Fecharegistro { get => fecharegistro; set => fecharegistro = value; }
        public string Turno { get => turno; set => turno = value; }
        public string Revision { get => revision; set => revision = value; }





    }
}
