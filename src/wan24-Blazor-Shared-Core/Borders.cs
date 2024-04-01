using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Border flags
    /// </summary>
    [Flags]
    public enum Borders
    {
        /// <summary>
        /// No border
        /// </summary>
        [DisplayText("No border")]
        None = 0,
        /// <summary>
        /// Top border
        /// </summary>
        [DisplayText("Top border")]
        Top = 1,
        /// <summary>
        /// Bottom border
        /// </summary>
        [DisplayText("Bottom border")]
        Bottom = 2,
        /// <summary>
        /// Left border
        /// </summary>
        [DisplayText("Left border")]
        Left = 4,
        /// <summary>
        /// Right border
        /// </summary>
        [DisplayText("Right border")]
        Right = 8,
        /// <summary>
        /// All borders
        /// </summary>
        [DisplayText("All borders")]
        All = Top | Bottom | Left | Right
    }
}
