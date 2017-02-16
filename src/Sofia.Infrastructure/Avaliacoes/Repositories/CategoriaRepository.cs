using Sofia.Domain.Avaliacoes.Entities;
using Sofia.Domain.Avaliacoes.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Sofia.Infrastructure.Avaliacoes.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        readonly AvaliacoesContext _context;

        public AvaliacaoRepository(AvaliacoesContext context)
        {
            _context = context;
        }

        public void Add(Avaliacao entity)
        {
            _context.Avaliacoes.Add(entity);
        }

        public Avaliacao Find(int id)
        {
            return _context
                .Avaliacoes
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Avaliacao Obter(int idColaborador, int idTecnologia)
        {
            return _context
                .Avaliacoes
                .Where(x => x.Colaborador.Id == idColaborador && x.Tecnologia.Id == idTecnologia)
                .FirstOrDefault();
        }

        public Colaborador ObterColaborador(int id)
        {
            return _context
               .Colaboradores
               .Where(x => x.Id == id)
               .FirstOrDefault();
        }

        public Tecnologia ObterTecnologia(int id)
        {
            return _context
               .Tecnologias
               .Where(x => x.Id == id)
               .FirstOrDefault();
        }

        public void Remove(Avaliacao entity)
        {
            _context.Avaliacoes.Remove(entity);
        }

        public void Update(Avaliacao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
