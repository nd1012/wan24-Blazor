using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using wan24.Blazor.Parameters;
using wan24.Blazor.Parameters.Complex;

namespace wan24.Blazor.Components.Complex
{
    /// <summary>
    /// Bar item
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="type">Menu item component type (must be a <see cref="ComponentBase"/>, should be an <see cref="IBlazorComponent"/>)</param>
    public abstract partial class BarItemBase(in Type type) : ParentComponentBase(), IBarItemParametersExt, IMenuItemComponentHost, IMenuParentItem
    {
        /// <summary>
        /// Sub items (only top level!)
        /// </summary>
        protected readonly List<IMenuItem> _Items = [];

        /// <inheritdoc/>
        [CascadingParameter]
        public virtual IMenu? Menu { get; set; }

        /// <inheritdoc/>
        [Parameter, CascadingParameter]
        public virtual IMenuParentItem? Parent { get; set; }

        /// <inheritdoc/>
        public virtual ComponentBase? HostedComponent { get; set; }

        /// <inheritdoc/>
        public virtual IEnumerable<IMenuItem> Items => _Items;

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Href { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual EventCallback<MouseEventArgs>? ClickHandler { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Target { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Text { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual IImageParameters? IconParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual IImageParameters? ActiveIconParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual IBodyTextParameters? TextParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual IParameters? ComponentParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual NavLinkMatch? ActiveMatch { get; set; }

        /// <inheritdoc/>
        public virtual bool IsActiveItem
        {
            get => IsActive;
            set => IsActive = value;
        }

        /// <inheritdoc/>
        [Parameter]
        public virtual Type Type { get; set; } = type;

        /// <summary>
        /// Component element parameters
        /// </summary>
        public virtual Dictionary<string, object> Parameters
        {
            get
            {
                Dictionary<string, object> res = [];
                if (Href is not null) res[nameof(Href)] = Href;
                if (ClickHandler is not null) res[nameof(ClickHandler)] = ClickHandler;
                if (Target is not null) res[nameof(Target)] = Target;
                if (Text is not null) res[nameof(Text)] = Text;
                if (IconParameters is not null) res[nameof(IconParameters)] = IconParameters;
                if (ActiveIconParameters is not null) res[nameof(ActiveIconParameters)] = ActiveIconParameters;
                if (TextParameters is not null) res[nameof(TextParameters)] = TextParameters;
                if (ComponentParameters is not null) res[nameof(ComponentParameters)] = ComponentParameters;
                if (ActiveMatch.HasValue) res[nameof(ActiveMatch)] = ActiveMatch.Value;
                res[nameof(IsActiveItem)] = IsActiveItem;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual void AddMenuItem(IMenuItem item) => _Items.Add(item);

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            if (Parent is not IMenuParentItem parentItem)
            {
                Menu?.AddMenuItem(this);
            }
            else
            {
                Menu ??= parentItem.Menu;
                parentItem.AddMenuItem(this);
            }
            if (Menu is not null)
            {
                if (IconParameters is null)
                {
                    if (Menu.IconParameters is not null) IconParameters = new ImageParameters(Menu.IconParameters);
                }
                else
                {
                    Menu.IconParameters?.ApplyToExcluding(IconParameters);
                }
                if (ActiveIconParameters is null)
                {
                    if (Menu.ActiveIconParameters is not null) ActiveIconParameters = new ImageParameters(Menu.ActiveIconParameters);
                }
                else
                {
                    Menu.ActiveIconParameters?.ApplyToExcluding(ActiveIconParameters);
                }
                if (TextParameters is null)
                {
                    if (Menu.TextParameters is not null) TextParameters = new BodyTextParameters(Menu.TextParameters);
                }
                else
                {
                    Menu.TextParameters?.ApplyToExcluding(TextParameters);
                }
                if (ComponentParameters is null)
                {
                    ComponentParameters = Menu.ComponentParameters;
                }
                else
                {
                    Menu.ComponentParameters?.ApplyToExcluding(ComponentParameters);
                }
                ActiveMatch ??= Menu.ActiveMatch;
            }
            base.OnParametersSet();
        }
    }
}
