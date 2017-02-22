using Sofia.SharedKernel.Domain;
using Sofia.Domain.Avaliacoes.Commands.Inputs;
using Sofia.Domain.Avaliacoes.Commands.Results;
using Sofia.Domain.Avaliacoes.Entities;
using System.Collections.Generic;

namespace Sofia.Domain.Avaliacoes.Repositories
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        Colaborador ObterColaborador(int id);
        Tecnologia ObterTecnologia(int id);
        Avaliacao Obter(int idColaborador, int idTecnologia);
        IEnumerable<BuscarColaboradorPorTecnologiasResult> BuscarColaboradorPortecnologias(BuscarColaboradorPorTecnologiasCommand command);
    }
}
