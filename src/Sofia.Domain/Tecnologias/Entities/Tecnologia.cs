using Core.Crosscutting.Domain;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Tecnologias.Entities
{
    public class Tecnologia : EntityBase<Tecnologia>, IAggregateRoot
    {
        public Tecnologia(string nome, Categoria categoria, Imagem icone)
        {
            Nome = nome;
            Categoria = categoria;
            Icone = icone;
        }

        public string Nome { get; private set; }
        public Categoria Categoria { get; private set; }
        public Imagem Icone { get; private set; }
    }
}
