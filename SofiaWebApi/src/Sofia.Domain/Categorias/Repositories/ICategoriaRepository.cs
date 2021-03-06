﻿using Sofia.Domain.Categorias.Commands.Results;
using Sofia.Domain.Categorias.Entities;
using Sofia.SharedKernel.Domain;
using System.Collections.Generic;

namespace Sofia.Domain.Categorias.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        IEnumerable<ListarCategoriasResult> ListarCategorias();
        IList<ObterTotalizadorCategoriasResult> ObterTotalizadorCategorias();
    }
}
