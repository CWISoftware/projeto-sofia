using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Avaliacoes.Commands;
using System.Threading.Tasks;

namespace Sofia.WebApi.Controllers
{
    [Route("v1/busca")]
    public class BuscaController : ControllerBase
    {
        readonly AvaliacaoCommandHandler _avaliacaoCommandHandler;

        public BuscaController(AvaliacaoCommandHandler avaliacaoCommandHandler)
        {
            _avaliacaoCommandHandler = avaliacaoCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuscar([FromQuery]string texto)
        {
            return await Task.Run(() =>
            {
                return Response(_avaliacaoCommandHandler.Retrieve(new PesquisarPorTecnologiasCommand() { Texto = texto }));
            });
        }
    }
}