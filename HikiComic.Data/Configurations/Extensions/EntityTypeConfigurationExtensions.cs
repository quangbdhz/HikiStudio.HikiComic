using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace HikiComic.Data.Configurations.Extensions
{
    public static class EntityTypeConfigurationExtensions
    {
        public static ReferenceCollectionBuilder<TRelatedEntity, TEntity> WithManyFlex<TEntity, TRelatedEntity>(
            this ReferenceNavigationBuilder<TEntity, TRelatedEntity> referenceNavigationBuilder,
            Expression<Func<TRelatedEntity, IEnumerable<TEntity>?>> navigationExpression)
            where TEntity : class
            where TRelatedEntity : class
        {
            return referenceNavigationBuilder.WithMany(navigationExpression);
        }
    }
}
