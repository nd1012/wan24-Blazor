using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Growing box
    /// </summary>
    public partial class GrowBox : Box, IGrowBoxParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GrowBox() : this("div") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected GrowBox(in string tagName) : base(tagName) => Grow = true;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => GrowBoxParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new GrowBoxParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => GrowBoxParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => GrowBoxParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => GrowBoxParametersExt.Instance.AccessabilityProperties;
    }
}
