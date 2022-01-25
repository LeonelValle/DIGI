namespace DIGI_Sensor
{
    class Ensamble : Conexion
    {
        static int id_ensamble;
        string ensamble;

        public int Id_ensamble { get => id_ensamble; set => id_ensamble = value; }
        public string Ensambles { get => ensamble; set => ensamble = value; }
    }
}
