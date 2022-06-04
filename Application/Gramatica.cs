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

        public  List<Regra> Regras { get; private set; }
    
        public void AdicionarRegra(string nome, List<Producao> producoes)
        {
            Regras.Add(new Regra(nome, producoes));
        }
        public Regra ObterRegra(string nome)
        {
            foreach (var regra in Regras)
            {
                if (regra.Nome == nome) return regra;
            }
            return null;
        }
        public List<Regra> ObterRegras(string producao)
        {
            var regras = new List<Regra>();
            foreach (var regra in Regras)
            {
                foreach (var prod in regra.Producoes)
                {
                    if (prod.ProducaoString.Equals(producao)) regras.Add(regra);
                }
            }
            return regras;
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
