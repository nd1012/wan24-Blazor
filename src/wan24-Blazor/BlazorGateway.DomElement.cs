using Microsoft.JSInterop;
using wan24.Core;

namespace wan24.Blazor
{
    // DOM element
    public partial class BlazorGateway
    {
        /// <summary>
        /// Get a DOM element by its ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>DOM element (don't forget to dispose!)</returns>
        public virtual async ValueTask<DomElement?> GetElementByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            return await Gateway.InvokeAsync<string?>("getElementByid", cancellationToken, id).DynamicContext() is string json
                ? SetGateway(JsonHelper.Decode<DomElement>(json) ?? throw new InvalidDataException("Failed to decode DOM element"))
                : null;
        }

        /// <summary>
        /// Get DOM elements by HTML tag name
        /// </summary>
        /// <param name="tag">HTML tag name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>DOM elements (don't forget to dispose!)</returns>
        public virtual async ValueTask<HashSet<DomElement>> GetElementsByTagNameAsync(string tag, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            return new((JsonHelper.Decode<DomElement[]>(await Gateway.InvokeAsync<string>("getElementsByTagName", cancellationToken, tag).DynamicContext())
                ?? throw new InvalidDataException("Failed to decode DOM element list"))
                .Select(e => SetGateway(e)));
        }

        /// <summary>
        /// Get a DOM element by CSS selector
        /// </summary>
        /// <param name="selector">CSS selector</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>DOM element (don't forget to dispose!)</returns>
        public virtual async ValueTask<DomElement?> QuerySelectorAsync(string selector, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            return await Gateway.InvokeAsync<string?>("querySelector", cancellationToken, selector).DynamicContext() is string json
                ? SetGateway(JsonHelper.Decode<DomElement>(json) ?? throw new InvalidDataException("Failed to decode DOM element"))
                : null;
        }

        /// <summary>
        /// Get DOM elements by CSS selector
        /// </summary>
        /// <param name="selector">CSS selector</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>DOM elements (don't forget to dispose!)</returns>
        public virtual async ValueTask<HashSet<DomElement>> QuerySelectorAllAsync(string selector, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            return new((JsonHelper.Decode<HashSet<DomElement>>(await Gateway.InvokeAsync<string>("querySelectorAll", cancellationToken, selector).DynamicContext())
                ?? throw new InvalidDataException("Failed to decode DOM element list"))
                .Select(e => SetGateway(e)));
        }

        /// <summary>
        /// Get the element count of a CSS selector
        /// </summary>
        /// <param name="selector">CSS selector</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Element count</returns>
        public virtual async ValueTask<int> QuerySelectorAllCountAsync(string selector, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            return await Gateway.InvokeAsync<int>("querySelectorAllCount", cancellationToken, selector).DynamicContext();
        }

        /// <summary>
        /// Create a new DOM element
        /// </summary>
        /// <param name="parent">Parent ID</param>
        /// <param name="tag">HTML tag name</param>
        /// <param name="id">ID</param>
        /// <param name="attr">Attributes</param>
        /// <param name="text">Inner text</param>
        /// <param name="html">Inner HTML</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>New DOM element ID or <see langword="null"/> on error (see JS console messages)</returns>
        public virtual async ValueTask<string?> CreateElementAsync(
            string parent,
            string tag,
            string? id = null,
            Dictionary<string, string>? attr = null,
            string? text = null,
            string? html = null,
            CancellationToken cancellationToken = default
            )
        {
            EnsureUndisposed();
            return await Gateway.InvokeAsync<string?>("createElement", cancellationToken, [
                parent,
                tag,
                id,
                attr is null ? null : JsonHelper.Encode(attr),
                text,
                html
                ]).DynamicContext();
        }
    }
}
