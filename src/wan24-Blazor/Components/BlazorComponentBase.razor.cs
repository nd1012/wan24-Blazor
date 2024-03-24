using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using wan24.Core;

// Components: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-8.0
// Events: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-8.0

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Base class for a Blazor component
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    public abstract partial class BlazorComponentBase() : ComponentBase()
    {
        /// <summary>
        /// Factory CSS class (override to provide default class names)
        /// </summary>
        public virtual string? FactoryClass => null;

        /// <summary>
        /// Horizontal align CSS
        /// </summary>
        public virtual string HAlignCss => HAlign.HasValue
            ? HAlign.Value switch
            {
                HorizontalAligns.Right => "right",
                HorizontalAligns.Center => "center",
                _ => "start"
            }
            : "start";

        /// <summary>
        /// CSS class attribute raw HTML
        /// </summary>
        public virtual string? ClassAttribute
        {
            get
            {
                CssBuilder builder = new();

                // Factory CSS classes
                if (FactoryClass is string factoryClass) builder.AddClass(factoryClass);
                if (FactoryAttributes is Dictionary<string, object> factoryAttributes) builder.AddClassFromAttributes(factoryAttributes);

                // Flex box
                if (Grow) builder.AddClass("flex-grow-1");
                if (FlexBox)
                {
                    builder.AddClass(InlineFlex ? "d-inline-flex" : "d-flex");
                    builder.AddClass(Flex switch
                    {
                        FlexBoxTypes.Row => "flex-row",
                        FlexBoxTypes.RowReverse => "flex-row-reverse",
                        FlexBoxTypes.Column => "flex-column",
                        FlexBoxTypes.ColumnReverse => "flex-column-reverse",
                        _ => throw new InvalidProgramException(Flex.ToString())
                    });
                }

                // Rounded edges
                if (Rounded) builder.AddClass("rounded");

                // Shadow
                if (Shadow != ShadowTypes.None) builder.AddClass(Shadow switch
                {
                    ShadowTypes.Small => "shadow-sm",
                    ShadowTypes.Regular => "shadow",
                    ShadowTypes.Large => "shadow-lg",
                    _ => throw new InvalidProgramException(Shadow.ToString())
                });

                // Overflow
                if (Overflow != OverflowTypes.Auto) builder.AddClass(Overflow switch
                {
                    OverflowTypes.Hidden => "overflow-hidden",
                    OverflowTypes.Visible => "overflow-visible",
                    OverflowTypes.Scroll => "overflow-scroll",
                    _ => throw new InvalidProgramException(Overflow.ToString())
                });
                if (OverflowX != OverflowTypes.Auto) builder.AddClass(OverflowX switch
                {
                    OverflowTypes.Hidden => "overflow-x-hidden",
                    OverflowTypes.Visible => "overflow-x-visible",
                    OverflowTypes.Scroll => "overflow-x-scroll",
                    _ => throw new InvalidProgramException(OverflowX.ToString())
                });
                if (OverflowY != OverflowTypes.Auto) builder.AddClass(OverflowY switch
                {
                    OverflowTypes.Hidden => "overflow-y-hidden",
                    OverflowTypes.Visible => "overflow-y-visible",
                    OverflowTypes.Scroll => "overflow-y-scroll",
                    _ => throw new InvalidProgramException(OverflowY.ToString())
                });

                // Floating
                if (Float != HorizontalAligns.Center) builder.AddClass(Float switch
                {
                    HorizontalAligns.Left => "float-start",
                    HorizontalAligns.Right => "float-end",
                    _ => throw new InvalidProgramException(Float.ToString())
                });

                // Background
                if (BackGroundColor is not null)
                {
                    builder.AddClass($"bg-{BackGroundColor}{(BackGroundSubtle ? "-subtle" : string.Empty)}");
                    if (BackGroundGradient) builder.AddClass("bg-gradient");
                    if (BackGroundOpacity != Opacities.Op100) builder.AddClass(BackGroundOpacity switch
                    {
                        Opacities.Op75 => "bg-opacity-75",
                        Opacities.Op50 => "bg-opacity-50",
                        Opacities.Op25 => "bg-opacity-25",
                        Opacities.Op10 => "bg-opacity-10",
                        _ => throw new InvalidProgramException(BackGroundOpacity.ToString())
                    });
                }

                // Text
                if (TextColor is not null) builder.AddClass($"text-{TextColor}{(TextEmphasis ? "-emphasis" : string.Empty)}");
                if (TextBackGroundColor is not null) builder.AddClass($"text-bg-{TextBackGroundColor}");
                if (TextSize.HasValue) builder.AddClass(TextSize.Value switch
                {
                    Sizes.Small => $"text-sm-{HAlignCss}",
                    Sizes.Large => $"text-lg-{HAlignCss}",
                    Sizes.Regular => $"text-md-{HAlignCss}",
                    _ => throw new InvalidProgramException(TextSize.Value.ToString())
                });
                if (Wrap) builder.AddClass("wrap");
                if (NoWrap) builder.AddClass("no-wrap");
                if (Truncate) builder.AddClass("text-truncate");
                if (Muted) builder.AddClass("text-muted");
                if (Selection.HasValue) builder.AddClass(Selection.Value switch
                {
                    TextSelections.All => "user-select-all",
                    TextSelections.None => "user-select-none",
                    TextSelections.Auto => "user-select-auto",
                    _ => throw new InvalidProgramException(Selection.Value.ToString())
                });

                // Borders
                switch (Border)
                {
                    case Borders.None:
                        break;
                    case Borders.All:
                        builder.AddClass("border");
                        break;
                    default:
                        if ((Border & Borders.Top) == Borders.Top) builder.AddClass("border-top");
                        if ((Border & Borders.Bottom) == Borders.Bottom) builder.AddClass("border-bottom");
                        if ((Border & Borders.Left) == Borders.Left) builder.AddClass("border-start");
                        if ((Border & Borders.Right) == Borders.Right) builder.AddClass("border-end");
                        break;
                }
                if (BorderColor is not null) builder.AddClass($"border-{BorderColor}{(BorderEmphasis ? "-emphasis" : string.Empty)}");
                if (BorderOpacity != Opacities.Op100) builder.AddClass(BorderOpacity switch
                {
                    Opacities.Op75 => "border-opacity-75",
                    Opacities.Op50 => "border-opacity-50",
                    Opacities.Op25 => "border-opacity-25",
                    Opacities.Op10 => "border-opacity-10",
                    _ => throw new InvalidProgramException(BorderOpacity.ToString())
                });

                // User CSS classes
                if (Class is not null) builder.AddClass(Class);
                if (Attributes is Dictionary<string, object> attributes) builder.AddClassFromAttributes(attributes);

                return builder.NullIfEmpty();
            }
        }

        /// <summary>
        /// CSS class names
        /// </summary>
        public virtual IEnumerable<string> ClassNames
            => (Class ?? string.Empty).Split(' ')
                .Select(n => n.Trim()).Concat((FactoryClass ?? string.Empty).Split(' ').Select(n => n.Trim()))
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct();

        /// <summary>
        /// Factory CSS style (override to provide default styles)
        /// </summary>
        public virtual string? FactoryStyle => null;

        /// <summary>
        /// CSS style attribute raw HTML
        /// </summary>
        public virtual string? StyleAttribute
        {
            get
            {
                StyleBuilder builder = new();
                if (FactoryStyle is string factoryStyle) builder.AddStyle(factoryStyle);
                if (FactoryAttributes is Dictionary<string, object> factoryAttributes) builder.AddStyleFromAttributes(factoryAttributes);
                if (Color is not null) builder.AddStyle($"color: {Color};");
                if (TextOpacity != Opacities.Op100) builder.AddStyle(TextOpacity switch
                {
                    Opacities.Op75 => "--bs-text-opacity: .75;",
                    Opacities.Op50 => "--bs-text-opacity: .5;",
                    Opacities.Op25 => "--bs-text-opacity: .25;",
                    Opacities.Op10 => "--bs-text-opacity: .1;",
                    _ => throw new InvalidProgramException(TextOpacity.ToString())
                });
                if (ZIndex.HasValue) builder.AddStyle($"z-index: {ZIndex};");
                if (Style is not null) builder.AddStyle(Style);
                if (Attributes is Dictionary<string, object> attributes) builder.AddStyleFromAttributes(attributes);
                return builder.NullIfEmpty();
            }
        }

        /// <summary>
        /// Additional factory attributes (override to provide default attributes)
        /// </summary>
        public virtual Dictionary<string, object>? FactoryAttributes => null;

        /// <summary>
        /// All additional attributes
        /// </summary>
        public Dictionary<string, object> AdditionalAttributes
        {
            get
            {
                Dictionary<string, object>? factoryAttributes = FactoryAttributes,
                    attributes = Attributes;
                int capacity = (attributes?.Count ?? 0) + (factoryAttributes?.Count ?? 0);
                if (Id is not null) capacity++;
                if (Title is not null) capacity++;
                string? classNames = ClassAttribute,
                    style = StyleAttribute;
                if (classNames is not null) capacity++;
                if (style is not null) capacity++;
                if (Disabled) capacity++;
                Dictionary<string, object> res = new(capacity);
                if (factoryAttributes is not null) res.Merge(factoryAttributes);
                if (Id is not null) res["id"] = Id;
                if (Title is not null) res["title"] = Title;
                if (classNames is not null) res["class"] = classNames;
                if (style is not null) res["style"] = style;
                if (Disabled)
                {
                    res["disabled"] = "disabled";
                    res["aria-disabled"] = "true";
                }
                if (attributes is not null) res.Merge(attributes);
                return res;
            }
        }

        /// <summary>
        /// Handle a click
        /// </summary>
        /// <param name="e">Arguments</param>
        protected virtual void OnClick(MouseEventArgs e) { }
    }
}
