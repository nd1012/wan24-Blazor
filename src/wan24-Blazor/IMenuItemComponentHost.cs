using Microsoft.AspNetCore.Components;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a component hosting menu item
    /// </summary>
    public interface IMenuItemComponentHost : IMenuItem
    {
        /// <summary>
        /// Hosted component
        /// </summary>
        ComponentBase? HostedComponent { get; set; }
    }
}
