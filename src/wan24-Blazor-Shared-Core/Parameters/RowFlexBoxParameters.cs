namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Row flexbox parameters
    /// </summary>
    public record class RowFlexBoxParameters : BoxParameters, IRowFlexBoxParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RowFlexBoxParameters() : base() => Flex = FlexBoxTypes.Row;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public RowFlexBoxParameters(in IRowFlexBoxParameters original) : base(original) { }
    }
}
