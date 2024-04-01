namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for image parameters
    /// </summary>
    public interface IImageParameters : IBoxParameters
    {
        /// <summary>
        /// Image source URI
        /// </summary>
        string? Src { get; set; }
        /// <summary>
        /// SVG XML (ignored when <see cref="Src" /> is being used; see <see cref="Images" /> and  <see cref="Images.AsSvgXml(string)" />
        /// CAUTION: Will be used 1:1 in HTML!)
        /// </summary>
        string? SvgXml { get; set; }
        /// <summary>
        /// Image size CSS style
        /// </summary>
        string? Size { get; set; }
        /// <summary>
        /// Image width HTML attribute value
        /// </summary>
        string? Width { get; set; }
        /// <summary>
        /// Image size HTML attribute value
        /// </summary>
        string? Height { get; set; }
        /// <summary>
        /// SVG HTML color value
        /// </summary>
        string? SvgColor { get; set; }
    }
}
