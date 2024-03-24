using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using wan24.Core;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Clickable
    /// </summary>
    public partial class Clickable : Box
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Clickable() : base("div") => InlineFlex = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected Clickable(in string tagName) : base(tagName) => InlineFlex = true;

        /// <summary>
        /// Target URI
        /// </summary>
        [Parameter]
        public string Href { get; set; } = "#";

        /// <summary>
        /// Click handler
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs>? ClickHandler { get; set; }

        /// <summary>
        /// Used click handler
        /// </summary>
        public EventCallback<MouseEventArgs> ClickHandlerDelegate => ClickHandler ?? new(receiver: null, @delegate: OnClick);

        /// <summary>
        /// Target name
        /// </summary>
        [Parameter]
        public string Target { get; set; } = "_self";

        /// <summary>
        /// If a load is forced
        /// </summary>
        [Parameter]
        public bool ForceLoad { get; set; }

        /// <inheritdoc/>
        public override string? FactoryStyle => $"{base.FactoryStyle};cursor: pointer;";

        /// <inheritdoc/>
        public override Dictionary<string, object>? FactoryAttributes
        {
            get
            {
                Dictionary<string, object> res = base.FactoryAttributes ?? [];
                res["target"] = Target;
                res["onclick"] = ClickHandlerDelegate;
                return res;
            }
        }

        /// <inheritdoc/>
        protected override void OnClick(MouseEventArgs e) => Navigation.NavigateTo(Href, ForceLoad);
    }
}
