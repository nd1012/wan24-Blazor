using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Sections;
using wan24.Blazor.Parameters;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Box
    /// </summary>
    public partial class Box : ParentComponentBase, IBoxParametersExt
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Box() : this("div") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected Box(in string tagName) : base() => TagName = tagName;

        /// <inheritdoc/>
        public override IParameters DefaultParameters => BoxParametersExt.Instance;

        /// <inheritdoc/>
        public override IParameters CurrentParameters => new BoxParametersExt(this);

        /// <inheritdoc/>
        public override IEnumerable<string> ObjectProperties => BoxParametersExt.Instance.ObjectProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> DesignProperties => BoxParametersExt.Instance.DesignProperties;

        /// <inheritdoc/>
        public override IEnumerable<string> AccessabilityProperties => BoxParametersExt.Instance.AccessabilityProperties;

        /// <summary>
        /// Use the section of the inheriting top component (do not render the child content - will be rendered from the inheriting top component within the section content)
        /// </summary>
        public virtual string? UseBoxSection { get; protected set; }

        /// <inheritdoc/>
        [Parameter]
        public virtual string TagName { get; set; }

        /// <summary>
        /// Render the content
        /// </summary>
        /// <returns>Content</returns>
        protected virtual RenderFragment RenderContent() => builder =>
        {
            builder.OpenElement(0, TagName);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            if (UseBoxSection is not null)
            {
                builder.OpenComponent<SectionOutlet>(2);
                builder.AddComponentParameter(3, nameof(SectionOutlet.SectionName), UseBoxSection);
                builder.CloseComponent();
            }
            else
            {
                builder.AddContent(4, ChildContent);
            }
            builder.CloseElement();
        };
    }
}
