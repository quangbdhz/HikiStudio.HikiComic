namespace HikiComic.Data.Entities.Base.Interfaces
{
    /// <summary>
    /// Represents an entity that supports soft deletion and contains information about creation and update timestamps, with an additional user type.
    /// </summary>
    /// <typeparam name="TUser">The type representing the user or creator/updater of the entity.</typeparam>
    public interface IEntitySoftDeleteWithTimestamps<TUser> : IEntitySoftDelete, IEntityTimestamps<TUser>
    {
    }
}
