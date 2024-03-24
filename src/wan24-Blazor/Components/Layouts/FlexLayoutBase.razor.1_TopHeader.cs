using Microsoft.AspNetCore.Components;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Top header (display at the top of the screen)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Top header section component (overrides <see cref="TopHeader"/> from any child component)
        /// </summary>
        public static object? TopHeaderSection { get; set; }

        /// <summary>
        /// Top header component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        public Type? TopHeader { get; protected set; }

        /// <summary>
        /// Top header parameters
        /// </summary>
        public Dictionary<string, object>? TopHeaderParameters { get; protected set; }

        /// <summary>
        /// Display the top header?
        /// </summary>
        public virtual bool DisplayTopHeader => !((TopHeader is null && TopHeaderSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowTopHeaderOnLandscape) ||
                    (IsPortrait && !ShowTopHeaderOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowTopHeaderOnSmallLandscape) ||
                    (IsPortrait && !ShowTopHeaderOnSmallPortrait)
                )
            ));

        /// <summary>
        /// Top header HTML tag name
        /// </summary>
        public string TopHeaderTag { get; protected set; } = "header";

        /// <summary>
        /// Show the top header on a landscape screen?
        /// </summary>
        public bool ShowTopHeaderOnLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the top header on a small landscape screen?
        /// </summary>
        public bool ShowTopHeaderOnSmallLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the top header on a portrait screen?
        /// </summary>
        public bool ShowTopHeaderOnPortrait { get; protected set; } = true;

        /// <summary>
        /// Show the top header on a small portrait screen?
        /// </summary>
        public bool ShowTopHeaderOnSmallPortrait { get; protected set; } = true;
    }
}
