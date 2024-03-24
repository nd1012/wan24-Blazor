using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tagName">HTML tag name</param>
    public abstract partial class FlexLayoutBase(in string? tagName = null) : LayoutBase(tagName)
    {
        /// <summary>
        /// Stretch the content sidebar over header and footer?
        /// </summary>
        public bool StretchContentSidebar { get; protected set; }//TODO Stretch content sidebar

        /// <summary>
        /// Body HTML tag name
        /// </summary>
        public string BodyTag { get; protected set; } = "main";

        /// <summary>
        /// Content flex box type (defines the sidebar and body apperance in landscape/portrait view on a small/large screen)
        /// </summary>
        public virtual FlexBoxTypes ContentFlex => IsLargeScreen
            ? IsLandscape
                ? LandscapeContentFlex
                : PortraitContentFlex
            : IsLandscape
                ? SmallLandscapeContentFlex
                : SmallPortraitContentFlex;

        /// <summary>
        /// Content flex box type in landscape view
        /// </summary>
        public FlexBoxTypes LandscapeContentFlex { get; protected set; } = FlexBoxTypes.Row;

        /// <summary>
        /// Content flex box type in portrait view
        /// </summary>
        public FlexBoxTypes PortraitContentFlex { get; protected set; } = FlexBoxTypes.ColumnReverse;

        /// <summary>
        /// Content flex box type in landscape view on a small screen
        /// </summary>
        public FlexBoxTypes SmallLandscapeContentFlex { get; protected set; } = FlexBoxTypes.Row;

        /// <summary>
        /// Content flex box type in portrait view on a small screen
        /// </summary>
        public FlexBoxTypes SmallPortraitContentFlex { get; protected set; } = FlexBoxTypes.ColumnReverse;

        /// <summary>
        /// Content body flex box type (defines the body and content sidebar apperance in landscape/portrait view on a small/large screen)
        /// </summary>
        public virtual FlexBoxTypes ContentBodyFlex => IsLargeScreen
            ? IsLandscape
                ? LandscapeContentBodyFlex
                : PortraitContentBodyFlex
            : IsLandscape
                ? SmallLandscapeContentBodyFlex
                : SmallPortraitContentBodyFlex;

        /// <summary>
        /// Content body flex box type in landscape view
        /// </summary>
        public FlexBoxTypes LandscapeContentBodyFlex { get; protected set; } = FlexBoxTypes.Column;

        /// <summary>
        /// Content body flex box type in portrait view
        /// </summary>
        public FlexBoxTypes PortraitContentBodyFlex { get; protected set; } = FlexBoxTypes.Row;

        /// <summary>
        /// Content body flex box type in landscape view on a small screen
        /// </summary>
        public FlexBoxTypes SmallLandscapeContentBodyFlex { get; protected set; } = FlexBoxTypes.Column;

        /// <summary>
        /// Content body flex box type in portrait view on a small screen
        /// </summary>
        public FlexBoxTypes SmallPortraitContentBodyFlex { get; protected set; } = FlexBoxTypes.Row;
    }
}
