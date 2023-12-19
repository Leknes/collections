namespace Senkel.Collections.Model;

/// <summary>
/// Represents a collection that items can only be added to, or removed from 
/// so that the collection can only be modified using inputs from the caller. 
/// </summary>
public interface ISimplexCollection<T>
{
    /// <summary>
    /// Adds the specified item to the collection.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Add(T item);

    /// <summary>
    /// Removes the specified item from the collection.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns>If an item has been removed.</returns>
    public bool Remove(T item);
} 