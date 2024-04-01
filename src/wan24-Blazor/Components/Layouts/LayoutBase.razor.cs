using BlazorComponentUtilities;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Sections;
using wan24.Core;
using static wan24.Blazor.BlazorEnv;
using static wan24.Blazor.BlazorTools;
using static wan24.Blazor.GuiEnv;
using static wan24.Core.Logger;
using static wan24.Core.Logging;

namespace wan24.Blazor.Components.Layouts
{
    /// <summary>
    /// Layout component
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="tagName">HTML tag name</param>
    /// <param name="asyncDisposing">If <see cref="DisposeCore"/> was implemented</param>
    public abstract partial class LayoutBase(in string? tagName = null, in bool asyncDisposing = false) : LayoutComponentBase(), ILayout
    {
        /// <summary>
        /// Layout section name
        /// </summary>
        protected const string LAYOUT_SECTION = "layout";

        /// <summary>
        /// An object for thread synchronization
        /// </summary>
        protected readonly object DisposeLock = new();
        /// <summary>
        /// Dispose cancellation
        /// </summary>
        protected readonly CancellationTokenSource DisposeCancellation = new();
        /// <summary>
        /// If <see cref="DisposeCore"/> was implemented
        /// </summary>
        protected readonly bool AsyncDisposing = asyncDisposing;
        /// <summary>
        /// If disposing
        /// </summary>
        private bool _IsDisposing = false;
        /// <summary>
        /// If disposed
        /// </summary>
        private bool _IsDisposed = false;

        /// <summary>
        /// Destructor
        /// </summary>
        ~LayoutBase()
        {
            if (_IsDisposing) return;
            Dispose(disposing: false);
        }

        /// <inheritdoc/>
        public bool IsDisposing => _IsDisposing;

        /// <inheritdoc/>
        public bool IsDisposed => _IsDisposed;

        /// <inheritdoc/>
        public bool DisplayChangesState { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ColorModeChangesState { get; protected set; } = false;

        /// <inheritdoc/>
        public virtual string TagName { get; protected set; } = tagName ?? "div";

        /// <inheritdoc/>
        public string Id { get; protected set; } = "main";

        /// <inheritdoc/>
        public string? Class { get; protected set; }

        /// <inheritdoc/>
        public IBsTheme? Theme { get; protected set; }

        /// <inheritdoc/>
        public virtual string? FactoryClass
            => $"{IfLandscape("landscape", "portrait")} {IfSmallScreen("small-screen", "large-screen")} {(IsDebug ? "debug" : string.Empty)} vh-100 vw-100";

        /// <inheritdoc/>
        public virtual FlexBoxTypes Flex { get; protected set; } = FlexBoxTypes.Column;

        /// <inheritdoc/>
        public virtual OverflowTypes Overflow { get; protected set; } = OverflowTypes.Hidden;

        /// <inheritdoc/>
        public virtual OverflowTypes OverflowX { get; protected set; }

        /// <inheritdoc/>
        public virtual OverflowTypes OverflowY { get; protected set; }

        /// <inheritdoc/>
        public virtual string? ClassAttribute
        {
            get
            {
                CssBuilder builder = new();
                if (FactoryClass is not null) builder.AddClass(FactoryClass);
                if (Class is not null) builder.AddClass(Class);
                if (FactoryAttributes is not null) builder.AddClassFromAttributes(FactoryAttributes);
                if (Attributes is not null) builder.AddClassFromAttributes(Attributes);
                if (Flex != FlexBoxTypes.None)
                {
                    builder.AddClass("d-flex");
                    builder.AddClass(Flex switch
                    {
                        FlexBoxTypes.Row => "flex-row",
                        FlexBoxTypes.RowReverse => "flex-row-reverse",
                        FlexBoxTypes.Column => "flex-column",
                        FlexBoxTypes.ColumnReverse => "flex-column-reverse",
                        _ => throw new InvalidProgramException(Flex.ToString())
                    });
                }
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
        public string? Style { get; protected set; }

        /// <inheritdoc/>
        public virtual string? FactoryStyle => null;

        /// <inheritdoc/>
        public virtual string? StyleAttribute
        {
            get
            {
                StyleBuilder builder = new();
                if (FactoryStyle is not null) builder.AddStyle(FactoryStyle);
                if (Style is not null) builder.AddStyle(Style);
                return builder.FinalStyle();
            }
        }

        /// <inheritdoc/>
        public Dictionary<string, object>? Attributes { get; protected set; }

        /// <inheritdoc/>
        public virtual Dictionary<string, object>? FactoryAttributes => null;

        /// <inheritdoc/>
        public Dictionary<string, object> AdditionalAttributes
        {
            get
            {
                int capacity = (Attributes?.Count ?? 0) + (FactoryAttributes?.Count ?? 0);
                if (Id is not null) capacity++;
                string? classNames = ClassAttribute,
                    style = StyleAttribute;
                if (classNames is not null) capacity++;
                if (style is not null) capacity++;
                Dictionary<string, object> res = new(capacity);
                if (FactoryAttributes is not null) res.Merge(FactoryAttributes);
                if (Id is not null) res["id"] = Id;
                if (classNames is not null) res["class"] = classNames;
                if (style is not null) res["style"] = style;
                if (Attributes is not null) res.Merge(Attributes);
                return res;
            }
        }

        /// <summary>
        /// Render the content
        /// </summary>
        /// <returns>Content</returns>
        protected virtual RenderFragment RenderContent() => builder =>
        {
            builder.OpenElement(0, TagName);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.OpenComponent<SectionOutlet>(2);
            builder.AddComponentParameter(3, nameof(SectionOutlet.SectionName), LAYOUT_SECTION);
            builder.CloseComponent();
            builder.CloseElement();
        };

        /// <summary>
        /// Handle a resize event (update the razor environment and re-render, if the screen orientation/size changed)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="size">Size</param>
        protected virtual void HandleResize(object? sender, BrowserWindowSize size)
        {
            bool wasLandscape = IsLandscape,
                wasSmallScreen = IsSmallScreen;
            WindowWidth = size.Width;
            WindowHeight = size.Height;
            if (Trace) WriteTrace($"Size change {size.Width}x{size.Height} was landscape {wasLandscape}, is landscape {IsLandscape}, was small screen {wasSmallScreen}, is small screen {IsSmallScreen}");
            bool changed = wasLandscape != IsLandscape || wasSmallScreen != IsSmallScreen;
            if (changed)
            {
                RaiseOnScreenOrientationChanged();
                if (DisplayChangesState)
                    try
                    {
                        DisplayChanged = true;
                        StateHasChanged();
                    }
                    finally
                    {
                        DisplayChanged = false;
                    }
            }
        }

        /// <summary>
        /// Handle a color mode change (update the razor environment and re-render, if the color mode changed)
        /// </summary>
        /// <param name="matches">If matches</param>
        protected virtual void HandleColorModeChange(bool matches)
        {
            bool wasLightMode = LightMode;
            if ((BsTheme.Current.Mode & BsThemeMode.UserDefined) != BsThemeMode.UserDefined)
                BsTheme.Current.Mode = LightMode ? BsThemeMode.Light : BsThemeMode.Dark;
            LightMode = !matches;
            if (Trace) WriteTrace($"Color mode change was light mode {wasLightMode}, is light mode {LightMode}");
            if (DisplayChangesState && wasLightMode != LightMode)
                try
                {
                    ColorModeChanged = true;
                    StateHasChanged();
                }
                finally
                {
                    ColorModeChanged = false;
                }
        }

        /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                ResizeListener.OnResized += HandleResize;
            }
            base.OnAfterRender(firstRender);
        }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (BlazorGateway.Instance is null) await BlazorGateway.CreateAsync(JsRuntime).DynamicContext();
            }
            await base.OnAfterRenderAsync(firstRender).DynamicContext();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">If disposing</param>
        protected virtual void Dispose(bool disposing) { }

        /// <summary>
        /// Dispose
        /// </summary>
        protected virtual Task DisposeCore() => Task.CompletedTask;

        /// <inheritdoc/>
        public void Dispose()
        {
            lock (DisposeLock)
            {
                if (_IsDisposing) return;
                _IsDisposing = true;
            }
            DisposeCancellation.Cancel();
            Dispose(disposing: true);
            DisposeCancellation.Dispose();
            ResizeListener.OnResized -= HandleResize;
            _IsDisposed = true;
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (!AsyncDisposing)
            {
                Dispose();
                return;
            }
            lock (DisposeLock)
            {
                if (_IsDisposing) return;
                _IsDisposing = true;
            }
            DisposeCancellation.Cancel();
            await DisposeCore().DynamicContext();
            DisposeCancellation.Dispose();
            ResizeListener.OnResized -= HandleResize;
            _IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
