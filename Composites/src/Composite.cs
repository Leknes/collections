using Senkel.Collections.Model;

namespace Senkel.Collections.Composites;

/// <summary>
/// Represents a composite including objects of the specified type <see cref="T"/>.
/// </summary>
/// <typeparam name="T">The type of the leaves in the composite.</typeparam>
public abstract class Composite<T> : ISimplexCollection<T> 
{
    private ICollection<T> _leaves;

    /// <summary>
    /// The leaf objects in the composite.
    /// </summary>
    protected IEnumerable<T> Leaves => _leaves;

    /// <summary>
    /// Initializes a new <see cref="Composite{T}"/> instance that uses the specified list of leaves.
    /// </summary>
    /// <param name="leaves">The leaves that the composite has initially.</param>
    protected Composite(ICollection<T> leaves)
    {
        _leaves = leaves;
    }

    /// <summary>
    /// Initializes a new <see cref="Composite{T}"/> instance with no initial leaves.
    /// </summary>
    protected Composite() : this(new List<T>()) { }
    
    /// <summary>
    /// Initializes a new <see cref="Composite{T}"/> instance that uses a list created with the <see cref="Enumerable.ToList"/> method on the specified enumerable.
    /// </summary>
    /// <param name="leaves">The leaves that the composite has initially.</param>
    protected Composite(IEnumerable<T> leaves) : this(leaves.ToList()) { }
    
    /// <summary>
    /// Adds a new leaf to the composite.
    /// </summary>
    /// <param name="leaf">The leaf to add.</param>
    public void Add(T leaf)
    { 
       _leaves.Add(leaf);
    }
     
    /// <summary>
    /// Removes a new leaf from the composite.
    /// </summary>
    /// <param name="leaf">The leaf to remove.</param>
    public bool Remove(T leaf)
    {
       return _leaves.Remove(leaf);
    }
   
}