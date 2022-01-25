namespace MWTrace_beta
{
    class Device : Conexion
    {
        public int id_device { get; set; }
        public int count { get; set; }
        public string serialno { get; set; }
        public string mac1 { get; set; }
        public string macaddress1 { get; set; }
        public string mac2 { get; set; }
        public string macaddress2 { get; set; }
        public string deviceID { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string version { get; set; }
        public string qr { get; set; }
        public string imei { get; set; }

    }
}
