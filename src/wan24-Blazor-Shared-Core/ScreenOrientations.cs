using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Screen orientations enumeration
    /// </summary>
    public enum ScreenOrientations
    {
        /// <summary>
        /// Landscape
        /// </summary>
        [DisplayText("Landscape (wide)")]
        Landscape = 0,
        /// <summary>
        /// Portrait
        /// </summary>
        [DisplayText("Portrait (high)")]
        Portrait = 1
    }
}
