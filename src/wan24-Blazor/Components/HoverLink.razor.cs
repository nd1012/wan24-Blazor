using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Hover link
    /// </summary>
    public partial class HoverLink : Link, IHoverLinkParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HoverLink() : base() => Hover = true;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => HoverLinkParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new HoverLinkParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ClickablePropertyNames => HoverLinkParametersExt.Instance.ClickablePropertyNames;

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => HoverLinkParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => HoverLinkParametersExt.Instance.DesignProperties;
    }
}
