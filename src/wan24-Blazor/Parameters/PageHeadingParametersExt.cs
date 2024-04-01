using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Extended page heading parameters
    /// </summary>
    public record class PageHeadingParametersExt : PageHeadingParameters, IPageHeadingParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PageHeadingParametersExt() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public PageHeadingParametersExt(in IPageHeadingParametersExt original) : base(original) => ChildContent = original.ChildContent;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static PageHeadingParametersExt Instance { get; set; } = new();

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
            if (other is IParentComponentParameters parent)
            {
                if (!excludeProperties.Contains(nameof(ChildContent))) parent.ChildContent = ChildContent;
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
        }
    }
}
