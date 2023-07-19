using HikiComic.Data.Entities;
using HikiComic.Data.Entities.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations.Base
{
    public abstract class EntityTypeConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (typeof(IEntitySoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                builder.Property<bool>("IsDeleted").IsRequired(true).HasDefaultValue(false);
            }

            if (typeof(IEntityCreatedDate).IsAssignableFrom(typeof(TEntity)))
            {
                builder.Property<DateTime>("DateCreated").IsRequired(true);
            }

            if (typeof(IEntitySoftDeleteWithTimestamps<>).IsAssignableFrom(typeof(TEntity)))
            {
                builder.Property<bool>("IsDeleted").IsRequired(true).HasDefaultValue(false);
                builder.Property<DateTime>("DateCreated").IsRequired(true);
                builder.Property<DateTime?>("DateUpdated").IsRequired(false);

                var relatedEntityPluralName = GetPluralizedName(typeof(TEntity).Name);

                var createdByProperty = typeof(TEntity).GetProperty("CreatedBy");
                if (createdByProperty != null)
                {
                    builder.HasOne(typeof(AppUser)).WithMany(relatedEntityPluralName).HasForeignKey("CreatedBy").IsRequired(true);
                }

                var updatedByProperty = typeof(TEntity).GetProperty("UpdatedBy");
                if (updatedByProperty != null)
                {
                    builder.HasOne(typeof(AppUser)).WithMany(relatedEntityPluralName).HasForeignKey("UpdatedBy").IsRequired(false);
                }
            }
        }

        private string GetPluralizedName(string entityName)
        {
            if (entityName.EndsWith("y"))
            {
                return entityName.Substring(0, entityName.Length - 1) + "ies";
            }
            else if (entityName.EndsWith("s") || entityName.EndsWith("x") || entityName.EndsWith("z") || entityName.EndsWith("ch") || entityName.EndsWith("sh"))
            {
                return entityName + "es";
            }
            else
            {
                return entityName + "s";
            }
        }
    }

    public abstract class EntityTypeConfigurationBase<TEntity, TUser> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (typeof(IEntitySoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                builder.Property<bool>("IsDeleted").IsRequired(true).HasDefaultValue(false);
            }

            if (typeof(IEntityCreatedDate).IsAssignableFrom(typeof(TEntity)))
            {
                builder.Property<DateTime>("DateCreated").IsRequired(true);
            }

            if (typeof(IEntitySoftDeleteWithTimestamps<TUser>).IsAssignableFrom(typeof(TEntity)))
            {
                builder.Property<bool>("IsDeleted").IsRequired(true).HasDefaultValue(false);
                builder.Property<DateTime>("DateCreated").IsRequired(true);
                builder.Property<DateTime?>("DateUpdated").IsRequired(false);
                builder.Property<TUser>("CreatedBy").IsRequired(true);
                builder.Property<TUser?>("UpdatedBy").IsRequired(false).HasColumnType("uniqueidentifier");

                var relatedEntityPluralName = GetPluralizedName(typeof(TEntity).Name);

                var createdByProperty = typeof(TEntity).GetProperty("CreatedBy");
                if (createdByProperty != null)
                {
                    builder.HasOne(typeof(TUser)).WithMany(relatedEntityPluralName).HasForeignKey("CreatedBy").IsRequired();
                }

                var updatedByProperty = typeof(TEntity).GetProperty("UpdatedBy");
                if (updatedByProperty != null)
                {
                    builder.HasOne(typeof(TUser)).WithMany(relatedEntityPluralName).HasForeignKey("UpdatedBy").IsRequired(false);
                }
            }
        }

        private string GetPluralizedName(string entityName)
        {
            if (entityName.EndsWith("y"))
            {
                return entityName.Substring(0, entityName.Length - 1) + "ies";
            }
            else if (entityName.EndsWith("s") || entityName.EndsWith("x") || entityName.EndsWith("z") || entityName.EndsWith("ch") || entityName.EndsWith("sh"))
            {
                return entityName + "es";
            }
            else
            {
                return entityName + "s";
            }
        }
    }
}

