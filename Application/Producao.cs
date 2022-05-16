using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Producao
    {
        // Construtores
        public Producao()
        {
            Elementos = new List<char>();
        }
        public Producao(List<char> elementos)
        {
            Elementos = elementos;
        }

        // Propriedades
        private List<char> Elementos { get; set; }

        // Métodos
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
