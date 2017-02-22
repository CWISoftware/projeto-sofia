namespace Sofia.SharedKernel.Domain
{
    /// <summary>
    /// Repository main interface
    /// </summary>
    /// <typeparam name="TEntity">entity type of the repository</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : IAggregateRoot
    {

        /// <summary>
        /// Add/Create an item to repository and persist.
        /// </summary>
        /// <param name="entity">item to add</param>
        void Add(TEntity entity);

        /// <summary>
        /// Delete item and persist.
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Update entity into the repository and persist.
        /// </summary>
        /// <param name="item">Item with changes</param>
        void Update(TEntity entity);

        /// <summary>
        /// Get specific entity by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>requested entity</returns>
        TEntity Find(int id);
    }
}
