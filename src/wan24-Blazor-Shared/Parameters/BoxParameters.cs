namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Box parameters
    /// </summary>
    public record class BoxParameters : BlazorComponentParameters, IBoxParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BoxParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original"></param>
        public BoxParameters(in IBoxParameters original) : base(original) => TagName = original.TagName;

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                res[nameof(TagName)] = TagName;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => [.. base.ObjectProperties, nameof(TagName)];

        /// <inheritdoc/>
        public virtual string TagName { get; set; } = "div";

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IBoxParameters box && !excludeProperties.Contains(nameof(TagName))) box.TagName = TagName;
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IBoxParameters box && includeProperties.Contains(nameof(TagName))) box.TagName = TagName;
        }
    }
}
