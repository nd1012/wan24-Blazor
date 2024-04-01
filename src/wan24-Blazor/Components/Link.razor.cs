using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Link
    /// </summary>
    public partial class Link : Clickable, ILinkParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Link() : base("a") => TextColor = Colors.Primary;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => LinkParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new LinkParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ClickablePropertyNames => LinkParametersExt.Instance.ClickablePropertyNames;

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => LinkParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => LinkParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool NoUnderline { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? UnderlineColor { get; set; } = Colors.Primary;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool Hover { get; set; }

        /// <inheritdoc/>
        public override string FactoryClass
            => NoUnderline
                ? $"{(TextColor is null ? string.Empty : $"link-{TextColor}")}{(TextEmphasis ? "-emphasis" : string.Empty)} link-underline-opacity-0"
                : Hover
                    ? $"{(TextColor is null ? string.Empty : $"link-{TextColor}")}{(TextEmphasis ? "-emphasis" : string.Empty)} link-offset-2 link-offset-3-hover link-underline{(UnderlineColor is null ? string.Empty : $"-{UnderlineColor}")} link-underline-opacity-0 link-underline-opacity-100-hover"
                    : $"{(TextColor is null ? string.Empty : $"link-{TextColor}")}{(TextEmphasis ? "-emphasis" : string.Empty)} link-offset-2 link-underline{(UnderlineColor is null ? string.Empty : $"-{UnderlineColor}")}";
    }
}
