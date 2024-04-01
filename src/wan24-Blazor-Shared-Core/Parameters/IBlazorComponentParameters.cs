namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for a type which exports Blazor parameters
    /// </summary>
    public interface IBlazorComponentParameters : IParameters
    {
        /// <summary>
        /// Object properties (names of properties which serve object/component configuration)
        /// </summary>
        IEnumerable<string> ObjectProperties { get; }
        /// <summary>
        /// Design properties (names of properties which serve design related configuration)
        /// </summary>
        IEnumerable<string> DesignProperties { get; }
        /// <summary>
        /// Accessability properties (names of properties which serve component accessability configuration)
        /// </summary>
        IEnumerable<string> AccessabilityProperties { get; }
        /// <summary>
        /// DOM element ID
        /// </summary>
        string? Id { get; set; }
        /// <summary>
        /// DOM element title
        /// </summary>
        string? Title { get; set; }
        /// <summary>
        /// CSS classes
        /// </summary>
        string? Class { get; set; }
        /// <summary>
        /// Flex box type
        /// </summary>
        FlexBoxTypes Flex { get; set; }
        /// <summary>
        /// If displaying as inline flex box when flex box was enabled (<see cref="Flex"/>)
        /// </summary>
        bool InlineFlex { get; set; }
        /// <summary>
        /// If this is a growing flex element (uses Bootstraps <c>flex-grow-1</c> class)
        /// </summary>
        bool Grow { get; set; }
        /// <summary>
        /// Rounded?
        /// </summary>
        bool Rounded { get; set; }
        /// <summary>
        /// Shadow type
        /// </summary>
        ShadowTypes Shadow { get; set; }
        /// <summary>
        /// Overflow type
        /// </summary>
        OverflowTypes Overflow { get; set; }
        /// <summary>
        /// X-overflow type
        /// </summary>
        OverflowTypes OverflowX { get; set; }
        /// <summary>
        /// Y-overflow type
        /// </summary>
        OverflowTypes OverflowY { get; set; }
        /// <summary>
        /// Floating (<see cref="HorizontalAligns.Center"/> is an invalid value and will be ignored)
        /// </summary>
        HorizontalAligns Float { get; set; }
        /// <summary>
        /// Background color (<see cref="Colors"/>)
        /// </summary>
        string? BackGroundColor { get; set; }
        /// <summary>
        /// Subtle backgrund color?
        /// </summary>
        bool BackGroundSubtle { get; set; }
        /// <summary>
        /// Background gradient
        /// </summary>
        bool BackGroundGradient { get; set; }
        /// <summary>
        /// Background opacity
        /// </summary>
        Opacities BackGroundOpacity { get; set; }
        /// <summary>
        /// Text color (<see cref="Colors"/>)
        /// </summary>
        string? TextColor { get; set; }
        /// <summary>
        /// Text background color (with contract text color, <see cref="Colors"/>)
        /// </summary>
        string? TextBackGroundColor { get; set; }
        /// <summary>
        /// Emphasis text color?
        /// </summary>
        bool TextEmphasis { get; set; }
        /// <summary>
        /// Text size
        /// </summary>
        Sizes? TextSize { get; set; }
        /// <summary>
        /// Text styles
        /// </summary>
        FontStyles? FontStyle { get; set; }
        /// <summary>
        /// Horizontal align
        /// </summary>
        HorizontalAligns? HAlign { get; set; }
        /// <summary>
        /// Vertical align
        /// </summary>
        VerticalAligns? VAlign { get; set; }
        /// <summary>
        /// Wrap content?
        /// </summary>
        bool Wrap { get; set; }
        /// <summary>
        /// Don't wrap content?
        /// </summary>
        bool NoWrap { get; set; }
        /// <summary>
        /// Truncate text (with ellipsis)?
        /// </summary>
        bool Truncate { get; set; }
        /// <summary>
        /// Muted text?
        /// </summary>
        bool Muted { get; set; }
        /// <summary>
        /// Selection behavior
        /// </summary>
        TextSelections? Selection { get; set; }
        /// <summary>
        /// Borders
        /// </summary>
        Borders Border { get; set; }
        /// <summary>
        /// Border color (<see cref="Colors"/>)
        /// </summary>
        string? BorderColor { get; set; }
        /// <summary>
        /// Emphasis border
        /// </summary>
        bool BorderEmphasis { get; set; }
        /// <summary>
        /// Border opacity
        /// </summary>
        Opacities BorderOpacity { get; set; }
        /// <summary>
        /// If active
        /// </summary>
        bool IsActive { get; set; }
        /// <summary>
        /// CSS style
        /// </summary>
        string? Style { get; set; }
        /// <summary>
        /// CSS color value (not the class name)
        /// </summary>
        string? Color { get; set; }
        /// <summary>
        /// Text opacities
        /// </summary>
        Opacities TextOpacity { get; set; }
        /// <summary>
        /// Z-Index
        /// </summary>
        int? ZIndex { get; set; }
        /// <summary>
        /// Additional attributes of the DOM element
        /// </summary>
        Dictionary<string, object>? Attributes { get; set; }
        /// <summary>
        /// If the DOM element is disabled
        /// </summary>
        bool Disabled { get; set; }
        /// <summary>
        /// If the DOM element is hidden
        /// </summary>
        bool Hidden { get; set; }
        /// <summary>
        /// Show the element on a landscape screen?
        /// </summary>
        bool ShowOnLandscape { get; set; }
        /// <summary>
        /// Show the element on a small landscape screen?
        /// </summary>
        bool ShowOnSmallLandscape { get; set; }
        /// <summary>
        /// Show the element on a portrait screen?
        /// </summary>
        bool ShowOnPortrait { get; set; }
        /// <summary>
        /// Show the element on a small portrait screen?
        /// </summary>
        bool ShowOnSmallPortrait { get; set; }
        /// <summary>
        /// Enable the element on a landscape screen?
        /// </summary>
        bool EnableOnLandscape { get; set; }
        /// <summary>
        /// Enable the element on a small landscape screen?
        /// </summary>
        bool EnableOnSmallLandscape { get; set; }
        /// <summary>
        /// Enable the element on a portrait screen?
        /// </summary>
        bool EnableOnPortrait { get; set; }
        /// <summary>
        /// Enable the element on a small portrait screen?
        /// </summary>
        bool EnableOnSmallPortrait { get; set; }
        /// <summary>
        /// The forced color mode of this single DOM element
        /// </summary>
        BsThemeMode? ForcedColorMode { get; set; }
    }
}
