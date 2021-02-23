using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The flash close button component
    /// </summary>
    public partial class PrimerFlashCloseButton : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Event callback for OnClick
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ClassGenerator.Add("flash-close")
                .Add("js-flash-close");
        }
    }
}
