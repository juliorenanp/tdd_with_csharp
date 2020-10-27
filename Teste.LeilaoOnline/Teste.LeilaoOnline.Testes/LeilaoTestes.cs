using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Teste.LeilaoOnline.Testes
{
   public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            // A - Arranje - cenário
            // Give When Then
            // Dado leilão com 3 clientes e lances realizados 
            var leilao = new Leilao("Van Gogh");
            var pessoa1 = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Ichigo", leilao);
            var pessoa3 = new Interessada("Inoe", leilao);


            leilao.RecebeLance(pessoa1, 1400);
            leilao.RecebeLance(pessoa3, 900);
            leilao.RecebeLance(pessoa2, 1000);
            leilao.RecebeLance(pessoa1, 1100);

            // Act - método sob teste
            // Ao acabar o pregão termina
            leilao.TerminaPregao();

            //Assert 
            // Então o valor esperado é o maior valor/lance.
            // O Ganhador deverá ser o cliente com o maior lance.
            var valorEsperado = 1400;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(pessoa1, leilao.Ganhador.Cliente);

        }

        [Fact]
        public void LeilaoComLancesOrdenadosPorValor()
        {
            // A - Arranje - cenário
            // Leilão com lances ordenados por valor
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Ichigo", leilao);


            leilao.RecebeLance(pessoa, 800);
            leilao.RecebeLance(pessoa2, 900);
            leilao.RecebeLance(pessoa, 1000);
            leilao.RecebeLance(pessoa2, 900);


            // Act - método sob teste
            // Quando o pregão ser finalizado
            leilao.TerminaPregao();

            //Assert 
            // Então o valor esperado é o maior valor
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);


        }

        [Fact]
        public void LeilaoComVariosLances()
        {
            // A - Arranje - cenário
            // Leilão com vários lances sem ordem de valor
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Ichigo", leilao);


            leilao.RecebeLance(pessoa, 800);
            leilao.RecebeLance(pessoa2, 900);
            leilao.RecebeLance(pessoa, 1000);
            leilao.RecebeLance(pessoa2, 900);

            // Act - método sob teste
            // Quando o pregão terminar
            leilao.TerminaPregao();

            //Assert 
            // O ganhador deverá ser o cliente com maior valor
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
        [Fact]
        public void LeilaoComApenasUmLance()
        {
            // Arranje - Cenário
            // Dado leilão apenas com 1 lance
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);

            leilao.RecebeLance(pessoa, 800);

            // Act - método sob teste
            // Quando o leilão acabar
            leilao.TerminaPregao();

            //Assert 
            // Então o valor esperado é o maior valor
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
    }
}
