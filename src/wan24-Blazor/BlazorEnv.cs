namespace wan24.Blazor
{
    /// <summary>
    /// Blazor environment
    /// </summary>
    public static class BlazorEnv
    {
        /// <summary>
        /// Max. small screen width in pixel
        /// </summary>
        public const int SMALL_SCREEN_WIDTH = 480;

        /// <summary>
        /// Screen orientation
        /// </summary>
        public static ScreenOrientations ScreenOrientation => WindowHeight > WindowWidth
            ? ScreenOrientations.Portrait
            : ScreenOrientations.Landscape;// for square also

        /// <summary>
        /// Is landscape screen orientation?
        /// </summary>
        public static bool IsLandscape => ScreenOrientation == ScreenOrientations.Landscape;

        /// <summary>
        /// Is portrait screen orientation?
        /// </summary>
        public static bool IsPortrait => ScreenOrientation == ScreenOrientations.Portrait;

        /// <summary>
        /// Window width in pixel
        /// </summary>
        public static int WindowWidth { get; set; } = int.MaxValue;

        /// <summary>
        /// Window height in pixel
        /// </summary>
        public static int WindowHeight { get; set; } = int.MaxValue;

        /// <summary>
        /// If there's a small screen
        /// </summary>
        public static bool IsSmallScreen => IsLandscape? WindowHeight <= SMALL_SCREEN_WIDTH : WindowWidth <= SMALL_SCREEN_WIDTH;

        /// <summary>
        /// If there's a large screen
        /// </summary>
        public static bool IsLargeScreen => !IsSmallScreen;

        /// <summary>
        /// <see langword="true"/> during display change (landscape &lt;-&gt; portrait / small &lt;-&gt; large screen) event handling
        /// </summary>
        public static bool DisplayChanged { get; internal set; }
    }
}
