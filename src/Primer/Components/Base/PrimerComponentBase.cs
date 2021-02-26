using Microsoft.AspNetCore.Components;
using Primer.Utilities;

namespace Primer.Components.Base
{
    /// <summary>
    /// The common primer component
    /// </summary>
    public abstract class PrimerComponentBase : ComponentBase
    {
        /// <summary>
        /// The class generator for the component
        /// </summary>
        protected readonly ClassGenerator ClassGenerator = new ClassGenerator();

        /// <summary>
        /// Defines what the element should be rendered as
        /// </summary>
        [Parameter]
        public virtual string As { get; set; }

        /// <summary>
        /// Animations to apply to the component
        /// </summary>
        [Parameter]
        public PrimerAnimation Animation { get; set; } = PrimerAnimation.Component;

        /// <summary>
        /// Top borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder TopBorder { get; set; } = PrimerBorder.Component;

        /// <summary>
        /// Top border corners to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorderCorner TopBorderCorners { get; set; } = PrimerBorderCorner.Component;

        /// <summary>
        /// Right borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder RightBorder { get; set; } = PrimerBorder.Component;

        /// <summary>
        /// Right border corners to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorderCorner RightBorderCorners { get; set; } = PrimerBorderCorner.Component;

        /// <summary>
        /// Bottom borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder BottomBorder { get; set; } = PrimerBorder.Component;

        /// <summary>
        /// Bottom border corners to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorderCorner BottomBorderCorners { get; set; } = PrimerBorderCorner.Component;

        /// <summary>
        /// Left borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder LeftBorder { get; set; } = PrimerBorder.Component;

        /// <summary>
        /// Left border corners to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorderCorner LeftBorderCorners { get; set; } = PrimerBorderCorner.Component;

        /// <summary>
        /// Borders style to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorderStyle BorderStyle { get; set; } = PrimerBorderStyle.Component;

        /// <summary>
        /// X borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder XBorder { set { LeftBorder = value; RightBorder = value; } }

        /// <summary>
        /// Y borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder YBorder { set { TopBorder = value; BottomBorder = value; } }

        /// <summary>
        /// Borders to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorder AllBorders { set { TopBorder = value; RightBorder = value; BottomBorder = value; LeftBorder = value; } }

        /// <summary>
        /// Corners to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBorderCorner AllCorners { set { TopBorderCorners = value; RightBorderCorners = value; BottomBorderCorners = value; LeftBorderCorners = value; } }

        /// <summary>
        /// Box shadow to apply to the component
        /// </summary>
        [Parameter]
        public PrimerBoxShadow BoxShadow { get; set; } = PrimerBoxShadow.Component;

        /// <summary>
        /// Text color to apply to the component
        /// </summary>
        [Parameter]
        public PrimerColor TextColor { get; set; } = PrimerColor.Component;

        /// <summary>
        /// Icon color to apply to the component
        /// </summary>
        [Parameter]
        public PrimerColor IconColor { get; set; } = PrimerColor.Component;

        /// <summary>
        /// Background color to apply to the component
        /// </summary>
        [Parameter]
        public PrimerColor BackgroundColor { get; set; } = PrimerColor.Component;

        /// <summary>
        /// Border color to apply to the component
        /// </summary>
        [Parameter]
        public PrimerColor BorderColor { get; set; } = PrimerColor.Component;

        /// <summary>
        /// If the component is visible
        /// </summary>
        [Parameter]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Occurs when the component is initialized
        /// </summary>
        protected override void OnInitialized()
        {
            //Animations
            ClassGenerator.AddIf("anim-fade-in", () => Animation.HasFlag(PrimerAnimation.FadeIn))
                .AddIf("anim-fade-out", () => Animation.HasFlag(PrimerAnimation.FadeOut))
                .AddIf("anim-fade-up", () => Animation.HasFlag(PrimerAnimation.FadeUp))
                .AddIf("anim-fade-down", () => Animation.HasFlag(PrimerAnimation.FadeDown))
                .AddIf("anim-scale-in", () => Animation.HasFlag(PrimerAnimation.ScaleIn))
                .AddIf("anim-grow-x", () => Animation.HasFlag(PrimerAnimation.GrowX))
                .AddIf("anim-pulse", () => Animation.HasFlag(PrimerAnimation.Pulse))
                .AddIf("hover-grow", () => Animation.HasFlag(PrimerAnimation.HoverGrow));

            //Borders
            ClassGenerator.AddIf("border-left", () => LeftBorder == PrimerBorder.Default)
                .AddIf("border-top", () => TopBorder == PrimerBorder.Default)
                .AddIf("border-bottom", () => BottomBorder == PrimerBorder.Default)
                .AddIf("border-right", () => RightBorder == PrimerBorder.Default)
                .AddIf("border-top-0", () => TopBorder == PrimerBorder.None)
                .AddIf("border-right-0", () => RightBorder == PrimerBorder.None)
                .AddIf("border-bottom-0", () => BottomBorder == PrimerBorder.None)
                .AddIf("border-left-0", () => LeftBorder == PrimerBorder.None)
                .AddIf("border-dashed", () => BorderStyle == PrimerBorderStyle.Dashed)
                .AddIf("circle", () => LeftBorderCorners == PrimerBorderCorner.Circle && TopBorderCorners == PrimerBorderCorner.Circle &&
                                       BottomBorderCorners == PrimerBorderCorner.Circle && RightBorderCorners == PrimerBorderCorner.Circle)
                .AddIf("rounded-top-0", () => TopBorderCorners == PrimerBorderCorner.Rounded0)
                .AddIf("rounded-right-0", () => RightBorderCorners == PrimerBorderCorner.Rounded0)
                .AddIf("rounded-bottom-0", () => BottomBorderCorners == PrimerBorderCorner.Rounded0)
                .AddIf("rounded-left-0", () => LeftBorderCorners == PrimerBorderCorner.Rounded0)
                .AddIf("rounded-top-1", () => TopBorderCorners == PrimerBorderCorner.Rounded1)
                .AddIf("rounded-right-1", () => RightBorderCorners == PrimerBorderCorner.Rounded1)
                .AddIf("rounded-bottom-1", () => BottomBorderCorners == PrimerBorderCorner.Rounded1)
                .AddIf("rounded-left-1", () => LeftBorderCorners == PrimerBorderCorner.Rounded1)
                .AddIf("rounded-top-2", () => TopBorderCorners == PrimerBorderCorner.Rounded2)
                .AddIf("rounded-right-2", () => RightBorderCorners == PrimerBorderCorner.Rounded2)
                .AddIf("rounded-bottom-2", () => BottomBorderCorners == PrimerBorderCorner.Rounded2)
                .AddIf("rounded-left-2", () => LeftBorderCorners == PrimerBorderCorner.Rounded2)
                .AddIf("rounded-top-3", () => TopBorderCorners == PrimerBorderCorner.Rounded3)
                .AddIf("rounded-right-3", () => RightBorderCorners == PrimerBorderCorner.Rounded3)
                .AddIf("rounded-bottom-3", () => BottomBorderCorners == PrimerBorderCorner.Rounded3)
                .AddIf("rounded-left-3", () => LeftBorderCorners == PrimerBorderCorner.Rounded3)
                .AddIf("border-sm-left", () => LeftBorder == PrimerBorder.ResponsiveAddAtSmallBreakpoint)
                .AddIf("border-md-left", () => LeftBorder == PrimerBorder.ResponsiveAddAtMediumBreakpoint)
                .AddIf("border-lg-left", () => LeftBorder == PrimerBorder.ResponsiveAddAtLargeBreakpoint)
                .AddIf("border-xl-left", () => LeftBorder == PrimerBorder.ResponsiveAddAtExtraLargeBreakpoint)
                .AddIf("border-sm-top", () => TopBorder == PrimerBorder.ResponsiveAddAtSmallBreakpoint)
                .AddIf("border-md-top", () => TopBorder == PrimerBorder.ResponsiveAddAtMediumBreakpoint)
                .AddIf("border-lg-top", () => TopBorder == PrimerBorder.ResponsiveAddAtLargeBreakpoint)
                .AddIf("border-xl-top", () => TopBorder == PrimerBorder.ResponsiveAddAtExtraLargeBreakpoint)
                .AddIf("border-sm-bottom", () => BottomBorder == PrimerBorder.ResponsiveAddAtSmallBreakpoint)
                .AddIf("border-md-bottom", () => BottomBorder == PrimerBorder.ResponsiveAddAtMediumBreakpoint)
                .AddIf("border-lg-bottom", () => BottomBorder == PrimerBorder.ResponsiveAddAtLargeBreakpoint)
                .AddIf("border-xl-bottom", () => BottomBorder == PrimerBorder.ResponsiveAddAtExtraLargeBreakpoint)
                .AddIf("border-sm-right", () => RightBorder == PrimerBorder.ResponsiveAddAtSmallBreakpoint)
                .AddIf("border-md-right", () => RightBorder == PrimerBorder.ResponsiveAddAtMediumBreakpoint)
                .AddIf("border-lg-right", () => RightBorder == PrimerBorder.ResponsiveAddAtLargeBreakpoint)
                .AddIf("border-xl-right", () => RightBorder == PrimerBorder.ResponsiveAddAtExtraLargeBreakpoint)
                .AddIf("border-sm-left-0", () => LeftBorder == PrimerBorder.ResponsiveRemoveAtSmallBreakpoint)
                .AddIf("border-md-left-0", () => LeftBorder == PrimerBorder.ResponsiveRemoveAtMediumBreakpoint)
                .AddIf("border-lg-left-0", () => LeftBorder == PrimerBorder.ResponsiveRemoveAtLargeBreakpoint)
                .AddIf("border-xl-left-0", () => LeftBorder == PrimerBorder.ResponsiveRemoveAtExtraLargeBreakpoint)
                .AddIf("border-sm-top-0", () => TopBorder == PrimerBorder.ResponsiveRemoveAtSmallBreakpoint)
                .AddIf("border-md-top-0", () => TopBorder == PrimerBorder.ResponsiveRemoveAtMediumBreakpoint)
                .AddIf("border-lg-top-0", () => TopBorder == PrimerBorder.ResponsiveRemoveAtLargeBreakpoint)
                .AddIf("border-xl-top-0", () => TopBorder == PrimerBorder.ResponsiveRemoveAtExtraLargeBreakpoint)
                .AddIf("border-sm-bottom-0", () => BottomBorder == PrimerBorder.ResponsiveRemoveAtSmallBreakpoint)
                .AddIf("border-md-bottom-0", () => BottomBorder == PrimerBorder.ResponsiveRemoveAtMediumBreakpoint)
                .AddIf("border-lg-bottom-0", () => BottomBorder == PrimerBorder.ResponsiveRemoveAtLargeBreakpoint)
                .AddIf("border-xl-bottom-0", () => BottomBorder == PrimerBorder.ResponsiveRemoveAtExtraLargeBreakpoint)
                .AddIf("border-sm-right-0", () => RightBorder == PrimerBorder.ResponsiveRemoveAtSmallBreakpoint)
                .AddIf("border-md-right-0", () => RightBorder == PrimerBorder.ResponsiveRemoveAtMediumBreakpoint)
                .AddIf("border-lg-right-0", () => RightBorder == PrimerBorder.ResponsiveRemoveAtLargeBreakpoint)
                .AddIf("border-xl-right-0", () => RightBorder == PrimerBorder.ResponsiveRemoveAtExtraLargeBreakpoint);

            //Box shadows
            ClassGenerator.AddIf("color-shadow-small", () => BoxShadow == PrimerBoxShadow.Small)
                .AddIf("color-shadow-medium", () => BoxShadow == PrimerBoxShadow.Medium)
                .AddIf("color-shadow-large", () => BoxShadow == PrimerBoxShadow.Large)
                .AddIf("color-shadow-extra-large", () => BoxShadow == PrimerBoxShadow.ExtraLarge)
                .AddIf("color-shadow-none", () => BoxShadow == PrimerBoxShadow.None);

            //Colors
            ClassGenerator.AddIf("color-text-primary", () => TextColor == PrimerColor.Primary)
                .AddIf("color-text-secondary", () => TextColor == PrimerColor.Secondary)
                .AddIf("color-text-tertiary", () => TextColor == PrimerColor.Tertiary)
                .AddIf("color-text-link", () => TextColor == PrimerColor.Link)
                .AddIf("color-text-success", () => TextColor == PrimerColor.Success)
                .AddIf("color-text-warning", () => TextColor == PrimerColor.Warning)
                .AddIf("color-text-danger", () => TextColor == PrimerColor.Danger)
                .AddIf("text-inherit", () => TextColor == PrimerColor.Inherit)
                .AddIf("color-icon-primary", () => IconColor == PrimerColor.Primary)
                .AddIf("color-icon-secondary", () => IconColor == PrimerColor.Secondary)
                .AddIf("color-icon-tertiary", () => IconColor == PrimerColor.Tertiary)
                .AddIf("color-icon-info", () => IconColor == PrimerColor.Info)
                .AddIf("color-icon-success", () => IconColor == PrimerColor.Success)
                .AddIf("color-icon-warning", () => IconColor == PrimerColor.Warning)
                .AddIf("color-icon-danger", () => IconColor == PrimerColor.Danger)
                .AddIf("color-bg-canvas", () => BackgroundColor == PrimerColor.Canvas)
                .AddIf("color-bg-primary", () => BackgroundColor == PrimerColor.Primary)
                .AddIf("color-bg-secondary", () => BackgroundColor == PrimerColor.Secondary)
                .AddIf("color-bg-tertiary", () => BackgroundColor == PrimerColor.Tertiary)
                .AddIf("color-bg-info", () => BackgroundColor == PrimerColor.Info)
                .AddIf("color-bg-success", () => BackgroundColor == PrimerColor.Success)
                .AddIf("color-bg-warning", () => BackgroundColor == PrimerColor.Warning)
                .AddIf("color-bg-danger", () => BackgroundColor == PrimerColor.Danger)
                .AddIf("color-bg-canvas-inverse", () => BackgroundColor == PrimerColor.CanvasInverse)
                .AddIf("color-text-inverse", () => TextColor == PrimerColor.Inverse)
                .AddIf("color-bg-info-inverse", () => BackgroundColor == PrimerColor.InfoInverse)
                .AddIf("color-bg-success-inverse", () => BackgroundColor == PrimerColor.SuccessInverse)
                .AddIf("color-bg-warning-inverse", () => BackgroundColor == PrimerColor.WarningInverse)
                .AddIf("color-bg-danger-inverse", () => BackgroundColor == PrimerColor.DangerInverse)
                .AddIf("color-border-primary", () => BorderColor == PrimerColor.Primary)
                .AddIf("color-border-secondary", () => BorderColor == PrimerColor.Secondary)
                .AddIf("color-border-tertiary", () => BorderColor == PrimerColor.Tertiary)
                .AddIf("color-border-info", () => BorderColor == PrimerColor.Info)
                .AddIf("color-border-success", () => BorderColor == PrimerColor.Success)
                .AddIf("color-border-warning", () => BorderColor == PrimerColor.Warning)
                .AddIf("color-border-danger", () => BorderColor == PrimerColor.Danger)
                .AddIf("color-border-inverse", () => BorderColor == PrimerColor.Inverse);
        }
    }
}
