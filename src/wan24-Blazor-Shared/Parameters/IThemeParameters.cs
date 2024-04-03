namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for theme parameters
    /// </summary>
    public interface IThemeParameters : IParameters
    {
        /// <summary>
        /// DOM element ID
        /// </summary>
        string? Id { get; set; }
        /// <summary>
        /// Bootstrap theme to apply
        /// </summary>
        IBsTheme Apply { get; set; }
        /// <summary>
        /// If this is not the current theme (<see cref="BsTheme.Current"/>)
        /// </summary>
        bool NotCurrent { get; set; }
    }
}
