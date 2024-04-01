using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Content
    /// </summary>
    public partial class Content : ColumnFlexBox, IContentParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Content() : this("div") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected Content(in string tagName) : base(tagName) { }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => ContentParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new ContentParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => ContentParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => ContentParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ContentParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        public override string FactoryClass => $"{base.FactoryClass} p-3";
    }
}
