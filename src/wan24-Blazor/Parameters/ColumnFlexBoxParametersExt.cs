using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Extended column flex box parameters
    /// </summary>
    public record class ColumnFlexBoxParametersExt : ColumnFlexBoxParameters, IColumnFlexBoxParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColumnFlexBoxParametersExt() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        public ColumnFlexBoxParametersExt(in IColumnFlexBoxParametersExt original) : base(original) => ChildContent = original.ChildContent;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static ColumnFlexBoxParametersExt Instance { get; set; } = new();

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
