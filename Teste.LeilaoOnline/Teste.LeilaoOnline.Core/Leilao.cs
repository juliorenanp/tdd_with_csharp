using System.Collections.Generic;
using System.Linq;

namespace Teste.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoEmAndamento,
        LeilaoFinalizado,
        LeilaoAntesPregao
    }

    public class Leilao
    {
        private Interessada _ultimoCliente;
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }

        public EstadoLeilao Estado{ get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesPregao;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(Estado == EstadoLeilao.LeilaoEmAndamento)
            {
                if(NovoLanceAceito(cliente, valor))
                {
                    _lances.Add(new Lance(cliente, valor));
                    _ultimoCliente = cliente;
                }
            }
        }

        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilao.LeilaoEmAndamento) && (cliente != _ultimoCliente);
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if(Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new System.InvalidOperationException("Não é possível terminar o pregão sem ele ter começado. Use o método IniciaPregao() para corrigir");
            }
            
            Ganhador = Lances.OrderBy(l => l.Valor).DefaultIfEmpty(new Lance(null,0)).LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
