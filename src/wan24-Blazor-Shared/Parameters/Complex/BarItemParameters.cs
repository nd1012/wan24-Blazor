namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Bar item parameters
    /// </summary>
    public record class BarItemParameters : BarItemParametersBase, IBarItemParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarItemParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BarItemParameters(in IBarItemParameters original) : base(original) { }
    }
}
