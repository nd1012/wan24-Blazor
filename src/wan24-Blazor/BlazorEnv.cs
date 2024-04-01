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
        /// Light color mode?
        /// </summary>
        private static bool _LightMode = true;

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
        /// Light color mode
        /// </summary>
        public static bool LightMode
        {
            get => _LightMode;
            set
            {
                bool oldValue = _LightMode;
                _LightMode = value;
                if (value != oldValue) RaiseOnColorModeChanged();
            }
        }

        /// <summary>
        /// Dark color mode
        /// </summary>
        public static bool DarkMode => !LightMode;

        /// <summary>
        /// <see langword="true"/> during display change (landscape &lt;-&gt; portrait / small &lt;-&gt; large screen) event handling
        /// </summary>
        public static bool DisplayChanged { get; internal set; }

        /// <summary>
        /// <see langword="true"/> during color mode change (light &lt;-&gt; dark color mode) event handling
        /// </summary>
        public static bool ColorModeChanged { get; internal set; }

        /// <summary>
        /// Delegate for an <see cref="OnScreenOrientationChanged"/> event handler
        /// </summary>
        public delegate void ScreenOrientation_Handler();
        /// <summary>
        /// Raised when the screen orientation changed
        /// </summary>
        public static event ScreenOrientation_Handler? OnScreenOrientationChanged;
        /// <summary>
        /// Raise the <see cref="OnScreenOrientationChanged"/> event
        /// </summary>
        public static void RaiseOnScreenOrientationChanged() => OnScreenOrientationChanged?.Invoke();

        /// <summary>
        /// Delegate for an <see cref="OnColorModeChanged"/> event handler
        /// </summary>
        public delegate void ColorMode_Handler();
        /// <summary>
        /// Raised when the color mode changed
        /// </summary>
        public static event ColorMode_Handler? OnColorModeChanged;
        /// <summary>
        /// Raise the <see cref="OnColorModeChanged"/> event
        /// </summary>
        private static void RaiseOnColorModeChanged() => OnColorModeChanged?.Invoke();
    }
}
