using Core.Crosscutting.Domain;
using Core.Crosscutting.Validators;
using Sofia.SharedKernel.Globalization;

namespace Sofia.SharedKernel.ValueObjects
{
    public class NomePessoa : ValueObjectBase<NomePessoa>
    {
        public NomePessoa(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;

            new ValidationContract<NomePessoa>(this)
                .IsRequired(x => x.NomeCompleto, string.Format(Messages.IsRequired, nameof(NomeCompleto)))
                .HasMinLenght(x => x.NomeCompleto, 3, string.Format(Messages.InvalidMinLenght, nameof(NomeCompleto), 3))
                .HasMaxLenght(x => x.NomeCompleto, 256, string.Format(Messages.InvalidMaxLenght, nameof(NomeCompleto), 256));
        }

        public string NomeCompleto { get; private set; }
    }
}