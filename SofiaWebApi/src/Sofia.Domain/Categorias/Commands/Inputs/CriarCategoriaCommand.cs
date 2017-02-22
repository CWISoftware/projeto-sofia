using Core.Crosscutting.Commands;

namespace Sofia.Domain.Categorias.Commands.Inputs
{
    public class CriarCategoriaCommand : ICommand
    {
        public string Nome { get; set; }
    }
}
