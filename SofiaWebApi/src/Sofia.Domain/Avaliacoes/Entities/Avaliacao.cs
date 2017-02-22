using Sofia.SharedKernel.Domain;
using Sofia.SharedKernel.ValueObjects;
using System;

namespace Sofia.Domain.Avaliacoes.Entities
{
    public class Avaliacao : EntityBase<Avaliacao>, IAggregateRoot
    {
        //EF
        protected Avaliacao() { }

        public Avaliacao(Colaborador colaborador, Tecnologia tecnologia, Nivel conceito)
        {
            Colaborador = colaborador;
            Nivel = Nivel;
            Tecnologia = tecnologia;
            AvaliadoEm = DateTime.UtcNow;
        }

        public Colaborador Colaborador { get; private set; }
        public Nivel Nivel { get; private set; }
        public Tecnologia Tecnologia { get; private set; }
        public DateTime AvaliadoEm { get; private set; }

        public void MudarAvaliacao(Nivel conceito)
        {
            Nivel = Nivel;
            AvaliadoEm = DateTime.UtcNow;
        }
    }
}