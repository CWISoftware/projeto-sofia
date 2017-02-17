using System.Collections.Generic;

namespace Sofia.Domain.Avaliacoes.Queries
{
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