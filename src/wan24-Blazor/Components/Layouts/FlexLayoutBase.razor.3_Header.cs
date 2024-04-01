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

        /// <inheritdoc/>
        public Type? Header { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? HeaderParameters { get; protected set; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public string HeaderTag { get; protected set; } = "header";

        /// <inheritdoc/>
        public bool ShowHeaderOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowHeaderOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowHeaderOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowHeaderOnSmallPortrait { get; protected set; } = true;
    }
}
