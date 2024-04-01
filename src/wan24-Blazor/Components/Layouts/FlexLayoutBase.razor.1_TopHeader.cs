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

        /// <inheritdoc/>
        public Type? TopHeader { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? TopHeaderParameters { get; protected set; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public string TopHeaderTag { get; protected set; } = "header";

        /// <inheritdoc/>
        public bool ShowTopHeaderOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowTopHeaderOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowTopHeaderOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowTopHeaderOnSmallPortrait { get; protected set; } = true;
    }
}
