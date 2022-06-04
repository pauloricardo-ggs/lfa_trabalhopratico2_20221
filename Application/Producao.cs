using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class Producao
    {
        public Producao()
        {
            Elementos = new List<char>();
        }
        public Producao(string producaoString)
        {
            ProducaoString = producaoString;
            Elementos = producaoString.ToList();
        }

        public string ProducaoString { get; private set; }
        public List<char> Elementos { get; private set; }

        public StringBuilder Imprimir(StringBuilder sb)
        {
            sb.Append(ProducaoString);
            return sb;
        }
    }
}
