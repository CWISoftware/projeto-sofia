using Core.Crosscutting.Domain;
using Sofia.Domain.Avaliacoes.Entities;

namespace Sofia.Domain.Avaliacoes.Repositories
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        Colaborador ObterColaborador(int id);
        Tecnologia ObterTecnologia(int id);
        Avaliacao Obter(int idColaborador, int idTecnologia);
    }
}
