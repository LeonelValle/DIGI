namespace MWTrace_beta
{
    class SetUp : Conexion
    {
        int id_setup;
        bool serialnumber;
        bool serialnumberCaja;
        bool mac;
        bool macCaja;
        bool imei;
        bool imeiCaja;
        bool iccid;
        bool iccidCaja;
        int id_orden;

        public int Id_setup { get => id_setup; set => id_setup = value; }
        public bool Serialnumber { get => serialnumber; set => serialnumber = value; }
        public bool SerialnumberCaja { get => serialnumberCaja; set => serialnumberCaja = value; }
        public bool Mac { get => mac; set => mac = value; }
        public bool MacCaja { get => macCaja; set => macCaja = value; }
        public bool Imei { get => imei; set => imei = value; }
        public bool ImeiCaja { get => imeiCaja; set => imeiCaja = value; }
        public int Id_orden { get => id_orden; set => id_orden = value; }
        public bool Iccid { get => iccid; set => iccid = value; }
        public bool IccidCaja { get => iccidCaja; set => iccidCaja = value; }
    }
}
