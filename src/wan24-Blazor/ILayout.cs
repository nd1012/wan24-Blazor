using Microsoft.AspNetCore.Components;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a layout
    /// </summary>
    public interface ILayout : IComponent, IHandleEvent, IHandleAfterRender, IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// If disposing
        /// </summary>
        bool IsDisposing { get; }
        /// <summary>
        /// If disposed
        /// </summary>
        bool IsDisposed { get; }
        /// <summary>
        /// If a changed display changes the state (forces re-rendering)
        /// </summary>
        bool DisplayChangesState { get; }
        /// <summary>
        /// If a changed color mode changes the state (forces re-rendering)
        /// </summary>
        bool ColorModeChangesState { get; }
        /// <summary>
        /// HTML tag name
        /// </summary>
        string TagName { get; }
        /// <summary>
        /// ID
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Theme
        /// </summary>
        IBsTheme? Theme { get; }
        /// <summary>
        /// CSS class
        /// </summary>
        string? Class { get; }
        /// <summary>
        /// Factory CSS class (override to provide default class names)
        /// </summary>
        string? FactoryClass { get; }
        /// <summary>
        /// Flex box type
        /// </summary>
        FlexBoxTypes Flex { get; }
        /// <summary>
        /// Overflow type
        /// </summary>
        OverflowTypes Overflow { get; }
        /// <summary>
        /// X-overflow type
        /// </summary>
        OverflowTypes OverflowX { get; }
        /// <summary>
        /// Y-overflow type
        /// </summary>
        OverflowTypes OverflowY { get; }
        /// <summary>
        /// CSS class attribute raw HTML
        /// </summary>
        string? ClassAttribute { get; }
        /// <summary>
        /// CSS class names
        /// </summary>
        IEnumerable<string> ClassNames { get; }
        /// <summary>
        /// CSS style
        /// </summary>
        string? Style { get; }
        /// <summary>
        /// Factory CSS style (override to provide default styles)
        /// </summary>
        string? FactoryStyle { get; }
        /// <summary>
        /// CSS style attribute raw HTML
        /// </summary>
        string? StyleAttribute { get; }
        /// <summary>
        /// Additional attributes
        /// </summary>
        Dictionary<string, object>? Attributes { get; }
        /// <summary>
        /// Additional factory attributes (override to provide default attributes)
        /// </summary>
        Dictionary<string, object>? FactoryAttributes { get; }
        /// <summary>
        /// All additional attributes
        /// </summary>
        Dictionary<string, object> AdditionalAttributes { get; }
    }
}
