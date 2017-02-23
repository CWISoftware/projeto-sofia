using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Categorias.Commands.Handlers;
using Sofia.Domain.Categorias.Commands.Inputs;
using Sofia.Domain.Categorias.Repositories;
using Sofia.Infrastructure.Categorias;
using System.Threading.Tasks;

namespace Sofia.WebApi.Controllers
{
    [Route("v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        readonly CategoriaCommandHandler _categoriaCommandHandler;
        readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(
            CategoriasContext uow,
            CategoriaCommandHandler categoriaCommandHandler,
            ICategoriaRepository categoriaRepository) : base(uow)
        {
            _categoriaCommandHandler = categoriaCommandHandler;
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoriaAsync([FromBody]CriarCategoriaCommand command)
        {
            return await Task.Run(() =>
            {
                _categoriaCommandHandler.Handle(command);

                return Response(_categoriaCommandHandler.Result, _categoriaCommandHandler.Notifications);
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutCategoriaAsync([FromBody]AtualizarCategoriaCommand command)
        {
            return await Task.Run(() =>
            {
                _categoriaCommandHandler.Handle(command);

                return Response(_categoriaCommandHandler.Result, _categoriaCommandHandler.Notifications);
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoriaAsync([FromBody]ExcluirCategoriaCommand command)
        {
            return await Task.Run(() =>
            {
                _categoriaCommandHandler.Handle(command);

                return Response(_categoriaCommandHandler.Result, _categoriaCommandHandler.Notifications);
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriaAsync()
        {
            return await Task.Run(() =>
            {
                return Response(_categoriaRepository.ListarCategorias());
            });
        }

        [HttpGet, Route("TotalizadorCategorias")]
        public async Task<IActionResult> GetTotalizadorCategoriasResultAsync()
        {
            return await Task.Run(() =>
            {
                return Response(_categoriaRepository.ObterTotalizadorCategorias());
            });
        }
            

    }
}
