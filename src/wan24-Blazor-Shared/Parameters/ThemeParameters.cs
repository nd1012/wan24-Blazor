namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Theme parameters
    /// </summary>
    public record class ThemeParameters : ParametersBase, IThemeParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ThemeParameters() : base() => Apply = new Bs5Theme().Merge(Bs5Theme.Default);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public ThemeParameters(in IThemeParameters original) : base()
        {
            Id = original.Id;
            Apply = original.Apply;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = [];
                if (Id is not null) res[nameof(Id)] = Id;
                res[nameof(Apply)] = Apply;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual string? Id { get; set; }

        /// <inheritdoc/>
        public virtual IBsTheme Apply { get; set; }

        /// <inheritdoc/>
        public virtual bool NotCurrent { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            if (other is IThemeParameters theme)
            {
                if (Id is not null && !excludeProperties.Contains(nameof(Id))) Id = theme.Id;
                if (!excludeProperties.Contains(nameof(Apply))) Apply = theme.Apply;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            if (other is IThemeParameters theme)
            {
                if (Id is not null && includeProperties.Contains(nameof(Id))) Id = theme.Id;
                if (includeProperties.Contains(nameof(Apply))) Apply = theme.Apply;
            }
        }
    }
}
