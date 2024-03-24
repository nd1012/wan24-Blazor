using Microsoft.AspNetCore.Components;

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
        /// Icon size CSS
        /// </summary>
        string? IconSize { get; }
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
        /// Add a menu item (only top items!)
        /// </summary>
        /// <param name="item">Top menu item</param>
        void AddMenuItem(IMenuItem item);
        /// <summary>
        /// Find a menu item
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Found menu item</returns>
        IMenuItem? FindMenuItem(string id);
    }
}
