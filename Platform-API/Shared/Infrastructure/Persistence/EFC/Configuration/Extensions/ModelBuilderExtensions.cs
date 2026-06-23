using Microsoft.EntityFrameworkCore;

namespace Platform_API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Model builder extensions for centralized database naming conventions.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Sets the naming convention for tables, columns, keys, and indexes to snake_case and pluralized tables.
    /// </summary>
    /// <param name="builder">The ModelBuilder instance to apply conventions on.</param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Pone el nombre de las tablas en plural y snake_case (ej: FavoriteSource -> favorite_sources)
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName)) entity.SetTableName(tableName.ToPlural().ToSnakeCase());

            // Pone las columnas en snake_case (ej: NewsApiKey -> news_api_key)
            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            // Pone las llaves primarias en snake_case
            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.ToSnakeCase());
            }

            // Pone las llaves foráneas en snake_case
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyName)) foreignKey.SetConstraintName(foreignKeyName.ToSnakeCase());
            }

            // Pone los índices en snake_case (ej: IX_FavoriteSource_NewsApiKey -> ix_favorite_sources_news_api_key)
            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName)) index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
            }
        }
    }
}