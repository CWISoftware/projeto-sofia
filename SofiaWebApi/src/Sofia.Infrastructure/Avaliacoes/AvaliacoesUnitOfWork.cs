using Core.Crosscutting.Transactions;

namespace Sofia.Infrastructure.Avaliacoes
{
    public class AvaliacoesUnitOfWork : IUnitOfWork
    {
        private readonly AvaliacoesContext _context;

        public AvaliacoesUnitOfWork(AvaliacoesContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing for EF
        }
    }
}
