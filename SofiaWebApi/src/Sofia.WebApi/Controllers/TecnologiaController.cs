using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Avaliacoes.Commands.Handlers;
using Sofia.Domain.Avaliacoes.Commands.Inputs;
using Sofia.Domain.Categorias.Commands.Handlers;
using Sofia.Domain.Categorias.Commands.Inputs;
using Sofia.Infrastructure.Avaliacoes;
using Sofia.Infrastructure.Categorias;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Sofia.WebApi.Controllers
{
    [Route("v1/tecnologias")]
    public class TecnologiaController : ControllerBase
    {
        readonly CategoriaCommandHandler _categoriaCommandHandler;
        readonly AvaliacaoCommandHandler _avaliacaoCommandHandler;
        readonly CategoriasContext _uowCategorias;
        readonly AvaliacoesContext _uowAvaliacoes;

        public TecnologiaController(
            CategoriasContext uowCategorias,
            CategoriaCommandHandler categoriaCommandHandler,
            AvaliacoesContext uowAvaliacoes,
            AvaliacaoCommandHandler avaliacaoCommandHandler) :
            base(uowCategorias, uowAvaliacoes)
        {
            _uowCategorias = uowCategorias;
            _categoriaCommandHandler = categoriaCommandHandler;

            _uowAvaliacoes = uowAvaliacoes;
            _avaliacaoCommandHandler = avaliacaoCommandHandler;
        }

        [HttpPut]
        public async Task<IActionResult> PutTecnologiaAsync([FromBody]AtualizarNivelCommand command)
        {
            return await Task.Run(() =>
            {
                _avaliacaoCommandHandler.Handle(command);

                return Response(_avaliacaoCommandHandler.Notifications);
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostTecnologiaAsync([FromBody]AvaliarNovaTecnologiaCommand command)
        {
            return await Task.Run(() =>
            {
                using (var tran = new TransactionScope())
                {
                    _categoriaCommandHandler.Handle(new AdicionarTecnologiaCommand()
                    {
                        IconeUrl = command.IconeUrl,
                        IdCategoria = command.IdCategoria,
                        Tecnologia = command.Tecnologia
                    });

                    _uowCategorias.Commit();

                    var tecnologia = _categoriaCommandHandler.Result.Tecnologias.FirstOrDefault(x => x.Nome == command.Tecnologia);

                    _avaliacaoCommandHandler.Handle(new AtualizarNivelCommand()
                    {
                        Nivel = command.Nivel,
                        IdColaborador = command.IdColaborador,
                        IdTecnologia = tecnologia.Id,
                    });

                    _uowAvaliacoes.Commit();

                    tran.Complete();

                    return Response(_avaliacaoCommandHandler.Notifications);
                }
            });
        }
    }
}
