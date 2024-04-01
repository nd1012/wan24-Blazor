namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Clickable parameters
    /// </summary>
    public record class ClickableParameters : BoxParameters, IClickableParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ClickableParameters() : base() => InlineFlex = true;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClickableParameters(in IClickableParameters original) : base(original)
        {
            Href = original.Href;
            Target = original.Target;
            ForceLoad = original.ForceLoad;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                res[nameof(Href)] = Href;
                res[nameof(Target)] = Target;
                res[nameof(ForceLoad)] = ForceLoad;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerable<string> ClickablePropertyNames => [
            nameof(Href),
            nameof(Target),
            nameof(ForceLoad)
            ];

        /// <inheritdoc/>
        public string Href { get; set; } = "#";

        /// <inheritdoc/>
        public string Target { get; set; } = "_self";

        /// <inheritdoc/>
        public bool ForceLoad { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IClickableParameters clickable)
            {
                if (!excludeProperties.Contains(nameof(Href))) clickable.Href = Href;
                if (!excludeProperties.Contains(nameof(Target))) clickable.Target = Target;
                if (!excludeProperties.Contains(nameof(ForceLoad))) clickable.ForceLoad = ForceLoad;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IClickableParameters clickable)
            {
                if (includeProperties.Contains(nameof(Href))) clickable.Href = Href;
                if (includeProperties.Contains(nameof(Target))) clickable.Target = Target;
                if (includeProperties.Contains(nameof(ForceLoad))) clickable.ForceLoad = ForceLoad;
            }
        }
    }
}
