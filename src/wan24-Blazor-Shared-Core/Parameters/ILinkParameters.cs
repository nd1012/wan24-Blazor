namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for link parameters
    /// </summary>
    public interface ILinkParameters : IClickableParameters
    {
        /// <summary>
        /// No underline?
        /// </summary>
        bool NoUnderline { get; set; }
        /// <summary>
        /// Link underline color (<see cref="Colors" />)
        /// </summary>
        string? UnderlineColor { get; set; }
        /// <summary>
        /// Show link underline on hover only?
        /// </summary>
        bool Hover { get; set; }
    }
}
