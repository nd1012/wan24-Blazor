using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for parent parameters
    /// </summary>
    public interface IParentComponentParameters : IBlazorComponentParameters
    {
        /// <summary>
        /// Child content
        /// </summary>
        RenderFragment? ChildContent { get; set; }
    }
}
