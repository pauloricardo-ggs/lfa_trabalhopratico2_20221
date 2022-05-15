using System.Collections.Generic;

namespace Application
{
    public class Producao
    {
        public Producao()
        {
            Elementos = new List<char>();
        }

        public Producao(List<char> elementos)
        {
            Elementos = elementos;
        }

        public List<char> Elementos { get; set; }
    }
}
