using BlazorComponentUtilities;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Get the final CSS classes
        /// </summary>
        /// <param name="builder">Builder</param>
        /// <returns>Classes or <see langword="null"/>, if empty</returns>
        public static string? FinalClasses(this CssBuilder builder)
            => builder.NullIfEmpty() is not string res ? null : string.Join(' ', res.Split(' ').Where(c => !string.IsNullOrWhiteSpace(c)).Distinct()).Trim();

        /// <summary>
        /// Get the final CSS style
        /// </summary>
        /// <param name="builder">Builder</param>
        /// <returns>Style or <see langword="null"/>, if empty</returns>
        public static string? FinalStyle(this StyleBuilder builder)
        {
            if (builder.NullIfEmpty() is not string res) return null;
            while (res.StartsWith(';')) res = res[1..];
            while (res.Contains(";;")) res = res.Replace(";;", ";");
            while (res.Contains("; ;")) res = res.Replace("; ;", ";");
            res = res.Trim();
            return string.IsNullOrWhiteSpace(res) ? null : res;
        }

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <param name="gateway">Gateway</param>
        /// <param name="id">DOM element ID to set</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Style element ID</returns>
        public static async Task<string> ApplyAsync(this IBsTheme theme, BlazorGateway? gateway = null, string? id = null, CancellationToken cancellationToken = default)
        {
            gateway ??= BlazorGateway.Instance ?? throw new ArgumentNullException(nameof(gateway));
            DomElement head = (await gateway.GetElementsByTagNameAsync("head", cancellationToken).DynamicContext()).FirstOrDefault()
                ?? throw new InvalidDataException("Missing HEAD element in DOM");
            await using (head.DynamicContext())
                return await gateway.CreateElementAsync(
                    head.ID!,
                    "style",
                    id,
                    new Dictionary<string, string>()
                    {
                        {"type", "text/css" }
                    },
                    text: theme.ToString(),
                    cancellationToken: cancellationToken
                    ).DynamicContext()
                    ?? throw new InvalidOperationException("Failed to create the theme style DOM element (see JS console messages)");
        }
    }
}
