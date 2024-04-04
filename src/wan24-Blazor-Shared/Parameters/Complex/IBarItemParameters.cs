namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Interface for bar item parameters
    /// </summary>
    public interface IBarItemParameters : IBlazorComponentParameters
    {
        /// <summary>
        /// URI
        /// </summary>
        string? Href { get; set; }
        /// <summary>
        /// URI target
        /// </summary>
        string? Target { get; set; }
        /// <summary>
        /// Text
        /// </summary>
        string? Text { get; set; }
        /// <summary>
        /// Icon parameters
        /// </summary>
        IImageParameters? IconParameters { get; set; }
        /// <summary>
        /// Active icn parameters
        /// </summary>
        IImageParameters? ActiveIconParameters { get; set; }
        /// <summary>
        /// Text parameters
        /// </summary>
        IBoxParameters? TextParameters { get; set; }
        /// <summary>
        /// Component parameters (used as <see cref="BoxParameters.TagName"/> for <c>Box</c> based component parameters)
        /// </summary>
        IParameters? ComponentParameters { get; set; }
        /// <summary>
        /// Is an active menu item?
        /// </summary>
        bool IsActiveItem { get; set; }
        /// <summary>
        /// Component type
        /// </summary>
        Type Type { get; set; }
        /// <summary>
        /// Component DOM element HTML tag name
        /// </summary>
        string? ComponentTagName { get; set; }
    }
}
