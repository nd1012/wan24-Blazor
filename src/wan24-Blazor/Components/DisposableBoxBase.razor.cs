using wan24.Core;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Base class for a disposable <see cref="Box"/> component
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="tagName">HTML tag name</param>
    /// <param name="asyncDisposing">If <see cref="DisposeCore"/> was implemented</param>
    public abstract partial class DisposableBoxBase(in string tagName, in bool asyncDisposing = false) : Box(tagName), IDisposableParentComponent
    {
        /// <summary>
        /// An object for thread synchronization
        /// </summary>
        protected readonly object DisposeLock = new();
        /// <summary>
        /// Dispose cancellation
        /// </summary>
        protected readonly CancellationTokenSource DisposeCancellation = new();
        /// <summary>
        /// If <see cref="DisposeCore"/> was implemented
        /// </summary>
        protected readonly bool AsyncDisposing = asyncDisposing;
        /// <summary>
        /// If disposing
        /// </summary>
        private bool _IsDisposing = false;
        /// <summary>
        /// If disposed
        /// </summary>
        private bool _IsDisposed = false;
        /// <summary>
        /// DOM element
        /// </summary>
        private DomElement? Element = null;

        /// <summary>
        /// Constructor
        /// </summary>
        protected DisposableBoxBase() : this(asyncDisposing: false) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="asyncDisposing">If <see cref="DisposeCore"/> was implemented</param>
        protected DisposableBoxBase(in bool asyncDisposing) : this("div", asyncDisposing) { }

        /// <summary>
        /// Destructor
        /// </summary>
        ~DisposableBoxBase()
        {
            if (_IsDisposing) return;
            Dispose(disposing: false);
        }

        /// <inheritdoc/>
        public bool IsDisposing => _IsDisposing;

        /// <inheritdoc/>
        public bool IsDisposed => _IsDisposed;

        /// <inheritdoc/>
        public async Task<DomElement> GetDomElement(CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            if (Element is not null) return Element;
            if (BlazorGateway.Instance is null || Id is null) throw new InvalidOperationException();
            return Element = await BlazorGateway.Instance.GetElementByIdAsync(Id, cancellationToken).DynamicContext()
                ?? throw new InvalidDataException($"DOM element \"{Id}\" not found");
        }

        /// <summary>
        /// Ensure undisposed state
        /// </summary>
        /// <param name="allowDisposing">Allow disposing?</param>
        /// <param name="throwWhenDisposing">Throw an exception when disposing</param>
        /// <returns>If not disposed</returns>
        /// <exception cref="ObjectDisposedException">Disposing or disposed</exception>
        protected virtual bool EnsureUndisposed(in bool allowDisposing = false, in bool throwWhenDisposing = true)
        {
            if (!_IsDisposed && (!_IsDisposing || allowDisposing)) return true;
            if (!throwWhenDisposing) return false;
            throw new ObjectDisposedException(GetType().ToString());
        }

        /// <summary>
        /// Dispose the DOM element
        /// </summary>
        protected virtual void DisposeElement()
        {
            if (Element is null) return;
            Element.Dispose();
            Element = null;
        }

        /// <summary>
        /// Dispose the DOM element
        /// </summary>
        protected virtual async Task DisposeElementAsync()
        {
            if (Element is null) return;
            await Element.DisposeAsync().DynamicContext();
            Element = null;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">If disposing</param>
        protected virtual void Dispose(bool disposing) { }

        /// <summary>
        /// Dispose
        /// </summary>
        protected virtual Task DisposeCore() => Task.CompletedTask;

        /// <inheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            if (!IsVisible) await DisposeElementAsync().DynamicContext();
            await base.OnInitializedAsync().DynamicContext();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            lock (DisposeLock)
            {
                if (_IsDisposing) return;
                _IsDisposing = true;
            }
            DisposeCancellation.Cancel();
            Dispose(disposing: true);
            DisposeCancellation.Dispose();
            DisposeElement();
            _IsDisposed = true;
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (!AsyncDisposing)
            {
                Dispose();
                return;
            }
            lock (DisposeLock)
            {
                if (_IsDisposing) return;
                _IsDisposing = true;
            }
            DisposeCancellation.Cancel();
            await DisposeCore().DynamicContext();
            DisposeCancellation.Dispose();
            await DisposeElementAsync().DynamicContext();
            _IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
