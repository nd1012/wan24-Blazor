using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Background image repeat types enumeration
    /// </summary>
    public enum BackGroundRepeatTypes : byte
    {
        /// <summary>
        /// None
        /// </summary>
        [DisplayText("None")]
        None = 0,
        /// <summary>
        /// No repeat
        /// </summary>
        [DisplayText("No repeat")]
        NoRepeat = 1,
        /// <summary>
        /// Repeat
        /// </summary>
        [DisplayText("Repeat")]
        Repeat = 2,
        /// <summary>
        /// Repeat horizontal
        /// </summary>
        [DisplayText(" Repeat horizontal")]
        RepeatX = 3,
        /// <summary>
        /// Repeat vertical
        /// </summary>
        [DisplayText("Repeat vertical")]
        RepeatY = 4,
        /// <summary>
        /// Space (no clipping)
        /// </summary>
        [DisplayText("Space (no clipping)")]
        Space = 5,
        /// <summary>
        /// Round (stretch)
        /// </summary>
        [DisplayText("Round (stretch)")]
        Round = 6,
        /// <summary>
        /// Revert
        /// </summary>
        [DisplayText("Revert")]
        Revert = 7,
        /// <summary>
        /// Unset
        /// </summary>
        [DisplayText("Unset")]
        Unset = 8
    }
}
