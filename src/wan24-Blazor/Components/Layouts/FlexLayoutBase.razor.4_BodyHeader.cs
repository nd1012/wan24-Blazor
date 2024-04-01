using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Body header (display on top of the body, scrolls with the body content)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Header section component (overrides <see cref="BodyHeader"/> from any child component)
        /// </summary>
        public static object? BodyHeaderSection { get; set; }

        /// <inheritdoc/>
        public Type? BodyHeader { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? BodyHeaderParameters { get; protected set; }

        /// <inheritdoc/>
        public virtual bool DisplayBodyHeader => !((BodyHeader is null && BodyHeaderSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowBodyHeaderOnLandscape) ||
                    (IsPortrait && !ShowBodyHeaderOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowBodyHeaderOnSmallLandscape) ||
                    (IsPortrait && !ShowBodyHeaderOnSmallPortrait)
                )
            ));

        /// <inheritdoc/>
        public string BodyHeaderTag { get; protected set; } = "header";

        /// <inheritdoc/>
        public bool ShowBodyHeaderOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBodyHeaderOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBodyHeaderOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBodyHeaderOnSmallPortrait { get; protected set; } = true;
    }
}
