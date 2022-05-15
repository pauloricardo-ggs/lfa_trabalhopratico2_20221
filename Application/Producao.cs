using System;
using System.Collections.Generic;
using System.Text;

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

        private List<char> Elementos { get; set; }

        public StringBuilder Imprimir(StringBuilder sb)
        {
            foreach (var elemento in Elementos)
            {
                sb.Append(elemento.ToString());
            }

            return sb;
        }
    }
}
