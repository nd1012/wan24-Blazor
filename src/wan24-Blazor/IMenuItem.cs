using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using wan24.Blazor.Parameters;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a menu item
    /// </summary>
    public interface IMenuItem : IComponent
    {
        /// <summary>
        /// Menu
        /// </summary>
        IMenu? Menu { get; }
        /// <summary>
        /// Parent menu item
        /// </summary>
        IMenuParentItem? Parent { get; }
        /// <summary>
        /// DOM ID
        /// </summary>
        string? Id { get; }
        /// <summary>
        /// Click target URI
        /// </summary>
        string? Href { get; }
        /// <summary>
        /// Click handler
        /// </summary>
        EventCallback<MouseEventArgs>? ClickHandler { get; }
        /// <summary>
        /// Navigation target
        /// </summary>
        string? Target { get; }
        /// <summary>
        /// Active menu item <see cref="Href"/> match logic to apply (default is the menu setting from <see cref="IMenu.ActiveMatch"/> or <see cref="NavLinkMatch.All"/>)
        /// </summary>
        NavLinkMatch? ActiveMatch { get; }
        /// <summary>
        /// Text
        /// </summary>
        string? Text { get; }
        /// <summary>
        /// Icon parameters
        /// </summary>
        IImageParameters? IconParameters { get; }
        /// <summary>
        /// Active parameters
        /// </summary>
        IImageParameters? ActiveIconParameters { get; }
        /// <summary>
        /// Text parameters
        /// </summary>
        IBoxParameters? TextParameters { get; }
        /// <summary>
        /// Get/set if this is an active item
        /// </summary>
        bool IsActiveItem { get; set; }
        /// <summary>
        /// Update the component (rerender)
        /// </summary>
        void Update();
    }
}
