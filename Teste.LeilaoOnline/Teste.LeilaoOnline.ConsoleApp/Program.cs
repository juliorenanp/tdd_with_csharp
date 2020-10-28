
using System;
using Teste.LeilaoOnline.Core;

namespace Teste.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void LeilaoComVariosLances()
        {
            // A - Arranje - cenário
            var leilao = new Leilao("Bleach");
            var pessoa = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Ichigo", leilao);


            leilao.RecebeLance(pessoa, 800);
            leilao.RecebeLance(pessoa2, 900);
            leilao.RecebeLance(pessoa, 1000);
            leilao.RecebeLance(pessoa2, 900);

            // Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);

        }

        private static void LeilaoComApenasUmLance()
        {
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);

            leilao.RecebeLance(pessoa, 800);

            // Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        
        }

        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;

            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TESTE FALHOU! Esperado {esperado}, obtido {obtido}");
            }

            Console.ForegroundColor = cor;

        }


        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
