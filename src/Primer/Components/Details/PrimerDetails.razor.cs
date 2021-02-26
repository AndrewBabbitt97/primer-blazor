using Microsoft.AspNetCore.Components;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The details component
    /// </summary>
    public partial class PrimerDetails : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The tag to render the component with
        /// </summary>
        public override string As { get; set; } = "details";

        /// <summary>
        /// The details type
        /// </summary>
        [Parameter]
        public PrimerDetailsType Type { get; set; } = PrimerDetailsType.Default;

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ClassGenerator.AddIf("details-overlay", () => Type == PrimerDetailsType.Default || Type == PrimerDetailsType.DarkOverlay)
                .AddIf("details-overlay-dark", () => Type == PrimerDetailsType.DarkOverlay)
                .AddIf("details-reset", () => Type == PrimerDetailsType.Reset);

            base.OnInitialized();
        }
    }
}
