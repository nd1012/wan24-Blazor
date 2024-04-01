using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// <see cref="CssRgbA"/> tpes enumeration
    /// </summary>
    public enum CssRgbATypes
    {
        /// <summary>
        /// RGBA value
        /// </summary>
        [DisplayText("RGBA value")]
        RGBA = 0,
        /// <summary>
        /// Color name
        /// </summary>
        [DisplayText("Color name")]
        ColorName = 1,
        /// <summary>
        /// Inherited
        /// </summary>
        [DisplayText("Inherited")]
        Inherit = 2
    }
}
