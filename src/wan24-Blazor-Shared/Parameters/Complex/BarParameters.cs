
namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Bar parameters
    /// </summary>
    public record class BarParameters : BoxParameters, IBarParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarParameters() : base()
        {
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BarParameters(in IBarParameters original) : base(original)
        {
            IconParameters = original.IconParameters;
            ActiveIconParameters = original.ActiveIconParameters;
            TextParameters = original.TextParameters;
            ComponentParameters = original.ComponentParameters;
            ComponentType = original.ComponentType;
            ShowTextHorizontal = original.ShowTextHorizontal;
            ShowTextVertical = original.ShowTextVertical;
            ShowTextOnLandscape = original.ShowTextOnLandscape;
            ShowTextOnPortrait = original.ShowTextOnPortrait;
            ShowTextOnSmallLandscape = original.ShowTextOnSmallLandscape;
            ShowTextOnSmallPortrait = original.ShowTextOnSmallPortrait;
            ShowActive = original.ShowActive;
            ShowActivePath = original.ShowActivePath;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<string> MenuItemProperties => [nameof(IconParameters), nameof(ActiveIconParameters), nameof(TextParameters)];

        /// <inheritdoc/>
        public virtual IEnumerable<string> MenuItemAccessabilityProperties => [
            nameof(ShowTextHorizontal),
            nameof(ShowTextVertical),
            nameof(ShowTextOnLandscape),
            nameof(ShowTextOnPortrait),
            nameof(ShowTextOnSmallLandscape),
            nameof(ShowTextOnSmallPortrait)
            ];

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => [.. base.ObjectProperties, nameof(ComponentType), nameof(ComponentParameters)];

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => [.. base.DesignProperties, nameof(ShowActive), nameof(ShowActivePath)];

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (IconParameters is not null) res[nameof(IconParameters)] = IconParameters;
                if (ActiveIconParameters is not null) res[nameof(ActiveIconParameters)] = ActiveIconParameters;
                if (TextParameters is not null) res[nameof(TextParameters)] = TextParameters;
                if (ComponentParameters is not null) res[nameof(ComponentParameters)] = ComponentParameters;
                if (ComponentType is not null) res[nameof(ComponentType)] = ComponentType;
                res[nameof(ShowTextHorizontal)] = ShowTextHorizontal;
                res[nameof(ShowTextVertical)] = ShowTextVertical;
                res[nameof(ShowTextOnLandscape)] = ShowTextOnLandscape;
                res[nameof(ShowTextOnPortrait)] = ShowTextOnPortrait;
                res[nameof(ShowTextOnSmallLandscape)] = ShowTextOnSmallLandscape;
                res[nameof(ShowTextOnSmallPortrait)] = ShowTextOnSmallPortrait;
                res[nameof(ShowActive)] = ShowActive;
                res[nameof(ShowActivePath)] = ShowActivePath;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual IImageParameters? IconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IImageParameters? ActiveIconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IBodyTextParameters? TextParameters { get; set; }

        /// <inheritdoc/>
        public virtual IParameters? ComponentParameters { get; set; }

        /// <inheritdoc/>
        public virtual Type? ComponentType { get; set; }

        /// <inheritdoc/>
        public virtual bool ShowTextHorizontal { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowTextVertical { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowTextOnLandscape { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowTextOnPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowTextOnSmallLandscape { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowTextOnSmallPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowActive { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowActivePath { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if(other is IBarParameters bar)
            {
                if (IconParameters is not null && !excludeProperties.Contains(nameof(IconParameters))) bar.IconParameters = IconParameters;
                if (ActiveIconParameters is not null && !excludeProperties.Contains(nameof(ActiveIconParameters))) bar.ActiveIconParameters = ActiveIconParameters;
                if (TextParameters is not null && !excludeProperties.Contains(nameof(TextParameters))) bar.TextParameters = TextParameters;
                if (ComponentParameters is not null && !excludeProperties.Contains(nameof(ComponentParameters))) bar.ComponentParameters = ComponentParameters;
                if (ComponentType is not null && !excludeProperties.Contains(nameof(ComponentType))) bar.ComponentType = ComponentType;
                if (!excludeProperties.Contains(nameof(ShowTextHorizontal))) bar.ShowTextHorizontal = ShowTextHorizontal;
                if (!excludeProperties.Contains(nameof(ShowTextVertical))) bar.ShowTextVertical = ShowTextVertical;
                if (!excludeProperties.Contains(nameof(ShowTextOnLandscape))) bar.ShowTextOnLandscape = ShowTextOnLandscape;
                if (!excludeProperties.Contains(nameof(ShowTextOnPortrait))) bar.ShowTextOnPortrait = ShowTextOnPortrait;
                if (!excludeProperties.Contains(nameof(ShowTextOnSmallLandscape))) bar.ShowTextOnSmallLandscape = ShowTextOnSmallLandscape;
                if (!excludeProperties.Contains(nameof(ShowTextOnSmallPortrait))) bar.ShowTextOnSmallPortrait = ShowTextOnSmallPortrait;
                if (!excludeProperties.Contains(nameof(ShowActive))) bar.ShowActive = ShowActive;
                if (!excludeProperties.Contains(nameof(ShowActivePath))) bar.ShowActivePath = ShowActivePath;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IBarParameters bar)
            {
                if (IconParameters is not null && includeProperties.Contains(nameof(IconParameters))) bar.IconParameters = IconParameters;
                if (ActiveIconParameters is not null && includeProperties.Contains(nameof(ActiveIconParameters))) bar.ActiveIconParameters = ActiveIconParameters;
                if (TextParameters is not null && includeProperties.Contains(nameof(TextParameters))) bar.TextParameters = TextParameters;
                if (ComponentParameters is not null && includeProperties.Contains(nameof(ComponentParameters))) bar.ComponentParameters = ComponentParameters;
                if (ComponentType is not null && includeProperties.Contains(nameof(ComponentType))) bar.ComponentType = ComponentType;
                if (includeProperties.Contains(nameof(ShowTextHorizontal))) bar.ShowTextHorizontal = ShowTextHorizontal;
                if (includeProperties.Contains(nameof(ShowTextVertical))) bar.ShowTextVertical = ShowTextVertical;
                if (includeProperties.Contains(nameof(ShowTextOnLandscape))) bar.ShowTextOnLandscape = ShowTextOnLandscape;
                if (includeProperties.Contains(nameof(ShowTextOnPortrait))) bar.ShowTextOnPortrait = ShowTextOnPortrait;
                if (includeProperties.Contains(nameof(ShowTextOnSmallLandscape))) bar.ShowTextOnSmallLandscape = ShowTextOnSmallLandscape;
                if (includeProperties.Contains(nameof(ShowTextOnSmallPortrait))) bar.ShowTextOnSmallPortrait = ShowTextOnSmallPortrait;
                if (includeProperties.Contains(nameof(ShowActive))) bar.ShowActive = ShowActive;
                if (includeProperties.Contains(nameof(ShowActivePath))) bar.ShowActivePath = ShowActivePath;
            }
        }
    }
}
