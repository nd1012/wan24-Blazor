using System.Collections.Concurrent;

namespace wan24.Blazor
{
    /// <summary>
    /// Additional component factory defaults
    /// </summary>
    public record class ComponentFactoryDefaults
    {
        /// <summary>
        /// Registered additional component factory defaults
        /// </summary>
        private static readonly ConcurrentDictionary<int, ComponentFactoryDefaults> Registered = [];

        /// <summary>
        /// Cnstructor
        /// </summary>
        public ComponentFactoryDefaults() { }

        /// <summary>
        /// CSS class names
        /// </summary>
        public string? Class { get; set; }

        /// <summary>
        /// CSS style
        /// </summary>
        public string? Style { get; set; }

        /// <summary>
        /// HTML element attributes
        /// </summary>
        public Dictionary<string, object>? Attributes { get; set; }

        /// <summary>
        /// Register additional component factory defaults
        /// </summary>
        /// <param name="type">Component type</param>
        /// <param name="defaults">Additional component factory defaults</param>
        public static void Register(Type type, ComponentFactoryDefaults defaults) => Registered[type.GetHashCode()] = defaults;

        /// <summary>
        /// Get additional component factory defaults
        /// </summary>
        /// <param name="type">Component type</param>
        /// <returns>Additional component factory defaults</returns>
        public static ComponentFactoryDefaults? Get(Type type) => Registered.TryGetValue(type.GetHashCode(), out ComponentFactoryDefaults? res) ? res : null;
    }
}
