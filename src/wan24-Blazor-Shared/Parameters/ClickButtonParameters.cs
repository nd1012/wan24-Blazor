
namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Click button parameters
    /// </summary>
    public record class ClickButtonParameters : ClickableParameters, IClickButtonParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ClickButtonParameters() : base()
        {
            TagName = "button";
            Flex = FlexBoxTypes.Row;
            Overflow = OverflowTypes.Hidden;
            HAlign = HorizontalAligns.Center;
            VAlign = VerticalAligns.Center;
            BackGroundColor = Colors.Primary;
            Truncate = true;
            NoWrap = true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public ClickButtonParameters(in IClickButtonParameters original) : base(original)
        {
            Text = original.Text;
            TextParameters = original.TextParameters;
            IconParameters = original.IconParameters;
            ActiveIconParameters = original.ActiveIconParameters;
            Outline = original.Outline;
            Size = original.Size;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (Text is not null) res[nameof(Text)] = Text;
                if (TextParameters is not null) res[nameof(TextParameters)] = TextParameters;
                if (IconParameters is not null) res[nameof(IconParameters)] = IconParameters;
                if (ActiveIconParameters is not null) res[nameof(ActiveIconParameters)] = ActiveIconParameters;
                res[nameof(Outline)] = Outline;
                res[nameof(Size)] = Size;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => [.. base.ObjectProperties, nameof(Text)];

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => [
            .. base.DesignProperties,
            nameof(TextParameters),
            nameof(IconParameters),
            nameof(ActiveIconParameters),
            nameof(Outline),
            nameof(Size)
            ];

        /// <inheritdoc/>
        public virtual string? Text { get; set; }

        /// <inheritdoc/>
        public virtual IBoxParameters? TextParameters { get; set; }

        /// <inheritdoc/>
        public virtual IImageParameters? IconParameters { get; set; }

        /// <inheritdoc/>
        public virtual IImageParameters? ActiveIconParameters { get; set; }

        /// <inheritdoc/>
        public virtual bool Outline { get; set; }

        /// <inheritdoc/>
        public virtual Sizes Size { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IClickButtonParameters clickButton)
            {
                if (Text is not null && !excludeProperties.Contains(nameof(Text))) clickButton.Text = Text;
                if (TextParameters is not null && !excludeProperties.Contains(nameof(TextParameters))) clickButton.TextParameters = TextParameters;
                if (IconParameters is not null && !excludeProperties.Contains(nameof(IconParameters))) clickButton.IconParameters = IconParameters;
                if (ActiveIconParameters is not null && !excludeProperties.Contains(nameof(ActiveIconParameters))) clickButton.ActiveIconParameters = ActiveIconParameters;
                if (!excludeProperties.Contains(nameof(Outline))) clickButton.Outline = Outline;
                if (!excludeProperties.Contains(nameof(Size))) clickButton.Size = Size;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IClickButtonParameters clickButton)
            {
                if (Text is not null && includeProperties.Contains(nameof(Text))) clickButton.Text = Text;
                if (TextParameters is not null && includeProperties.Contains(nameof(TextParameters))) clickButton.TextParameters = TextParameters;
                if (IconParameters is not null && includeProperties.Contains(nameof(IconParameters))) clickButton.IconParameters = IconParameters;
                if (ActiveIconParameters is not null && includeProperties.Contains(nameof(ActiveIconParameters))) clickButton.ActiveIconParameters = ActiveIconParameters;
                if (includeProperties.Contains(nameof(Outline))) clickButton.Outline = Outline;
                if (includeProperties.Contains(nameof(Size))) clickButton.Size = Size;
            }
        }
    }
}
