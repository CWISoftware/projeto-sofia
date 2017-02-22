using System.Collections.Generic;
using System.Diagnostics;

namespace Sofia.Domain.Avaliacoes.Commands.Results
{
    [DebuggerDisplay("Id = {Id}, Nome = {Nome}")]
    public class BuscarColaboradorPorTecnologiasResult
    {
        public BuscarColaboradorPorTecnologiasResult()
        {
            Tecnologias = new List<BuscarColaboradorPorTecnologiasTecnologiaResult>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<BuscarColaboradorPorTecnologiasTecnologiaResult> Tecnologias { get; set; }
    }
}