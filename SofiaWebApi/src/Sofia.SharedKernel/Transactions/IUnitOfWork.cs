namespace Sofia.SharedKernel.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
