using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Sections;

namespace wan24.Blazor.Components
{
    /// <summary>
    /// Box
    /// </summary>
    public partial class Box : ParentComponentBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Box() : base() => TagName = "div";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagName">HTML tag name</param>
        protected Box(in string tagName) : base() => TagName = tagName;

        /// <summary>
        /// Use the section of the inheriting top component (do not render the child content - will be rendered from the inheriting top component within the section content)
        /// </summary>
        public virtual string? UseBoxSection { get; protected set; }

        /// <summary>
        /// HTML tag name
        /// </summary>
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
                builder.AddContent(2, ChildContent);
            }
            builder.CloseElement();
        };
    }
}
