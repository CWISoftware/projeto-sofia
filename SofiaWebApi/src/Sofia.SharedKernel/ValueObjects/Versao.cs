using Sofia.SharedKernel.Domain;

namespace Sofia.SharedKernel.ValueObjects
{
    public class Versao : ValueObjectBase<Versao>
    {
        //EF
        protected Versao() { }

        public Versao(byte[] numero)
        {
            Numero = numero;
        }

        public byte[] Numero { get; private set; }
    }
}