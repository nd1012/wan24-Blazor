using Microsoft.AspNetCore.Components;
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

        /// <summary>
        /// Footer component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        public Type? Footer { get; protected set; }

        /// <summary>
        /// Footer parameters
        /// </summary>
        public Dictionary<string, object>? FooterParameters { get; protected set; }

        /// <summary>
        /// Display the footer?
        /// </summary>
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

        /// <summary>
        /// Footer HTML tag name
        /// </summary>
        public string FooterTag { get; protected set; } = "footer";

        /// <summary>
        /// Show the footer on a landscape screen?
        /// </summary>
        public bool ShowFooterOnLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the footer on a small landscape screen?
        /// </summary>
        public bool ShowFooterOnSmallLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the footer on a portrait screen?
        /// </summary>
        public bool ShowFooterOnPortrait { get; protected set; } = true;

        /// <summary>
        /// Show the footer on a portrait screen?
        /// </summary>
        public bool ShowFooterOnSmallPortrait { get; protected set; } = true;
    }
}
