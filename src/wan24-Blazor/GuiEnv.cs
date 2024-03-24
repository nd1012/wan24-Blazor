namespace wan24.Blazor
{
    /// <summary>
    /// wan24-I8NGUI environment
    /// </summary>
    public static class GuiEnv
    {
        /// <summary>
        /// Type
        /// </summary>
        public static GuiType AppType { get; internal set; }

        /// <summary>
        /// Is a .NET MAUI app?
        /// </summary>
        public static bool IsMAUI => AppType == GuiType.MAUI;

        /// <summary>
        /// Is a Blazor WebAssembly app?
        /// </summary>
        public static bool IsWASM => AppType == GuiType.WASM;

        /// <summary>
        /// Build
        /// </summary>
        public static BuildTypes AppBuild { get; internal set; }

        /// <summary>
        /// If this is a debug build
        /// </summary>
        public static bool IsDebug => (AppBuild & BuildTypes.Debug) == BuildTypes.Debug;

        /// <summary>
        /// If this is a release build
        /// </summary>
        public static bool IsRelease => !IsDebug;

        /// <summary>
        /// If this is a local app
        /// </summary>
        public static bool IsLocalApp => AppType == GuiType.MAUI;

        /// <summary>
        /// If this is a browser app (WebAssembly)
        /// </summary>
        public static bool IsBrowserApp => !IsLocalApp;
    }
}
