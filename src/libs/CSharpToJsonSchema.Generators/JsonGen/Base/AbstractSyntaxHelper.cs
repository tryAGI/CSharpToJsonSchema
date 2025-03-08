using Microsoft.CodeAnalysis;

namespace CSharpToJsonSchema.Generators.JsonGen.Base;

internal abstract class AbstractSyntaxHelper : ISyntaxHelper
{
    public abstract bool IsCaseSensitive { get; }

    public abstract bool IsValidIdentifier(string name);

    public abstract SyntaxToken GetUnqualifiedIdentifierOfName(SyntaxNode name);

    public abstract bool IsAnyNamespaceBlock(SyntaxNode node);

    public abstract bool IsAttribute(SyntaxNode node);
    public abstract SyntaxNode GetNameOfAttribute(SyntaxNode node);

    public abstract bool IsAttributeList(SyntaxNode node);
    public abstract SeparatedSyntaxList<SyntaxNode> GetAttributesOfAttributeList(SyntaxNode node);
    public abstract void AddAttributeTargets(SyntaxNode node, ref ValueListBuilder<SyntaxNode> targets);

    public abstract bool IsLambdaExpression(SyntaxNode node);

    public abstract void AddAliases(SyntaxNode node, ref ValueListBuilder<(string aliasName, string symbolName)> aliases, bool global);
    public abstract void AddAliases(CompilationOptions options, ref ValueListBuilder<(string aliasName, string symbolName)> aliases);

    public abstract bool ContainsGlobalAliases(SyntaxNode root);
}