using Microsoft.JSInterop;
using wan24.Core;

namespace wan24.Blazor
{
    // Download
    public partial class BlazorGateway
    {
        /// <summary>
        /// Send a file download
        /// </summary>
        /// <param name="source">Source stream (will be disposed unless <c>leaveOpen</c> was set to <see langword="true"/>)</param>
        /// <param name="fileName">Filename</param>
        /// <param name="mimeType">MIME type</param>
        /// <param name="leaveOpen">Leave the source stream open?</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public async Task SendFileDownloadAsync(
            Stream source, 
            string fileName, 
            string? mimeType = null, 
            bool leaveOpen = false, 
            CancellationToken cancellationToken = default
            )
        {
            try
            {
                EnsureUndisposed();
                using DotNetStreamReference streamRef = new(source, leaveOpen: true);
                await Gateway.InvokeAsync<string>("runStreamAsync", cancellationToken, streamRef, fileName, mimeType, true).DynamicContext();
            }
            finally
            {
                if (!leaveOpen) await source.DisposeAsync().DynamicContext();
            }
        }

        /// <summary>
        /// Add a data chunk to a running download stream
        /// </summary>
        /// <param name="id">Download stream ID</param>
        /// <param name="chunk">Data chunk</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If still streaming</returns>
        public ValueTask<bool> AddDownloadStreamChunk(string id, byte[] chunk, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            return Gateway.InvokeAsync<bool>("addDownloadStreamChunkArray", cancellationToken, id, chunk);
        }
    }
}
