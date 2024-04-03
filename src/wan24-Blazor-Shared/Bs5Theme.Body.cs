using wan24.Core;

namespace wan24.Blazor
{
    // Body
    public partial record class Bs5Theme
    {
        /// <summary>
        /// Body font family
        /// </summary>
        public virtual string? BodyFontFamily { get; set; }

        /// <summary>
        /// Body font size
        /// </summary>
        public virtual string? BodyFontSize { get; set; }

        /// <summary>
        /// Body font weight
        /// </summary>
        public virtual string? BodyFontWeight { get; set; }

        /// <summary>
        /// Body line height
        /// </summary>
        public virtual string? BodyLineHeight { get; set; }

        /// <summary>
        /// Body color
        /// </summary>
        public virtual Rgb? BodyColor { get; set; }

        /// <summary>
        /// Body background
        /// </summary>
        public virtual Rgb? BodyBg { get; set; }
    }
}
