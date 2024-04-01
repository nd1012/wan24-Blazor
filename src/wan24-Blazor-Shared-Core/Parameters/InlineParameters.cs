namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Inline parameters
    /// </summary>
    public record class InlineParameters : BoxParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InlineParameters() : base() => TagName = "span";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original"></param>
        public InlineParameters(in IInlineParameters original) : base(original) { }
    }
}
