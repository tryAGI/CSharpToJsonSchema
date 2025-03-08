namespace CSharpToJsonSchema.Generators.JsonGen.Base;

internal static class Hash
{
    /// <summary>
    /// This is how VB Anonymous Types combine hash values for fields.
    /// </summary>
    internal static int Combine(int newKey, int currentKey)
    {
        return unchecked((currentKey * (int)0xA5555529) + newKey);
    }

    // The rest of this file was removed as they were not currently needed in the polyfill of SyntaxValueProvider.ForAttributeWithMetadataName.
    // If that changes, they should be added back as necessary.
}