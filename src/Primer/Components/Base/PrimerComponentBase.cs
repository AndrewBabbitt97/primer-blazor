using Microsoft.AspNetCore.Components;
using Primer.Utilities;

namespace Primer.Components.Base
{
    /// <summary>
    /// The common primer component
    /// </summary>
    public class PrimerComponentBase : ComponentBase
    {
        /// <summary>
        /// The class generator for the component
        /// </summary>
        protected readonly ClassGenerator ClassGenerator = new ClassGenerator();

        /// <summary>
        /// If the component is visible
        /// </summary>
        [Parameter]
        public bool Visible { get; set; } = true;
    }
}
