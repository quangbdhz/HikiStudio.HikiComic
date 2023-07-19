namespace HikiComic.Data.Entities.Base.Interfaces
{
    /// <summary>
    /// Base class that contains information about the creation and update timestamps of objects, along with the identifiers of the creators and updaters.
    /// </summary>
    public interface IEntityTimestamps<TUser> : IEntityCreatedDate
    {
        /// <summary>
        /// Identifier of the creator.
        /// </summary>
        public TUser CreatedBy { get; set; }

        /// <summary>
        /// Date and time of object update (if applicable).
        /// </summary>
        public  DateTime? DateUpdated { get; set; }

        /// <summary>
        /// Identifier of the last updater (if applicable).
        /// </summary>
        public TUser? UpdatedBy { get; set; }
    }
}
