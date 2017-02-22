using Sofia.SharedKernel.Transactions;

namespace Sofia.Infrastructure.Categorias
{
    public class CategoriasUnitOfWork : IUnitOfWork
    {
        private readonly CategoriasContext _context;

        public CategoriasUnitOfWork(CategoriasContext context)
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
