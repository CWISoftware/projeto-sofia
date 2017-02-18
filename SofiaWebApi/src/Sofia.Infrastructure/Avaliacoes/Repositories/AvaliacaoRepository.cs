using Sofia.Domain.Avaliacoes.Commands;
using Sofia.Domain.Avaliacoes.Entities;
using Sofia.Domain.Avaliacoes.Queries;
using Sofia.Domain.Avaliacoes.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using Sofia.SharedKernel.Services;
using Core.Crosscutting.Runtime;

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

        public IEnumerable<ColaboradorViewModel> Retrieve(PesquisarPorTecnologiasCommand query)
        {
            var dic = new Dictionary<int, ColaboradorViewModel>();

            var sql = @"SELECT
                    ColaboradorId Id
	                ,ColaboradorNome Nome
	                ,TecnologiaNome Nome
	                ,TecnologiaIcone Icone
	                ,TecnologiaNivel Nivel
                  FROM [sofia].[vwBuscarNivelColaboradorPorTecnologia]
                  WHERE TecnologiaNome LIKE @tecnologia";

            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return
                    conn.Query<ColaboradorViewModel, TecnologiaViewModel, ColaboradorViewModel>(sql,
                    param: new { tecnologia = query.Texto ?? "%" },
                    splitOn: "Nome",
                    map: (colaboradorIn, tecnologiaIn) =>
                 {
                     ColaboradorViewModel colaborador;

                     tecnologiaIn.NivelPorExtenso = NivelPorExtenso.ConverterParaTerceiraPessoa(tecnologiaIn.Nivel);

                     if (!dic.TryGetValue(colaboradorIn.Id, out colaborador))
                     {
                         dic.Add(colaboradorIn.Id, colaboradorIn);
                         colaborador = colaboradorIn;
                     }

                     colaborador.Tecnologias.Add(tecnologiaIn);

                     return colaborador;
                 }).Distinct();
            }
        }
    }
}
