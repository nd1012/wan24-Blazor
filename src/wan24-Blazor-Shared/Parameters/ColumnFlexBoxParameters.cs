namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Column flex box parameters
    /// </summary>
    public record class ColumnFlexBoxParameters : BoxParameters, IColumnFlexBoxParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColumnFlexBoxParameters() : base() => Flex = FlexBoxTypes.Column;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public ColumnFlexBoxParameters(in IColumnFlexBoxParameters original) : base(original) { }
    }
}
