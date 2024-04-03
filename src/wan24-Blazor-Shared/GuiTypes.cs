using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// GUI type
    /// </summary>
    public enum GuiTypes : byte
    {
        /// <summary>
        /// MAUI
        /// </summary>
        [DisplayText(".NET MAUI")]
        MAUI = 0,
        /// <summary>
        /// WASM
        /// </summary>
        [DisplayText("Blazor WebAssembly")]
        WASM = 1
    }
}
