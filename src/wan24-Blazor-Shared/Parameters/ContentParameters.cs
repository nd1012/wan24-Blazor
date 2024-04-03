namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Content parameters
    /// </summary>
    public record class ContentParameters : ColumnFlexBoxParameters, IContentParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ContentParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public ContentParameters(in IContentParameters original) : base(original) { }
    }
}
