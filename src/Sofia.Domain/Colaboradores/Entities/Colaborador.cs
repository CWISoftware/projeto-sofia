using Core.Crosscutting.Domain;
using Sofia.SharedKernel.ValueObjects;

namespace Sofia.Domain.Colaboradores.Entities
{
    public class Colaborador : EntityBase<Colaborador>, IAggregateRoot
    {
        public Colaborador(Nome nome, Email email)
        {

        }

        public Nome Nome { get; private set; }
        public string Email { get; private set; }
        public Imagem Foto { get; private set; }
    }
}
