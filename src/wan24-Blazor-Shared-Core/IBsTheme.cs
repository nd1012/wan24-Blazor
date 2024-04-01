using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a Bootstrap theme
    /// </summary>
    public interface IBsTheme
    {
        /// <summary>
        /// Theme name
        /// </summary>
        string? Name { get; }
        /// <summary>
        /// Mode
        /// </summary>
        BsThemeMode Mode { get; set; }
        /// <summary>
        /// Primary color
        /// </summary>
        Rgb? Primary { get; }
        /// <summary>
        /// Secondary color
        /// </summary>
        Rgb? Secondary { get; }
        /// <summary>
        /// Success color
        /// </summary>
        Rgb? Success { get; }
        /// <summary>
        /// Danger color
        /// </summary>
        Rgb? Danger { get; }
        /// <summary>
        /// Warning color
        /// </summary>
        Rgb? Warning { get; }
        /// <summary>
        /// Info color
        /// </summary>
        Rgb? Info { get; }
        /// <summary>
        /// Light color
        /// </summary>
        Rgb? Light { get; }
        /// <summary>
        /// Dark color
        /// </summary>
        Rgb? Dark { get; }
        /// <summary>
        /// Body color
        /// </summary>
        Rgb? Body { get; }
    }
}
