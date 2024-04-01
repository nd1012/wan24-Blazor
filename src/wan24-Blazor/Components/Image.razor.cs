using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Image
    /// </summary>
    public partial class Image : Box, IImageParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Image() : base("img") => InlineFlex = true;

        /// <summary>
        /// Use the section of the inheriting top component (do not render the child content - will be rendered from the inheriting top component within the section content)
        /// </summary>
        public virtual string? UseImageSection { get; protected set; }

        /// <inheritdoc/>
        public override IParameters DefaultParameters => ImageParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new ImageParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => ImageParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => ImageParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ImageParametersExt.Instance.AccessabilityProperties;

        /// <inheritdoc/>
        [Parameter]
        public string? Src { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? SvgXml { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Size { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Width { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? Height { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public string? SvgColor { get; set; }

        /// <summary>
        /// Render SVG?
        /// </summary>
        [MemberNotNullWhen(returnValue: true, nameof(SvgXml))]
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
            base.OnParametersSet();
            UseBoxSection = Helper.CreateSectionId(ChildContent is not null || (Src is null && SvgXml is not null));
            if (UseBoxSection is not null && TagName == "img") TagName = "span";
            Title ??= Src;
        }
    }
}
