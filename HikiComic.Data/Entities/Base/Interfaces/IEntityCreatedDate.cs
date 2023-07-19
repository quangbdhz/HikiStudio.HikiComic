namespace HikiComic.Data.Entities.Base.Interfaces
{
    /// <summary>
    /// Represents an entity that contains information about the creation date.
    /// </summary>
    public interface IEntityCreatedDate
    {
        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        public DateTime DateCreated { get; set; }
    }

}
