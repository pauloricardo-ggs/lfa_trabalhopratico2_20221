using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gramatica = CriarGramatica();
            Console.WriteLine(gramatica.Imprimir());
            Console.ReadLine();
        }

        public static Gramatica CriarGramatica()
        {
            var gramatica = new Gramatica();

            foreach (var linha in LinhasDoArquivo())
            {
                var regras = FormatarRegra(linha);
                var nome = regras[0];

                var producoes = new List<Producao>();

                foreach (var producaoInteira in SepararProducoes(regras))
                {
                    producoes.Add(new Producao(producaoInteira.ToCharArray().ToList()));
                }

                var indexRegra = gramatica.ContemNomeRegra(nome);
                if (indexRegra == -1)
                {
                    gramatica.AdicionarRegra(nome, producoes);
                }
                else
                {
                    gramatica.AdicionarProducaoARegra(indexRegra, producoes);
                }
            }

            return gramatica;
        }

        private static List<string> SepararProducoes(List<string> regras)
        {
            return (regras[1].Split("|").ToList());
        }
        private static List<string> FormatarRegra(string linha)
        {
            var linhaFormatada = linha.Replace(" ", "").Replace(">", "");
            return linhaFormatada.Split("=").ToList();
        }
        private static string[] LinhasDoArquivo()
        {
            var caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            return File.ReadAllLines($@"{caminho}\Gramatica.txt");
        }

    }
}
