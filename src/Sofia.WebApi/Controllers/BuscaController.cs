using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Avaliacoes.Commands;
using System.Threading.Tasks;
using System.Linq;

namespace Sofia.WebApi.Controllers
{
    [Route("busca")]
    public class BuscaController : ControllerBase
    {
        readonly AvaliacaoCommandHandler _avaliacaoCommandHandler;

        public BuscaController(AvaliacaoCommandHandler avaliacaoCommandHandler)
        {
            _avaliacaoCommandHandler = avaliacaoCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuscar(PesquisarPorTecnologiasCommand command)
        {
            return await Task.Run(() =>
            {
                return Response(_avaliacaoCommandHandler.Retrieve(command));
            });
        }
    }
}