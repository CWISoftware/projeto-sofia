using Core.Crosscutting.Domain;
using Sofia.Domain.Avaliacoes.Commands;
using Sofia.Domain.Avaliacoes.Entities;
using Sofia.Domain.Avaliacoes.Queries;
using System.Collections.Generic;

namespace Sofia.Domain.Avaliacoes.Repositories
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        Colaborador ObterColaborador(int id);
        Tecnologia ObterTecnologia(int id);
        Avaliacao Obter(int idColaborador, int idTecnologia);
        IEnumerable<ColaboradorViewModel> Retrieve(PesquisarPorTecnologiasCommand query);
    }
}
