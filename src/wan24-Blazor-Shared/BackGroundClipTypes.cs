using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Background clip types
    /// </summary>
    public enum BackGroundClipTypes : int
    {
        /// <summary>
        /// None
        /// </summary>
        [DisplayText("None")]
        None = 0,
        /// <summary>
        /// Border box
        /// </summary>
        [DisplayText("Border box")]
        BorderBox = 1,
        /// <summary>
        /// Padding box
        /// </summary>
        [DisplayText("Padding box")]
        PaddingBox = 2,
        /// <summary>
        /// Content box
        /// </summary>
        [DisplayText("Content box")]
        ContentBox = 3,
        /// <summary>
        /// Text
        /// </summary>
        [DisplayText("Text")]
        Text = 4,
        /// <summary>
        /// Revert
        /// </summary>
        [DisplayText("Revert")]
        Revert = 5,
        /// <summary>
        /// Revert layer
        /// </summary>
        [DisplayText("Revert layer")]
        RevertLayer = 6,
        /// <summary>
        /// Unset
        /// </summary>
        [DisplayText("Unset")]
        Unset = 7
    }
}
