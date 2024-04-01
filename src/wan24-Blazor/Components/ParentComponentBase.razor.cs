using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Base class for a parent component (with child components)
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    public abstract partial class ParentComponentBase() : BlazorComponentBase(), IParentComponent, IParentComponentParameters
    {
        /// <inheritdoc/>
        [Parameter]
        public virtual RenderFragment? ChildContent { get; set; }
    }
}
