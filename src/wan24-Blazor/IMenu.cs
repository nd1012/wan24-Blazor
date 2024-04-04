using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using wan24.Blazor.Components;
using wan24.Blazor.Components.Complex;
using wan24.Blazor.Parameters;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a menu
    /// </summary>
    public interface IMenu : IComponent
    {
        /// <summary>
        /// DOM ID
        /// </summary>
        string? Id { get; }
        /// <summary>
        /// Menu items (contains only top items)
        /// </summary>
        IEnumerable<IMenuItem> Items { get; }
        /// <summary>
        /// Navigation manager
        /// </summary>
        NavigationManager Navigation { get; }
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
        /// Component parameters
        /// </summary>
        IParameters? ComponentParameters { get; set; }
        /// <summary>
        /// Default <see cref="BarItem"/> component type (overrides the default <see cref="MenuItem"/>)
        /// </summary>
        Type? ComponentType { get; }
        /// <summary>
        /// Show item text?
        /// </summary>
        bool ShowText { get; }
        /// <summary>
        /// Show item text in horizontal bar display mode?
        /// </summary>
        bool ShowTextHorizontal { get; }
        /// <summary>
        /// Show item text in vertical bar display mode?
        /// </summary>
        bool ShowTextVertical { get; }
        /// <summary>
        /// Show item text on landscape display?
        /// </summary>
        bool ShowTextOnLandscape { get; }
        /// <summary>
        /// Show item text on portrait display?
        /// </summary>
        bool ShowTextOnPortrait { get; }
        /// <summary>
        /// Show item text on small landscape display?
        /// </summary>
        bool ShowTextOnSmallLandscape { get; }
        /// <summary>
        /// Show item text on small portrait display?
        /// </summary>
        bool ShowTextOnSmallPortrait { get; }
        /// <summary>
        /// Active menu item <see cref="IMenuItem.Href"/> match logic to apply
        /// </summary>
        NavLinkMatch ActiveMatch { get; }
        /// <summary>
        /// Get/set the active menu item during rendering
        /// </summary>
        IMenuItem? ActiveItem { get; set; }
        /// <summary>
        /// Show the active menu item?
        /// </summary>
        bool ShowActive { get; }
        /// <summary>
        /// Show all menu items from the active menu item to its root as active?
        /// </summary>
        bool ShowActivePath { get; }
        /// <summary>
        /// Add a menu item (only top items!)
        /// </summary>
        /// <param name="item">Top menu item</param>
        void AddMenuItem(IMenuItem item);
        /// <summary>
        /// Update the menu
        /// </summary>
        void Update();
    }
}
