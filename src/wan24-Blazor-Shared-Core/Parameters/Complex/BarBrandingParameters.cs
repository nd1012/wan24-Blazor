namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Bar branding parameters
    /// </summary>
    public record class BarBrandingParameters : BarItemParameters, IBarBrandingParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarBrandingParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BarBrandingParameters(in IBarBrandingParameters original) : base(original) { }
    }
}
