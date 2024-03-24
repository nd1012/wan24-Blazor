using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Components
{
    // Parameters
    public abstract partial class BlazorComponentBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Parameter]
        public string? Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// CSS class
        /// </summary>
        [Parameter]
        public string? Class { get; set; }

        /// <summary>
        /// Flex box type
        /// </summary>
        [Parameter]
        public virtual FlexBoxTypes Flex { get; set; }

        /// <summary>
        /// Flex box switch (switches to flex row, if set to <see langword="true"/>; disables flex box otherwise)
        /// </summary>
        [Parameter]
#pragma warning disable BL0007 // Should be auto property
        public virtual bool FlexBox
        {
            get => Flex != FlexBoxTypes.None;
            set => Flex = value ? FlexBoxTypes.Column : FlexBoxTypes.None;
        }
#pragma warning restore BL0007 // Should be auto property

        /// <summary>
        /// If displaying as inline flex box, if flex box was enabled
        /// </summary>
        [Parameter]
        public virtual bool InlineFlex { get; set; }

        /// <summary>
        /// If this is a growing flex element
        /// </summary>
        [Parameter]
        public virtual bool Grow { get; set; }

        /// <summary>
        /// Rounded?
        /// </summary>
        [Parameter]
        public virtual bool Rounded { get; set; }

        /// <summary>
        /// Shadow type
        /// </summary>
        [Parameter]
        public virtual ShadowTypes Shadow { get; set; }

        /// <summary>
        /// Overflow type
        /// </summary>
        [Parameter]
        public virtual OverflowTypes Overflow { get; set; }

        /// <summary>
        /// X-overflow type
        /// </summary>
        [Parameter]
        public virtual OverflowTypes OverflowX { get; set; }

        /// <summary>
        /// Y-overflow type
        /// </summary>
        [Parameter]
        public virtual OverflowTypes OverflowY { get; set; }

        /// <summary>
        /// Floating (<see cref="HorizontalAligns.Center"/> is an invalid value and will be ignored)
        /// </summary>
        [Parameter]
        public virtual HorizontalAligns Float { get; set; } = HorizontalAligns.Center;

        /// <summary>
        /// Background color
        /// </summary>
        [Parameter]
        public virtual string? BackGroundColor { get; set; }

        /// <summary>
        /// Subtle backgrund color?
        /// </summary>
        [Parameter]
        public virtual bool BackGroundSubtle { get; set; }

        /// <summary>
        /// Background gradient
        /// </summary>
        [Parameter]
        public virtual bool BackGroundGradient { get; set; }

        /// <summary>
        /// Background opacity
        /// </summary>
        [Parameter]
        public virtual Opacities BackGroundOpacity { get; set; }

        /// <summary>
        /// Text color
        /// </summary>
        [Parameter]
        public virtual string? TextColor { get; set; }

        /// <summary>
        /// Text background color (with contract text color)
        /// </summary>
        [Parameter]
        public virtual string? TextBackGroundColor { get; set; }

        /// <summary>
        /// Emphasis text color?
        /// </summary>
        [Parameter]
        public virtual bool TextEmphasis { get; set; }

        /// <summary>
        /// Text size
        /// </summary>
        [Parameter]
        public virtual Sizes? TextSize { get; set; }

        /// <summary>
        /// Horizontal align
        /// </summary>
        [Parameter]
        public virtual HorizontalAligns? HAlign { get; set; }

        /// <summary>
        /// Vertical align
        /// </summary>
        [Parameter]
        public virtual VerticalAligns? VAlign { get; set; }

        /// <summary>
        /// Wrap content?
        /// </summary>
        [Parameter]
        public virtual bool Wrap { get; set; }

        /// <summary>
        /// Don't wrap content?
        /// </summary>
        [Parameter]
        public virtual bool NoWrap { get; set; }

        /// <summary>
        /// Truncate text (with ellipsis)?
        /// </summary>
        [Parameter]
        public virtual bool Truncate { get; set; }

        /// <summary>
        /// Muted text?
        /// </summary>
        [Parameter]
        public virtual bool Muted { get; set; }

        /// <summary>
        /// Selection behavior
        /// </summary>
        [Parameter]
        public virtual TextSelections? Selection { get; set; }

        /// <summary>
        /// Borders
        /// </summary>
        [Parameter]
        public virtual Borders Border { get; set; }

        /// <summary>
        /// Border color
        /// </summary>
        [Parameter]
        public virtual string? BorderColor { get; set; }

        /// <summary>
        /// Emphasis border
        /// </summary>
        [Parameter]
        public virtual bool BorderEmphasis { get; set; }

        /// <summary>
        /// Border opacity
        /// </summary>
        [Parameter]
        public virtual Opacities BorderOpacity { get; set; }

        /// <summary>
        /// CSS style
        /// </summary>
        [Parameter]
        public string? Style { get; set; }

        /// <summary>
        /// CSS color value (not the class name)
        /// </summary>
        [Parameter]
        public string? Color { get; set; }

        /// <summary>
        /// Text opacities
        /// </summary>
        [Parameter]
        public virtual Opacities TextOpacity { get; set; }

        /// <summary>
        /// Z-Index
        /// </summary>
        [Parameter]
        public virtual int? ZIndex { get; set; }

        /// <summary>
        /// Additional attributes
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? Attributes { get; set; }

        /// <summary>
        /// If the element is disabled
        /// </summary>
        [Parameter]
        public virtual bool Disabled { get; set; }
    }
}
