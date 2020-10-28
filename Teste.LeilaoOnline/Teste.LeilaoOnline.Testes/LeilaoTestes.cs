using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Teste.LeilaoOnline.Testes
{
   public class LeilaoTestes
    {

        [Theory]
        [InlineData(1100, new double[] { 800, 900, 1000, 1100 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800,new double[] { 800 })]
        public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            // A - Arranje - cenário
            // Leilão com vários lances sem ordem de valor
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Ichigo", leilao);


            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(pessoa, valor);
            }

            // Act - método sob teste
            // Quando o pregão terminar
            leilao.TerminaPregao();

            //Assert 
            // O ganhador deverá ser o cliente com maior valor
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }

        [Fact]
        public void LeilaoSemLances()
        {
            // Arranje - Cenário
            // Dado leilão apenas com 1 lance
            var leilao = new Leilao("Van Gogh");

            // Act - método sob teste
            // Quando o leilão acabar
            leilao.TerminaPregao();

            //Assert 
            // Então o valor esperado é o maior valor
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
