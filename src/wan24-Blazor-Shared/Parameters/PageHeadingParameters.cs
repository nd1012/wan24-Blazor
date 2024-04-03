namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Page heading parameters
    /// </summary>
    public record class PageHeadingParameters : BlazorComponentParameters, IPageHeadingParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PageHeadingParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original"></param>
        public PageHeadingParameters(in IPageHeadingParameters original) : base(original) { }
    }
}
