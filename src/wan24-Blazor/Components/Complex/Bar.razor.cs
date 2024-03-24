using Microsoft.AspNetCore.Components;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Complex
{
    /// <summary>
    /// Bar
    /// </summary>
    public partial class Bar : Box, IMenu
    {
        /// <summary>
        /// Items (contains only top items)
        /// </summary>
        protected readonly List<IMenuItem> _Items = [];

        /// <summary>
        /// Constructor
        /// </summary>
        public Bar() : base("nav")
        {
            UseBoxSection = BlazorTools.CreateSectionId();
            Grow = true;
            TextBackGroundColor = Colors.Primary;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        public Bar(in string tagName) : base(tagName)
        {
            UseBoxSection = BlazorTools.CreateSectionId();
            Grow = true;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<IMenuItem> Items => _Items;

        /// <inheritdoc/>
        [Parameter]
        public virtual string? IconSize { get; set; }

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
        public override string? FactoryClass => $"{base.FactoryClass} p-3";

        /// <inheritdoc/>
        public virtual void AddMenuItem(IMenuItem item) => _Items.Add(item);

        /// <inheritdoc/>
        public virtual IMenuItem? FindMenuItem(string id)
        {
            Queue<IMenuParentItem> parents = [];
            foreach (IMenuItem item in _Items)
                if (item.Id == id)
                {
                    return item;
                }
                else if (item is IMenuParentItem parentItem)
                {
                    parents.Enqueue(parentItem);
                }
            while(parents.TryDequeue(out IMenuParentItem? item))
                if (item.Id == id)
                {
                    return item;
                }
                else
                {
                    foreach (IMenuItem subItem in _Items)
                        if (subItem.Id == id)
                        {
                            return subItem;
                        }
                        else if (subItem is IMenuParentItem parentItem)
                        {
                            parents.Enqueue(parentItem);
                        }
                }
            return null;
        }
    }
}
