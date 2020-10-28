using Teste.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Teste.LeilaoOnline.Testes
{
    public class LeilaoRecebeOferta
    {

        [Theory]
        [InlineData(4, new double[] { 222, 1440, 1555, 8000})]
        [InlineData(2, new double[] {800,900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            // Arranje - Cenário
            // Dado leilão apenas com 1 lance
            var leilao = new Leilao("Van Gogh");
            var pessoa1 = new Interessada("Zaraki", leilao);
            
            leilao.IniciaPregao();

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(pessoa1, valor);
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
