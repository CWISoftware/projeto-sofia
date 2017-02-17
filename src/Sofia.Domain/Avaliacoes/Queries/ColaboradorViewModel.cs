using System.Collections.Generic;
using System.Diagnostics;

namespace Sofia.Domain.Avaliacoes.Queries
{
    [DebuggerDisplay("Id = {Id}, Nome = {Nome}")]
    public class ColaboradorViewModel
    {
        public ColaboradorViewModel()
        {
            Tecnologias = new List<TecnologiaViewModel>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<TecnologiaViewModel> Tecnologias { get; set; }
    }
}