﻿using System.Collections.Generic;
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
                _lances.Add(new Lance(cliente, valor));
            }
            
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            Ganhador = Lances.OrderBy(l => l.Valor).DefaultIfEmpty(new Lance(null,0)).LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
