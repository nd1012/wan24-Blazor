using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Orientations enumeration
    /// </summary>
    public enum Orientations : byte
    {
        /// <summary>
        /// Horizontal
        /// </summary>
        [DisplayText("Horizontal")]
        Horizontal = 0,
        /// <summary>
        /// Vertical
        /// </summary>
        [DisplayText("Vertical")]
        Vertical = 1
    }
}
