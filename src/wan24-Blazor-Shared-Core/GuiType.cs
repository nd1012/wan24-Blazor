using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// GUI type
    /// </summary>
    public enum GuiType
    {
        /// <summary>
        /// MAUI
        /// </summary>
        [DisplayText(".NET MAUI")]
        MAUI,
        /// <summary>
        /// WASM
        /// </summary>
        [DisplayText("WebAssembly")]
        WASM
    }
}
