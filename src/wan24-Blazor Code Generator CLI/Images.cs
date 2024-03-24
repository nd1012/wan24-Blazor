using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Images (SVG)
    /// </summary>
    public static class Images
    {
#define CONTENT

        /// <summary>
        /// Decode the raw SVG XML from an image
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns>Raw SVG XML</returns>
        public static string AsSvgXml(this string image)
        {
            if (!image.StartsWith("data:image/svg+xml;base64, ")) throw new ArgumentException("Not a valid data URI", nameof(image));
            return image.AsSpan(27).DecodeBase64().ToUtf8String();
        }
    }
}
