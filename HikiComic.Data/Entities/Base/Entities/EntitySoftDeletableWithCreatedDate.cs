using HikiComic.Data.Entities.Base.Interfaces;

namespace HikiComic.Data.Entities.Base.Entities
{
    /// <summary>
    /// Represents an entity that supports soft deletion and contains information about the creation date.
    /// </summary>
    public class EntitySoftDeletableWithCreatedDate : IEntityCreatedDate, IEntitySoftDelete
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is deleted.
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time of object creation.
        /// </summary>
        public virtual DateTime DateCreated { get; set; }
    }
}
