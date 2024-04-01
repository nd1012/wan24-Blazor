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

        /// <inheritdoc/>
        public Type? ContentSidebar { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? ContentSidebarParameters { get; protected set; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public string ContentSidebarTag { get; protected set; } = "aside";

        /// <inheritdoc/>
        public bool ShowContentSidebarOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowContentSidebarOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowContentSidebarOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowContentSidebarOnSmallPortrait { get; protected set; } = true;
    }
}
