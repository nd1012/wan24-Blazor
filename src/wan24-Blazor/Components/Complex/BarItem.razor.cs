using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Components.Complex
{
    /// <summary>
    /// Bar item
    /// </summary>
    public partial class BarItem : ComponentBase, IMenuItemComponentHost, IMenuParentItem, IServeChildContent
    {
        /// <summary>
        /// Sub items (only top level!)
        /// </summary>
        protected readonly List<IMenuItem> _Items = [];

        /// <summary>
        /// Constructor
        /// </summary>
        public BarItem() : base() { }

        /// <inheritdoc/>
        [Parameter]
        public virtual RenderFragment? ChildContent { get; set; }

        /// <inheritdoc/>
        [CascadingParameter]
        public IMenu? Menu { get; set; }

        /// <inheritdoc/>
        [Parameter, CascadingParameter]
        public IMenuParentItem? Parent { get; set; }

        /// <inheritdoc/>
        public ComponentBase? HostedComponent { get; set; }

        /// <inheritdoc/>
        public IEnumerable<IMenuItem> Items => _Items;

        /// <inheritdoc/>
        [Parameter]
        public string? Id { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Href { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public Delegate? ClickHandler { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Target { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Text { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public Sizes TextSize { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? TextClass { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? TextStyle { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public Dictionary<string, object>? TextAttributes { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public Dictionary<string, object>? TextParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Icon { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? IconSize { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? IconClass { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? IconStyle { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public Dictionary<string, object>? IconAttributes { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public Dictionary<string, object>? IconParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? SvgIconXml { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? SvgIconColor { get; set; }

        /// <summary>
        /// Render component type
        /// </summary>
        [Parameter]
        public virtual Type Type { get; set; } = typeof(MenuItem);

        /// <summary>
        /// Component CSS classes
        /// </summary>
        [Parameter]
        public string? ComponentClass { get; set; }

        /// <summary>
        /// Component CSS style
        /// </summary>
        [Parameter]
        public string? ComponentStyle { get; set; }

        /// <summary>
        /// Component attributes
        /// </summary>
        [Parameter]
        public Dictionary<string, object>? ComponentParameters { get; set; }

        /// <summary>
        /// Render component parameters
        /// </summary>
        public virtual Dictionary<string, object> Parameters
        {
            get
            {
                Dictionary<string, object> res = ComponentParameters ?? [];
                res[nameof(BlazorComponentBase.InlineFlex)] = false;
                if (ChildContent is not null) res[nameof(ChildContent)] = ChildContent;
                if (ComponentClass is not null) res[nameof(BlazorComponentBase.Class)] = ComponentClass;
                if (ComponentStyle is not null) res[nameof(BlazorComponentBase.Style)] = ComponentStyle;
                if (Href is not null) res[nameof(Href)] = Href;
                if (ClickHandler is not null) res[nameof(ClickHandler)] = ClickHandler;
                if (Target is not null) res[nameof(Target)] = Target;
                if (Text is not null) res[nameof(Text)] = Text;
                res[nameof(TextSize)] = TextSize;
                if (TextClass is not null) res[nameof(TextClass)] = TextClass;
                if (TextStyle is not null) res[nameof(TextStyle)] = TextStyle;
                if (TextAttributes is not null) res[nameof(TextAttributes)] = TextAttributes;
                if (TextParameters is not null) res[nameof(TextParameters)] = TextParameters;
                if (Icon is not null) res[nameof(Icon)] = Icon;
                if (IconSize is not null) res[nameof(IconSize)] = IconSize;
                if (IconClass is not null) res[nameof(IconClass)] = IconClass;
                if (IconStyle is not null) res[nameof(IconStyle)] = IconStyle;
                if (IconAttributes is not null) res[nameof(IconAttributes)] = IconAttributes;
                if (IconParameters is not null) res[nameof(IconParameters)] = IconParameters;
                if (SvgIconXml is not null) res[nameof(SvgIconXml)] = SvgIconXml;
                if (SvgIconColor is not null) res[nameof(SvgIconColor)] = SvgIconColor;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual void AddMenuItem(IMenuItem item) => _Items.Add(item);

        /// <inheritdoc/>
        protected override void OnInitialized()
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
            base.OnInitialized();
        }
    }
}
