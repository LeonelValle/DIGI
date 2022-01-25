namespace MWTrace_beta
{
    class Ensamble : Conexion
    {
        int id_ensamble;
        string ensambles;
        string tested;
        bool test;
        public int Id_ensamble { get => id_ensamble; set => id_ensamble = value; }
        public string Ensambles { get => ensambles; set => ensambles = value; }
        public string Tested { get => tested; set => tested = value; }
        public bool Test { get => test; set => test = value; }
    }
}
