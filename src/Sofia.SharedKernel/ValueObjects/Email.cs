using Core.Crosscutting.Domain;

namespace Sofia.SharedKernel.ValueObjects
{
    public class Email : ValueObjectBase<Email>
    {
        public Email(string email)
        {
            Endereco = email;
        }

        public string Endereco { get; private set; }
    }
}