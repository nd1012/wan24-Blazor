using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// <see cref="CssRgbA"/> tpes enumeration
    /// </summary>
    public enum CssRgbATypes : byte
    {
        /// <summary>
        /// RGBA value
        /// </summary>
        [DisplayText("RGBA value")]
        RGBA = 0,
        /// <summary>
        /// HTML color name
        /// </summary>
        [DisplayText("HTML color name")]
        ColorName = 1,
        /// <summary>
        /// CSS value
        /// </summary>
        [DisplayText("CSS value")]
        CssValue = 2,
        /// <summary>
        /// Inherited
        /// </summary>
        [DisplayText("Inherited")]
        Inherit = 3
    }
}
