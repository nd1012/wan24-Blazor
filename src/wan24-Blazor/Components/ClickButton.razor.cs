using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using wan24.Core;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Click button
    /// </summary>
    public partial class ClickButton : Clickable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ClickButton() : this("button") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected ClickButton(in string tagName) : base(tagName)
        {
            UseBoxSection = BlazorTools.CreateSectionId();
            Flex = FlexBoxTypes.Row;
            Overflow = OverflowTypes.Hidden;
            VAlign = VerticalAligns.Center;
        }

        /// <summary>
        /// Text
        /// </summary>
        [Parameter]
        public virtual string? Text { get; set; }

        /// <summary>
        /// If to show the text
        /// </summary>
        public virtual bool ShowText => true;

        /// <summary>
        /// Text CSS classes
        /// </summary>
        [Parameter]
        public virtual string? TextClass { get; set; }

        /// <summary>
        /// Text CSS factory classes
        /// </summary>
        public virtual string? TextFactoryClass => "ps-3";

        /// <summary>
        /// All text CSS classes
        /// </summary>
        public string? AllTextClass
        {
            get
            {
                CssBuilder builder = new();
                if (TextFactoryClass is not null) builder.AddClass(TextFactoryClass);
                if (TextClass is not null) builder.AddClass(TextClass);
                return builder.NullIfEmpty();
            }
        }

        /// <summary>
        /// Text CSS style
        /// </summary>
        [Parameter]
        public virtual string? TextStyle { get; set; }

        /// <summary>
        /// Text CSS factory style
        /// </summary>
        public virtual string? TextFactoryStyle { get; }

        /// <summary>
        /// All text CSS style
        /// </summary>
        public string? AllTextStyle
        {
            get
            {
                StyleBuilder builder = new();
                if (TextFactoryStyle is not null) builder.AddStyle(TextFactoryStyle);
                if (TextStyle is not null) builder.AddStyle(TextStyle);
                return builder.NullIfEmpty();
            }
        }

        /// <summary>
        /// Text attributes
        /// </summary>
        [Parameter]
        public virtual Dictionary<string, object>? TextAttributes { get; set; }

        /// <summary>
        /// Text component factory attributes
        /// </summary>
        public virtual Dictionary<string, object>? TextFactoryAttributes { get; }

        /// <summary>
        /// All text attributes
        /// </summary>
        public Dictionary<string, object> AllTextAttributes
        {
            get
            {
                Dictionary<string, object> res = TextFactoryAttributes ?? [];
                if (TextAttributes is not null) res.Merge(TextAttributes);
                return res;
            }
        }

        /// <summary>
        /// Text component parameters
        /// </summary>
        [Parameter]
        public virtual Dictionary<string, object>? TextParameters { get; set; }

        /// <summary>
        /// Text component factory parameters
        /// </summary>
        public virtual Dictionary<string, object>? TextFactoryParameters { get; }

        /// <summary>
        /// All text parameters
        /// </summary>
        public Dictionary<string, object> AllTextParameters
        {
            get
            {
                Dictionary<string, object> res = TextFactoryParameters ?? [];
                if (TextParameters is not null) res.Merge(TextParameters);
                return res;
            }
        }

        /// <summary>
        /// Icon URI (will disable <see cref="SvgIconXml" />)
        /// </summary>
        [Parameter]
        public virtual string? Icon { get; set; }

        /// <summary>
        /// If to show the icon
        /// </summary>
        public virtual bool ShowIcon => true;

        /// <summary>
        /// Icon size CSS
        /// </summary>
        [Parameter]
        public virtual string? IconSize { get; set; }

        /// <summary>
        /// Icon CSS classes (not applicable for <see cref="SvgIconXml" />)
        /// </summary>
        [Parameter]
        public virtual string? IconClass { get; set; }

        /// <summary>
        /// Icon CSS factory classes
        /// </summary>
        public virtual string? IconFactoryClass { get; }

        /// <summary>
        /// All icon CSS classes
        /// </summary>
        public string? AllIconClass
        {
            get
            {
                CssBuilder builder = new();
                if (IconFactoryClass is not null) builder.AddClass(IconFactoryClass);
                if (IconClass is not null) builder.AddClass(IconClass);
                return builder.NullIfEmpty();
            }
        }

        /// <summary>
        /// Icon style (not applicable for <see cref="SvgIconXml" />)
        /// </summary>
        [Parameter]
        public virtual string? IconStyle { get; set; }

        /// <summary>
        /// Icon CSS factory style
        /// </summary>
        public virtual string? IconFactoryStyle { get; }

        /// <summary>
        /// All icon CSS style
        /// </summary>
        public string? AllIconStyle
        {
            get
            {
                StyleBuilder builder = new();
                if (IconFactoryStyle is not null) builder.AddStyle(IconFactoryStyle);
                if (IconStyle is not null) builder.AddStyle(IconStyle);
                return builder.NullIfEmpty();
            }
        }

        /// <summary>
        /// Icon attributes
        /// </summary>
        [Parameter]
        public virtual Dictionary<string, object>? IconAttributes { get; set; }

        /// <summary>
        /// Icon component factory attributes
        /// </summary>
        public virtual Dictionary<string, object>? IconFactoryAttributes { get; }

        /// <summary>
        /// All icon attributes
        /// </summary>
        public Dictionary<string, object> AllIconAttributes
        {
            get
            {
                Dictionary<string, object> res = IconFactoryAttributes ?? [];
                if (IconAttributes is not null) res.Merge(IconAttributes);
                return res;
            }
        }

        /// <summary>
        /// Icon component parameters
        /// </summary>
        [Parameter]
        public virtual Dictionary<string, object>? IconParameters { get; set; }

        /// <summary>
        /// Icon component factory parameters
        /// </summary>
        public virtual Dictionary<string, object>? IconFactoryParameters { get; }

        /// <summary>
        /// All icon parameters
        /// </summary>
        public Dictionary<string, object> AllIconParameters
        {
            get
            {
                Dictionary<string, object> res = IconFactoryParameters ?? [];
                if (IconParameters is not null) res.Merge(IconParameters);
                return res;
            }
        }

        /// <summary>
        /// SVG icon image XML (ignored when <see cref="Icon" /> is being used; see <see cref="Images" /> and  <see cref="Images.AsSvgXml(string)" /> 
        /// CAUTION: Will be used 1:1 in HTML!)
        /// </summary>
        [Parameter]
        public virtual string? SvgIconXml { get; set; }

        /// <summary>
        /// SVG icon CSS color (not a class name)
        /// </summary>
        [Parameter]
        public virtual string? SvgIconColor { get; set; }

        /// <summary>
        /// If there's an icon
        /// </summary>
        public virtual bool HasIcon => Icon is not null || SvgIconXml is not null;

        /// <summary>
        /// If to grow the icon
        /// </summary>
        public virtual bool GrowIcon => (Text is null || !ShowText) && ChildContent is null;

        /// <summary>
        /// Display outline
        /// </summary>
        [Parameter]
        public virtual bool Outline { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [Parameter]
        public virtual Sizes Size { get; set; }

        /// <inheritdoc/>
        public override string? FactoryClass
            => $"{base.FactoryClass} btn{(Color is not null ? $" btn-{(Outline ? "outline-" : string.Empty)}{BackGroundColor}" : string.Empty)}{(Size == Sizes.Regular ? string.Empty : $" btn-{Size.ToCss()}")}";

        /// <inheritdoc/>
        public override Dictionary<string, object>? FactoryAttributes
        {
            get
            {
                Dictionary<string, object> res = base.FactoryAttributes ?? [];
                if (TagName == "button") res["type"] = "button";
                return res;
            }
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            if (Text is not null) Title ??= Text;
            base.OnParametersSet();
        }
    }
}
