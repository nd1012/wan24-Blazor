namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for chapter parameters
    /// </summary>
    public interface IChapterParameters : IBoxParameters
    {
        /// <summary>
        /// Header text
        /// </summary>
        string? HeaderText { get; set; }
        /// <summary>
        /// Chapter level (will be managed automatic, if not defined)
        /// </summary>
        int Level { get; set; }
    }
}
