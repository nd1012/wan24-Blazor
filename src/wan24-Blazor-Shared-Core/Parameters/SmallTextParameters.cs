namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Small text parameters
    /// </summary>
    public record class SmallTextParameters : BodyTextParameters, ISmallTextParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SmallTextParameters() : base() => TagName = "small";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public SmallTextParameters(in ISmallTextParameters original) : base(original) { }
    }
}
