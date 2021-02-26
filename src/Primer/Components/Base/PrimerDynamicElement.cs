using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Primer.Components
{
    /// <summary>
    /// Renders an element dynamically
    /// </summary>
    public class PrimerDynamicElement : ComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The tag to use for the element
        /// </summary>
        [Parameter]
        public string Tag { get; set; }

        /// <summary>
        /// The attributes to add to the element
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Builds the elements render tree
        /// </summary>
        /// <param name="builder">The tree builder</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag);
            builder.AddMultipleAttributes(1, Attributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
