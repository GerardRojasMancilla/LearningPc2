namespace Platform_API.Shared.Domain.Repositories;

/// <summary>
/// Defines the generic read and write contract for repository operations across all contexts.
/// </summary>
/// <remarks>
/// This interface establishes the baseline CRUD methods leveraging asynchronous tasks 
/// and cancellation tokens to ensure performance and responsiveness.
/// </remarks>
/// <typeparam name="TEntity">The reference type of the domain entity managed by this repository.</typeparam>
public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Asynchronously adds a new entity instance to the persistence tracking context.
    /// </summary>
    /// <param name="entity">The entity object containing valid data to be added.</param>
    /// <param name="cancellationToken">A token used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a single entity instance by its unique integer identifier.
    /// </summary>
    /// <param name="id">The unique primary key value of the entity to search for.</param>
    /// <param name="cancellationToken">A token used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task containing the entity if a match is found; otherwise, null.</returns>
    Task<TEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the state of an existing entity within the tracking context.
    /// </summary>
    /// <param name="entity">The modified entity object instance.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Removes an existing entity instance from the tracking context.
    /// </summary>
    /// <param name="entity">The entity object instance to be removed.</param>
    void Remove(TEntity entity);

    /// <summary>
    /// Asynchronously retrieves all available instances of the specified entity from the persistence layer.
    /// </summary>
    /// <param name="cancellationToken">A token used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task containing an enumerable collection of all tracked entity objects.</returns>
    Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken = default);
}