using Sofia.SharedKernel.Runtime;
using Sofia.SharedKernel.Transactions;
using System.Data.Entity;

namespace Sofia.Infrastructure
{
    public abstract class DbContextBase<TContext> : DbContext, IUnitOfWork where TContext : DbContext
    {
        static DbContextBase()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected DbContextBase() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.UseDatabaseNullSemantics = true;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            // do nothing for EF.
        }
    }
}
