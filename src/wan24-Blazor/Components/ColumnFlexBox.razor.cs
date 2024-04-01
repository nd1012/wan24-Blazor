using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Column flex box
    /// </summary>
    public partial class ColumnFlexBox : Box, IColumnFlexBoxParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColumnFlexBox() : this("div") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected ColumnFlexBox(in string tagName) : base(tagName) => Flex = FlexBoxTypes.Column;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => ColumnFlexBoxParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new ColumnFlexBoxParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => ColumnFlexBoxParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => ColumnFlexBoxParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ColumnFlexBoxParametersExt.Instance.AccessabilityProperties;
    }
}
