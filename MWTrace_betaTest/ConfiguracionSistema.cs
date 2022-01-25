namespace MWTrace_beta
{
    class ConfiguracionSistema : Conexion
    {
        int id_cs;
        int consecutivo;
        string nomenclatura;
        int numerocaja;
        int piezanumero;
        static string usuario;

        public int Id_cs { get => id_cs; set => id_cs = value; }
        public int Consecutivo { get => consecutivo; set => consecutivo = value; }
        public string Nomenclatura { get => nomenclatura; set => nomenclatura = value; }
        public int Numerocaja { get => numerocaja; set => numerocaja = value; }
        public int Piezanumero { get => piezanumero; set => piezanumero = value; }
        public string Usuario { get => usuario; set => usuario = value; }
    }
}
