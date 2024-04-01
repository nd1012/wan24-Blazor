using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Page heading
    /// </summary>
    public partial class PageHeading : ParentComponentBase, IPageHeadingParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PageHeading() : base() { }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => PageHeadingParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new PageHeadingParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => PageHeadingParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => PageHeadingParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => PageHeadingParametersExt.Instance.AccessabilityProperties;
    }
}
