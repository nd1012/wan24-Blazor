namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for box parameters
    /// </summary>
    public interface IBoxParameters : IBlazorComponentParameters
    {
        /// <summary>
        /// DOM element HTML tag name
        /// </summary>
        string TagName { get; set; }
    }
}
