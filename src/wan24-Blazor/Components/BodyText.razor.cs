using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Body text
    /// </summary>
    public partial class BodyText : Box, IBodyTextParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BodyText() : this("p") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected BodyText(in string tagName) : base(tagName) => InlineFlex = true;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => BodyTextParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new BodyTextParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => BodyTextParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => BodyTextParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => BodyTextParametersExt.Instance.AccessabilityProperties;
    }
}
