using Teste.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Teste.LeilaoOnline.Testes
{
    public class LeilaoRecebeOferta
    {

        [Fact]
        public void NaoAceitaProximoLanceDadoOMesmoCliente()
        {
            // Arranje - Cenário
            var leilao = new Leilao("Bleach");
            var pessoa1 = new Interessada("Zaraki", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(pessoa1, 500);
            

            // Act - método sob teste
            leilao.RecebeLance(pessoa1, 1000);

            //Assert 
            var qtdEsperada= 1;
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }

        [Theory]
        [InlineData(4, new double[] { 222, 1440, 1555, 8000})]
        [InlineData(2, new double[] {800,900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            // Arranje - Cenário
            // Dado leilão apenas com 1 lance
            var leilao = new Leilao("Bleach");
            var pessoa1 = new Interessada("Zaraki", leilao);
            var pessoa2 = new Interessada("Kurosaki", leilao);
            
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i%2)== 0)
                {
                    leilao.RecebeLance(pessoa1, valor);
                }
                else
                {
                    leilao.RecebeLance(pessoa2, valor);
                }
            }
           
            leilao.TerminaPregao();

            // Act - método sob teste
            // Quando o leilão acabar
            leilao.RecebeLance(pessoa1, 1000);

            //Assert 
            // Então o valor esperado é o maior valor
            var qtdeObtida = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtida);
        }


    }
}
