namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for parameters
    /// </summary>
    public interface IParameters
    {
        /// <summary>
        /// All parameters (may be used with a <c>DynamicComponent</c>, for example)
        /// </summary>
        Dictionary<string, object> AllParameters { get; }
        /// <summary>
        /// Parameters to apply after initializing (applied during <c>OnParametersSet</c> is being called)
        /// </summary>
        IParameters? ApplyParameters { get; set; }
        /// <summary>
        /// Apply these parameters to another object (which may be any object which implements <see cref="IParameters"/>, like a component)
        /// </summary>
        /// <param name="other">Other</param>
        /// <param name="excludeProperties">Names of excluded properties</param>
        void ApplyToExcluding(in IParameters other, params string[] excludeProperties);
        /// <summary>
        /// Apply these parameters to another object (which may be any object which implements <see cref="IParameters"/>, like a component)
        /// </summary>
        /// <param name="other">Other</param>
        /// <param name="includeProperties">Names of included properties</param>
        void ApplyToIncluding(in IParameters other, params string[] includeProperties);
    }
}
