using Core.Crosscutting.Commands;

namespace Sofia.Domain.Categorias.Commands
{
    public class ExcluirCategoriaCommand : ICommand
    {
        public int Id { get; set; }
    }
}
