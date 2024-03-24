using Microsoft.AspNetCore.Components;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Content sidebar (default display right beside the content body)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Content sidebar section component (overrides <see cref="ContentSidebar"/> from any child component)
        /// </summary>
        public static object? ContentSidebarSection { get; set; }

        /// <summary>
        /// Sidebar component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        public Type? ContentSidebar { get; protected set; }

        /// <summary>
        /// Content sidebar parameters
        /// </summary>
        public Dictionary<string, object>? ContentSidebarParameters { get; protected set; }

        /// <summary>
        /// Display the content sidebar
        /// </summary>
        public virtual bool DisplayContentSidebar => !((ContentSidebar is null && ContentSidebarSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowContentSidebarOnLandscape) ||
                    (IsPortrait && !ShowContentSidebarOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowContentSidebarOnSmallLandscape) ||
                    (IsPortrait && !ShowContentSidebarOnSmallPortrait)
                )
            ));

        /// <summary>
        /// Content sidebar HTML tag name
        /// </summary>
        public string ContentSidebarTag { get; protected set; } = "aside";

        /// <summary>
        /// Show the content sidebar on a landscape screen?
        /// </summary>
        public bool ShowContentSidebarOnLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the content sidebar on a small landscape screen?
        /// </summary>
        public bool ShowContentSidebarOnSmallLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the content sidebar on a portrait screen?
        /// </summary>
        public bool ShowContentSidebarOnPortrait { get; protected set; } = true;

        /// <summary>
        /// Show the content sidebar on a portrait screen?
        /// </summary>
        public bool ShowContentSidebarOnSmallPortrait { get; protected set; } = true;
    }
}
