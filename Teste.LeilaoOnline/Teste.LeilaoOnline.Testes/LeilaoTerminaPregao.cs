﻿using Teste.LeilaoOnline.Core;
using Xunit;

namespace Teste.LeilaoOnline.Testes
{
    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1100, new double[] { 800, 900, 1000, 1100 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800,new double[] { 800 })]
        public void RetonaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            // A - Arranje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var pessoa1 = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Kurosaki", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(pessoa1, valor);
                }
                else
                {
                    leilao.RecebeLance(pessoa2, valor);
                }
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
        public void RetonaZeroDadoLeilaoSemLances()
        {
            // Arranje - Cenário
            // Dado leilão apenas com 1 lance
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            leilao.IniciaPregao();

            // Act - método sob teste
            // Quando o leilão acabar
            leilao.TerminaPregao();

            //Assert 
            // Então o valor esperado é o maior valor
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            // Arranje - Cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Bleach", modalidade);

            // Forma Deselegante
            //try
            //{
            //    // Act - método sob teste
            //    leilao.TerminaPregao();

            //    //Se a linha acima der certo, a próxima falhará;
            //    Assert.True(false);
            //}
            //catch (System.Exception e)
            //{
            //    //Assert 
            //    Assert.IsType<System.InvalidOperationException>(e);
            //}

            // Forma Elegante
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(() => leilao.TerminaPregao());

            var msgEsperada = "Não é possível terminar o pregão sem ele ter começado. Use o método IniciaPregao() para corrigir";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }

        [Theory]
        [InlineData(1600 ,1650, new double[] { 800, 1400, 1650 , 3000})]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperado, double[] ofertas)
        {
            // Arranje - Cenário
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);


            var leilao = new Leilao("Bleach", modalidade);
            var pessoa1 = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Kurosaki", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(pessoa1, valor);
                }
                else
                {
                    leilao.RecebeLance(pessoa2, valor);
                }
            }
            // Act - método sob teste
            leilao.TerminaPregao();

            Assert.Equal(valorEsperado,leilao.Ganhador.Valor);
        }
    }
}
