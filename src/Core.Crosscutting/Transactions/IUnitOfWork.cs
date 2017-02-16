namespace Core.Crosscutting.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
