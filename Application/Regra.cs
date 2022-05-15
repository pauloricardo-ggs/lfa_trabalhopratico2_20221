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

        public string Nome { get; set; }
        public List<Producao> Producoes { get; set; }

        public void AdicionarProducoes(List<Producao> producoes)
        {
            Producoes.AddRange(producoes);
        }
    }
}
