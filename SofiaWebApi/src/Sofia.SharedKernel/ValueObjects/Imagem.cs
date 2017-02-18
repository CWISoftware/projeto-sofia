using Core.Crosscutting.Domain;

namespace Sofia.SharedKernel.ValueObjects
{
    public class Imagem : ValueObjectBase<Imagem>
    {
        public Imagem(string url)
        {
            Url = url;
        }

        public string Url { get; private set; }
    }
}