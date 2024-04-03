using wan24.ObjectValidation;

namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Base class for parameters
    /// </summary>
    public abstract record class ParametersBase : ValidatableRecordBase, IParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected ParametersBase() : base() { }

        /// <inheritdoc/>
        public abstract Dictionary<string, object> AllParameters { get; }

        /// <inheritdoc/>
        public virtual IParameters? ApplyParameters { get; set; }

        /// <inheritdoc/>
        public abstract void ApplyToExcluding(in IParameters other, params string[] excludeProperties);

        /// <inheritdoc/>
        public abstract void ApplyToIncluding(in IParameters other, params string[] includeProperties);
    }
}
