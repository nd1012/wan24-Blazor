﻿using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Text selections enumeration
    /// </summary>
    public enum TextSelections
    {
        /// <summary>
        /// Default selection behavior
        /// </summary>
        [DisplayText("Default selection behavior")]
        Auto,
        /// <summary>
        /// Select all on user click
        /// </summary>
        [DisplayText("Select all on user click")]
        All,
        /// <summary>
        /// Selection disabled
        /// </summary>
        [DisplayText("Selection disabled")]
        None
    }
}
