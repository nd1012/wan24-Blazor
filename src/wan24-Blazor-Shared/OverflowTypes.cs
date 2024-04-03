using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Overflow types enumeration
    /// </summary>
    public enum OverflowTypes : byte
    {
        /// <summary>
        /// Auto
        /// </summary>
        [DisplayText("Automatic")]
        Auto = 0,
        /// <summary>
        /// Hidden
        /// </summary>
        [DisplayText("Hidden")]
        Hidden = 1,
        /// <summary>
        /// Visible
        /// </summary>
        [DisplayText("Visible")]
        Visible = 2,
        /// <summary>
        /// Scroll
        /// </summary>
        [DisplayText("Scroll")]
        Scroll = 3
    }
}
