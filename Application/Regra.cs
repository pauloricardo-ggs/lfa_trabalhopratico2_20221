using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Regra
    {
        public Regra()
        {
            Producoes = new List<Producao>();
        }
        public Regra(string nome, List<Producao> producoes)
        {
            Nome = nome;
            Producoes = producoes;
        }

        public string Nome { get; private set; }
        public List<Producao> Producoes { get; private set; }

        public void AdicionarProducoes(List<Producao> producoes)
        {
            Producoes.AddRange(producoes);
        }
        public bool ProduzRegras()
        {
            foreach(var producao in Producoes)
            {
                if (producao.Elementos.Count > 1) return true;
            }
            return false;
        }
        public void Imprimir(StringBuilder sb)
        {
            sb.Append(Nome + " => ");

            foreach (var producao in Producoes)
            {
                producao.Imprimir(sb);

                var ultimaProducao = Producoes.IndexOf(producao) == Producoes.Count - 1;
                if (!ultimaProducao)
                {
                    sb.Append(" | ");
                }
            }
        }
    }
}
