using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Flex box types enumeration
    /// </summary>
    public enum FlexBoxTypes : byte
    {
        /// <summary>
        /// None
        /// </summary>
        [DisplayText("No flex box")]
        None =  0,
        /// <summary>
        /// Row
        /// </summary>
        [DisplayText("Row (left to right stack)")]
        Row = 1,
        /// <summary>
        /// Row reverse
        /// </summary>
        [DisplayText("Row (right to left stack)")]
        RowReverse = 2,
        /// <summary>
        /// Column
        /// </summary>
        [DisplayText("Column (top down stack)")]
        Column = 3,
        /// <summary>
        /// Column reverse
        /// </summary>
        [DisplayText("Column (down top stack)")]
        ColumnReverse = 4
    }
}
