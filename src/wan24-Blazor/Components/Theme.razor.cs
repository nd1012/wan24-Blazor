using Microsoft.AspNetCore.Components;
using wan24.Blazor.Parameters;
using wan24.Core;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Theme
    /// </summary>
    public partial class Theme : ComponentBase, IThemeParametersExt, IServeChildContent, IDisposable
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static Theme()
        {
            if (BlazorGateway.Instance is null) return;
            try
            {
                using DomElement html = BlazorGateway.Instance.GetElementsByTagNameAsync("html").AsTask().Result.FirstOrDefault()
                    ?? throw new InvalidProgramException("Missing HTML element");
                html.SetAttributeAsync("data-bs-theme", (BsTheme.Current.Mode & BsThemeMode.Light) == BsThemeMode.Light ? "light" : "dark").Wait();
            }
            catch (Exception ex)
            {
                ErrorHandling.Handle(new("Failed to initialize theming", ex));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Theme() : base() => Id = Helper.CreateElementId();

        /// <summary>
        /// Current theme
        /// </summary>
        public static Theme? Current { get; set; }

        /// <inheritdoc/>
        public virtual Dictionary<string, object> AllParameters => CurrentParameters.AllParameters;

        /// <inheritdoc/>
        public virtual IParameters DefaultParameters => ThemeParametersExt.Instance;

        /// <inheritdoc/>
        public virtual IParameters CurrentParameters => new ThemeParametersExt(this);

        /// <inheritdoc/>
        [Parameter]
        public virtual IParameters? ApplyParameters { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? Id { get; set; }

        /// <inheritdoc/>
        [Parameter, EditorRequired]
        public virtual IBsTheme Apply { get; set; } = null!;

        /// <inheritdoc/>
        [Parameter]
        public virtual bool NotCurrent { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual RenderFragment? ChildContent { get; set; }

        /// <inheritdoc/>
        public virtual void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
            => CurrentParameters.ApplyToExcluding(other, excludeProperties);

        /// <inheritdoc/>
        public virtual void ApplyToIncluding(in IParameters other, params string[] includeProperties)
            => CurrentParameters.ApplyToIncluding(other, includeProperties);

        /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            BlazorEnv.OnColorModeChanged += StateHasChanged;
            base.OnAfterRender(firstRender);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            Id ??= Helper.CreateSectionId();
            ApplyParameters?.ApplyToExcluding(this);
            base.OnParametersSet();
            if (!NotCurrent)
            {
                BsTheme.Current = Apply;
                Current = this;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            BlazorEnv.OnColorModeChanged -= StateHasChanged;
            if (!NotCurrent && Current == this) Current = null;
            GC.SuppressFinalize(this);
        }
    }
}
