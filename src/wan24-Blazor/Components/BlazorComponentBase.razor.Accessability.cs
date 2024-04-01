using Microsoft.AspNetCore.Components;
using static wan24.Blazor.BlazorEnv;

namespace wan24.Blazor.Components
{
    // Accessability
    public abstract partial class BlazorComponentBase
    {
        /// <inheritdoc/>
        public virtual bool IsVisible => !(Hidden ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !ShowOnLandscape) ||
                    (IsPortrait && !ShowOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !ShowOnSmallLandscape) ||
                    (IsPortrait && !ShowOnSmallPortrait)
                )
            ));

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowOnLandscape { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowOnSmallLandscape { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowOnPortrait { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool ShowOnSmallPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool IsEnabled => !(Disabled ||
            (IsLargeScreen &&
                (
                    (IsLandscape && !EnableOnLandscape) ||
                    (IsPortrait && !EnableOnPortrait)
                )
            ) ||
            (IsSmallScreen &&
                (
                    (IsLandscape && !EnableOnSmallLandscape) ||
                    (IsPortrait && !EnableOnSmallPortrait)
                )
            ));

        /// <inheritdoc/>
        [Parameter]
        public virtual bool EnableOnLandscape { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool EnableOnSmallLandscape { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool EnableOnPortrait { get; set; } = true;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool EnableOnSmallPortrait { get; set; } = true;
    }
}
