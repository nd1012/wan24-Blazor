using System.Diagnostics.CodeAnalysis;
using wan24.Core;

namespace wan24.Blazor
{
    // DOM
#pragma warning disable CS8774 // ID must not be NULL when leaving the method
    public partial record class DomElement
    {
        /// <summary>
        /// Create the (non-comment/CDATA/text) element to the DOM (<see cref="ParentID"/> needs to be set; <see cref="ID"/>, <see cref="Attributes"/> and 
        /// <see cref="Text"/> may be set)
        /// </summary>
        /// <param name="tag">HTML tag name</param>
        /// <param name="html">Inner HTML (would overwrite <see cref="Text"/>)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>New DOM element ID or <see langword="null"/>, if failed (see JS console messages)</returns>
        public virtual ValueTask<string?> CreateAsync(string tag, string? html = null, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            if (Type != DomElementTypes.Node) throw new InvalidOperationException("Not supported for comment/CDATA/text elements");
            return Gateway.CreateElementAsync(
                ParentID ?? throw new InvalidOperationException("Missing Parent ID"),
                tag,
                ID,
                Attributes is null ? null : new(Attributes),
                Text,
                html,
                cancellationToken
                );
        }

        /// <summary>
        /// Remove from the DOM (all event handlers will be removed also)
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If the element was removed</returns>
        [MemberNotNull(nameof(ID))]
        public virtual ValueTask<bool> RemoveAsync(CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            EnsureNode();
            EventHandlers.Clear();
            Elements.TryRemove(ID!, out _);
            return Gateway.Gateway.InvokeAsync<bool>("removeElement", cancellationToken, [ID]);
        }

        /// <summary>
        /// Set an attribute
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If the attribute was set</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> SetAttributeAsync(string name, string value, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed(allowDisposing: true);
            EnsureNode();
            EventHandlers.Clear();
            Elements.TryRemove(ID!, out _);
            return await Gateway.Gateway.InvokeAsync<bool>("setAttribute", cancellationToken, [ID, name, value]).DynamicContext();
        }

        /// <summary>
        /// Remove an attribute
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If the attribute was removed</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> RemoveAttributeAsync(string name, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed(allowDisposing: true);
            EnsureNode();
            EventHandlers.Clear();
            Elements.TryRemove(ID!, out _);
            return await Gateway.Gateway.InvokeAsync<bool>("removeAttribute", cancellationToken, [ID, name]).DynamicContext();
        }

        /// <summary>
        /// Insert this element before an element
        /// </summary>
        /// <param name="target">Target element</param>
        /// <param name="index">Other element index</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If inserted</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> InsertBeforeAsync(DomElement target, int index, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed(allowDisposing: true);
            EnsureNode();
            if (!target.EnsureNode(throwOnError: false)) throw new ArgumentException("Invalid target", nameof(target));
            return await Gateway.Gateway.InvokeAsync<bool>("insertBefore", cancellationToken, [ID, target.ID, index]).DynamicContext();
        }

        /// <summary>
        /// Append this element
        /// </summary>
        /// <param name="target">Target element</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If inserted</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> AppendChildAsync(DomElement target, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed(allowDisposing: true);
            EnsureNode();
            if (!target.EnsureNode(throwOnError: false)) throw new ArgumentException("Invalid target", nameof(target));
            return await Gateway.Gateway.InvokeAsync<bool>("appendChild", cancellationToken, [ID, target.ID]).DynamicContext();
        }

        /// <summary>
        /// Validate this element exists in the DOM
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If this element exists in the DOM</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default)
        {
            EnsureUndisposed(allowDisposing: true);
            EnsureNode();
            return await Gateway.Gateway.InvokeAsync<bool>("exists", cancellationToken, [ID]).DynamicContext();
        }

        /// <summary>
        /// Reload
        /// </summary>
        /// <param name="dispose">Dispose this instance?</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>DOM element (don't forget to dispose!)</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async ValueTask<DomElement?> ReloadAsync(bool dispose = true, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            try
            {
                EnsureNode();
                return await Gateway.GetElementByIdAsync(ID!, cancellationToken).DynamicContext();
            }
            finally
            {
                if (dispose) await DisposeAsync().DynamicContext();
            }
        }

        /// <summary>
        /// Query a child element
        /// </summary>
        /// <param name="selector">CSS selector (start with <c>&gt;</c> to start the selector from this element)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Child element</returns>
        [MemberNotNull(nameof(ID))]
        public virtual ValueTask<DomElement?> QuerySelectorAsync(string selector, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            EnsureNode();
            if (string.IsNullOrWhiteSpace(selector)) throw new ArgumentException("Selector required", nameof(selector));
            if (selector.StartsWith('>')) selector = $"#{ID}{selector}";
            return Gateway.QuerySelectorAsync(selector, cancellationToken);
        }

        /// <summary>
        /// Query child elements
        /// </summary>
        /// <param name="selectors">CSS selector (start with <c>&gt;</c> to start the selector from this element)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Child elements</returns>
        [MemberNotNull(nameof(ID))]
        public virtual ValueTask<HashSet<DomElement>> QuerySelectorAllAsync(string[] selectors, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            EnsureNode();
            if (selectors.Length < 1) throw new ArgumentException("Selectors required", nameof(selectors));
            if (selectors.Any(s => string.IsNullOrWhiteSpace(s))) throw new ArgumentException("Found invalid empty selector", nameof(selectors));
            return Gateway.QuerySelectorAllAsync(string.Join(',', selectors.Select(s => s.StartsWith('>') ? $"#{ID}{s}" : s)), cancellationToken);
        }
    }
#pragma warning restore CS8774 // ID must not be NULL when leaving the method
}
