using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Small text
    /// </summary>
    public partial class SmallText : BodyText, ISmallTextParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SmallText() : base("small") { }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => SmallTextParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new SmallTextParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => SmallTextParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => SmallTextParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => SmallTextParametersExt.Instance.AccessabilityProperties;
    }
}
