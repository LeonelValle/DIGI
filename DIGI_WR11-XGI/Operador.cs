namespace DIGI_WR11_XGI
{
    class Operador : Conexion
    {
        static int id_user;
        string name;
        static int idemp;

        public int Id_user { get => id_user; set => id_user = value; }
        public string Name { get => name; set => name = value; }
        public int Idemp { get => idemp; set => idemp = value; }
    }
}
