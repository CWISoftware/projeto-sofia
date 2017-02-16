using Core.Crosscutting.Domain;

namespace Sofia.SharedKernel.ValueObjects
{
    public class Nome : ValueObjectBase<Nome>
    {
        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = sobrenome;
        }

        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
    }
}