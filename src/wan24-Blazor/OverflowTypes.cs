using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Overflow types enumeration
    /// </summary>
    public enum OverflowTypes
    {
        /// <summary>
        /// Auto
        /// </summary>
        [DisplayText("Automatic")]
        Auto,
        /// <summary>
        /// Hidden
        /// </summary>
        [DisplayText("Hidden")]
        Hidden,
        /// <summary>
        /// Visible
        /// </summary>
        [DisplayText("Visible")]
        Visible,
        /// <summary>
        /// Scroll
        /// </summary>
        [DisplayText("Scroll")]
        Scroll
    }
}
