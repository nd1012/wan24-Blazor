namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Lead text parameters
    /// </summary>
    public record class LeadTextParameters : BodyTextParameters, ILeadTextParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LeadTextParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public LeadTextParameters(in ILeadTextParameters original) : base(original) { }
    }
}
