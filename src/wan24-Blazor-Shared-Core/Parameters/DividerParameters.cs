
namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Divider parameters
    /// </summary>
    public record class DividerParameters : BoxParameters, IDividerParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DividerParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public DividerParameters(in IDividerParameters original) : base(original) => Orientation = original.Orientation;

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                res[nameof(Orientation)] = Orientation;
                return res;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => [.. base.DesignProperties, nameof(Orientation)];

        /// <summary>
        /// Orientation
        /// </summary>
        public Orientations Orientation { get; set; } = Orientations.Horizontal;

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IDividerParameters divider && !excludeProperties.Contains(nameof(TagName))) divider.Orientation = Orientation;
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IDividerParameters divider && includeProperties.Contains(nameof(TagName))) divider.Orientation = Orientation;
        }
    }
}
