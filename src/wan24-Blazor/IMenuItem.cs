using Microsoft.AspNetCore.Components;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a menu item
    /// </summary>
    public interface IMenuItem : IComponent
    {
        /// <summary>
        /// DOM ID
        /// </summary>
        string? Id { get; }
        /// <summary>
        /// Menu
        /// </summary>
        IMenu? Menu { get; }
        /// <summary>
        /// Parent menu item
        /// </summary>
        IMenuParentItem? Parent { get; }
        /// <summary>
        /// Click target URI
        /// </summary>
        string? Href { get; }
        /// <summary>
        /// Click handler
        /// </summary>
        Delegate? ClickHandler { get; }
        /// <summary>
        /// Navigation target
        /// </summary>
        string? Target { get; }
        /// <summary>
        /// Text
        /// </summary>
        string? Text { get; }
        /// <summary>
        /// Text size
        /// </summary>
        Sizes TextSize { get; }
        /// <summary>
        /// Text CSS classes
        /// </summary>
        string? TextClass { get; set; }
        /// <summary>
        /// Text CSS style
        /// </summary>
        string? TextStyle { get; set; }
        /// <summary>
        /// Text attributes
        /// </summary>
        Dictionary<string, object>? TextAttributes { get; set; }
        /// <summary>
        /// Text component paraneters
        /// </summary>
        Dictionary<string, object>? TextParameters { get; set; }
        /// <summary>
        /// Icon URI
        /// </summary>
        string? Icon { get; }
        /// <summary>
        /// Icon size CSS
        /// </summary>
        string? IconSize { get; }
        /// <summary>
        /// Icon CSS classes
        /// </summary>
        string? IconClass { get; set; }
        /// <summary>
        /// Icon CSS style
        /// </summary>
        string? IconStyle { get; set; }
        /// <summary>
        /// Icon attributes
        /// </summary>
        Dictionary<string, object>? IconAttributes { get; set; }
        /// <summary>
        /// Icon component paraneters
        /// </summary>
        Dictionary<string, object>? IconParameters { get; set; }
        /// <summary>
        /// SVG icon XML
        /// </summary>
        string? SvgIconXml { get; }
        /// <summary>
        /// SVG icon CSS color (not a class name)
        /// </summary>
        string? SvgIconColor { get; }
    }
}
