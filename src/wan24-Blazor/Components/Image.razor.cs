using Microsoft.AspNetCore.Components;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Image
    /// </summary>
    public partial class Image : Box
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Image() : base("img") => InlineFlex = true;

        /// <summary>
        /// Use the section of the inheriting top component (do not render the child content - will be rendered from the inheriting top component within the section content)
        /// </summary>
        public virtual string? UseImageSection { get; protected set; }

        /// <summary>
        /// Source URI
        /// </summary>
        [Parameter]
        public string? Src { get; set; }

        /// <summary>
        /// SVG XML (ignored when <see cref="Src" /> is being used; see <see cref="Images" /> and  <see cref="Images.AsSvgXml(string)" />
        /// CAUTION: Will be used 1:1 in HTML!)
        /// </summary>
        [Parameter]
        public string? SvgXml { get; set; }

        /// <summary>
        /// Image size CSS
        /// </summary>
        [Parameter]
        public string? Size { get; set; }

        /// <summary>
        /// Image width HTML
        /// </summary>
        [Parameter]
        public string? Width { get; set; }

        /// <summary>
        /// Image size HTML
        /// </summary>
        [Parameter]
        public string? Height { get; set; }

        /// <summary>
        /// SVG CSS color (not a class name)
        /// </summary>
        [Parameter]
        public string? SvgColor { get; set; }

        /// <summary>
        /// Render SVG?
        /// </summary>
        public bool RenderSvg => UseImageSection is null && Src is null && SvgXml is not null;

        /// <inheritdoc/>
        public override string? FactoryStyle => RenderSvg && SvgColor is not null 
            ? $"{base.FactoryStyle};color:{SvgColor};{Size};" 
            : $"{base.FactoryStyle};{Size};";

        /// <inheritdoc/>
        public override Dictionary<string, object>? FactoryAttributes
        {
            get
            {
                Dictionary<string, object> res = base.FactoryAttributes ?? [];
                if (Src is not null) res["src"] = Src;
                if (Width is not null) res["width"] = Width;
                if (Height is not null) res["height"] = Height;
                return res;
            }
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            UseBoxSection = BlazorTools.CreateSectionId(ChildContent is not null || (Src is null && SvgXml is not null));
            if (UseBoxSection is not null && TagName == "img") TagName = "span";
            Title ??= Src;
            base.OnParametersSet();
        }
    }
}
