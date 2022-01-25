using MWTrace_beta;

namespace DIGITrace
{
    class Test : Conexion
    {
        string rf;
        string current;
        string coldsoak;
        string nist;

        public string Rf { get => rf; set => rf = value; }
        public string Current { get => current; set => current = value; }
        public string Coldsoak { get => coldsoak; set => coldsoak = value; }
        public string Nist { get => nist; set => nist = value; }
    }
}
