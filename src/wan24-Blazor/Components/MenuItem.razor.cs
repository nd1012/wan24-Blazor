using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Menu item
    /// </summary>
    public partial class MenuItem : ClickButton, IMenuItemComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuItem() : base("div") => InlineFlex = false;

        /// <inheritdoc/>
        [CascadingParameter]
        public IMenu? Menu { get; set; }

        /// <summary>
        /// Menu orientation
        /// </summary>
        [CascadingParameter]
        public Orientations? Orientation { get; set; }

        /// <inheritdoc/>
        [CascadingParameter]
        public IMenuItemComponentHost? Parent { get; set; }

        /// <inheritdoc/>
        [Parameter]
#pragma warning disable BL0007 // Should be auto property
        public override string? Text
        {
            get => Menu?.ShowText ?? true ? base.Text : null;
            set => base.Text = value;
        }
#pragma warning restore BL0007 // Should be auto property

        /// <inheritdoc/>
        public override string? FactoryClass => "py-2";

        /// <inheritdoc/>
        public override Dictionary<string, object>? FactoryAttributes
        {
            get
            {
                Dictionary<string, object>? res = base.FactoryAttributes;
                if (res is null || TagName != "button") return res;
                res.Remove("type", out _);
                return res;
            }
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            IconSize ??= Menu?.IconSize;
            base.OnInitialized();
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            if (Parent is not null)
            {
                Menu ??= Parent.Menu;
                Parent.HostedComponent = this;
            }
            base.OnInitialized();
        }
    }
}
