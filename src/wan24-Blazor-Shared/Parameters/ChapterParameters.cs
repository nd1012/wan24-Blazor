namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Box parameters
    /// </summary>
    public record class ChapterParameters : BoxParameters, IChapterParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChapterParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original"></param>
        public ChapterParameters(in IChapterParameters original) : base(original)
        {
            if (original.HeaderText is not null) HeaderText = original.HeaderText;
            Level = original.Level;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                res[nameof(HeaderText)] = HeaderText;
                res[nameof(Level)] = Level;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => [.. base.ObjectProperties, nameof(HeaderText), nameof(Level)];

        /// <inheritdoc/>
        public virtual string? HeaderText { get; set; }

        /// <inheritdoc/>
        public virtual int Level { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IChapterParameters chapter)
            {
                if (!excludeProperties.Contains(nameof(HeaderText))) chapter.HeaderText = HeaderText;
                if (!excludeProperties.Contains(nameof(Level))) chapter.Level = Level;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IChapterParameters chapter)
            {
                if (includeProperties.Contains(nameof(HeaderText))) chapter.HeaderText = HeaderText;
                if (includeProperties.Contains(nameof(Level))) chapter.Level = Level;
            }
        }
    }
}
