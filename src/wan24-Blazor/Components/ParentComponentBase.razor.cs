using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Base class for a parent component (with child components)
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    public abstract partial class ParentComponentBase() : BlazorComponentBase(), IServeChildContent
    {
        /// <inheritdoc/>
        [Parameter]
        public virtual RenderFragment? ChildContent { get; set; }
    }
}
