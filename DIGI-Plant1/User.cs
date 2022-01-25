namespace DIGI_Plant1
{
    class User : Conexion
    {
        static int id_user;
        public string name { get; set; }
        public int idemp { get; set; }
        public int Id_user { get => id_user; set => id_user = value; }
    }
}
