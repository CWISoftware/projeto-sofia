using Core.Crosscutting.Commands;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Avaliacoes.Commands.Inputs
{
    public class AtualizarNivelCommand : ICommand
    {
        public int IdColaborador { get; set; }
        public int IdTecnologia { get; set; }
        public Nivel Nivel { get; set; }
    }
}