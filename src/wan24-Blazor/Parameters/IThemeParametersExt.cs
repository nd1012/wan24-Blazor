using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for extended theme parameters
    /// </summary>
    public interface IThemeParametersExt : IThemeParameters
    {
        /// <summary>
        /// Child content
        /// </summary>
        RenderFragment? ChildContent { get; set; }
    }
}
