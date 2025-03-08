using System.Collections.Immutable;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

public static class ValueEqualityImmutableDictionaryHelperExtensions
{
    public static ValueEqualityImmutableDictionary<TKey, TValue> ToValueEqualityImmutableDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
    {
        return new ValueEqualityImmutableDictionary<TKey, TValue>(source.ToImmutableDictionary(keySelector, valueSelector));
    }
    public static ValueEqualityImmutableDictionary<TKey, TValue> ToValueEquals<TKey, TValue>(this ImmutableDictionary<TKey, TValue> source)
    {
        return new ValueEqualityImmutableDictionary<TKey, TValue>(source);
    }

}