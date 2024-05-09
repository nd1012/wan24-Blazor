using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Sections;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Chapter
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    public partial class Chapter() : Box(), IChapterParametersExt
    {
        /// <inheritdoc/>
        public override IParameters DefaultParameters => ChapterParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new ChapterParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => ChapterParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => ChapterParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => ChapterParametersExt.Instance.AccessabilityProperties;

        /// <summary>
        /// Parent chapter
        /// </summary>
        [CascadingParameter]
        public virtual Chapter? Parent { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string? HeaderText { get; set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual int Level { get; set; }

        /// <inheritdoc/>
        public override string TagName
        {
            get => $"h{(Level < 7 ? Level : 6)}";
            set => base.TagName = value;
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            if (Level < 1) Level = (Parent?.Level ?? 0) + 1;
            base.OnParametersSet();
        }

        /// <inheritdoc/>
        protected override RenderFragment RenderContent() => builder =>
        {
            if (!string.IsNullOrWhiteSpace(HeaderText))
            {
                builder.OpenElement(0, TagName);
                builder.AddMultipleAttributes(1, AdditionalAttributes);
                builder.AddContent(2, HeaderText);
                builder.CloseElement();
            }
            if (UseBoxSection is not null)
            {
                builder.OpenComponent<SectionOutlet>(3);
                builder.AddComponentParameter(4, nameof(SectionOutlet.SectionName), UseBoxSection);
                builder.CloseComponent();
            }
            else
            {
                builder.AddContent(5, ChildContent);
            }
        };
    }
}
