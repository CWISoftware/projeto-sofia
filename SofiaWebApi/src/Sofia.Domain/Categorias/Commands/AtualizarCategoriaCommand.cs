using Core.Crosscutting.Commands;

namespace Sofia.Domain.Categorias.Commands
{
    public class AtualizarCategoriaCommand : ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
