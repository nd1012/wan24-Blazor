using wan24.Blazor.Parameters.Complex;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components.Complex
{
    /// <summary>
    /// Bar branding
    /// </summary>
    public partial class BarBranding : BarItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarBranding() : base() { }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => BarBrandingParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new BarBrandingParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => BarBrandingParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => BarBrandingParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => BarBrandingParametersExt.Instance.AccessabilityProperties;
    }
}
