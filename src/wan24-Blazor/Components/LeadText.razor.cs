using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Lead text
    /// </summary>
    public partial class LeadText : BodyText, ILeadTextParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LeadText() : this("p") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName"></param>
        protected LeadText(in string tagName) : base(tagName) { }

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

        /// <inheritdoc/>
        public override string? FactoryClass => $"{base.FactoryClass} lead";
    }
}
