using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Build type
    /// </summary>
    [Flags]
    public enum BuildTypes : byte
    {
        /// <summary>
        /// Windows
        /// </summary>
        [DisplayText("Windows")]
        Windows = 0,
        /// <summary>
        /// MAC Catalyst
        /// </summary>
        [DisplayText("MAC Catalyst")]
        MacCatalyst = 1,
        /// <summary>
        /// iOS
        /// </summary>
        [DisplayText("iOS")]
        IOS = 2,
        /// <summary>
        /// Android
        /// </summary>
        [DisplayText("Android")]
        Android = 3,
        /// <summary>
        /// Browser (WASM)
        /// </summary>
        [DisplayText("WebAssembly")]
        Browser = 4,
        /// <summary>
        /// Debug flag
        /// </summary>
        [DisplayText("Debug build")]
        Debug = 64,
        /// <summary>
        /// Release flag
        /// </summary>
        [DisplayText("Release build")]
        Release = 128,
        /// <summary>
        /// All flags
        /// </summary>
        FLAGS = Debug | Release
    }
}
