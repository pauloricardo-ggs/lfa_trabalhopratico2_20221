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
            var caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var linhas = File.ReadAllLines($@"{caminho}\Gramatica.txt");

            var gramatica = new Gramatica();

            foreach(var linha in linhas)
            {
                var linhaFormatada = linha.Replace(" ", "").Replace(">", "");
                var regraInteira = linhaFormatada.Split("=").ToList();

                var nome = regraInteira[0];
                
                var producoesInteiras = (regraInteira[1].Split("|").ToList());
                var producoes = new List<Producao>();
                foreach(var producaoInteira in producoesInteiras)
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
    }
}
