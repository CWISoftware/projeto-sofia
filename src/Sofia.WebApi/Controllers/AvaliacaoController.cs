using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Avaliacoes.Commands;
using Sofia.Infrastructure.Avaliacoes;
using System.Threading.Tasks;

namespace Sofia.WebApi.Controllers
{
    [Route("v1/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        readonly AvaliacaoCommandHandler _categoriaCommandHandler;

        public AvaliacaoController(AvaliacoesContext uow,
            AvaliacaoCommandHandler avaliacaoCommandHandler) : base(uow)
        {
            _categoriaCommandHandler = avaliacaoCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> PostAtualizarNivelAsync(AtualizarNivelCommand command)
        {
            return await Task.Run(() =>
            {
                _categoriaCommandHandler.Handle(command);

                return Response(_categoriaCommandHandler.Notifications);
            });
        }
    }
}
