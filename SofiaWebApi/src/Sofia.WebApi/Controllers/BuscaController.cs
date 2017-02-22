using Microsoft.AspNetCore.Mvc;
using Sofia.Domain.Avaliacoes.Commands.Inputs;
using Sofia.Domain.Avaliacoes.Repositories;
using System.Threading.Tasks;

namespace Sofia.WebApi.Controllers
{
    [Route("v1/busca")]
    public class BuscaController : ControllerBase
    {
        readonly IAvaliacaoRepository _avaliacaoRepository;

        public BuscaController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuscar([FromQuery]string texto)
        {
            return await Task.Run(() =>
            {
                return Response(_avaliacaoRepository.BuscarColaboradorPortecnologias(new BuscarColaboradorPorTecnologiasCommand() { Texto = texto }));
            });
        }
    }
}