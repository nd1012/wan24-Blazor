using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Horizontal aligns enumeration
    /// </summary>
    public enum HorizontalAligns : byte
    {
        /// <summary>
        /// Left
        /// </summary>
        [DisplayText("Left aligned")]
        Left = 0,
        /// <summary>
        /// Center
        /// </summary>
        [DisplayText("Centered")]
        Center = 1,
        /// <summary>
        /// Right
        /// </summary>
        [DisplayText("Right aligned")]
        Right = 2
    }
}
