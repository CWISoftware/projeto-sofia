using Sofia.SharedKernel.Commands;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Avaliacoes.Commands.Inputs
{
    public class AvaliarNovaTecnologiaCommand : ICommand
    {
        public string Tecnologia { get; set; }
        public int IdCategoria { get; set; }
        public int IdColaborador { get; set; }
        public Nivel Nivel { get; set; }
        public string IconeUrl { get; set; }
    }
}
