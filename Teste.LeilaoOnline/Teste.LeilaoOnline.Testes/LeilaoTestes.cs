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
        public void LeilaoComVariosLances()
        {
            // A - Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Ichigo", leilao);


            leilao.RecebeLance(pessoa, 800);
            leilao.RecebeLance(pessoa2, 900);
            leilao.RecebeLance(pessoa, 1000);
            leilao.RecebeLance(pessoa2, 900);

            // Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
        [Fact]
        public void LeilaoComApenasUmLance()
        {
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Zaraki", leilao);

            leilao.RecebeLance(pessoa, 800);

            // Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
    }
}
