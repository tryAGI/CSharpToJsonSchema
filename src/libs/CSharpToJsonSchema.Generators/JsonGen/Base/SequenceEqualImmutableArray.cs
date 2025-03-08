using System.Collections;
using System.Collections.Immutable;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

/// <summary>
/// This method provides a wrapper for an <see cref="ImmutableArray" /> that overrides the equality operation to provide elementwise comparison.
/// The default equality operation for an <see cref="ImmutableArray{T}" /> is reference equality of the underlying array, which is too strict
/// for many scenarios. This wrapper type allows us to use <see cref="ImmutableArray{T}" />s in our other record types without having to write an Equals method
/// that we may forget to update if we add new elements to the record.
/// </summary>
public readonly record struct SequenceEqualImmutableArray<T>(ImmutableArray<T> Array, IEqualityComparer<T> Comparer) : IEnumerable<T>
{
    public SequenceEqualImmutableArray(ImmutableArray<T> array)
        : this(array, EqualityComparer<T>.Default)
    {
    }

    public SequenceEqualImmutableArray<T> Add(T value)
    {
        return new SequenceEqualImmutableArray<T>(Array.Add(value));
    }

    public T this[int i] { get => Array[i]; }

    public int Length => Array.Length;
    public SequenceEqualImmutableArray<T> Insert(int index, T item)
        => new SequenceEqualImmutableArray<T>(Array.Insert(index, item), Comparer);

    public override int GetHashCode() => HashCode.SequentialValuesHash(Array);

    public bool Equals(SequenceEqualImmutableArray<T> other)
    {
        return Array.SequenceEqual(other.Array, Comparer);
    }

    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Array).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Array).GetEnumerator();
}