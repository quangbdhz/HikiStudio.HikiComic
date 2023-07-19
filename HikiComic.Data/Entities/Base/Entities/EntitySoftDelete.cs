using HikiComic.Data.Entities.Base.Interfaces;

namespace HikiComic.Data.Entities.Base.Entities
{
    /// <summary>
    /// Represents an entity that supports soft deletion.
    /// </summary>
    public class EntitySoftDelete : IEntitySoftDelete
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is deleted.
        /// </summary>
        public virtual bool IsDeleted { get; set; }
    }
}
