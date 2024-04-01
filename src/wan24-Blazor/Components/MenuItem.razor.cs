using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Menu item
    /// </summary>
    public partial class MenuItem : ClickButton, IMenuItemComponent, IMenuItemParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuItem() : base("div")
        {
            InlineFlex = false;
            BackGroundColor = null;
        }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => MenuItemParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new MenuItemParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ClickablePropertyNames => MenuItemParametersExt.Instance.ClickablePropertyNames;

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => MenuItemParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => MenuItemParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ClickButtonParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        [CascadingParameter]
        public virtual IMenu? Menu { get; set; }

        /// <summary>
        /// Menu orientation
        /// </summary>
        [CascadingParameter]
        public virtual Orientations? Orientation { get; set; }

        /// <inheritdoc/>
        [CascadingParameter]
        public virtual IMenuItemComponentHost? Parent { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual NavLinkMatch? ActiveMatch { get; set; }

        /// <inheritdoc/>
        public override bool ShowText => (Menu?.ShowText ?? true) && base.ShowText;

        /// <inheritdoc/>
        public override string? TextFactoryClass
            => $"{base.TextFactoryClass}{(TextColor is null ? string.Empty : $" link-{TextColor}{(TextEmphasis ? "-emphasis" : string.Empty)}")}";

        /// <inheritdoc/>
        public override string? FactoryClass
            => $"nav-link px-3 py-2{(Orientation.HasValue && Orientation.Value == Orientations.Vertical ? " flex-fill" : string.Empty)}";

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            if (Parent is not null)
            {
                Menu ??= Parent.Menu;
                Parent.HostedComponent = this;
            }
            base.OnParametersSet();
        }
    }
}
