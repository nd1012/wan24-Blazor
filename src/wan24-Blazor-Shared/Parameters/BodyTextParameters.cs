namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Body text parameters
    /// </summary>
    public record class BodyTextParameters : BoxParameters, IBodyTextParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BodyTextParameters() : base()
        {
            TagName = "p";
            InlineFlex = true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BodyTextParameters(in IBodyTextParameters original) : base(original) { }
    }
}
