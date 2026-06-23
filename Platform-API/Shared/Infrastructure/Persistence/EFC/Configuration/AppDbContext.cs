using Platform_API.News.Domain.Model.Aggregates;
using Platform_API.News.Domain.Model.ValueObjects;
using Platform_API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Platform_API.Shared.Infrastructure.Persistence.EFC.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Platform_API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
// 1. Inyección de las opciones de conexión a MySQL mediante constructor primario.
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <inheritdoc />
    // 2. Configuración previa al encendido del contexto (registro de interceptores de auditoría).
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Aplica el interceptor automático que llena los campos CreatedAt y UpdatedAt
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    /// <inheritdoc />
    // 3. Método donde se definen las reglas para traducir las clases de C# a MySQL.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //DESDE AQUI RECIEN SE COMIENZA A EDITAR 
        // REGLA 1: Define el identificador principal como Llave Primaria (PK)
        builder.Entity<FavoriteSource>().HasKey(f => f.Id);
        
        // REGLA 2: Hace el Id obligatorio y autoincremental en la Base de Datos
        builder.Entity<FavoriteSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        
        // REGLA 3: Convierte el Value Object "SourceId" a un string primitivo para MySQL
        builder.Entity<FavoriteSource>()
            .Property(f => f.SourceId)
            .HasConversion(valueObject => valueObject.Value, value => new SourceId(value))
            .IsRequired();

        // REGLA 4: Convierte el Value Object "NewsApiKey" a un string primitivo para MySQL
        builder.Entity<FavoriteSource>()
            .Property(f => f.NewsApiKey)
            .HasConversion(valueObject => valueObject.Value, value => new NewsApiKey(value))
            .IsRequired();

        // =========================================================================
        // ✍️ ¡ZONA DE FUTUROS VALUE OBJECTS DEL EXAMEN! (CUALQUIER OTRO VA AQUÍ)
        // =========================================================================
        // Si el profesor te dice: "Agreguen el campo X a FavoriteSource", lo pones aquí abajo.
        // Al estar comentados con /* ... */, Rider los ignorará por completo y tu código compilará en verde.

        /*
        // EJEMPLO FUTURO 1: Si añades un nuevo Value Object de tipo Texto Obligatorio (ej: SourceUrl)
        builder.Entity<FavoriteSource>()
            .Property(f => f.SourceUrl)
            .HasConversion(valueObject => valueObject.Value, value => new SourceUrl(value))
            .IsRequired();
        */

        /*
        // EJEMPLO FUTURO 2: Si añades un nuevo Value Object de tipo Número Obligatorio (ej: SourceRating)
        builder.Entity<FavoriteSource>()
            .Property(f => f.SourceRating)
            .HasConversion(valueObject => valueObject.Value, value => new SourceRating(value))
            .IsRequired();
        */

        /*
        // EJEMPLO FUTURO 3: Si añades un nuevo Value Object que pueda quedar Vacío/Null (ej: CustomNote)
        builder.Entity<FavoriteSource>()
            .Property(f => f.CustomNote)
            .HasConversion(valueObject => valueObject.Value, value => new CustomNote(value))
            .IsRequired(false); // Le dice a MySQL que permite valores nulos (NULL)
        */

        // =========================================================================
        // FINAL DE LA ENTIDAD: RESTRICCIONES E ÍNDICES
        // =========================================================================

        // REGLA 5: Índice Compuesto Único (Evita que un mismo usuario duplique la misma fuente)
        builder.Entity<FavoriteSource>()
            .HasIndex(f => new { f.NewsApiKey, f.SourceId })
            .IsUnique();

        // REGLA 6: Aplica la conversión automática a todas las columnas a formato snake_case (ej: news_api_key)
        builder.UseSnakeCaseNamingConvention();
    }
}