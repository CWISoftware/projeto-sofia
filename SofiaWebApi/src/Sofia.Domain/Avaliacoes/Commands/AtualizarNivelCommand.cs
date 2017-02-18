using Core.Crosscutting.Commands;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Avaliacoes.Commands
{
    public class AtualizarNivelCommand : ICommand
    {
        public int IdColaborador { get; set; }
        public int IdTecnologia { get; set; }
        public Nivel Conceito { get; set; }
    }
}