using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Bottom footer (display at the bottom of the screen)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Bottom footer section component (overrides <see cref="BottomFooter"/> from any child component)
        /// </summary>
        public static object? BottomFooterSection { get; set; }

        /// <inheritdoc/>
        public Type? BottomFooter { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? BottomFooterParameters { get; protected set; }

        /// <inheritdoc/>
        public virtual bool DisplayBottomFooter => !((BottomFooter is null && BottomFooterSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowBottomFooterOnLandscape) ||
                    (IsPortrait && !ShowBottomFooterOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowBottomFooterOnSmallLandscape) ||
                    (IsPortrait && !ShowBottomFooterOnSmallPortrait)
                )
            ));

        /// <inheritdoc/>
        public string BottomFooterTag { get; protected set; } = "footer";

        /// <inheritdoc/>
        public bool ShowBottomFooterOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBottomFooterOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBottomFooterOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBottomFooterOnSmallPortrait { get; protected set; } = true;
    }
}
