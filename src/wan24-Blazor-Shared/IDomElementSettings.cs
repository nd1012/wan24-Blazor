namespace wan24.Blazor
{
    /// <summary>
    /// Interface for DOM element settings
    /// </summary>
    public interface IDomElementSettings
    {
        /// <summary>
        /// CSS class names
        /// </summary>
        string? Class { get; set; }
        /// <summary>
        /// CSS style
        /// </summary>
        string? Style { get; set; }
        /// <summary>
        /// HTML element attributes
        /// </summary>
        Dictionary<string, object>? Attributes { get; set; }
    }
}
