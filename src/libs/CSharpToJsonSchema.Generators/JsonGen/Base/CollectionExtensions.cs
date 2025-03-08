using System.Collections.Immutable;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

public static partial class CollectionExtensions
{
    public static SequenceEqualImmutableArray<T> ToSequenceEqualImmutableArray<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
    {
        return new(source.ToImmutableArray(), comparer);
    }
    public static SequenceEqualImmutableArray<T> ToSequenceEqualImmutableArray<T>(this IEnumerable<T> source)
    {
        return new(source.ToImmutableArray());
    }
    public static SequenceEqualImmutableArray<T> ToSequenceEqual<T>(this ImmutableArray<T> source)
    {
        return new(source);
    }
}