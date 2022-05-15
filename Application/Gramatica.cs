using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class Gramatica
    {
        public Gramatica()
        {
            Regras = new List<Regra>();
        }

        private List<Regra> Regras { get; set; }
    
        public void AdicionarRegra(string nome, List<Producao> producoes)
        {
            Regras.Add(new Regra(nome, producoes));
        }
        public int ContemNomeRegra(string nome)
        {
            foreach (var regra in Regras)
            {
                if(regra.GetNome() == nome)
                {
                    return Regras.IndexOf(regra);
                }
            }

            return -1;
        }
        public void AdicionarProducaoARegra(int indexRegra, List<Producao> producoes)
        {
            Regras[indexRegra].AdicionarProducoes(producoes);
        }
        public string Imprimir()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var regra in Regras)
            {
                regra.Imprimir(sb);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
