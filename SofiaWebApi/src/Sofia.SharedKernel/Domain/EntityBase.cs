using Sofia.SharedKernel.Validators;
using System;

namespace Sofia.SharedKernel.Domain
{
    // <summary>
    /// Entity base class 
    /// (Handles equality and identity)
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public abstract class EntityBase<TEntity> : Notifiable, IEquatable<EntityBase<TEntity>> where TEntity : EntityBase<TEntity>
    {
        const int _defaultid = default(int);
        /// <summary>
        /// Gets ID.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return (Id.Equals(default(int)));
        }

        /// <summary>
        /// Indicates whether the current object 
        /// is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal 
        /// to the <paramref name="other"/> parameter; 
        /// otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(EntityBase<TEntity> other)
        {
            if (other == null)
                return false;

            // Handle the case of comparing two NEW objects    
            var otherIsTransient = Equals(other.Id, default(int));
            var currentIsTransient = Equals(Id, default(int));

            if (otherIsTransient && currentIsTransient)
                return ReferenceEquals(other, this);

            return other.Id.Equals(Id);
        }

        /// <summary>
        /// Equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as TEntity;

            return Equals(other);
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        public override int GetHashCode()
        {
            var thisIsTransient = Equals(Id, _defaultid);

            // When this instance is transient, we use the base GetHashCode()    
            return thisIsTransient ? _defaultid.GetHashCode() : Id.GetHashCode();
        }

        /// <summary>
        /// Equal operator
        /// </summary>
        public static bool operator ==(EntityBase<TEntity> x, EntityBase<TEntity> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        public static bool operator !=(EntityBase<TEntity> x, EntityBase<TEntity> y)
        {
            return !(x == y);
        }
    }
}
