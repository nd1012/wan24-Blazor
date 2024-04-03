using wan24.Core;

namespace wan24.Blazor
{
    // Others
    public partial record class Bs5Theme
    {
        /// <summary>
        /// Gradient
        /// </summary>
        public virtual string? Gradient { get; set; }

        /// <summary>
        /// Emphasis color
        /// </summary>
        public virtual Rgb? Emphasis { get; set; }

        /// <summary>
        /// Secondary color
        /// </summary>
        public virtual RgbA? SecondaryColor { get; set; }

        /// <summary>
        /// Secondary background color
        /// </summary>
        public virtual Rgb? SecondaryBg { get; set; }

        /// <summary>
        /// Teritary color
        /// </summary>
        public virtual RgbA? TeritaryColor { get; set; }

        /// <summary>
        /// Teritary background color
        /// </summary>
        public virtual Rgb? TeritaryBg { get; set; }

        /// <summary>
        /// Heading color
        /// </summary>
        public virtual CssRgbA? HeadingColor { get; set; }

        /// <summary>
        /// Link color
        /// </summary>
        public virtual Rgb? LinkColor { get; set; }

        /// <summary>
        /// Link decoration
        /// </summary>
        public virtual string? LinkDecoration { get; set; }

        /// <summary>
        /// Link hover color
        /// </summary>
        public virtual Rgb? LinkHoverColor { get; set; }

        /// <summary>
        /// Code color
        /// </summary>
        public virtual CssRgbA? CodeColor { get; set; }

        /// <summary>
        /// Highlight color
        /// </summary>
        public virtual CssRgbA? HighlightColor { get; set; }

        /// <summary>
        /// Highlight background color
        /// </summary>
        public virtual CssRgbA? HighlightBg { get; set; }

        /// <summary>
        /// Box shadow
        /// </summary>
        public virtual string? BoxShadow { get; set; }

        /// <summary>
        /// Box shadow SM
        /// </summary>
        public virtual string? BoxShadowSm { get; set; }

        /// <summary>
        /// Box shadow LG
        /// </summary>
        public virtual string? BoxShadowLg { get; set; }

        /// <summary>
        /// Box shadow inset
        /// </summary>
        public virtual string? BoxShadowInset { get; set; }

        /// <summary>
        /// Focus ring width
        /// </summary>
        public virtual string? FocusRingWidth { get; set; }

        /// <summary>
        /// Focus ring opacity
        /// </summary>
        public virtual string? FocusRingOpacity { get; set; }

        /// <summary>
        /// Focus ring color
        /// </summary>
        public virtual CssRgbA? FocusRingColor { get; set; }

        /// <summary>
        /// Form valid color
        /// </summary>
        public virtual CssRgbA? FormValidColor { get; set; }

        /// <summary>
        /// Form valid border color
        /// </summary>
        public virtual CssRgbA? FormValidBorderColor { get; set; }

        /// <summary>
        /// Form invalid color
        /// </summary>
        public virtual CssRgbA? FormInvalidColor { get; set; }

        /// <summary>
        /// Form invalid border color
        /// </summary>
        public virtual CssRgbA? FormInvalidBorderColor { get; set; }

        /// <summary>
        /// Additional CSS
        /// </summary>
        public virtual string? AdditionalCss { get; set; }

        /// <summary>
        /// Additional CSS (dark mode)
        /// </summary>
        public virtual string? AdditionalDarkCss { get; set; }
    }
}
