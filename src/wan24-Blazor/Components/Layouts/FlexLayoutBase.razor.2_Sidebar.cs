using Microsoft.AspNetCore.Components;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Sidebar (default display at the left of the screen, between top header and footer)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Sidebar section component (overrides <see cref="Sidebar"/> from any child component)
        /// </summary>
        public static object? SidebarSection { get; protected set; }

        /// <summary>
        /// Sidebar component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        public Type? Sidebar { get; protected set; }

        /// <summary>
        /// Sidebar parameters
        /// </summary>
        public Dictionary<string, object>? SidebarParameters { get; protected set; }

        /// <summary>
        /// Display the sidebar?
        /// </summary>
        public virtual bool DisplaySidebar => !((Sidebar is null && SidebarSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowSidebarOnLandscape) ||
                    (IsPortrait && !ShowSidebarOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowSidebarOnSmallLandscape) ||
                    (IsPortrait && !ShowSidebarOnSmallPortrait)
                )
            ));

        /// <summary>
        /// Sidebar HTML tag name
        /// </summary>
        public string SidebarTag { get; protected set; } = "aside";

        /// <summary>
        /// Show the sidebar on a landscape screen?
        /// </summary>
        public bool ShowSidebarOnLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the sidebar on a small landscape screen?
        /// </summary>
        public bool ShowSidebarOnSmallLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the sidebar on a portrait screen?
        /// </summary>
        public bool ShowSidebarOnPortrait { get; protected set; } = true;

        /// <summary>
        /// Show the sidebar on a portrait screen?
        /// </summary>
        public bool ShowSidebarOnSmallPortrait { get; protected set; } = true;
    }
}
