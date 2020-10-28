using System.Linq;

namespace Teste.LeilaoOnline.Core
{
    public class MaiorValor : IModalidadeAvaliacao
    {
        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                .OrderBy(l => l.Valor)
                .DefaultIfEmpty(new Lance(null, 0))
                .LastOrDefault();
        }
    }
}
