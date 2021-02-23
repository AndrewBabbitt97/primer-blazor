using Microsoft.AspNetCore.Components;
using Primer.Components.Base;

namespace Primer.Components
{
    /// <summary>
    /// The flash component
    /// </summary>
    public partial class PrimerFlash : PrimerComponentBase
    {
        /// <summary>
        /// The child content of the element
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// If this flash should be spaced out
        /// </summary>
        [Parameter]
        public bool Messages { get; set; }

        /// <summary>
        /// The color of the flash
        /// </summary>
        [Parameter]
        public PrimerFlashColor Color { get; set; } = PrimerFlashColor.Default;

        /// <summary>
        /// If the flash is full width
        /// </summary>
        [Parameter]
        public bool Full { get; set; }

        /// <summary>
        /// If the flash is a banner
        /// </summary>
        [Parameter]
        public bool Banner { get; set; }

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ClassGenerator.Add("flash")
                .AddIf("flash-messages", () => Messages)
                .AddIf("flash-warn", () => Color == PrimerFlashColor.Warn)
                .AddIf("flash-error", () => Color == PrimerFlashColor.Error)
                .AddIf("flash-success", () => Color == PrimerFlashColor.Success)
                .AddIf("flash-full", () => Full)
                .AddIf("flash-banner", () => Banner);
        }
    }
}
