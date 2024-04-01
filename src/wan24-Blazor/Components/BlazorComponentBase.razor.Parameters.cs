using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    // Parameters
    public abstract partial class BlazorComponentBase
    {
        /// <inheritdoc/>
        [Parameter]
        public virtual IParameters? ApplyParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Id { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Title { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Class { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual FlexBoxTypes Flex { get; set; }

        /// <inheritdoc/>
        [Parameter]
#pragma warning disable BL0007 // Should be auto property
        public virtual bool FlexBox
        {
            get => Flex != FlexBoxTypes.None;
            set => Flex = value ? FlexBoxTypes.Column : FlexBoxTypes.None;
        }
#pragma warning restore BL0007 // Should be auto property

        /// <inheritdoc/>
        [Parameter]
        public virtual bool InlineFlex { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Grow { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Rounded { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual ShadowTypes Shadow { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual OverflowTypes Overflow { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual OverflowTypes OverflowX { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual OverflowTypes OverflowY { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual HorizontalAligns Float { get; set; } = HorizontalAligns.Center;

        /// <inheritdoc/>
        [Parameter]
        public virtual string? BackGroundColor { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool BackGroundSubtle { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool BackGroundGradient { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual Opacities BackGroundOpacity { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? TextColor { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? TextBackGroundColor { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool TextEmphasis { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual Sizes? TextSize { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual FontStyles? FontStyle { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual HorizontalAligns? HAlign { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual VerticalAligns? VAlign { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Wrap { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool NoWrap { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Truncate { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Muted { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual TextSelections? Selection { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual Borders Border { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? BorderColor { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool BorderEmphasis { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual Opacities BorderOpacity { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool IsActive { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Style { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Color { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual Opacities TextOpacity { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual int? ZIndex { get; set; }

        /// <inheritdoc/>
        [Parameter(CaptureUnmatchedValues = true)]
        public virtual Dictionary<string, object>? Attributes { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Disabled { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Hidden { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual BsThemeMode? ForcedColorMode { get; set; }
    }
}
