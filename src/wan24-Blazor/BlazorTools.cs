using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Frozen;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Razor tools
    /// </summary>
    public static class BlazorTools
    {
        /// <summary>
        /// Unreserved URI path characters
        /// </summary>
        public static readonly FrozenSet<char> UnreservedCharacters = "-._~".ToFrozenSet();

        /// <summary>
        /// Return a value if landscape, or another value if portrait
        /// </summary>
        /// <param name="landscape">Landscape value</param>
        /// <param name="portrait">Portrait value</param>
        /// <returns>Value</returns>
        public static T? IfLandscape<T>(in T landscape, in T? portrait = default) => BlazorEnv.IsLandscape ? landscape : portrait;

        /// <summary>
        /// Return a string if landscape, or another string if portrait
        /// </summary>
        /// <param name="landscape">Landscape string</param>
        /// <param name="portrait">Portrait string</param>
        /// <returns>String (may be empty, if <c>portrait</c> wasn't given)</returns>
        public static string IfLandscape(in string landscape, in string? portrait = default) => BlazorEnv.IsLandscape ? landscape : portrait ?? string.Empty;

        /// <summary>
        /// Return a value if portrait, or another value if landscape
        /// </summary>
        /// <param name="portrait">Portrait value</param>
        /// <param name="landscape">Landscape value</param>
        /// <returns>Value</returns>
        public static T? IfPortrait<T>(in T portrait, in T? landscape = default) => BlazorEnv.IsPortrait ? portrait : landscape;

        /// <summary>
        /// Return a string if portrait, or another string if landscape
        /// </summary>
        /// <param name="portrait">Portrait string</param>
        /// <param name="landscape">Landscape string</param>
        /// <returns>String (may be empty, if <c>landscape</c> wasn't given)</returns>
        public static string IfPortrait(in string portrait, in string? landscape = default) => BlazorEnv.IsPortrait ? portrait : landscape ?? string.Empty;

        /// <summary>
        /// Return a value if having a small screen, or another value if having a large screen
        /// </summary>
        /// <param name="small">Small screen value</param>
        /// <param name="large">Large screen value</param>
        /// <returns>Value</returns>
        public static T? IfSmallScreen<T>(in T small, in T? large = default) => BlazorEnv.IsSmallScreen ? small : large;

        /// <summary>
        /// Return a string if having a small screen, or another string if having a large screen
        /// </summary>
        /// <param name="small">Small screen string</param>
        /// <param name="large">Large screen string</param>
        /// <returns>String (may be empty, if <c>large</c> wasn't given)</returns>
        public static string IfSmallScreen(in string small, in string? large = default) => BlazorEnv.IsSmallScreen ? small : large ?? string.Empty;

        /// <summary>
        /// Return a value if having a large screen, or another value if having a small screen
        /// </summary>
        /// <param name="large">Large screen value</param>
        /// <param name="small">Small screen value</param>
        /// <returns>Value</returns>
        public static T? IfLargeScreen<T>(in T large, in T? small = default) => !BlazorEnv.IsSmallScreen ? large : small;

        /// <summary>
        /// Return a string if having a large screen, or another string if having a small screen
        /// </summary>
        /// <param name="large">Large screen string</param>
        /// <param name="small">Small screen string</param>
        /// <returns>String (may be empty, if <c>small</c> wasn't given)</returns>
        public static string IfLargeScreen(in string large, in string? small = default) => !BlazorEnv.IsSmallScreen ? large : small ?? string.Empty;

        /*/// <summary>
        /// Show an info dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static void InfoDialog(in string message, in string? title = null) => BlazorEnv.CurrentDialogService?.Info(message, title ?? _("Info"));

        /// <summary>
        /// Show a warning dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static void WarningDialog(in string message, in string? title = null) => BlazorEnv.CurrentDialogService?.Warning(message, title ?? _("Warning"));

        /// <summary>
        /// Show an error dialog
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        public static void ErrorDialog(in string message, in string? title = null) => BlazorEnv.CurrentDialogService?.Error(message, title ?? _("Error"));*/

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
