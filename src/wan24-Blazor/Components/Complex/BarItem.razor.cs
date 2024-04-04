using wan24.Blazor.Parameters;
using wan24.Blazor.Parameters.Complex;

namespace wan24.Blazor.Components.Complex
{
    /// <summary>
    /// Bar item (<see cref="MenuItem"/>)
    /// </summary>
    public partial class BarItem : BarItemBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarItem() : base(typeof(MenuItem)) { }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => BarItemParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new BarItemParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => BarItemParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => BarItemParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => BarItemParametersExt.Instance.AccessabilityProperties;
    }
}
