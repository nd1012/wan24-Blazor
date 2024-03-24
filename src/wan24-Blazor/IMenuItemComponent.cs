using Microsoft.AspNetCore.Components;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for menu item component, which can be hosted by a <see cref="IMenuItemComponentHost"/>
    /// </summary>
    public interface IMenuItemComponent : IComponent
    {
        /// <summary>
        /// Menu
        /// </summary>
        IMenu? Menu { get; }
        /// <summary>
        /// Menu item component host
        /// </summary>
        IMenuItemComponentHost? Parent { get; }
    }
}
