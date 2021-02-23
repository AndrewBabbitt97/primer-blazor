using Microsoft.AspNetCore.Components;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The button group component
    /// </summary>
    public partial class PrimerButtonGroup : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
