using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Extended menu item parameters
    /// </summary>
    public record class MenuItemParametersExt : MenuItemParameters, IMenuItemParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuItemParametersExt() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public MenuItemParametersExt(in IMenuItemParametersExt original) : base(original)
        {
            ChildContent = original.ChildContent;
            ClickHandler = original.ClickHandler;
            ActiveMatch = original.ActiveMatch;
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static MenuItemParametersExt Instance { get; set; } = new();

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (ChildContent is not null) res[nameof(ChildContent)] = ChildContent;
                if (ClickHandler is not null) res[nameof(ClickHandler)] = ClickHandler;
                if (ActiveMatch.HasValue) res[nameof(ActiveMatch)] = ActiveMatch.Value;
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
        [Parameter]
        public virtual NavLinkMatch? ActiveMatch { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IClickableParametersExt clickable)
            {
                if (ChildContent is not null && !excludeProperties.Contains(nameof(ChildContent))) clickable.ChildContent = ChildContent;
                if (ClickHandler is not null && !excludeProperties.Contains(nameof(ClickHandler))) clickable.ClickHandler = ClickHandler;
            }
            if (other is IMenuItemParametersExt menuItem && !excludeProperties.Contains(nameof(ActiveMatch)) && ActiveMatch.HasValue) menuItem.ActiveMatch = ActiveMatch.Value;
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
            if (other is IMenuItemParametersExt menuItem && includeProperties.Contains(nameof(ActiveMatch)) && ActiveMatch.HasValue) menuItem.ActiveMatch = ActiveMatch.Value;
        }
    }
}
