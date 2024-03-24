using Microsoft.AspNetCore.Components;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Header (display on top of the body)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Header section component (overrides <see cref="Header"/> from any child component)
        /// </summary>
        public static object? HeaderSection { get; set; }

        /// <summary>
        /// Header component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        public Type? Header { get; protected set; }

        /// <summary>
        /// Header parameters
        /// </summary>
        public Dictionary<string, object>? HeaderParameters { get; protected set; }

        /// <summary>
        /// Display the header?
        /// </summary>
        public virtual bool DisplayHeader => !((Header is null && HeaderSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowHeaderOnLandscape) ||
                    (IsPortrait && !ShowHeaderOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowHeaderOnSmallLandscape) ||
                    (IsPortrait && !ShowHeaderOnSmallPortrait)
                )
            ));

        /// <summary>
        /// Header HTML tag name
        /// </summary>
        public string HeaderTag { get; protected set; } = "header";

        /// <summary>
        /// Show the header on a landscape screen?
        /// </summary>
        public bool ShowHeaderOnLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the header on a small landscape screen?
        /// </summary>
        public bool ShowHeaderOnSmallLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the header on a portrait screen?
        /// </summary>
        public bool ShowHeaderOnPortrait { get; protected set; } = true;

        /// <summary>
        /// Show the header on a portrait screen?
        /// </summary>
        public bool ShowHeaderOnSmallPortrait { get; protected set; } = true;
    }
}
