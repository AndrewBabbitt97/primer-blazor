using Microsoft.AspNetCore.Components;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The box component
    /// </summary>
    public partial class PrimerBox : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ClassGenerator.Add("Box");

            base.OnInitialized();
        }
    }
}
