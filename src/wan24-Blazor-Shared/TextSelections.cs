using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Text selections enumeration
    /// </summary>
    public enum TextSelections : byte
    {
        /// <summary>
        /// Default selection behavior
        /// </summary>
        [DisplayText("Default selection behavior")]
        Auto = 0,
        /// <summary>
        /// Select all on user click
        /// </summary>
        [DisplayText("Select all on user click")]
        All = 1,
        /// <summary>
        /// Selection disabled
        /// </summary>
        [DisplayText("Selection disabled")]
        None = 2
    }
}
