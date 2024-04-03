namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Grow box parameters
    /// </summary>
    public record class GrowBoxParameters : BoxParameters, IGrowBoxParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GrowBoxParameters() : base() => Grow = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public GrowBoxParameters(in IGrowBoxParameters original) : base(original) { }
    }
}
