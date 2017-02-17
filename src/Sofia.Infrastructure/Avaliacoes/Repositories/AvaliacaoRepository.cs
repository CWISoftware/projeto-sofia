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

            using (var conn = new SqlConnection(_context.Database.Connection.ConnectionString))
            {
                conn.Open();
                return
                    conn.Query<ColaboradorViewModel, TecnologiaViewModel, ColaboradorViewModel>(sql,
                    param: new { tecnologia = query.Texto ?? "%" },
                    splitOn: "Nome",
                    map: (pColaborador, pTecnologia) =>
                 {
                     ColaboradorViewModel colaborador;

                     pTecnologia.NivelPorExtenso = NivelPorExtenso.ConverterParaTerceiraPessoa(pTecnologia.Nivel);

                     if (dic.TryGetValue(pColaborador.Id, out colaborador))
                         colaborador.Tecnologias.Add(pTecnologia);
                     else
                     {
                         colaborador = pColaborador;
                         colaborador.Tecnologias.Add(pTecnologia);
                         dic.Add(pColaborador.Id, pColaborador);
                     }

                     return colaborador;
                 });
            }
        }
    }
}
