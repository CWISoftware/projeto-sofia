using Core.Crosscutting.Domain;
using Sofia.Domain.Categorias.Validations;

namespace Sofia.Domain.Categorias.Entities
{
    public class Categoria : EntityBase<Categoria>, IAggregateRoot
    {
        public Categoria(string nome)
        {
            Nome = nome;

            CategoriaContract.IsValid(this);
        }

        public string Nome { get; private set; }

        public void Atualizar(string nome)
        {
            Nome = nome;

            CategoriaContract.IsValid(this);
        }
    }
}
