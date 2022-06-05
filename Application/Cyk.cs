using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class Cyk
    {
        public Cyk(Gramatica gramatica)
        {
            Gramatica = gramatica;
        }

        public Gramatica Gramatica { get; private set; }
        public string PalavraInteira { get; private set; }
        public char[] Palavra { get; private set; }
        public int N { get; private set; }
        public List<Regra>[,] Tabela { get; private set; }

        public bool TestarPalavra(string palavra)
        {
            FormatarPalavra(palavra);

            for (int j = 1; j <= N; j++)
            {
                var regras = Gramatica.ObterRegras(Palavra[j-1].ToString());
                if (regras.Any())
                {
                    Tabela[1, j] = regras;
                }
            }

            for (int i = 2; i <= N; i++)
            {
                for (int j = 1; j <= N-i+1; j++)
                {
                    for (int k = 1; k <= i-1; k++)
                    {
                        // Para cada regra que possui uma producao do estilo X => YZ
                        foreach (var regra in Gramatica.Regras)
                        {
                            foreach(var producao in regra.Producoes.Where(producao => producao.Elementos.Count > 1))
                            {
                                var Y = Gramatica.ObterRegra(producao.Elementos[0].ToString());
                                var Z = Gramatica.ObterRegra(producao.Elementos[1].ToString());

                                if (Tabela[k, j].Contains(Y) && Tabela[i-k, j+k].Contains(Z))
                                {
                                    Tabela[i, j].Add(regra);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (Tabela[N, 1].Contains(Gramatica.ObterRegra("S"))) return true;
            return false;
        }
        public void FormatarPalavra(string palavra)
        {
            PalavraInteira = palavra;
            Palavra = palavra.ToCharArray();

            N = Palavra.Length;
            Tabela = new List<Regra>[N+1, N+1];
            for(int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N-i+1; j++)
                {
                    Tabela[i, j] = new List<Regra>();
                }
            }
        }
    }
}
