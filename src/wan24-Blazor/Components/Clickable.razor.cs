using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Clickable
    /// </summary>
    public partial class Clickable : Box, IClickableParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Clickable() : this("div") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected Clickable(in string tagName) : base(tagName)
        {
            Id = Helper.CreateElementId();
            InlineFlex = true;
        }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => ClickableParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new ClickableParametersExt(this);

        /// <inheritdoc/>
        public virtual IEnumerable<string> ClickablePropertyNames => ClickableParametersExt.Instance.ClickablePropertyNames;

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => ClickableParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => ClickableParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ClickableParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        [Parameter]
        public virtual string Href { get; set; } = "#";

        /// <inheritdoc/>
        [Parameter]
        public EventCallback<MouseEventArgs>? ClickHandler { get; set; }

        /// <inheritdoc/>
        public EventCallback<MouseEventArgs> ClickHandlerDelegate => ClickHandler ?? new(receiver: null, @delegate: OnClick);

        /// <inheritdoc/>
        [Parameter]
        public virtual string Target { get; set; } = "_self";

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ForceLoad { get; set; }

        /// <inheritdoc/>
        public override string? FactoryStyle => $"{base.FactoryStyle};cursor:pointer;";

        /// <inheritdoc/>
        public override Dictionary<string, object>? FactoryAttributes
        {
            get
            {
                Dictionary<string, object> res = base.FactoryAttributes ?? [];
                if (TagName == "a") res["target"] = Target;
                res["onclick"] = ClickHandlerDelegate;
                return res;
            }
        }

        /// <inheritdoc/>
        protected override void OnClick(MouseEventArgs e) => Navigation.NavigateTo(Href, ForceLoad);
    }
}
