using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Background attachment types enumeration
    /// </summary>
    public enum BackGroundAttachmentTypes : byte
    {
        /// <summary>
        /// None
        /// </summary>
        [DisplayText("None")]
        None = 0,
        /// <summary>
        /// Scroll
        /// </summary>
        [DisplayText("Scroll")]
        Scroll = 1,
        /// <summary>
        /// Fixed
        /// </summary>
        [DisplayText("Fixed")]
        Fixed = 2,
        /// <summary>
        /// Local
        /// </summary>
        [DisplayText("Local")]
        Local = 3,
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
