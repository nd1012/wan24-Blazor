using wan24.Core;

namespace wan24.Blazor
{
    // Border
    public partial record class Bs5Theme
    {
        /// <summary>
        /// Border width
        /// </summary>
        public virtual string? BorderWidth { get; set; }

        /// <summary>
        /// Border style
        /// </summary>
        public virtual string? BorderStyle { get; set; }

        /// <summary>
        /// Border color
        /// </summary>
        public virtual CssRgbA? BorderColor { get; set; }

        /// <summary>
        /// Border translucent color
        /// </summary>
        public virtual CssRgbA? BorderTranslucent { get; set; }

        /// <summary>
        /// Border radius
        /// </summary>
        public virtual string? BorderRadius { get; set; }

        /// <summary>
        /// Border radius SM
        /// </summary>
        public virtual string? BorderRadiusSm { get; set; }

        /// <summary>
        /// Border radius LG
        /// </summary>
        public virtual string? BorderRadiusLg { get; set; }

        /// <summary>
        /// Border radius XL
        /// </summary>
        public virtual string? BorderRadiusXl { get; set; }

        /// <summary>
        /// Border radius XXL
        /// </summary>
        public virtual string? BorderRadiusXxl { get; set; }

        /// <summary>
        /// Border radius 2XL
        /// </summary>
        public virtual string? BorderRadius2Xl { get; set; }

        /// <summary>
        /// Border radius pill
        /// </summary>
        public virtual string? BorderRadiusPill { get; set; }
    }
}
