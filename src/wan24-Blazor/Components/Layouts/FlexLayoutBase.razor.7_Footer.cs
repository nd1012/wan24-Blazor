using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components.Layouts
{
    // Footer (display below the body)
    public abstract partial class FlexLayoutBase
    {
        /// <summary>
        /// Footer section component (overrides <see cref="Footer"/> from any child component)
        /// </summary>
        public static object? FooterSection { get; set; }

        /// <inheritdoc/>
        public Type? Footer { get; protected set; }

        /// <inheritdoc/>
        public Dictionary<string, object>? FooterParameters { get; protected set; }

        /// <inheritdoc/>
        public virtual bool DisplayFooter => !((Footer is null && FooterSection is null) ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowFooterOnLandscape) ||
                    (IsPortrait && !ShowFooterOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowFooterOnSmallLandscape) ||
                    (IsPortrait && !ShowFooterOnSmallPortrait)
                )
            ));

        /// <inheritdoc/>
        public string FooterTag { get; protected set; } = "footer";

        /// <inheritdoc/>
        public bool ShowFooterOnLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowFooterOnSmallLandscape { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowFooterOnPortrait { get; protected set; } = true;

        /// <inheritdoc/>
        public bool ShowFooterOnSmallPortrait { get; protected set; } = true;
    }
}
