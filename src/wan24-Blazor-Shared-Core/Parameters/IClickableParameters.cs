namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for clickable parameters
    /// </summary>
    public interface IClickableParameters : IBoxParameters
    {
        /// <summary>
        /// Clickable property names (names of properties which serve click handling configuration)
        /// </summary>
        IEnumerable<string> ClickablePropertyNames { get; }
        /// <summary>
        /// Target URI
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// Target (window) name
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// If a load is forced
        /// </summary>
        public bool ForceLoad { get; set; }
    }
}
