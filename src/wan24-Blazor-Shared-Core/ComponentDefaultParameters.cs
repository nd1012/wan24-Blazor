using System.Collections.Concurrent;
using wan24.Blazor.Parameters;

namespace wan24.Blazor
{
    /// <summary>
    /// Default component parameters
    /// </summary>
    public static class ComponentDefaultParameters
    {
        /// <summary>
        /// Registered default component parameters
        /// </summary>
        private static readonly ConcurrentDictionary<int, IParameters> Registered = [];

        /// <summary>
        /// Register component default parameters
        /// </summary>
        /// <param name="type">Component type</param>
        /// <param name="parameters">Default parameters</param>
        public static void Register(Type type, IParameters parameters) => Registered[type.GetHashCode()] = parameters;

        /// <summary>
        /// Get component default parameters
        /// </summary>
        /// <param name="type">Component type</param>
        /// <returns>Default parameters</returns>
        public static IParameters? Get(Type type) => Registered.TryGetValue(type.GetHashCode(), out IParameters? res) ? res : null;
    }
}
