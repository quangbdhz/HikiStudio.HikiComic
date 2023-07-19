namespace HikiComic.Data.Entities.Base.Interfaces
{
    /// <summary>
    /// Represents an entity that supports soft deletion.
    /// </summary>
    public interface IEntitySoftDelete
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is deleted.
        /// </summary>
        public  bool IsDeleted { get; set; }
    }
}
