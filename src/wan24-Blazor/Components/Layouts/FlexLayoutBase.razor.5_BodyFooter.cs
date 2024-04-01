using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Body footer (display below the body, scrolls with the body content)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Footer section component (overrides <see cref="BodyFooter"/> from any child component)
        /// </summary>
        public static object? BodyFooterSection { get; set; }

        /// <inheritdoc/>
        public Type? BodyFooter { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? BodyFooterParameters { get; protected set; }

        /// <inheritdoc/>
        public virtual bool DisplayBodyFooter => !((Footer is null && FooterSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowBodyFooterOnLandscape) ||
                    (IsPortrait && !ShowBodyFooterOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowBodyFooterOnSmallLandscape) ||
                    (IsPortrait && !ShowBodyFooterOnSmallPortrait)
                )
            ));

        /// <inheritdoc/>
        public string BodyFooterTag { get; protected set; } = "footer";

        /// <inheritdoc/>
        public bool ShowBodyFooterOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBodyFooterOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBodyFooterOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowBodyFooterOnSmallPortrait { get; protected set; } = true;
    }
}
