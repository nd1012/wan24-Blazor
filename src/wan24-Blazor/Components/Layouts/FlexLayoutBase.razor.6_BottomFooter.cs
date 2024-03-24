using Microsoft.AspNetCore.Components;
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

        /// <summary>
        /// Bottom footer component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        public Type? BottomFooter { get; protected set; }

        /// <summary>
        /// Bottom footer parameters
        /// </summary>
        public Dictionary<string, object>? BottomFooterParameters { get; protected set; }

        /// <summary>
        /// Display the bottom footer
        /// </summary>
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

        /// <summary>
        /// Bottom footer HTML tag name
        /// </summary>
        public string BottomFooterTag { get; protected set; } = "footer";

        /// <summary>
        /// Show the bottom footer on a landscape screen?
        /// </summary>
        public bool ShowBottomFooterOnLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the bottom footer on a small landscape screen?
        /// </summary>
        public bool ShowBottomFooterOnSmallLandscape { get; protected set; } = true;

        /// <summary>
        /// Show the bottom footer on a portrait screen?
        /// </summary>
        public bool ShowBottomFooterOnPortrait { get; protected set; } = true;

        /// <summary>
        /// Show the bottom footer on a portrait screen?
        /// </summary>
        public bool ShowBottomFooterOnSmallPortrait { get; protected set; } = true;
    }
}
