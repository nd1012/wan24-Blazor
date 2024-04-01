using Microsoft.AspNetCore.Components.Routing;

namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Interface for bar parameters
    /// </summary>
    public interface IBarParametersExt : IBarParameters, IParentComponentParameters
    {
        /// <summary>
        /// Active menu item match logic
        /// </summary>
        NavLinkMatch ActiveMatch { get; set; }
    }
}
