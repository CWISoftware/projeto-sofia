using Sofia.SharedKernel.Commands;
using Sofia.SharedKernel.Validators;
using Sofia.Domain.Categorias.Commands.Inputs;
using Sofia.Domain.Categorias.Commands.Results;
using Sofia.Domain.Categorias.Entities;
using Sofia.Domain.Categorias.Repositories;
using Sofia.SharedKernel.ValueObjects;
using System.Collections.Generic;

namespace Sofia.Domain.Categorias.Commands.Handlers
{
    public class CategoriaCommandHandler : Notifiable,
        ICommandHandler<AtualizarCategoriaCommand>,
        ICommandHandler<CriarCategoriaCommand>,
        ICommandHandler<ExcluirCategoriaCommand>,
        ICommandHandler<AdicionarTecnologiaCommand>
    {

        readonly ICategoriaRepository _categoriaRepository;
        public Categoria Result { get; private set; }

        public CategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Handle(ExcluirCategoriaCommand command)
        {
            var categoria = _categoriaRepository.Find(command.Id);

            _categoriaRepository.Remove(categoria);
        }

        public void Handle(CriarCategoriaCommand command)
        {
            var categoria = new Categoria(command.Nome);

            _categoriaRepository.Add(categoria);

            Result = categoria;

            AddNotifications(categoria.Notifications);
        }

        public void Handle(AtualizarCategoriaCommand command)
        {
            var categoria = _categoriaRepository.Find(command.Id);

            categoria.Atualizar(command.Nome);

            AddNotifications(categoria.Notifications);
        }

        public void Handle(AdicionarTecnologiaCommand command)
        {
            var categoria = _categoriaRepository.Find(command.IdCategoria);

            categoria.AdicionarTecnologia(command.Tecnologia, new Imagem(command.IconeUrl));

            _categoriaRepository.Update(categoria);

            Result = categoria;
        }
    }
}
