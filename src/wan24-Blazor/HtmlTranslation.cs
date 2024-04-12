using Microsoft.AspNetCore.Components;
using System.Web;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// HTML translation
    /// </summary>
    public sealed class HtmlTranslation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        private HtmlTranslation() { }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static HtmlTranslation Instance { get; } = new();

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <returns>Translated term</returns>
        public MarkupString this[string key] => new(Current()[key]);

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="values">Parser values (will be HTML encoded)</param>
        /// <returns>Translated term</returns>
        public MarkupString this[in string key, params string[] values] => new(Current()[key, HtmlEncodeValues(values)]);

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="values">Parser values (will be converted to string and HTML encoded)</param>
        /// <returns>Translated term</returns>
        public MarkupString this[string key, params object[] values]
            => new(Current()[key, HtmlEncodeValues([.. values.Select(v => v as string ?? v.ToString() ?? string.Empty)])]);

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="count">Count</param>
        /// <param name="values">Parser values (will be HTML encoded)</param>
        /// <returns>Translated term</returns>
        public MarkupString this[in string key, in int count, params string[] values]
            => new(Current().TranslatePlural(key, count, HtmlEncodeValues(values)));

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="count">Count</param>
        /// <param name="values">Parser values (will be converted to string and HTML encoded)</param>
        /// <returns>Translated term</returns>
        public MarkupString this[string key, in int count, params object[] values]
            => new(Current().TranslatePlural(key, count, HtmlEncodeValues([.. values.Select(v => v as string ?? v.ToString() ?? string.Empty)])));

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <returns>Translated term</returns>
        public static MarkupString GetHtmlTerm(in string key) => new(Current()[key]);

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="values">Parser values (will be HTML encoded)</param>
        /// <returns>Translated term</returns>
        public static MarkupString GetHtmlTerm(in string key, params string[] values) => new(Current()[key, HtmlEncodeValues(values)]);

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="values">Parser values (will be converted to string and HTML encoded)</param>
        /// <returns>Translated term</returns>
        public static MarkupString GetHtmlTerm(in string key, params object[] values)
            => new(Current()[key, HtmlEncodeValues([.. values.Select(v => v as string ?? v.ToString() ?? string.Empty)])]);

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="count">Count</param>
        /// <param name="values">Parser values (will be HTML encoded)</param>
        /// <returns>Translated term</returns>
        public static MarkupString GetHtmlTerm(in string key, in int count, params string[] values)
            => new(Current().TranslatePlural(key, count, HtmlEncodeValues(values)));

        /// <summary>
        /// Get a translated term
        /// </summary>
        /// <param name="key">Term</param>
        /// <param name="count">Count</param>
        /// <param name="values">Parser values (will be converted to string and HTML encoded)</param>
        /// <returns>Translated term</returns>
        public static MarkupString GetHtmlTerm(in string key, in int count, params object[] values)
            => new(Current().TranslatePlural(key, count, HtmlEncodeValues([.. values.Select(v => v as string ?? v.ToString() ?? string.Empty)])));

        /// <summary>
        /// HTML encode values
        /// </summary>
        /// <param name="values">Values to encode</param>
        /// <returns>Encoded values</returns>
        public static string[] HtmlEncodeValues(params string[] values)
        {
            int len = values.Length;
            if (len < 1) return [];
            string[] res = new string[len];
            for (int i = 0; i < len; res[i] = HttpUtility.HtmlEncode(values[i]), i++) ;
            return res;
        }

        /// <summary>
        /// Get the current translation
        /// </summary>
        /// <returns>Current translation</returns>
        private static Translation Current() => Translation.Current ?? throw new InvalidOperationException("No current translation set");
    }
}
