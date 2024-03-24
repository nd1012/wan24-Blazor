using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Link
    /// </summary>
    public partial class Link : Clickable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Link() : base("a") => TextColor = Colors.Primary;

        /// <summary>
        /// No underline?
        /// </summary>
        [Parameter]
        public bool NoUnderline { get; set; }

        /// <summary>
        /// Link underline color (<see cref="Colors" />)
        /// </summary>
        [Parameter]
        public string? UnderlineColor { get; set; } = Colors.Primary;

        /// <summary>
        /// Show link underline on hover only?
        /// </summary>
        [Parameter]
        public bool Hover { get; set; }

        /// <inheritdoc/>
        public override string FactoryClass
            => NoUnderline
                ? $"{(TextColor is null ? string.Empty : $"link-{TextColor}")} link-underline-opacity-0"
                : Hover
                    ? $"{(TextColor is null ? string.Empty : $"link-{TextColor}")} link-offset-2 link-offset-3-hover link-underline{(UnderlineColor is null ? string.Empty : $"-{UnderlineColor}")} link-underline-opacity-0 link-underline-opacity-100-hover"
                    : $"{(TextColor is null ? string.Empty : $"link-{TextColor}")} link-offset-2 link-underline{(UnderlineColor is null ? string.Empty : $"-{UnderlineColor}")}";
    }
}
