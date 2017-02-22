using Sofia.SharedKernel.Validators;
using Sofia.Domain.Categorias.Entities;
using Sofia.SharedKernel.Globalization;

namespace Sofia.Domain.Categorias.Validations
{
    public static class CategoriaContract
    {
        public static void IsValid(this Categoria categoria)
        {
            new ValidationContract<Categoria>(categoria)
                .IsRequired(x => x.Nome, string.Format(Messages.IsRequired, nameof(categoria.Nome)))
                .HasMinLenght(x => x.Nome, 3, string.Format(Messages.InvalidMinLenght, nameof(categoria.Nome), 3))
                .HasMaxLenght(x => x.Nome, 50, string.Format(Messages.InvalidMaxLenght, nameof(categoria.Nome), 50));
        }
    }
}
