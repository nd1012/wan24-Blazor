namespace wan24.Blazor
{
    /// <summary>
    /// DOM element settings
    /// </summary>
    public sealed record class DomElementSettings : IDomElementSettings
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DomElementSettings() { }

        /// <inheritdoc/>
        public string? Class { get; set; }

        /// <inheritdoc/>
        public string? Style { get; set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? Attributes { get; set; }
    }
}
