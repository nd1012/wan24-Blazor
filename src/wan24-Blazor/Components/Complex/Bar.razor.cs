using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using wan24.Blazor.Parameters;
using wan24.Blazor.Parameters.Complex;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Complex
{
    /// <summary>
    /// Bar
    /// </summary>
    public partial class Bar : DisposableBoxBase, IMenu, IBarParametersExt
    {
        /// <summary>
        /// Items (contains only top items)
        /// </summary>
        protected readonly List<IMenuItem> _Items = [];

        /// <summary>
        /// Constructor
        /// </summary>
        public Bar() : this("nav") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        public Bar(in string tagName) : base(tagName)
        {
            Id = Helper.CreateElementId();
            UseBoxSection = Helper.CreateSectionId();
            Grow = true;
            BackGroundColor = Colors.Primary;
            TextParameters = new BodyTextParameters()
            {
                TextColor = Colors.Light
            };
            IconParameters = new ImageParameters()
            {
                SvgColor = BsTheme.Current.Light?.ToHtmlString(),
                Size = "width:1.25rem;height:1.25rem;"
            };
        }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => BarParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new BarParametersExt(this);

        /// <inheritdoc/>
        public virtual IEnumerable<string> MenuItemProperties => BarParametersExt.Instance.MenuItemProperties;

        /// <inheritdoc/>
        public virtual IEnumerable<string> MenuItemAccessabilityProperties => BarParametersExt.Instance.MenuItemAccessabilityProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => BarParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => BarParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => BarParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        public virtual IEnumerable<IMenuItem> Items => _Items;

        /// <inheritdoc/>
        NavigationManager IMenu.Navigation => Navigation;

        /// <inheritdoc/>
        public virtual IImageParameters? IconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IImageParameters? ActiveIconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IBodyTextParameters? TextParameters { get; set; }

        /// <inheritdoc/>
        public virtual IParameters? ComponentParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual Type? ComponentType { get; set; }

        /// <inheritdoc/>
        public virtual bool ShowText
        {
            get
            {
                if (IsLandscape && !ShowTextOnLandscape) return false;
                if (IsPortrait && !ShowTextOnPortrait) return false;
                switch (Flex.Flip().ToOrientation())
                {
                    case Orientations.Horizontal:
                        if (!ShowTextHorizontal) return false;
                        break;
                    case Orientations.Vertical:
                        if (!ShowTextVertical) return false;
                        break;
                }
                if (IsSmallScreen)
                {
                    if (IsLandscape && !ShowTextOnSmallLandscape) return false;
                    if (IsPortrait && !ShowTextOnSmallPortrait) return false;
                }
                return true;
            }
        }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowTextHorizontal { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowTextVertical { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowTextOnLandscape { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowTextOnPortrait { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowTextOnSmallLandscape { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowTextOnSmallPortrait { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual IMenuItem? ActiveItem { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowActive { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowActivePath { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual NavLinkMatch ActiveMatch { get; set; } = NavLinkMatch.All;

        /// <inheritdoc/>
        public override string? FactoryClass => $"{base.FactoryClass} nav pt-3";

        /// <inheritdoc/>
        public virtual void AddMenuItem(IMenuItem item) => _Items.Add(item);

        /// <summary>
        /// Set the active menu item (and update changed items; <see cref="OnActiveChanged"/> will be raised)
        /// </summary>
        /// <param name="item">New active item</param>
        /// <param name="update">Invalidate changed items?</param>
        /// <returns>Changed items (which have been updated, if <c>update</c> was <see langword="true"/>)</returns>
        public virtual IMenuItem[] ActivateItem(IMenuItem? item, bool update = true)
        {
            IMenuItem? previous = this.GetActiveItem();
            IMenuItem[] inactivated = this.ResetActiveItem();
            HashSet<IMenuItem> res = [.. inactivated];
            if (item is not null)
                if (ShowActivePath)
                {
                    foreach (IMenuItem path in item.GetPath())
                    {
                        res.Add(path);
                        item.IsActiveItem = true;
                    }
                }
                else
                {
                    res.Add(item);
                    item.IsActiveItem = true;
                }
            if (update) foreach (IMenuItem updated in res) updated.Update();
            RaiseOnActiveChanged(previous, item);
            return [.. res];
        }

        /// <summary>
        /// Handle a changed location
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        protected virtual void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            lock (DisposeLock)
            {
                if (IsDisposing) return;
                ActivateItem(this.GetMatchingItem(new Uri(e.Location).AbsolutePath));
            }
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            Navigation.LocationChanged += HandleLocationChanged;
            ActivateItem(ActiveItem, update: false);
            base.OnInitialized();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (Navigation is not null) Navigation.LocationChanged -= HandleLocationChanged;
            base.Dispose(disposing);
        }

        /// <summary>
        /// Delegate for an <see cref="OnActiveChanged"/> event handler
        /// </summary>
        /// <param name="bar">Bar</param>
        /// <param name="e">Arguments</param>
        public delegate void ActiveChanged_Delegate(Bar bar, ActiveChangedEventArgs e);
        /// <summary>
        /// Raised when the active menu item changed
        /// </summary>
        public event ActiveChanged_Delegate? OnActiveChanged;
        /// <summary>
        /// Raise the <see cref="OnActiveChanged"/> event
        /// </summary>
        /// <param name="previous">Previously active menu item</param>
        /// <param name="active">Now active menu item</param>
        protected virtual void RaiseOnActiveChanged(in IMenuItem? previous, in IMenuItem? active) => RaiseOnActiveChanged(new(previous, active));
        /// <summary>
        /// Raise the <see cref="OnActiveChanged"/> event
        /// </summary>
        /// <param name="e">Arguments</param>
        protected void RaiseOnActiveChanged(in ActiveChangedEventArgs e) => OnActiveChanged?.Invoke(this, e);

        /// <summary>
        /// Event arguments for the <see cref="OnActiveChanged"/> event
        /// </summary>
        /// <remarks>
        /// Constructor
        /// </remarks>
        /// <param name="previous">Previously active menu item</param>
        /// <param name="active">Now active menu item</param>
        public class ActiveChangedEventArgs(in IMenuItem? previous, in IMenuItem? active) : EventArgs()
        {
            /// <summary>
            /// Previously active menu item
            /// </summary>
            public IMenuItem? Previous { get; } = previous;

            /// <summary>
            /// Now active menu item
            /// </summary>
            public IMenuItem? Active { get; } = active;
        }
    }
}
