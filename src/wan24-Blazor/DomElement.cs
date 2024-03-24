using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;
using System.Web;
using wan24.Core;
using wan24.ObjectValidation;

namespace wan24.Blazor
{
    /// <summary>
    /// DOM element
    /// </summary>
    public partial record class DomElement : DisposableRecordBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DomElement() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gateway">Blazor gateway</param>
        public DomElement(in BlazorGateway gateway) : base() => Gateway = gateway;

        /// <summary>
        /// DOM
        /// </summary>
        [NoValidation, JsonIgnore]
        public BlazorGateway Gateway { get; protected set; } = null!;

        /// <summary>
        /// Index of this element in the parent child nodes
        /// </summary>
        [Range(0, int.MaxValue)]
        public int ParentIndex { get; init; }

        /// <summary>
        /// ID
        /// </summary>
        [RequiredIf(nameof(Type), DomElementTypes.Node)]
        public string? ID { get; init; }

        /// <summary>
        /// Parent ID
        /// </summary>
        public string? ParentID { get; init; }

        /// <summary>
        /// HTML tag name (upper case)
        /// </summary>
        [RequiredIf(nameof(Type), DomElementTypes.Node)]
        public string? Tag { get; init; }

        /// <summary>
        /// Type
        /// </summary>
        public required DomElementTypes Type { get; init; }

        /// <summary>
        /// Attributes
        /// </summary>
        [RequiredIf(nameof(Type), DomElementTypes.Node)]
        public IReadOnlyDictionary<string, string>? Attributes { get; init; }

        /// <summary>
        /// Number of child nodes
        /// </summary>
        [Range(0, int.MaxValue)]
        public required int ChildNodesCount { get; init; }

        /// <summary>
        /// Text
        /// </summary>
        [RequiredIf(nameof(Type), DomElementTypes.Text)]
        public string? Text { get; init; }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (Type == DomElementTypes.Text) return $"#{ParentIndex} (\"{ParentID?.ToLiteral()}\"): {HttpUtility.HtmlEncode(Text?.MaxLength(byte.MaxValue).ToQuotedLiteral())}";
            if (Type == DomElementTypes.Comment) return $"#{ParentIndex} (\"{ParentID?.ToLiteral()}\"): <!-- {HttpUtility.HtmlEncode(Text?.MaxLength(byte.MaxValue).ToLiteral())} -->";
            if (Type == DomElementTypes.CDATA) return $"#{ParentIndex} (\"{ParentID?.ToLiteral()}\"): <![CDATA[{Text?.MaxLength(byte.MaxValue).ToLiteral()}]]>";
            if (Tag is null) return $"INVALID DOM ELEMENT #{ParentIndex} (\"{ParentID?.ToLiteral()}\") \"{ID?.ToLiteral()}\"";
            StringBuilder sb = new();
            sb.Append('#');
            sb.Append(ParentIndex);
            sb.Append($" (\"{ParentID?.ToLiteral()}\")");
            sb.Append(": <");
            sb.Append(Tag);
            if (ID is not null)
            {
                sb.Append(" id=\"");
                sb.Append(HttpUtility.HtmlEncode(ID.ToLiteral()));
                sb.Append('"');
            }
            if (Attributes is not null)
                foreach (var kvp in Attributes)
                {
                    sb.Append(' ');
                    sb.Append(kvp.Key);
                    sb.Append("=\"");
                    sb.Append(kvp.Value == string.Empty ? string.Empty : HttpUtility.HtmlEncode(kvp.Value.MaxLength(byte.MaxValue).ToLiteral()));
                    sb.Append('"');
                }
            if(Text is not null)
            {
                sb.Append('>');
                sb.Append(HttpUtility.HtmlEncode(Text.MaxLength(byte.MaxValue).ToLiteral()));
                sb.Append("</");
                sb.Append(Tag);
            }
            sb.Append('>');
            if (ChildNodesCount > 0)
            {
                sb.Append(" (+");
                sb.Append(ChildNodesCount);
                sb.Append(" child node(s))");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Ensure this is a valid node for several operations like event listening or DOM manipulation
        /// </summary>
        /// <param name="throwOnError">Throw an exception, if this is not a valid <see cref="DomElementTypes.Node"/>?</param>
        /// <returns>If this is a valid node</returns>
        /// <exception cref="InvalidOperationException">Not a node</exception>
        [MemberNotNullWhen(returnValue: true, nameof(ID))]
        protected virtual bool EnsureNode(bool throwOnError = true)
        {
            if (Type != DomElementTypes.Node || ID is null)
            {
                if (!throwOnError) return false;
                throw new InvalidOperationException();
            }
            return true;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (!EnsureNode(throwOnError: false)) return;
            ClearEventListenersAsync().Wait();
        }

        /// <inheritdoc/>
        protected override async Task DisposeCore()
        {
            if (!EnsureNode(throwOnError: false)) return;
            await ClearEventListenersAsync().DynamicContext();
        }

        /// <summary>
        /// Set the Blazor gateway
        /// </summary>
        /// <param name="gateway">Blazor gateway</param>
        /// <returns>This</returns>
        internal DomElement SetGateway(in BlazorGateway gateway)
        {
            EnsureUndisposed();
            if (Gateway is not null) throw new InvalidOperationException();
            Gateway = gateway;
            return this;
        }
    }
}
