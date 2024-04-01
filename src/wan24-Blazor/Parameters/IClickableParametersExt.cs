using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for extended clickable parameters
    /// </summary>
    public interface IClickableParametersExt : IClickableParameters, IBoxParametersExt
    {
        /// <summary>
        /// Click handler
        /// </summary>
        EventCallback<MouseEventArgs>? ClickHandler { get; set; }
    }
}
