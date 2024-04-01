using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a Blazor component
    /// </summary>
    public interface IBlazorComponent : IBlazorComponentParameters, IComponent, IHandleEvent, IHandleAfterRender
    {
        /// <summary>
        /// Factory CSS class (override to provide default class names)
        /// </summary>
        string? FactoryClass { get; }
        /// <summary>
        /// Horizontal align CSS extension
        /// </summary>
        string HAlignCss { get; }
        /// <summary>
        /// CSS class attribute raw HTML
        /// </summary>
        string? ClassAttribute { get; }
        /// <summary>
        /// CSS class names
        /// </summary>
        IEnumerable<string> ClassNames { get; }
        /// <summary>
        /// Factory CSS style (override to provide default styles)
        /// </summary>
        string? FactoryStyle { get; }
        /// <summary>
        /// CSS style attribute raw HTML
        /// </summary>
        string? StyleAttribute { get; }
        /// <summary>
        /// Additional factory attributes (override to provide default attributes)
        /// </summary>
        Dictionary<string, object>? FactoryAttributes { get; }
        /// <summary>
        /// All additional attributes
        /// </summary>
        Dictionary<string, object> AdditionalAttributes { get; }
        /// <summary>
        /// If the element is visible
        /// </summary>
        bool IsVisible { get; }
        /// <summary>
        /// If the element is enabled
        /// </summary>
        bool IsEnabled { get; }
        /// <summary>
        /// Update the component (rerender)
        /// </summary>
        void Update();
    }
}
