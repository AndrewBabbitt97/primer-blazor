using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The button component
    /// </summary>
    public partial class PrimerButton : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The tag to render the component with
        /// </summary>
        public override string As { get; set; } = "button";

        /// <summary>
        /// Event callback for OnClick
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// The button type
        /// </summary>
        [Parameter]
        public PrimerButtonType Type { get; set; } = PrimerButtonType.Default;

        /// <summary>
        /// If the button is selected
        /// </summary>
        [Parameter]
        public bool Selected { get; set; } = false;

        /// <summary>
        /// If the button is disabled
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The button size
        /// </summary>
        [Parameter]
        public PrimerButtonSize Size { get; set; } = PrimerButtonSize.Normal;

        /// <summary>
        /// If the button should be displayed as a block
        /// </summary>
        [Parameter]
        public bool Block { get; set; } = false;

        /// <summary>
        /// If the button is a link
        /// </summary>
        [Parameter]
        public bool Link { get; set; } = false;

        /// <summary>
        /// If the button is a part of a button group
        /// </summary>
        [Parameter]
        public bool ButtonGroupItem { get; set; } = false;

        /// <summary>
        /// If the button is a flash action
        /// </summary>
        [Parameter]
        public bool FlashAction { get; set; } = false;

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ClassGenerator.AddIf("btn", () => Link == false)
                .AddIf("btn-link", () => Link)
                .AddIf("btn-primary", () => Type == PrimerButtonType.Primary)
                .AddIf("btn-outline", () => Type == PrimerButtonType.Outline)
                .AddIf("btn-danger", () => Type == PrimerButtonType.Danger)
                .AddIf("btn-octicon", () => Type == PrimerButtonType.Icon)
                .AddIf("close-button", () => Type == PrimerButtonType.Close)
                .AddIf("btn-sm", () => Size == PrimerButtonSize.Small || FlashAction)
                .AddIf("btn-large", () => Size == PrimerButtonSize.Large)
                .AddIf("btn-block", () => Block)
                .AddIf("BtnGroup-item", () => ButtonGroupItem)
                .AddIf("flash-action", () => FlashAction);

            base.OnInitialized();
        }
    }
}
