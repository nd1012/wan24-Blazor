namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for divider parameters
    /// </summary>
    public interface IDividerParameters : IBoxParameters
    {
        /// <summary>
        /// Divider orientation
        /// </summary>
        Orientations Orientation { get; set; }
    }
}
