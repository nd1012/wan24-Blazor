using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Inline
    /// </summary>
    public partial class Inline : Box, IInlineParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Inline() : base() => TagName = "span";

        /// <inheritdoc/>
        public override IParameters DefaultParameters => InlineParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new InlineParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => InlineParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => InlineParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => InlineParametersExt.Instance.AccessabilityProperties;
    }
}
