using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using wan24.Blazor.Parameters;
using wan24.Core;

// Components: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-8.0
// Events: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-8.0

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Base class for a Blazor component
    /// </summary>
    public abstract partial class BlazorComponentBase : ComponentBase, IBlazorComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BlazorComponentBase() : base()
        {
            if (ComponentDefaultParameters.Get(GetType()) is IParameters parameters)
                parameters.ApplyToExcluding(this);
        }

        /// <inheritdoc/>
        public virtual Dictionary<string, object> AllParameters => CurrentParameters.AllParameters;

        /// <inheritdoc/>
        public abstract IParameters DefaultParameters { get; }

        /// <inheritdoc/>
        public abstract IParameters CurrentParameters { get; }

        /// <inheritdoc/>
        public abstract IEnumerable<string> ObjectProperties { get; }

        /// <inheritdoc/>
        public abstract IEnumerable<string> DesignProperties { get; }

        /// <inheritdoc/>
        public abstract IEnumerable<string> AccessabilityProperties { get; }

        /// <inheritdoc/>
        public virtual string? FactoryClass => null;

        /// <inheritdoc/>
        public virtual string HAlignCss => HAlign.HasValue
            ? HAlign.Value switch
            {
                HorizontalAligns.Right => "end",
                HorizontalAligns.Center => "center",
                _ => "start"
            }
            : "start";

        /// <inheritdoc/>
        public virtual string? ClassAttribute
        {
            get
            {
                CssBuilder builder = new();
                bool visible = IsVisible,
                    enabled = IsEnabled;

                // Factory CSS classes
                if (FactoryClass is string factoryClass) builder.AddClass(factoryClass);
                if (FactoryAttributes is Dictionary<string, object> factoryAttributes) builder.AddClassFromAttributes(factoryAttributes);
                if (ComponentFactoryDefaults.Get(GetType())?.Class is string addFactoryClass) builder.AddClass(addFactoryClass);

                // Flex box
                if (Grow) builder.AddClass("flex-grow-1");
                if (FlexBox)
                {
                    if (visible) builder.AddClass(InlineFlex ? "d-inline-flex" : "d-flex");
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
                if (BackGroundColor is not null) builder.AddClass($"bg-{BackGroundColor}{(BackGroundSubtle ? "-subtle" : string.Empty)}");
                if (BackGroundOpacity != Opacities.Op100) builder.AddClass(BackGroundOpacity switch
                {
                    Opacities.Op75 => "bg-opacity-75",
                    Opacities.Op50 => "bg-opacity-50",
                    Opacities.Op25 => "bg-opacity-25",
                    Opacities.Op10 => "bg-opacity-10",
                    _ => throw new InvalidProgramException(BackGroundOpacity.ToString())
                });
                if (BackGroundGradient) builder.AddClass("bg-gradient");

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
                if (FontStyle.HasValue)
                {
                    if ((FontStyle.Value & FontStyles.Bold) == FontStyles.Bold) builder.AddClass("fw-bold");
                    if ((FontStyle.Value & FontStyles.Italic) == FontStyles.Italic) builder.AddClass("fst-italic");
                    if ((FontStyle.Value & FontStyles.Underline) == FontStyles.Underline) builder.AddClass("text-decoration-underline");
                    if ((FontStyle.Value & FontStyles.Stroke) == FontStyles.Stroke) builder.AddClass("text-decoration-line-through");
                    if ((FontStyle.Value & FontStyles.LowerCase) == FontStyles.LowerCase) builder.AddClass("text-lowercase");
                    if ((FontStyle.Value & FontStyles.UpperCase) == FontStyles.UpperCase) builder.AddClass("text-uppercase");
                    if ((FontStyle.Value & FontStyles.Capitalize) == FontStyles.Capitalize) builder.AddClass("text-capitalize");
                    if ((FontStyle.Value & FontStyles.Bolder) == FontStyles.Bolder) builder.AddClass("fw-bolder");
                    if ((FontStyle.Value & FontStyles.SemiBold) == FontStyles.SemiBold) builder.AddClass("fw-semibold");
                    if ((FontStyle.Value & FontStyles.MediumBold) == FontStyles.MediumBold) builder.AddClass("fw-medium");
                    if ((FontStyle.Value & FontStyles.NormalWeight) == FontStyles.NormalWeight) builder.AddClass("fw-normal");
                    if ((FontStyle.Value & FontStyles.Light) == FontStyles.Light) builder.AddClass("fw-light");
                    if ((FontStyle.Value & FontStyles.Lighter) == FontStyles.Lighter) builder.AddClass("fw-lighter");
                    if ((FontStyle.Value & FontStyles.Monospace) == FontStyles.Monospace) builder.AddClass("font-monospace");
                    if ((FontStyle.Value & FontStyles.ResetColor) == FontStyles.ResetColor) builder.AddClass("text-reset");
                    if ((FontStyle.Value & FontStyles.NoDecoration) == FontStyles.NoDecoration) builder.AddClass("text-decoration-none");
                }

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

                // Disabled
                if (!enabled) builder.AddClass("disabled");

                // Hidden
                if (!visible) builder.AddClass("d-none");

                // Active
                if (IsActive && enabled && visible) builder.AddClass("active");

                // User CSS classes
                if (Class is not null) builder.AddClass(Class);
                if (Attributes is Dictionary<string, object> attributes) builder.AddClassFromAttributes(attributes);

                return builder.FinalClasses();
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerable<string> ClassNames
            => (Class ?? string.Empty).Split(' ')
                .Select(n => n.Trim()).Concat((FactoryClass ?? string.Empty).Split(' ').Select(n => n.Trim()))
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct();

        /// <inheritdoc/>
        public virtual string? FactoryStyle => null;

        /// <inheritdoc/>
        public virtual string? StyleAttribute
        {
            get
            {
                StyleBuilder builder = new();
                if (FactoryStyle is string factoryStyle) builder.AddStyle(factoryStyle);
                if (FactoryAttributes is Dictionary<string, object> factoryAttributes) builder.AddStyleFromAttributes(factoryAttributes);
                if (ComponentFactoryDefaults.Get(GetType())?.Style is string addFactoryStyle) builder.AddStyle(addFactoryStyle);
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
                return builder.FinalStyle();
            }
        }

        /// <inheritdoc/>
        public virtual Dictionary<string, object>? FactoryAttributes => null;

        /// <inheritdoc/>
        public Dictionary<string, object> AdditionalAttributes
        {
            get
            {
                Dictionary<string, object>? factoryAttributes = FactoryAttributes,
                    addFactoryAttributes = ComponentFactoryDefaults.Get(GetType())?.Attributes,
                    attributes = Attributes;
                bool visible = IsVisible,
                    enabled = IsEnabled;
                int capacity = (attributes?.Count ?? 0) + (factoryAttributes?.Count ?? 0) + (addFactoryAttributes?.Count ?? 0);
                if (Id is not null) capacity++;
                if (Title is not null) capacity++;
                string? classNames = ClassAttribute,
                    style = StyleAttribute;
                if (classNames is not null) capacity++;
                if (style is not null) capacity++;
                if (!enabled) capacity++;
                if (!visible) capacity++;
                if (ForcedColorMode.HasValue) capacity++;
                Dictionary<string, object> res = new(capacity);
                if (factoryAttributes is not null) res.Merge(factoryAttributes);
                if (addFactoryAttributes is not null) res.Merge(addFactoryAttributes);
                if (Id is not null) res["id"] = Id;
                if (Title is not null) res["title"] = Title;
                if (classNames is not null) res["class"] = classNames;
                if (style is not null) res["style"] = style;
                if (!enabled)
                {
                    res["disabled"] = "disabled";
                    res["aria-disabled"] = "true";
                }
                if (!visible)
                {
                    res["hidden"] = "hidden";
                    res["aria-hidden"] = "true";
                }
                if (IsActive && enabled && visible) res["aria-current"] = "true";
                if (ForcedColorMode.HasValue) res["data-bs-theme"] = (ForcedColorMode.Value & BsThemeMode.Dark) == BsThemeMode.Dark ? "dark" : "light";
                if (attributes is not null) res.Merge(attributes);
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
            => CurrentParameters.ApplyToExcluding(other, excludeProperties);

        /// <inheritdoc/>
        public virtual void ApplyToIncluding(in IParameters other, params string[] includeProperties)
            => CurrentParameters.ApplyToIncluding(other, includeProperties);

        /// <inheritdoc/>
        public virtual void Update() => StateHasChanged();

        /// <summary>
        /// Handle a click
        /// </summary>
        /// <param name="e">Arguments</param>
        protected virtual void OnClick(MouseEventArgs e) { }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            ApplyParameters?.ApplyToExcluding(this);
            base.OnParametersSet();
        }
    }
}
