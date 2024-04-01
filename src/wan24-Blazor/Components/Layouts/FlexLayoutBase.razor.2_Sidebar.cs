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

        /// <inheritdoc/>
        public Type? Sidebar { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? SidebarParameters { get; protected set; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public string SidebarTag { get; protected set; } = "aside";

        /// <inheritdoc/>
        public bool ShowSidebarOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowSidebarOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowSidebarOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowSidebarOnSmallPortrait { get; protected set; } = true;
    }
}
