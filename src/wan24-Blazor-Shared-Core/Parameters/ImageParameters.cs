
namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Image parameters
    /// </summary>
    public record class ImageParameters : BoxParameters, IImageParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ImageParameters() : base() => TagName = "img";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public ImageParameters(in IImageParameters original) : base(original)
        {
            Src = original.Src;
            SvgXml = original.SvgXml;
            Size = original.Size;
            Width = original.Width;
            Height = original.Height;
            SvgColor = original.SvgColor;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = base.AllParameters;
                if (Src is not null) res[nameof(Src)] = Src;
                if (SvgXml is not null) res[nameof(SvgXml)] = SvgXml;
                if (Size is not null) res[nameof(Size)] = Size;
                if (Width is not null) res[nameof(Width)] = Width;
                if (Height is not null) res[nameof(Height)] = Height;
                if (SvgColor is not null) res[nameof(SvgColor)] = SvgColor;
                return res;
            }
        }

        /// <summary>
        /// Image parameter names
        /// </summary>
        public virtual IEnumerable<string> ImageParameterNames => [
            nameof(Src),
            nameof(SvgXml),
            nameof(Size),
            nameof(Width),
            nameof(Height),
            nameof(SvgColor)
            ];

        /// <inheritdoc/>
        public virtual string? Src { get; set; }

        /// <inheritdoc/>
        public virtual string? SvgXml { get; set; }

        /// <inheritdoc/>
        public virtual string? Size { get; set; }

        /// <inheritdoc/>
        public virtual string? Width { get; set; }

        /// <inheritdoc/>
        public virtual string? Height { get; set; }

        /// <inheritdoc/>
        public virtual string? SvgColor { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            base.ApplyToExcluding(other, excludeProperties);
            if (other is IImageParameters image)
            {
                if (Src is not null && !excludeProperties.Contains(nameof(Src))) image.Src = Src;
                if (SvgXml is not null && !excludeProperties.Contains(nameof(SvgXml))) image.SvgXml = SvgXml;
                if (Size is not null && !excludeProperties.Contains(nameof(Size))) image.Size = Size;
                if (Width is not null && !excludeProperties.Contains(nameof(Width))) image.Width = Width;
                if (Height is not null && !excludeProperties.Contains(nameof(Height))) image.Height = Height;
                if (SvgColor is not null && !excludeProperties.Contains(nameof(SvgColor))) image.SvgColor = SvgColor;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            base.ApplyToIncluding(other, includeProperties);
            if (other is IImageParameters image)
            {
                if (Src is not null && includeProperties.Contains(nameof(Src))) image.Src = Src;
                if (SvgXml is not null && includeProperties.Contains(nameof(SvgXml))) image.SvgXml = SvgXml;
                if (Size is not null && includeProperties.Contains(nameof(Size))) image.Size = Size;
                if (Width is not null && includeProperties.Contains(nameof(Width))) image.Width = Width;
                if (Height is not null && includeProperties.Contains(nameof(Height))) image.Height = Height;
                if (SvgColor is not null && includeProperties.Contains(nameof(SvgColor))) image.SvgColor = SvgColor;
            }
        }
    }
}
