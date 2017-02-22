using Core.Crosscutting.Commands;

namespace Sofia.Domain.Categorias.Commands.Inputs
{
    public class AdicionarTecnologiaCommand : ICommand
    {
        public int IdCategoria { get; set; }
        public string Tecnologia { get; set; }
        public string IconeUrl { get; set; }
    }
}
