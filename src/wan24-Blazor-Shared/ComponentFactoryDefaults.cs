using System.Collections.Concurrent;

namespace wan24.Blazor
{
    /// <summary>
    /// Additional component factory defaults
    /// </summary>
    public static class ComponentFactoryDefaults
    {
        /// <summary>
        /// Registered additional component factory defaults
        /// </summary>
        private static readonly ConcurrentDictionary<int, IDomElementSettings> Registered = [];

        /// <summary>
        /// Register additional component factory defaults
        /// </summary>
        /// <param name="type">Component type</param>
        /// <param name="defaults">Additional component factory defaults</param>
        public static void Register(Type type, IDomElementSettings defaults) => Registered[type.GetHashCode()] = defaults;

        /// <summary>
        /// Get additional component factory defaults
        /// </summary>
        /// <param name="type">Component type</param>
        /// <returns>Additional component factory defaults</returns>
        public static IDomElementSettings? Get(Type type) => Registered.TryGetValue(type.GetHashCode(), out IDomElementSettings? res) ? res : null;
    }
}
