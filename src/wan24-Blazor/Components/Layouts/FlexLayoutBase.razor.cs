using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tagName">HTML tag name</param>
    public abstract partial class FlexLayoutBase(in string? tagName = null) : LayoutBase(tagName), IFlexLayout
    {
        /// <inheritdoc/>
        public bool StretchContentSidebar { get; protected set; }

        /// <inheritdoc/>
        public string BodyTag { get; protected set; } = "main";

        /// <inheritdoc/>
        public Dictionary<string, object>? BodyParameters { get; protected set; }

        /// <inheritdoc/>
        public virtual FlexBoxTypes ContentFlex => IsLargeScreen
            ? IsLandscape
                ? LandscapeContentFlex
                : PortraitContentFlex
            : IsLandscape
                ? SmallLandscapeContentFlex
                : SmallPortraitContentFlex;

        /// <inheritdoc/>
        public FlexBoxTypes LandscapeContentFlex { get; protected set; } = FlexBoxTypes.Row;

        /// <inheritdoc/>
        public FlexBoxTypes PortraitContentFlex { get; protected set; } = FlexBoxTypes.ColumnReverse;

        /// <inheritdoc/>
        public FlexBoxTypes SmallLandscapeContentFlex { get; protected set; } = FlexBoxTypes.Row;

        /// <inheritdoc/>
        public FlexBoxTypes SmallPortraitContentFlex { get; protected set; } = FlexBoxTypes.ColumnReverse;

        /// <inheritdoc/>
        public virtual FlexBoxTypes BodyFlex => StretchContentSidebar ? FlexBoxTypes.Row : FlexBoxTypes.Column;

        /// <inheritdoc/>
        public virtual FlexBoxTypes ContentBodyFlex => IsLargeScreen
            ? IsLandscape
                ? LandscapeContentBodyFlex
                : PortraitContentBodyFlex
            : IsLandscape
                ? SmallLandscapeContentBodyFlex
                : SmallPortraitContentBodyFlex;

        /// <inheritdoc/>
        public FlexBoxTypes LandscapeContentBodyFlex { get; protected set; } = FlexBoxTypes.Column;

        /// <inheritdoc/>
        public FlexBoxTypes PortraitContentBodyFlex { get; protected set; } = FlexBoxTypes.Row;

        /// <inheritdoc/>
        public FlexBoxTypes SmallLandscapeContentBodyFlex { get; protected set; } = FlexBoxTypes.Column;

        /// <inheritdoc/>
        public FlexBoxTypes SmallPortraitContentBodyFlex { get; protected set; } = FlexBoxTypes.Row;
    }
}
