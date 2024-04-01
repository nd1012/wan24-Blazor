using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Extended body text parameters
    /// </summary>
    public record class BodyTextParametersExt : BodyTextParameters, IBodyTextParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BodyTextParametersExt() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BodyTextParametersExt(in IBodyTextParametersExt original) : base(original) => ChildContent = original.ChildContent;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static BodyTextParametersExt Instance { get; set; } = new();

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (ChildContent is not null) res[nameof(ChildContent)] = ChildContent;
                return res;
            }
        }

        /// <inheritdoc/>
        public RenderFragment? ChildContent { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IBoxParametersExt box)
            {
                if (!excludeProperties.Contains(nameof(ChildContent))) box.ChildContent = ChildContent;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IBoxParametersExt box)
            {
                if (includeProperties.Contains(nameof(ChildContent))) box.ChildContent = ChildContent;
            }
        }
    }
}
