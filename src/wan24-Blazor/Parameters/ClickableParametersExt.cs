using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Extended clickable parameters
    /// </summary>
    public record class ClickableParametersExt : ClickableParameters, IClickableParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ClickableParametersExt() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public ClickableParametersExt(in IClickableParametersExt original) : base(original)
        {
            ChildContent = original.ChildContent;
            ClickHandler = original.ClickHandler;
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static ClickableParametersExt Instance { get; set; } = new();

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (ChildContent is not null) res[nameof(ChildContent)] = ChildContent;
                if (ClickHandler is not null) res[nameof(ClickHandler)] = ClickHandler;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> ClickablePropertyNames => [.. base.ClickablePropertyNames, nameof(ClickHandler)];

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs>? ClickHandler { get; set; }

        /// <inheritdoc/>
        public RenderFragment? ChildContent { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IClickableParametersExt clickable)
            {
                if (ChildContent is not null && !excludeProperties.Contains(nameof(ChildContent))) clickable.ChildContent = ChildContent;
                if (ClickHandler is not null && !excludeProperties.Contains(nameof(ClickHandler))) clickable.ClickHandler = ClickHandler;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IClickableParametersExt clickable)
            {
                if (ChildContent is not null && includeProperties.Contains(nameof(ChildContent))) clickable.ChildContent = ChildContent;
                if (ClickHandler is not null && includeProperties.Contains(nameof(ClickHandler))) clickable.ClickHandler = ClickHandler;
            }
        }
    }
}
