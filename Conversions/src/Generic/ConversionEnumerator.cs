using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Senkel.Collections.Conversions;
   
/// <summary>
/// Represents an enumerator that is based on another <see cref="IEnumerator{TInput}"/> and converts 
/// the <see cref="IEnumerator{IInput}.Current"/> value to a corresponding value of the <see cref="TOutput"/> type.
/// </summary>
/// <typeparam name="TInput">The type of the enumerator that is meant to be converted.</typeparam>
/// <typeparam name="TOutput">The type to convert to, that this enumerator is based on.</typeparam>
public abstract class ConversionEnumerator<TInput, TOutput> : IEnumerator<TOutput>
{
    private readonly IEnumerator<TInput> _enumerator; 

    /// <summary>
    /// Initializes the enumerator to be based on the specified <see cref="IEnumerator{TInput}"/> instance.
    /// </summary>
    /// <param name="enumerator">The instance to convert from.</param>
    public ConversionEnumerator(IEnumerator<TInput> enumerator)
    { 
        _enumerator = enumerator;
    } 

    public TOutput Current => Convert(_enumerator.Current);

    [MaybeNull]
    object IEnumerator.Current => Current;

    /// <summary>
    /// Converts the given input value to a corresponding output value.
    /// </summary>
    /// <param name="input">The input value to convert.</param>
    /// <returns>The converted value.</returns>
    protected abstract TOutput Convert(TInput input);
    
    public void Dispose()
    {
        _enumerator.Dispose();
    }

    public bool MoveNext()
    {
        return _enumerator.MoveNext();
    }

    public void Reset()
    {
        _enumerator.Reset();
    }
}