namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Bar item parameters
    /// </summary>
    public abstract record class BarItemParametersBase : BlazorComponentParameters, IBarItemParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarItemParametersBase() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original"></param>
        public BarItemParametersBase(in IBarItemParameters original) : base(original)
        {
            Href = original.Href;
            Target = original.Target;
            Text = original.Text;
            IconParameters = original.IconParameters;
            ActiveIconParameters = original.ActiveIconParameters;
            TextParameters = original.TextParameters;
            ComponentParameters = original.ComponentParameters;
            IsActiveItem = original.IsActiveItem;
            Type = original.Type;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (Href is not null) res[nameof(Href)] = Href;
                if (Target is not null) res[nameof(Target)] = Target;
                if (IconParameters is not null) res[nameof(IconParameters)] = IconParameters;
                if (ActiveIconParameters is not null) res[nameof(ActiveIconParameters)] = ActiveIconParameters;
                if (TextParameters is not null) res[nameof(TextParameters)] = TextParameters;
                if (ComponentParameters is not null) res[nameof(ComponentParameters)] = ComponentParameters;
                res[nameof(IsActiveItem)] = IsActiveItem;
                res[nameof(Type)] = Type;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => [
            ..base.ObjectProperties,
            nameof(Href),
            nameof(Target),
            nameof(Text),
            nameof(ComponentParameters),
            nameof(IsActiveItem),
            nameof(Type),
            ];

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => [
            ..base.DesignProperties,
            nameof(IconParameters),
            nameof(ActiveIconParameters),
            nameof(TextParameters)
            ];

        /// <inheritdoc/>
        public virtual string? Href { get; set; }

        /// <inheritdoc/>
        public virtual string? Target { get; set; }

        /// <inheritdoc/>
        public virtual string? Text { get; set; }

        /// <inheritdoc/>
        public virtual IImageParameters? IconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IImageParameters? ActiveIconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IBodyTextParameters? TextParameters { get; set; }

        /// <inheritdoc/>
        public virtual IParameters? ComponentParameters { get; set; }

        /// <inheritdoc/>
        public virtual bool IsActiveItem { get; set; }

        /// <inheritdoc/>
        public virtual Type Type { get; set; } = null!;

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IBarItemParameters item)
            {
                if (Href is not null && !excludeProperties.Contains(nameof(Href))) item.Href = Href;
                if (Target is not null && !excludeProperties.Contains(nameof(Target))) item.Target = Target;
                if (Text is not null && !excludeProperties.Contains(nameof(Text))) item.Text = Text;
                if (IconParameters is not null && !excludeProperties.Contains(nameof(IconParameters))) item.IconParameters = IconParameters;
                if (ActiveIconParameters is not null && !excludeProperties.Contains(nameof(ActiveIconParameters))) item.ActiveIconParameters = ActiveIconParameters;
                if (TextParameters is not null && !excludeProperties.Contains(nameof(TextParameters))) item.TextParameters = TextParameters;
                if (ComponentParameters is not null && !excludeProperties.Contains(nameof(ComponentParameters))) item.ComponentParameters = ComponentParameters;
                if (!excludeProperties.Contains(nameof(IsActiveItem))) item.IsActiveItem = IsActiveItem;
                if (!excludeProperties.Contains(nameof(Type))) item.Type = Type;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IBarItemParameters item)
            {
                if (Href is not null && includeProperties.Contains(nameof(Href))) item.Href = Href;
                if (Target is not null && includeProperties.Contains(nameof(Target))) item.Target = Target;
                if (Text is not null && includeProperties.Contains(nameof(Text))) item.Text = Text;
                if (IconParameters is not null && includeProperties.Contains(nameof(IconParameters))) item.IconParameters = IconParameters;
                if (ActiveIconParameters is not null && includeProperties.Contains(nameof(ActiveIconParameters))) item.ActiveIconParameters = ActiveIconParameters;
                if (TextParameters is not null && includeProperties.Contains(nameof(TextParameters))) item.TextParameters = TextParameters;
                if (ComponentParameters is not null && includeProperties.Contains(nameof(ComponentParameters))) item.ComponentParameters = ComponentParameters;
                if (includeProperties.Contains(nameof(IsActiveItem))) item.IsActiveItem = IsActiveItem;
                if (includeProperties.Contains(nameof(Type))) item.Type = Type;
            }
        }
    }
}
