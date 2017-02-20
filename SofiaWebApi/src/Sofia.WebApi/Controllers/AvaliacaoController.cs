using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Avaliacoes.Commands;
using Sofia.Infrastructure.Avaliacoes;
using System.Threading.Tasks;

namespace Sofia.WebApi.Controllers
{
    [Route("v1/avaliacoes")]
    public class AvaliacaoController : ControllerBase
    {
        readonly AvaliacaoCommandHandler _avaliacaoCommandHandler;

        public AvaliacaoController(AvaliacoesContext uow,
            AvaliacaoCommandHandler avaliacaoCommandHandler) : base(uow)
        {
            _avaliacaoCommandHandler = avaliacaoCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> PostAtualizarNivelAsync([FromBody]AtualizarNivelCommand command)
        {
            return await Task.Run(() =>
            {
                _avaliacaoCommandHandler.Handle(command);

                return Response(_avaliacaoCommandHandler.Notifications);
            });
        }
    }
}
