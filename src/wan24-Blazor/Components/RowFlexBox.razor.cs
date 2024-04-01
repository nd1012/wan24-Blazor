using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Row flex box
    /// </summary>
    public partial class RowFlexBox : Box, IRowFlexBoxParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RowFlexBox() : this("div") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName"></param>
        protected RowFlexBox(in string tagName) : base(tagName) => Flex = FlexBoxTypes.Row;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => RowFlexBoxParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new RowFlexBoxParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => RowFlexBoxParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => RowFlexBoxParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => RowFlexBoxParametersExt.Instance.AccessabilityProperties;
    }
}
