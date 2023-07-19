using HikiComic.Data.Entities.Base.Interfaces;

namespace HikiComic.Data.Entities.Base.Entities
{
    /// <summary>
    /// Represents an entity that supports soft deletion and contains information about creation and update timestamps, with an additional user type.
    /// </summary>
    /// <typeparam name="TUser">The type representing the user or creator/updater of the entity.</typeparam>
    public class EntitySoftDeleteWithTimestamps<TUser> : IEntitySoftDeleteWithTimestamps<TUser>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is deleted.
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time of object creation.
        /// </summary>
        public virtual DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the user who created the object.
        /// </summary>
        public virtual TUser CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time of object update (if applicable).
        /// </summary>
        public virtual DateTime? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the user who last updated the object (if applicable).
        /// </summary>
        public virtual TUser? UpdatedBy { get; set; }
    }

}
