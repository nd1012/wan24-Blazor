namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a disposable Blazor component
    /// </summary>
    public interface IDisposableBlazorComponent : IBlazorComponent, IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// If disposing
        /// </summary>
        bool IsDisposing { get; }
        /// <summary>
        /// If disposed
        /// </summary>
        bool IsDisposed { get; }
        /// <summary>
        /// Get the DOM element
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>DOM element (will be disposed)</returns>
        Task<DomElement> GetDomElement(CancellationToken cancellationToken = default);
    }
}
