using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Divider
    /// </summary>
    public partial class Divider : Box, IDividerParametersExt
    {
        /// <summary>
        /// Divider
        /// </summary>
        public Divider() : base() { }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => DividerParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new DividerParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => DividerParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => DividerParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => DividerParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        [Parameter]
        public virtual Orientations Orientation { get; set; } = Orientations.Horizontal;

        /// <inheritdoc/>
        public override string? FactoryClass => $"{base.FactoryClass} {(Orientation == Orientations.Horizontal ? "hr" : "vr")}";
    }
}
