using Core.Crosscutting.Domain;
using Sofia.Domain.Categorias.Validations;
using Sofia.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace Sofia.Domain.Categorias.Entities
{
    public class Categoria : EntityBase<Categoria>, IAggregateRoot
    {
        //EF
        protected Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
            QtdTecnologias = 0;
            Versao = new Versao(Guid.NewGuid().ToByteArray());
            Tecnologias = new List<Tecnologia>();

            CategoriaContract.IsValid(this);
        }

        public string Nome { get; private set; }
        public int QtdTecnologias { get; private set; }
        public Versao Versao { get; private set; }
        public IList<Tecnologia> Tecnologias { get; private set; }

        public void Atualizar(string nome)
        {
            Nome = nome;

            CategoriaContract.IsValid(this);
        }

        public void AdicionarTecnologia(string nome, Imagem imagem)
        {
            var tecnologia = new Tecnologia(this, nome, imagem);

            AddNotifications(tecnologia.Notifications);

            if (tecnologia.IsValid())
                Tecnologias.Add(tecnologia);

            QtdTecnologias = Tecnologias.Count;
        }
    }
}
