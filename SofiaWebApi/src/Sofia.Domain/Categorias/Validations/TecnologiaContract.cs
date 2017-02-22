using Sofia.SharedKernel.Validators;
using Sofia.Domain.Categorias.Entities;
using Sofia.SharedKernel.Globalization;

namespace Sofia.Domain.Categorias.Validations
{
    public static class TecnologiaContract
    {
        public static void IsValid(this Tecnologia tecnologia)
        {
            new ValidationContract<Tecnologia>(tecnologia)
                .IsRequired(x => x.Nome, string.Format(Messages.IsRequired, nameof(Tecnologia.Nome)))
                .HasMinLenght(x => x.Nome, 3, string.Format(Messages.InvalidMinLenght, nameof(Tecnologia.Nome), 3))
                .HasMaxLenght(x => x.Nome, 50, string.Format(Messages.InvalidMaxLenght, nameof(Tecnologia.Nome), 50))
                .IsNotNull(tecnologia.Icone, string.Format(Messages.IsRequired, nameof(Tecnologia.Icone)))
                .IsNotNull(tecnologia.Categoria, string.Format(Messages.IsRequired, nameof(Tecnologia.Categoria)));
        }
    }
}
