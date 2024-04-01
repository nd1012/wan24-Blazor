using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Frozen;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Shared Blazor tools
    /// </summary>
    public static class BlazorToolsShared
    {
        /// <summary>
        /// Unreserved URI path characters
        /// </summary>
        public static readonly FrozenSet<char> UnreservedCharacters = "-._~".ToFrozenSet();

        /// <summary>
        /// Determine if an absolute URI path matches another absolute URI path (completely (with or without trailing slash) or as prefix)
        /// </summary>
        /// <param name="href">Absolute URI path</param>
        /// <param name="uriAbsolute">Another absolute URI path</param>
        /// <param name="match">Matching logic</param>
        /// <returns>If matches</returns>
        public static bool IsHrefMatch(in string href, in string uriAbsolute, in NavLinkMatch match = NavLinkMatch.All)
            // https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Routing/NavLink.cs
            => EqualsHrefExactlyOrIfTrailingSlashAdded(href, uriAbsolute) ||
                (match == NavLinkMatch.Prefix && IsHrefStrictlyPrefixWithSeparator(href, uriAbsolute));

        /// <summary>
        /// Determine if an absolute URI path matches another absolute URI path exactly (with or without trailing slash)
        /// </summary>
        /// <param name="href">Absolute URI path</param>
        /// <param name="uriAbsolute">Another absolute URI path</param>
        /// <returns>If equal</returns>
        public static bool EqualsHrefExactlyOrIfTrailingSlashAdded(in string href, in string uriAbsolute)
            => uriAbsolute.Equals(href, StringComparison.OrdinalIgnoreCase) ||
                (
                    uriAbsolute.Length == href.Length - 1 &&
                    href[^1] == '/' &&
                    href.StartsWith(uriAbsolute, StringComparison.OrdinalIgnoreCase)
                );

        /// <summary>
        /// Determine if an absolute URI path is the prefix of another absolute URI path
        /// </summary>
        /// <param name="href">Absolute URI path</param>
        /// <param name="uriAbsolute">Another absolute URI path</param>
        /// <returns>If matches as prefix</returns>
        public static bool IsHrefStrictlyPrefixWithSeparator(in string href, in string uriAbsolute)
        {
            int hrefLen = href.Length;
            if (uriAbsolute.Length < hrefLen) return false;
            if (hrefLen == 0) return true;
            if (!uriAbsolute.StartsWith(href, StringComparison.OrdinalIgnoreCase)) return false;
            char chr = href[^1];
            if (!(char.IsLetterOrDigit(chr) || UnreservedCharacters.Contains(chr))) return true;
            chr = uriAbsolute[^1];
            return !(char.IsLetterOrDigit(chr) || UnreservedCharacters.Contains(chr));
        }

        /// <summary>
        /// Get the absolute URI path from a Href value (without parameters and anchor)
        /// </summary>
        /// <param name="navigation">Navigation</param>
        /// <param name="href">Href value</param>
        /// <returns>Absolute URI path</returns>
        public static string GetAbsoluteUriPathFromHref(in NavigationManager navigation, in string href)
        {
            if (href.Length == 0 || href[0] == '#') return new Uri(navigation.Uri).AbsolutePath;
            if (href[0] == '/') return href;
            if (Uri.TryCreate(href, UriKind.Absolute, out Uri? uri)) return uri.AbsolutePath;
            uri = new(navigation.Uri);
            return FsHelper.NormalizeLinuxDisplayPath(Path.Combine(uri.AbsolutePath, href));
        }
    }
}
