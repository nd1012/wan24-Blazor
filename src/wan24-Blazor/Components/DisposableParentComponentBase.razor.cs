using wan24.Core;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Base class for a disposable component with child content
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="asyncDisposing">If <see cref="DisposeCore"/> was implemented</param>
    public abstract partial class DisposableParentComponentBase(in bool asyncDisposing) : ParentComponentBase(), IDisposable, IAsyncDisposable
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
        /// Destructor
        /// </summary>
        ~DisposableParentComponentBase()
        {
            if (_IsDisposing) return;
            Dispose(disposing: false);
        }

        /// <summary>
        /// If disposing
        /// </summary>
        public bool IsDisposing => _IsDisposing;

        /// <summary>
        /// If disposed
        /// </summary>
        public bool IsDisposed => _IsDisposed;

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">If disposing</param>
        protected virtual void Dispose(bool disposing) { }

        /// <inheritdoc/>
        protected virtual Task DisposeCore() => Task.CompletedTask;

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
            _IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}

