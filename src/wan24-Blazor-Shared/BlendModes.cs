using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Blend modes
    /// </summary>
    [Flags]
    public enum BlendModes : int
    {
        /// <summary>
        /// None
        /// </summary>
        [DisplayText("None")]
        None = 0,
        /// <summary>
        /// Normal
        /// </summary>
        [DisplayText("Normal")]
        Normal = 1 << 0,
        /// <summary>
        /// Multiply
        /// </summary>
        [DisplayText("Multiply")]
        Multiply = 1 << 1,
        /// <summary>
        /// Screen
        /// </summary>
        [DisplayText("Screen")]
        Screen = 1 << 2,
        /// <summary>
        /// Overlay
        /// </summary>
        [DisplayText("Overlay")]
        Overlay = 1 << 3,
        /// <summary>
        /// Darken
        /// </summary>
        [DisplayText("Darken")]
        Darken = 1 << 4,
        /// <summary>
        /// Lighten
        /// </summary>
        [DisplayText("Lighten")]
        Lighten = 1 << 5,
        /// <summary>
        /// Color dodge
        /// </summary>
        [DisplayText("Color dodge")]
        ColorDodge = 1 << 6,
        /// <summary>
        /// Color burn
        /// </summary>
        [DisplayText("Color burn")]
        ColorBurn = 1 << 7,
        /// <summary>
        /// Hard light
        /// </summary>
        [DisplayText("Hard light")]
        HardLight = 1 << 8,
        /// <summary>
        /// Soft light
        /// </summary>
        [DisplayText("Soft light")]
        SoftLight = 1 << 9,
        /// <summary>
        /// Difference
        /// </summary>
        [DisplayText("Difference")]
        Difference = 1 << 10,
        /// <summary>
        /// Exclusion
        /// </summary>
        [DisplayText("Exclusion")]
        Exclusion = 1 << 11,
        /// <summary>
        /// Hue
        /// </summary>
        [DisplayText("Hue")]
        Hue = 1 << 12,
        /// <summary>
        /// Saturation
        /// </summary>
        [DisplayText("Saturation")]
        Saturation = 1 << 13,
        /// <summary>
        /// Color
        /// </summary>
        [DisplayText("Color")]
        Color = 1 << 14,
        /// <summary>
        /// Luminosity
        /// </summary>
        [DisplayText("Luminosity")]
        Luminosity = 1 << 15,
        /// <summary>
        /// Revert
        /// </summary>
        [DisplayText("Revert")]
        Revert = 1 << 29,
        /// <summary>
        /// Revert layer
        /// </summary>
        [DisplayText("Revert layer")]
        RevertLayer = 1 << 30,
        /// <summary>
        /// Unset
        /// </summary>
        [DisplayText("Unset")]
        Unset = 1 << 31
    }
}
