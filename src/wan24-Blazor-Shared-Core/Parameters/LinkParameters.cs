namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Link parameters
    /// </summary>
    public record class LinkParameters : ClickableParameters, ILinkParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LinkParameters() : base()
        {
            TagName = "a";
            TextColor = Colors.Primary;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public LinkParameters(in ILinkParameters original) : base(original)
        {
            NoUnderline = original.NoUnderline;
            UnderlineColor = original.UnderlineColor;
            Hover = original.Hover;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                res[nameof(NoUnderline)] = NoUnderline;
                if (UnderlineColor is not null) res[nameof(UnderlineColor)] = UnderlineColor;
                res[nameof(Hover)] = Hover;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => [
            .. base.DesignProperties,
            nameof(NoUnderline),
            nameof(UnderlineColor),
            nameof(Hover)
            ];

        /// <inheritdoc/>
        public virtual bool NoUnderline { get; set; }

        /// <inheritdoc/>
        public virtual string? UnderlineColor { get; set; }

        /// <inheritdoc/>
        public virtual bool Hover { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is ILinkParameters link)
            {
                if (!excludeProperties.Contains(nameof(NoUnderline))) link.NoUnderline = NoUnderline;
                if (UnderlineColor is not null && !excludeProperties.Contains(nameof(UnderlineColor))) link.UnderlineColor = UnderlineColor;
                if (!excludeProperties.Contains(nameof(Hover))) link.Hover = Hover;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is ILinkParameters link)
            {
                if (includeProperties.Contains(nameof(NoUnderline))) link.NoUnderline = NoUnderline;
                if (UnderlineColor is not null && includeProperties.Contains(nameof(UnderlineColor))) link.UnderlineColor = UnderlineColor;
                if (includeProperties.Contains(nameof(Hover))) link.Hover = Hover;
            }
        }
    }
}
