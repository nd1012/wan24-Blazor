using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Flex box types enumeration
    /// </summary>
    public enum FlexBoxTypes
    {
        /// <summary>
        /// None
        /// </summary>
        [DisplayText("No flex box")]
        None,
        /// <summary>
        /// Row
        /// </summary>
        [DisplayText("Row (left to right stack)")]
        Row,
        /// <summary>
        /// Row reverse
        /// </summary>
        [DisplayText("Row (right to left stack)")]
        RowReverse,
        /// <summary>
        /// Column
        /// </summary>
        [DisplayText("Column (top down stack)")]
        Column,
        /// <summary>
        /// Column reverse
        /// </summary>
        [DisplayText("Column (down top stack)")]
        ColumnReverse
    }
}
