using Sofia.SharedKernel.Commands;

namespace Sofia.Domain.Categorias.Commands.Inputs
{
    public class AtualizarCategoriaCommand : ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
