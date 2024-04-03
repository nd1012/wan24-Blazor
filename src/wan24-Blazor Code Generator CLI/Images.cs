using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using wan24.Blazor.Parameters;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Images (Bootstrap Icons SVG files; property name is the sanitized filename with the <c>Icon_</c> prefix and without extension)
    /// </summary>
    public static class Images
    {
        /// <summary>
        /// All image properties (key is the filename with the <c>Icon_</c> prefix and without extension)
        /// </summary>
        private static readonly FrozenDictionary<string, PropertyInfoExt> All;

        /// <summary>
        /// Constructor
        /// </summary>
        static Images()
        {
            PropertyInfoExt[] properties = typeof(Images).GetPropertiesCached();
            int len = properties.Length;
            Dictionary<string, PropertyInfoExt> images = new(len);
            for (int i = 0; i < len; images[properties[i].Name] = properties[i], i++) ;
            All = images.ToFrozenDictionary();
        }

        /// <summary>
        /// All image property names
        /// </summary>
        public static IEnumerable<string> Names => All.Keys;

#define CONTENT

        /// <summary>
        /// Decode the raw SVG XML from an image data URI
        /// </summary>
        /// <param name="image">Image data URI</param>
        /// <returns>Raw SVG XML</returns>
        public static string AsSvgXml(this string image)
        {
            if (!image.StartsWith("data:image/svg+xml;base64, ")) throw new ArgumentException("Not a valid data URI", nameof(image));
            return image.AsSpan(27).DecodeBase64().ToUtf8String();
        }

        /// <summary>
        /// Get SVG image parameters from an image data URI
        /// </summary>
        /// <param name="image">Image data URI</param>
        /// <returns>Image parameters</returns>
        public static ImageParameters AsImageParameters(this string image) => new()
        {
            SvgXml = AsSvgXml(image)
        };

        /// <summary>
        /// Get an image by its name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Image data URI</returns>
        public static string? GetByName(string name)
        {
            string? key = All.Keys.FirstOrDefault(k => k.Equals(name, StringComparison.OrdinalIgnoreCase));
            return key is null ? null : (string)All[key].GetValueFast(obj: null)!;
        }

        /// <summary>
        /// Get an image by its name
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="result">Result</param>
        /// <returns>If succeed</returns>
        public static bool TryGetByName(string name, [NotNullWhen(returnValue: true)] out string? result)
        {
            string? key = All.Keys.FirstOrDefault(k => k.Equals(name, StringComparison.OrdinalIgnoreCase));
            result = key is null ? null : (string)All[key].GetValueFast(obj: null)!;
            return key is not null;
        }
    }
}
