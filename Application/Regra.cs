using System;
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

        private string Nome { get; set; }
        private List<Producao> Producoes { get; set; }

        public string GetNome()
        {
            return Nome;
        }
        public void AdicionarProducoes(List<Producao> producoes)
        {
            Producoes.AddRange(producoes);
        }
        public void Imprimir(StringBuilder sb)
        {
            sb.Append(Nome + " => ");

            foreach (var producao in Producoes)
            {
                producao.Imprimir(sb);
                if (Producoes.IndexOf(producao) != Producoes.Count-1)
                {
                    sb.Append(" | ");
                }
            }
        }
    }
}
