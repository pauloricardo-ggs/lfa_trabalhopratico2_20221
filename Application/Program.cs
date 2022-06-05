using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application
{
    internal class Program
    {
        private static Gramatica Gramatica { get; set; }
        private static Cyk Cyk { get; set; }

        static void Main(string[] args)
        {
            Gramatica = CriarGramatica();
            Cyk = new Cyk(Gramatica);

            Loop();

            Console.WriteLine("hello world");
        }

        public static void Loop()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    var palavra = SolicitarPalavra();

                    if (palavra == "=") break;
                    TestarPalavra(palavra);
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\nUm erro inesperado do tipo '{exception.Message}' aconteceu.");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Pressione qualquer tecla testar outra palavra.");

                Console.ReadKey();
            }
        }
        public static string SolicitarPalavra()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Gramatica.Imprimir() + "\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Insira a palavra de teste ('=' para sair): ");
            return Console.ReadLine();
        }
        public static void TestarPalavra(string palavra)
        {
            if (Cyk.TestarPalavra(palavra))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nA palavra {palavra} é aceita pela gramática.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nA palavra {palavra} não é aceita pela gramática.");
        }
        public static Gramatica CriarGramatica()
        {
            var gramatica = new Gramatica();

            foreach (var linha in LinhasDoArquivo())
            {
                var regras = FormatarRegra(linha);
                var nome = regras[0];

                var producoes = new List<Producao>();

                foreach (var producao in SepararProducoes(regras))
                {
                    producoes.Add(new Producao(producao));
                }

                var regra = gramatica.ObterRegra(nome);
                if (regra == null)
                {
                    gramatica.AdicionarRegra(nome, producoes);
                }
                else
                {
                    regra.AdicionarProducoes(producoes);
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
