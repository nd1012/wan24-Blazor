using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Background origin types enumeration
    /// </summary>
    public enum BackGroundOriginTypes : byte
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
        /// Revert
        /// </summary>
        [DisplayText("Revert")]
        Revert = 4,
        /// <summary>
        /// Revert layer
        /// </summary>
        [DisplayText("Revert layer")]
        RevertLayer = 5,
        /// <summary>
        /// Unset
        /// </summary>
        [DisplayText("Unset")]
        Unset = 6
    }
}
