using Microsoft.AspNetCore.Components.Routing;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Extended menu item parameters
    /// </summary>
    public interface IMenuItemParametersExt : IClickButtonParametersExt
    {
        /// <summary>
        /// Active match logic
        /// </summary>
        NavLinkMatch? ActiveMatch { get; set; }
    }
}
