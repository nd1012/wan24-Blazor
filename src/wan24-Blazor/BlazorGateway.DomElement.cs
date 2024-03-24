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
            return await Gateway.InvokeAsync<string?>("getElementByid", cancellationToken, id).DynamicContext() is not string json
                ? null
                : (await JsonHelper.DecodeAsync<DomElement>(json, cancellationToken).DynamicContext()
                    ?? throw new InvalidDataException("Failed to decode the DOM element")).SetGateway(this);
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
            return await Gateway.InvokeAsync<string?>("getElementsByTagName", cancellationToken, tag).DynamicContext() is not string json
                ? []
                : new((await JsonHelper.DecodeAsync<string[]>(json, cancellationToken).DynamicContext()
                    ?? throw new InvalidDataException("Failed to decode the DOM element list"))
                    .Select(json => (JsonHelper.Decode<DomElement>(json) ?? throw new InvalidDataException("Failed to decode the DOM element")).SetGateway(this)));
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
            return await Gateway.InvokeAsync<string?>("querySelector", cancellationToken, selector).DynamicContext() is not string json
                ? null
                : (await JsonHelper.DecodeAsync<DomElement>(json, cancellationToken).DynamicContext()
                    ?? throw new InvalidDataException("Failed to decode the DOM element")).SetGateway(this);
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
            return await Gateway.InvokeAsync<string?>("querySelectorAll", cancellationToken, selector).DynamicContext() is not string json
                ? []
                : new((await JsonHelper.DecodeAsync<string[]>(json, cancellationToken).DynamicContext()
                    ?? throw new InvalidDataException("Failed to decode the DOM element list"))
                    .Select(json => (JsonHelper.Decode<DomElement>(json) ?? throw new InvalidDataException("Failed to decode the DOM element")).SetGateway(this)));
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
    }
}
