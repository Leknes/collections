
namespace Senkel.Collections.Conversions;

/// <summary>
/// Represents an enumerator that is based on another <see cref="IEnumerator{TInput}"/> and converts 
/// the <see cref="IEnumerator{IInput}.Current"/> value to a corresponding value of the <see cref="TOutput"/> type,
/// using a specified <see cref="Converter{TInput, TOutput}"/> delegate instance.
/// </summary>
/// <typeparam name="TInput">The type of the enumerator that is meant to be converted.</typeparam>
/// <typeparam name="TOutput">The type to convert to, that this enumerator is based on.</typeparam>
public class FuncEnumerator<TInput, TOutput> : ConversionEnumerator<TInput, TOutput>
{
    private readonly Converter<TInput, TOutput> _convert;

    /// <summary>
    /// Creates a new instance of the <see cref="FuncEnumerator{TInput, TOutput}"/> class, 
    /// based on the specified enumerator using the given converter delegate.
    /// </summary>
    /// <param name="enumerator">The instance to convert from.</param>
    /// <param name="convert">The delegate that is used for conversion.</param>
    public FuncEnumerator(IEnumerator<TInput> enumerator, Converter<TInput, TOutput> convert) : base(enumerator)
    {
        _convert = convert;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="FuncEnumerator{TInput, TOutput}"/> class, 
    /// based on the enumerator of the specified enumerable using the given converter delegate.
    /// </summary>
    /// <param name="enumerator">The enumerable which enumerator is converted from.</param>
    /// <param name="convert">The delegate that is used for conversion.</param>

    public FuncEnumerator(IEnumerable<TInput> enumerator, Converter<TInput, TOutput> convert) : this(enumerator.GetEnumerator(), convert) { }
 
    protected override TOutput Convert(TInput input)
    {
        return _convert(input);
    }
}