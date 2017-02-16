using Core.Crosscutting.Transactions;
using System.Data.Entity;

namespace Sofia.Infrastructure.Base
{
    public abstract class DbContextBase<TContext> : DbContext, IUnitOfWork where TContext : DbContext
    {
        static DbContextBase()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected DbContextBase() : base(@"Server=(local);Database=SofiaDb;Trusted_Connection=True;MultipleActiveResultSets=true;Application Name=Sofia.WebApi")
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
