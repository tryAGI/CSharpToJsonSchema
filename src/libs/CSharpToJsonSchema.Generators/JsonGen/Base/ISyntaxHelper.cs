using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

internal interface ISyntaxHelper
{
    bool IsCaseSensitive { get; }

    bool IsValidIdentifier(string name);

    bool IsAnyNamespaceBlock(SyntaxNode node);

    bool IsAttributeList(SyntaxNode node);
    SeparatedSyntaxList<SyntaxNode> GetAttributesOfAttributeList(SyntaxNode node);

    void AddAttributeTargets(SyntaxNode node, ref ValueListBuilder<SyntaxNode> targets);

    bool IsAttribute(SyntaxNode node);
    SyntaxNode GetNameOfAttribute(SyntaxNode node);

    bool IsLambdaExpression(SyntaxNode node);

    SyntaxToken GetUnqualifiedIdentifierOfName(SyntaxNode node);

    /// <summary>
    /// <paramref name="node"/> must be a compilation unit or namespace block.
    /// </summary>
    void AddAliases(SyntaxNode node, ref ValueListBuilder<(string aliasName, string symbolName)> aliases, bool global);
    void AddAliases(CompilationOptions options, ref ValueListBuilder<(string aliasName, string symbolName)> aliases);

    bool ContainsGlobalAliases(SyntaxNode root);
}