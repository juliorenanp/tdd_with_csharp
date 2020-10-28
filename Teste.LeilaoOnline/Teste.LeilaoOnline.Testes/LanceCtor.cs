using Teste.LeilaoOnline.Core;
using Xunit;

namespace Teste.LeilaoOnline.Testes
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            // Arranje
            var valorNegativo = -100;

            // Assert
            Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo));
        }
    }
}
