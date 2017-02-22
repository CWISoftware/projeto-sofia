using Sofia.SharedKernel.Domain;
using Sofia.Domain.Categorias.Validations;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Categorias.Entities
{
    public class Tecnologia : EntityBase<Tecnologia>
    {
        //EF
        protected Tecnologia() { }

        public Tecnologia(Categoria categoria, string nome, Imagem icone)
        {
            Nome = nome;
            Categoria = categoria;
            Icone = icone;

            TecnologiaContract.IsValid(this);
        }

        public string Nome { get; private set; }
        public Categoria Categoria { get; private set; }
        public Imagem Icone { get; private set; }
    }
}
