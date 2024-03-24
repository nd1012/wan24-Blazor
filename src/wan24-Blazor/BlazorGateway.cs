using Microsoft.JSInterop;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Blazor gateway
    /// </summary>
    public partial class BlazorGateway : DisposableBase
    {
        /// <summary>
        /// URI to the gateway script
        /// </summary>
        public const string GATEWAY_URI =
#if !RELEASE
            "./_content/wan24.Blazor/wwwroot/js/transpiled/blazorGateway.js"
#else
            "./_content/wan24.Blazor/wwwroot/js/minified/blazorGateway.min.js"
#endif
            ;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gateway">Gateway (will be disposed!)</param>
        protected BlazorGateway(in IJSObjectReference gateway) : base()
        {
            if (Instance is not null) throw new InvalidOperationException();
            Instance = this;
            Gateway = gateway;
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static BlazorGateway? Instance { get; private set; }

        /// <summary>
        /// Gateway (will be disposed!)
        /// </summary>
        public IJSObjectReference Gateway { get; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>This</returns>
        protected virtual async Task<BlazorGateway> InitAsync(CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            await Gateway.InvokeVoidAsync("initAsync", cancellationToken).DynamicContext();
            return this;
        }

        /// <summary>
        /// Set this Blazor gateway for an element
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Element</returns>
        protected DomElement SetGateway(in DomElement element)
        {
            EnsureUndisposed();
            return element.SetGateway(this);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            Gateway.DisposeAsync().AsTask().Wait();
            Instance = null;
        }

        /// <inheritdoc/>
        protected override async Task DisposeCore()
        {
            await Gateway.DisposeAsync().DynamicContext();
            Instance = null;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="runtime">Runtime</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Blazor gateway (don't forget to dispose!)</returns>
        public static async Task<BlazorGateway> CreateAsync(IJSRuntime runtime, CancellationToken cancellationToken = default)
        {
            IJSObjectReference gateway = await runtime.InvokeAsync<IJSObjectReference>(GATEWAY_URI, cancellationToken).DynamicContext();
            try
            {
                return await new BlazorGateway(gateway).InitAsync(cancellationToken).DynamicContext();
            }
            catch
            {
                await gateway.DisposeAsync().DynamicContext();
                throw;
            }
        }
    }
}
