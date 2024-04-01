using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Extended bar parameters
    /// </summary>
    public record class BarParametersExt : BarParameters, IBarParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarParametersExt() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BarParametersExt(in IBarParametersExt original) : base(original)
        {
            ChildContent = original.ChildContent;
            ActiveMatch = original.ActiveMatch;
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static BarParametersExt Instance { get; set; } = new();

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (ChildContent is not null) res[nameof(ChildContent)] = ChildContent;
                res[nameof(ActiveMatch)] = ActiveMatch;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual RenderFragment? ChildContent { get; set; }

        /// <inheritdoc/>
        public virtual NavLinkMatch ActiveMatch { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IParentComponentParameters parent)
            {
                if (!excludeProperties.Contains(nameof(ChildContent))) parent.ChildContent = ChildContent;
            }
            if (other is IBarParametersExt bar)
            {
                if (!excludeProperties.Contains(nameof(ActiveMatch))) bar.ActiveMatch = ActiveMatch;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IParentComponentParameters parent)
            {
                if (includeProperties.Contains(nameof(ChildContent))) parent.ChildContent = ChildContent;
            }
            if (other is IBarParametersExt bar)
            {
                if (includeProperties.Contains(nameof(ActiveMatch))) bar.ActiveMatch = ActiveMatch;
            }
        }
    }
}
