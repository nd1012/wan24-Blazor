namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Hover link parameters
    /// </summary>
    public record class HoverLinkParameters : LinkParameters, IHoverLinkParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HoverLinkParameters() : base() => Hover = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public HoverLinkParameters(in IHoverLinkParameters original) : base(original) { }
    }
}
