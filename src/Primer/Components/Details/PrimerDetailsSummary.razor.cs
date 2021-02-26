using Microsoft.AspNetCore.Components;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The details summary component
    /// </summary>
    public partial class PrimerDetailsSummary : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The tag to render the component with
        /// </summary>
        public override string As { get; set; } = "summary";

        /// <summary>
        /// The details summary type
        /// </summary>
        [Parameter]
        public PrimerDetailsSummaryType Type { get; set; } = PrimerDetailsSummaryType.Default;

        /// <summary>
        /// The details summary size
        /// </summary>
        [Parameter]
        public PrimerDetailsSummarySize Size { get; set; } = PrimerDetailsSummarySize.Normal;

        /// <summary>
        /// If the details summary should be displayed as a block
        /// </summary>
        [Parameter]
        public bool Block { get; set; } = false;

        /// <summary>
        /// If the details summary is a link
        /// </summary>
        [Parameter]
        public bool Link { get; set; } = false;

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ClassGenerator.AddIf("btn", () => Link == false && Type != PrimerDetailsSummaryType.None)
                .AddIf("btn-link", () => Link)
                .AddIf("btn-primary", () => Type == PrimerDetailsSummaryType.Primary)
                .AddIf("btn-outline", () => Type == PrimerDetailsSummaryType.Outline)
                .AddIf("btn-danger", () => Type == PrimerDetailsSummaryType.Danger)
                .AddIf("btn-octicon", () => Type == PrimerDetailsSummaryType.Icon)
                .AddIf("btn-sm", () => Size == PrimerDetailsSummarySize.Small)
                .AddIf("btn-large", () => Size == PrimerDetailsSummarySize.Large)
                .AddIf("btn-block", () => Block);

            base.OnInitialized();
        }
    }
}
