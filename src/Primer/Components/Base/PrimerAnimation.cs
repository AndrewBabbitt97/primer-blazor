using System;

namespace Primer.Components
{
    /// <summary>
    /// Primer animations
    /// </summary>
    [Flags]
    public enum PrimerAnimation
    {
        /// <summary>
        /// Use the components animation
        /// </summary>
        Component = 0,

        /// <summary>
        /// Fade in
        /// </summary>
        FadeIn = 1,

        /// <summary>
        /// Fade out
        /// </summary>
        FadeOut = 2,

        /// <summary>
        /// Fade up
        /// </summary>
        FadeUp = 4,

        /// <summary>
        /// Fade down
        /// </summary>
        FadeDown = 8,

        /// <summary>
        /// Scale in
        /// </summary>
        ScaleIn = 16,

        /// <summary>
        /// Grow x
        /// </summary>
        GrowX = 32,

        /// <summary>
        /// Pulse
        /// </summary>
        Pulse = 64,

        /// <summary>
        /// Hover grow
        /// </summary>
        HoverGrow = 128
    }
}
