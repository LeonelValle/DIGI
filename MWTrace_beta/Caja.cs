using System.Collections.Generic;

namespace MWTrace_beta
{
    public class Caja : Conexion
    {
        int id_caja;
        int cajas;
        int top;
        int count;
        bool parcial;
        int oldid;

        public int Id_caja { get => id_caja; set => id_caja = value; }
        public int Cajas { get => cajas; set => cajas = value; }
        public int Top { get => top; set => top = value; }
        public int Count { get => count; set => count = value; }
        public bool Parcial { get => parcial; set => parcial = value; }
        public int Oldid { get => oldid; set => oldid = value; }
    }
}
