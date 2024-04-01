using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Text style flags
    /// </summary>
    [Flags]
    public enum FontStyles
    {
        /// <summary>
        /// Regular text style
        /// </summary>
        [DisplayText("Regular text style")]
        None = 0,
        /// <summary>
        /// Bold text
        /// </summary>
        [DisplayText("Bold text")]
        Bold = 1 << 0,
        /// <summary>
        /// Italic text
        /// </summary>
        [DisplayText("Italic text")]
        Italic = 1 << 1,
        /// <summary>
        /// Underlined text
        /// </summary>
        [DisplayText("Underlined text")]
        Underline = 1 << 2,
        /// <summary>
        /// Stroken text
        /// </summary>
        [DisplayText("Stroken text")]
        Stroke = 1 << 3,
        /// <summary>
        /// Lower case text
        /// </summary>
        [DisplayText("Lower case text")]
        LowerCase = 1 << 4,
        /// <summary>
        /// Upper case text
        /// </summary>
        [DisplayText("Upper case text")]
        UpperCase = 1 << 5,
        /// <summary>
        /// Capitalized text
        /// </summary>
        [DisplayText("Capitalized text")]
        Capitalize = 1 << 6,
        /// <summary>
        /// Bolder text
        /// </summary>
        [DisplayText("Bolder text")]
        Bolder = 1 << 7,
        /// <summary>
        /// Semi bold text
        /// </summary>
        [DisplayText("Semi bold text")]
        SemiBold = 1 << 8,
        /// <summary>
        /// Medium bold text
        /// </summary>
        [DisplayText("Medium bold text")]
        MediumBold = 1 << 9,
        /// <summary>
        /// Normal weight text (regular, resets font weight flags)
        /// </summary>
        [DisplayText("Normal weight text")]
        NormalWeight = 1 << 10,
        /// <summary>
        /// Light text
        /// </summary>
        [DisplayText("Light text")]
        Light = 1 << 11,
        /// <summary>
        /// Lighter text
        /// </summary>
        [DisplayText("Lighter text")]
        Lighter = 1 << 12,
        /// <summary>
        /// Normal text (regular, resets all styles)
        /// </summary>
        [DisplayText("Normal text")]
        Normal = 1 << 13,
        /// <summary>
        /// Monospace text
        /// </summary>
        [DisplayText("Monospace text")]
        Monospace = 1 << 14,
        /// <summary>
        /// Color reset
        /// </summary>
        [DisplayText("Color reset")]
        ResetColor = 1 << 15,
        /// <summary>
        /// Reset text decoration (underline/stroke)
        /// </summary>
        [DisplayText("Reset text decoration")]
        NoDecoration = 1 << 16
    }
}
