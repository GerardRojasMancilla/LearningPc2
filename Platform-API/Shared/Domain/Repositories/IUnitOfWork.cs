namespace Platform_API.Shared.Domain.Repositories;

/// <summary>
/// Defines the transactional control contract following the Unit of Work pattern.
/// </summary>
/// <remarks>
/// This interface ensures that all operations executed through multiple repositories 
/// are committed to the underlying database collectively as a single atomic transaction.
/// </remarks>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously commits all tracked entity changes and operations to the persistent database.
    /// </summary>
    /// <param name="cancellationToken">A token used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task CompleteAsync(CancellationToken cancellationToken = default);
}