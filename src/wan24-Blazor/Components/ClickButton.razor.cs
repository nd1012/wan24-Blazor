using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;
using wan24.Core;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Click button
    /// </summary>
    public partial class ClickButton : Clickable, IClickButtonParametersExt
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
            UseBoxSection = Helper.CreateSectionId();
            Flex = FlexBoxTypes.Row;
            Overflow = OverflowTypes.Hidden;
            HAlign = HorizontalAligns.Center;
            VAlign = VerticalAligns.Center;
            BackGroundColor = Colors.Primary;
            Truncate = true;
            NoWrap = true;
        }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => ClickButtonParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new ClickButtonParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ClickablePropertyNames => ClickButtonParametersExt.Instance.ClickablePropertyNames;

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => ClickButtonParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => ClickButtonParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ClickButtonParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Text { get; set; }

        /// <summary>
        /// If to show the text
        /// </summary>
        public virtual bool ShowText => !string.IsNullOrWhiteSpace(Text);

        /// <inheritdoc/>
        [Parameter]
        public virtual IBodyTextParameters? TextParameters { get; set; }

        /// <summary>
        /// Text CSS factory classes
        /// </summary>
        public virtual string? TextFactoryClass => (!IsActive && ShowIcon) || (IsActive && ShowActiveIcon) ? "ps-3" : null;

        /// <summary>
        /// All text CSS classes
        /// </summary>
        public virtual string? AllTextClass
        {
            get
            {
                CssBuilder builder = new();
                if (TextFactoryClass is string factoryCss) builder.AddClass(factoryCss);
                if (TextParameters?.Class is string css) builder.AddClass(css);
                return builder.FinalClasses();
            }
        }

        /// <summary>
        /// Text CSS factory style
        /// </summary>
        public virtual string? TextFactoryStyle { get; }

        /// <summary>
        /// All text CSS style
        /// </summary>
        public virtual string? AllTextStyle
        {
            get
            {
                StyleBuilder builder = new();
                if (TextFactoryStyle is string factoryStyle) builder.AddStyle(factoryStyle);
                if (TextParameters?.Style is string style) builder.AddStyle(style);
                return builder.FinalStyle();
            }
        }

        /// <summary>
        /// Text component factory attributes
        /// </summary>
        public virtual Dictionary<string, object>? TextFactoryAttributes { get; }

        /// <summary>
        /// All text attributes
        /// </summary>
        public virtual Dictionary<string, object> AllTextAttributes
        {
            get
            {
                Dictionary<string, object> res = TextFactoryAttributes ?? [];
                if (TextParameters?.Attributes is Dictionary<string, object> attr) res.Merge(attr);
                return res;
            }
        }

        /// <summary>
        /// Text component factory parameters
        /// </summary>
        public virtual Dictionary<string, object>? TextFactoryParameters
        {
            get
            {
                Dictionary<string, object> res = [];
                res[nameof(TagName)] = "div";
                res[nameof(Grow)] = true;
                if (AllTextClass is string css) res[nameof(Class)] = css;
                if (AllTextStyle is string style) res[nameof(Style)] = style;
                return res;
            }
        }

        /// <summary>
        /// All text parameters
        /// </summary>
        public virtual Dictionary<string, object> AllTextParameters
        {
            get
            {
                Dictionary<string, object> res = TextParameters?.AllParameters ?? [];
                if (TextFactoryParameters is Dictionary<string, object> factoryParameters) res.Merge(factoryParameters);
                if (AllTextAttributes is Dictionary<string, object> allAttributes) res[nameof(Attributes)] = allAttributes;
                return res;
            }
        }

        /// <inheritdoc/>
        [Parameter]
        public virtual IImageParameters? IconParameters { get; set; }

        /// <summary>
        /// If to show the icon
        /// </summary>
        public virtual bool ShowIcon => (!IsActive && HasIcon) || (IsActive && (HasActiveIcon || HasIcon));

        /// <summary>
        /// Icon CSS factory classes
        /// </summary>
        public virtual string? IconFactoryClass { get; }

        /// <summary>
        /// All icon CSS classes
        /// </summary>
        public virtual string? AllIconClass
        {
            get
            {
                CssBuilder builder = new();
                if (IconFactoryClass is string factoryCss) builder.AddClass(factoryCss);
                if (IconParameters?.Class is string css) builder.AddClass(css);
                return builder.FinalClasses();
            }
        }

        /// <summary>
        /// Icon CSS factory style
        /// </summary>
        public virtual string? IconFactoryStyle { get; }

        /// <summary>
        /// All icon CSS style
        /// </summary>
        public virtual string? AllIconStyle
        {
            get
            {
                StyleBuilder builder = new();
                if (IconFactoryStyle is string factoryCss) builder.AddStyle(factoryCss);
                if (IconParameters?.Style is string style) builder.AddStyle(style);
                return builder.FinalStyle();
            }
        }

        /// <summary>
        /// Icon component factory attributes
        /// </summary>
        public virtual Dictionary<string, object>? IconFactoryAttributes { get; }

        /// <summary>
        /// All icon attributes
        /// </summary>
        public virtual Dictionary<string, object> AllIconAttributes
        {
            get
            {
                Dictionary<string, object> res = IconFactoryAttributes ?? [];
                if (IconParameters?.Attributes is Dictionary<string, object> attr) res.Merge(attr);
                if ((Title is not null || Text is not null) && !res.ContainsKey("title")) res["title"] = Title ?? Text!;
                return res;
            }
        }

        /// <summary>
        /// Icon component factory parameters
        /// </summary>
        public virtual Dictionary<string, object>? IconFactoryParameters
        {
            get
            {
                Dictionary<string, object> res = [];
                res[nameof(TagName)] = "div";
                res[nameof(Flex)] = FlexBoxTypes.Row;
                if (GrowIcon) res[nameof(Grow)] = true;
                if (AllIconClass is string css) res[nameof(Class)] = css;
                if (AllIconStyle is string style) res[nameof(Style)] = style;
                return res;
            }
        }

        /// <summary>
        /// All icon parameters
        /// </summary>
        public virtual Dictionary<string, object> AllIconParameters
        {
            get
            {
                Dictionary<string, object> res = IconParameters?.AllParameters ?? [];
                if (IconFactoryParameters is Dictionary<string, object> factoryParameters) res.Merge(factoryParameters);
                if (AllIconAttributes is Dictionary<string, object> allAttributes) res[nameof(Attributes)] = allAttributes;
                return res;
            }
        }

        /// <inheritdoc/>
        [Parameter]
        public virtual IImageParameters? ActiveIconParameters { get; set; }

        /// <summary>
        /// If to show the active icon
        /// </summary>
        public virtual bool ShowActiveIcon => ShowIcon;

        /// <summary>
        /// Icon CSS factory classes
        /// </summary>
        public virtual string? ActiveIconFactoryClass { get; }

        /// <summary>
        /// All icon CSS classes
        /// </summary>
        public string? AllActiveIconClass
        {
            get
            {
                CssBuilder builder = new();
                if (ActiveIconFactoryClass is string factoryCss) builder.AddClass(factoryCss);
                if (ActiveIconParameters?.Class is string css) builder.AddClass(css);
                return builder.FinalClasses();
            }
        }

        /// <summary>
        /// Icon CSS factory style
        /// </summary>
        public virtual string? ActiveIconFactoryStyle { get; }

        /// <summary>
        /// All icon CSS style
        /// </summary>
        public string? AllActiveIconStyle
        {
            get
            {
                StyleBuilder builder = new();
                if (ActiveIconFactoryStyle is string factoryCss) builder.AddStyle(factoryCss);
                if (ActiveIconParameters?.Style is string style) builder.AddStyle(style);
                return builder.FinalStyle();
            }
        }

        /// <summary>
        /// Icon component factory attributes
        /// </summary>
        public virtual Dictionary<string, object>? ActiveIconFactoryAttributes { get; }

        /// <summary>
        /// All icon attributes
        /// </summary>
        public Dictionary<string, object> AllActiveIconAttributes
        {
            get
            {
                Dictionary<string, object> res = ActiveIconFactoryAttributes ?? [];
                if (ActiveIconParameters?.Attributes is Dictionary<string, object> attr) res.Merge(attr);
                if ((Title is not null || Text is not null) && !res.ContainsKey("title")) res["title"] = Title ?? Text!;
                return res;
            }
        }

        /// <summary>
        /// Icon component factory parameters
        /// </summary>
        public virtual Dictionary<string, object>? ActiveIconFactoryParameters
        {
            get
            {
                Dictionary<string, object> res = [];
                res[nameof(TagName)] = "div";
                res[nameof(Flex)] = FlexBoxTypes.Row;
                if (GrowIcon) res[nameof(Grow)] = true;
                if (AllActiveIconClass is string css) res[nameof(Class)] = css;
                if (AllActiveIconStyle is string style) res[nameof(Style)] = style;
                return res;
            }
        }

        /// <summary>
        /// All icon parameters
        /// </summary>
        public Dictionary<string, object> AllActiveIconParameters
        {
            get
            {
                Dictionary<string, object> res = ActiveIconParameters?.AllParameters ?? [];
                if (ActiveIconFactoryParameters is Dictionary<string, object> factoryParameters) res.Merge(factoryParameters);
                if (AllActiveIconAttributes is Dictionary<string, object> allAttributes) res[nameof(Attributes)] = allAttributes;
                return res;
            }
        }

        /// <summary>
        /// If there's an icon
        /// </summary>
        public virtual bool HasIcon => IconParameters is not null && (IconParameters.Src is not null || IconParameters.SvgXml is not null);

        /// <summary>
        /// If there's an active icon
        /// </summary>
        public virtual bool HasActiveIcon => ActiveIconParameters is not null && (ActiveIconParameters.Src is not null || ActiveIconParameters.SvgXml is not null);

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
        /// Button size
        /// </summary>
        [Parameter]
        public virtual Sizes Size { get; set; }

        /// <inheritdoc/>
        public override string? FactoryClass
            => $"{base.FactoryClass} btn{(BackGroundColor is not null ? $" btn-{(Outline ? "outline-" : string.Empty)}{BackGroundColor}" : string.Empty)}{(Size == Sizes.Regular ? string.Empty : $" btn-{Size.ToCss()}")}";

        /// <inheritdoc/>
        public override Dictionary<string, object>? FactoryAttributes
        {
            get
            {
                Dictionary<string, object> res = base.FactoryAttributes ?? [];
                if (TagName == "button" && !res.ContainsKey("type")) res["type"] = "button";
                if (Title is null && Text is not null && !ShowText) res["title"] = Text;
                return res;
            }
        }
    }
}
