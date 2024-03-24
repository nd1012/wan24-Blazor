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
        None,
        /// <summary>
        /// Top border
        /// </summary>
        [DisplayText("Top border")]
        Top,
        /// <summary>
        /// Bottom border
        /// </summary>
        [DisplayText("Bottom border")]
        Bottom,
        /// <summary>
        /// Left border
        /// </summary>
        [DisplayText("Left border")]
        Left,
        /// <summary>
        /// Right border
        /// </summary>
        [DisplayText("Right border")]
        Right,
        /// <summary>
        /// All borders
        /// </summary>
        [DisplayText("All borders")]
        All = Top | Bottom | Left | Right
    }
}
