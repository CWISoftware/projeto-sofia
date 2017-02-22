using Sofia.Domain.Categorias.Commands.Results;
using Sofia.Domain.Categorias.Entities;
using Sofia.Domain.Categorias.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sofia.Infrastructure.Categorias.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        readonly CategoriasContext _context;

        public CategoriaRepository(CategoriasContext context)
        {
            _context = context;
        }

        public void Add(Categoria entity)
        {
            _context.Categorias.Add(entity);
        }

        public Categoria Find(int id)
        {
            return _context
                .Categorias
                .Include(x => x.Tecnologias)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<ListarCategoriasResult> ListarCategorias()
        {
            return _context
                .Categorias
                .AsNoTracking()
                .Select(x => new ListarCategoriasResult()
                {
                    Id = x.Id,
                    Nome = x.Nome
                })
                .ToList();
        }

        public void Remove(Categoria entity)
        {
            _context.Categorias.Remove(entity);
        }

        public void Update(Categoria entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
