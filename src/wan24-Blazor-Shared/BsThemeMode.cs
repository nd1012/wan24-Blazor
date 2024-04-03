using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Bootstrap theme modes enumeration/flags
    /// </summary>
    [Flags]
    public enum BsThemeMode : byte
    {
        /// <summary>
        /// Light
        /// </summary>
        [DisplayText("Light mode")]
        Light = 0,
        /// <summary>
        /// Dark
        /// </summary>
        [DisplayText("Dark mode")]
        Dark = 1,
        /// <summary>
        /// User defined flag
        /// </summary>
        UserDefined = 128,
        /// <summary>
        /// Flags
        /// </summary>
        FLAGS = UserDefined
    }
}
