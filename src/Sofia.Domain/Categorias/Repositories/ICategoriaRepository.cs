using Sofia.Domain.Categorias.Entities;
using Sofia.Domain.Categorias.Queries;
using Core.Crosscutting.Domain;
using System.Collections.Generic;

namespace Sofia.Domain.Categorias.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        IEnumerable<CategoriaViewModel> ListarCategorias();
    }
}
