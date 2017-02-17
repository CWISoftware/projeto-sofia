using Core.Crosscutting.Commands;
using Core.Crosscutting.Validators;
using Sofia.Domain.Categorias.Entities;
using Sofia.Domain.Categorias.Queries;
using Sofia.Domain.Categorias.Repositories;
using System.Collections.Generic;

namespace Sofia.Domain.Categorias.Commands
{
    public class CategoriaCommandHandler : Notifiable,
        ICommandHandler<AtualizarCategoriaCommand>,
        ICommandHandler<CriarCategoriaCommand>,
        ICommandHandler<ExcluirCategoriaCommand>,
        IQueryHandler<EmptyParameter, IEnumerable<CategoriaViewModel>>
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

        public IEnumerable<CategoriaViewModel> Retrieve(EmptyParameter query)
        {
            return _categoriaRepository.ListarCategorias();
        }
    }
}
