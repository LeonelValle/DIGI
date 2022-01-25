namespace IX30_Project
{
    class PN : Conexion
    {
        int id_pn;
        string pn;
        string description;
        string sku;
        string tested;
        bool test;
        string revision;
        string shortSku;
        string asb;
        public int Id_pn { get => id_pn; set => id_pn = value; }
        public string Pn { get => pn; set => pn = value; }
        public string Tested { get => tested; set => tested = value; }
        public bool Test { get => test; set => test = value; }
        public string Description { get => description; set => description = value; }
        public string Sku { get => sku; set => sku = value; }
        public string Revision { get => revision; set => revision = value; }
        public string ShortSku { get => shortSku; set => shortSku = value; }
        public string Asb { get => asb; set => asb = value; }
    }
}
