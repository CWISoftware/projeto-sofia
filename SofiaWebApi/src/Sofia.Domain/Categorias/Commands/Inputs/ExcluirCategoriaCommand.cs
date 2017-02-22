using Sofia.SharedKernel.Commands;

namespace Sofia.Domain.Categorias.Commands.Inputs
{
    public class ExcluirCategoriaCommand : ICommand
    {
        public int Id { get; set; }
    }
}
