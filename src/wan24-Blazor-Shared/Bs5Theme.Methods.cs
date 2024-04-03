using System.Text;
using wan24.Core;

namespace wan24.Blazor
{
    // Methods
    public partial record class Bs5Theme
    {
        /// <summary>
        /// Auto-complete missing values where possible
        /// </summary>
        public virtual void AutoCompleteMissing()
        {

            // General
            White ??= Rgb.White;
            Black ??= Rgb.Black;

            // Gray
            if (Gray500.HasValue)
            {
                Gray100 ??= Gray500.Value.Shade(-0.4f);
                Gray200 ??= Gray500.Value.Shade(-0.3f);
                Gray300 ??= Gray500.Value.Shade(-0.2f);
                Gray400 ??= Gray500.Value.Shade(-0.1f);
                Gray600 ??= Gray500.Value.Shade(0.1f);
                Gray700 ??= Gray500.Value.Shade(0.2f);
                Gray800 ??= Gray500.Value.Shade(0.3f);
                Gray900 ??= Gray500.Value.Shade(0.4f);
            }
            Gray ??= Gray100;
            GrayDark ??= Gray800;

            // Dark mode
            DarkPrimaryTextEmphasis ??= Primary?.Tint(0.4f);
            DarkSecondaryTextEmphasis ??= Secondary?.Tint(0.4f);
            DarkSuccessTextEmphasis ??= Success?.Tint(0.4f);
            DarkInfoTextEmphasis ??= Info?.Tint(0.4f);
            DarkWarningTextEmphasis ??= Warning?.Tint(0.4f);
            DarkDangerTextEmphasis ??= Danger?.Tint(0.4f);
            DarkLightTextEmphasis ??= Light?.Tint(0.4f);
            DarkDarkTextEmphasis ??= Dark?.Tint(0.4f);

            DarkPrimaryBgSubtle ??= Primary?.Shade(0.8f);
            DarkSecondaryBgSubtle ??= Secondary?.Shade(0.8f);
            DarkSuccessBgSubtle ??= Success?.Shade(0.8f);
            DarkInfoBgSubtle ??= Info?.Shade(0.8f);
            DarkWarningBgSubtle ??= Warning?.Shade(0.8f);
            DarkDangerBgSubtle ??= Danger?.Shade(0.8f);
            DarkLightBgSubtle ??= Light?.Shade(0.8f);
            DarkDarkBgSubtle ??= Dark?.Shade(0.8f);

            DarkPrimaryBorderSubtle ??= Primary?.Shade(0.4f);
            DarkSecondaryBorderSubtle ??= Secondary?.Shade(0.4f);
            DarkSuccessBorderSubtle ??= Success?.Shade(0.4f);
            DarkInfoBorderSubtle ??= Info?.Shade(0.4f);
            DarkWarningBorderSubtle ??= Warning?.Shade(0.4f);
            DarkDangerBorderSubtle ??= Danger?.Shade(0.4f);
            DarkLightBorderSubtle ??= Gray700;
            DarkDarkBorderSubtle ??= Gray800;

            DarkBodyColor ??= Gray300;
            DarkBodyBg ??= Gray900;
            DarkSecondaryColor ??= DarkBodyColor.HasValue
                ? new RgbA(DarkBodyColor.Value, 0.75f)
                : default;
            DarkSecondaryBg ??= Gray800;
            DarkTeritaryColor ??= DarkBodyColor.HasValue
                ? new RgbA(DarkBodyColor.Value, 0.5f)
                : default;
            DarkTeritaryBg ??= Gray800.HasValue && Gray900.HasValue
                ? Gray800.Value.Mix(Gray900.Value)
                : default;
            DarkEmphasis ??= White;
            DarkBorderColor ??= Gray700;
            DarkBorderTranslucent ??= new RgbA(White.Value, 0.15f);
            DarkHeadingColor ??= CssRgbA.Inherited;
            DarkLinkColor ??= Primary?.Shade(0.4f);
            DarkLinkHoverColor ??= DarkLinkColor.HasValue
                ? Hsb.FromRgb(DarkLinkColor.Value).AddHue(0.2f)
                : default;
            if (!DarkCodeColor.HasValue && CodeColor.HasValue)
                DarkCodeColor = CodeColor.Value;

            DarkFormValidColor ??= Green.HasValue
                ? Green.Value.Shade(-0.2f)
                : default;
            DarkFormValidBorderColor ??= Green.HasValue
                ? Green.Value.Shade(-0.2f)
                : default;
            DarkFormInvalidColor ??= Red.HasValue
                ? Red.Value.Shade(-0.2f)
                : default;
            DarkFormInvalidBorderColor ??= Red.HasValue
                ? Red.Value.Shade(-0.2f)
                : default;

        }

        /// <summary>
        /// Merge another theme (will skip <see langword="null"/> values of the other theme)
        /// </summary>
        /// <param name="other">Other theme</param>
        /// <returns>This</returns>
        public virtual Bs5Theme Merge(in Bs5Theme other)
        {
            if (other.Blue.HasValue) Blue = other.Blue;
            if (other.Indigo.HasValue) Indigo = other.Indigo;
            if (other.Purple.HasValue) Purple = other.Purple;
            if (other.Pink.HasValue) Pink = other.Pink;
            if (other.Red.HasValue) Red = other.Red;
            if (other.Orange.HasValue) Orange = other.Orange;
            if (other.Yellow.HasValue) Yellow = other.Yellow;
            if (other.Green.HasValue) Green = other.Green;
            if (other.Teal.HasValue) Teal = other.Teal;
            if (other.Cyan.HasValue) Cyan = other.Cyan;
            if (other.Black.HasValue) Black = other.Black;
            if (other.White.HasValue) White = other.White;
            if (other.Gray.HasValue) Gray = other.Gray;
            if (other.GrayDark.HasValue) GrayDark = other.GrayDark;
            if (other.Gray100.HasValue) Gray100 = other.Gray100;
            if (other.Gray200.HasValue) Gray200 = other.Gray200;
            if (other.Gray300.HasValue) Gray300 = other.Gray300;
            if (other.Gray400.HasValue) Gray400 = other.Gray400;
            if (other.Gray500.HasValue) Gray500 = other.Gray500;
            if (other.Gray600.HasValue) Gray600 = other.Gray600;
            if (other.Gray700.HasValue) Gray700 = other.Gray700;
            if (other.Gray800.HasValue) Gray800 = other.Gray800;
            if (other.Gray900.HasValue) Gray900 = other.Gray900;
            if (other.Primary.HasValue) Primary = other.Primary;
            if (other.Secondary.HasValue) Secondary = other.Secondary;
            if (other.Success.HasValue) Success = other.Success;
            if (other.Danger.HasValue) Danger = other.Danger;
            if (other.Warning.HasValue) Warning = other.Warning;
            if (other.Info.HasValue) Info = other.Info;
            if (other.Light.HasValue) Light = other.Light;
            if (other.Dark.HasValue) Dark = other.Dark;
            if (other.Body.HasValue) Body = other.Body;
            if (other.SansSerif is not null) SansSerif = other.SansSerif;
            if (other.Monospace is not null) Monospace = other.Monospace;
            if (other.Gradient is not null) Gradient = other.Gradient;
            if (other.BodyFontFamily is not null) BodyFontFamily = other.BodyFontFamily;
            if (other.BodyFontSize is not null) BodyFontSize = other.BodyFontSize;
            if (other.BodyFontWeight is not null) BodyFontWeight = other.BodyFontWeight;
            if (other.BodyLineHeight is not null) BodyLineHeight = other.BodyLineHeight;
            if (other.BodyColor.HasValue) BodyColor = other.BodyColor;
            if (other.BodyBg.HasValue) BodyBg = other.BodyBg;
            if (other.Emphasis.HasValue) Emphasis = other.Emphasis;
            if (other.SecondaryColor.HasValue) SecondaryColor = other.SecondaryColor;
            if (other.SecondaryBg.HasValue) SecondaryBg = other.SecondaryBg;
            if (other.TeritaryColor.HasValue) TeritaryColor = other.TeritaryColor;
            if (other.TeritaryBg.HasValue) TeritaryBg = other.TeritaryBg;
            if (other.HeadingColor is not null) HeadingColor = other.HeadingColor;
            if (other.LinkColor.HasValue) LinkColor = other.LinkColor;
            if (other.LinkDecoration is not null) LinkDecoration = other.LinkDecoration;
            if (other.LinkHoverColor.HasValue) LinkHoverColor = other.LinkHoverColor;
            if (other.CodeColor is not null) CodeColor = other.CodeColor;
            if (other.HighlightColor is not null) HighlightColor = other.HighlightColor;
            if (other.HighlightBg is not null) HighlightBg = other.HighlightBg;
            if (other.BorderWidth is not null) BorderWidth = other.BorderWidth;
            if (other.BorderStyle is not null) BorderStyle = other.BorderStyle;
            if (other.BorderColor is not null) BorderColor = other.BorderColor;
            if (other.BorderTranslucent is not null) BorderTranslucent = other.BorderTranslucent;
            if (other.BorderRadius is not null) BorderRadius = other.BorderRadius;
            if (other.BorderRadiusSm is not null) BorderRadiusSm = other.BorderRadiusSm;
            if (other.BorderRadiusLg is not null) BorderRadiusLg = other.BorderRadiusLg;
            if (other.BorderRadiusXl is not null) BorderRadiusXl = other.BorderRadiusXl;
            if (other.BorderRadiusXxl is not null) BorderRadiusXxl = other.BorderRadiusXxl;
            if (other.BorderRadius2Xl is not null) BorderRadius2Xl = other.BorderRadius2Xl;
            if (other.BorderRadiusPill is not null) BorderRadiusPill = other.BorderRadiusPill;
            if (other.BoxShadow is not null) BoxShadow = other.BoxShadow;
            if (other.BoxShadowSm is not null) BoxShadowSm = other.BoxShadowSm;
            if (other.BoxShadowLg is not null) BoxShadowLg = other.BoxShadowLg;
            if (other.BoxShadowInset is not null) BoxShadowInset = other.BoxShadowInset;
            if (other.FocusRingWidth is not null) FocusRingWidth = other.FocusRingWidth;
            if (other.FocusRingOpacity is not null) FocusRingOpacity = other.FocusRingOpacity;
            if (other.FocusRingColor is not null) FocusRingColor = other.FocusRingColor;
            if (other.FormValidColor is not null) FormValidColor = other.FormValidColor;
            if (other.FormValidBorderColor is not null) FormValidBorderColor = other.FormValidBorderColor;
            if (other.FormInvalidColor is not null) FormInvalidColor = other.FormInvalidColor;
            if (other.FormInvalidBorderColor is not null) FormInvalidBorderColor = other.FormInvalidBorderColor;
            // Dark mode
            if (other.DarkBodyColor.HasValue) DarkBodyColor = other.DarkBodyColor.Value;
            if (other.DarkBodyBg.HasValue) DarkBodyBg = other.DarkBodyBg.Value;
            if (other.DarkEmphasis.HasValue) DarkEmphasis = other.DarkEmphasis.Value;
            if (other.DarkSecondaryColor.HasValue) DarkSecondaryColor = other.DarkSecondaryColor.Value;
            if (other.DarkSecondaryBg.HasValue) DarkSecondaryBg = other.DarkSecondaryBg.Value;
            if (other.DarkTeritaryColor.HasValue) DarkTeritaryColor = other.DarkTeritaryColor.Value;
            if (other.DarkTeritaryBg.HasValue) DarkTeritaryBg = other.DarkTeritaryBg.Value;
            if (other.DarkPrimaryTextEmphasis is not null) DarkPrimaryTextEmphasis = other.DarkPrimaryTextEmphasis;
            if (other.DarkSecondaryTextEmphasis is not null) DarkSecondaryTextEmphasis = other.DarkSecondaryTextEmphasis;
            if (other.DarkSuccessTextEmphasis is not null) DarkSuccessTextEmphasis = other.DarkSuccessTextEmphasis;
            if (other.DarkInfoTextEmphasis is not null) DarkInfoTextEmphasis = other.DarkInfoTextEmphasis;
            if (other.DarkWarningTextEmphasis is not null) DarkWarningTextEmphasis = other.DarkWarningTextEmphasis;
            if (other.DarkDangerTextEmphasis is not null) DarkDangerTextEmphasis = other.DarkDangerTextEmphasis;
            if (other.DarkLightTextEmphasis is not null) DarkLightTextEmphasis = other.DarkLightTextEmphasis;
            if (other.DarkDarkTextEmphasis is not null) DarkDarkTextEmphasis = other.DarkDarkTextEmphasis;
            if (other.DarkPrimaryBgSubtle is not null) DarkPrimaryBgSubtle = other.DarkPrimaryBgSubtle;
            if (other.DarkSecondaryBgSubtle is not null) DarkSecondaryBgSubtle = other.DarkSecondaryBgSubtle;
            if (other.DarkSuccessBgSubtle is not null) DarkSuccessBgSubtle = other.DarkSuccessBgSubtle;
            if (other.DarkInfoBgSubtle is not null) DarkInfoBgSubtle = other.DarkInfoBgSubtle;
            if (other.DarkWarningBgSubtle is not null) DarkWarningBgSubtle = other.DarkWarningBgSubtle;
            if (other.DarkDangerBgSubtle is not null) DarkDangerBgSubtle = other.DarkDangerBgSubtle;
            if (other.DarkLightBgSubtle is not null) DarkLightBgSubtle = other.DarkLightBgSubtle;
            if (other.DarkDarkBgSubtle is not null) DarkDarkBgSubtle = other.DarkDarkBgSubtle;
            if (other.DarkPrimaryBorderSubtle is not null) DarkPrimaryBorderSubtle = other.DarkPrimaryBorderSubtle;
            if (other.DarkSecondaryBorderSubtle is not null) DarkSecondaryBorderSubtle = other.DarkSecondaryBorderSubtle;
            if (other.DarkSuccessBorderSubtle is not null) DarkSuccessBorderSubtle = other.DarkSuccessBorderSubtle;
            if (other.DarkInfoBorderSubtle is not null) DarkInfoBorderSubtle = other.DarkInfoBorderSubtle;
            if (other.DarkWarningBorderSubtle is not null) DarkWarningBorderSubtle = other.DarkWarningBorderSubtle;
            if (other.DarkDangerBorderSubtle is not null) DarkDangerBorderSubtle = other.DarkDangerBorderSubtle;
            if (other.DarkLightBorderSubtle is not null) DarkLightBorderSubtle = other.DarkLightBorderSubtle;
            if (other.DarkDarkBorderSubtle is not null) DarkDarkBorderSubtle = other.DarkDarkBorderSubtle;
            if (other.DarkHeadingColor is not null) DarkHeadingColor = other.DarkHeadingColor;
            if (other.DarkLinkColor.HasValue) DarkLinkColor = other.DarkLinkColor.Value;
            if (other.DarkLinkHoverColor.HasValue) DarkLinkHoverColor = other.DarkLinkHoverColor.Value;
            if (other.CodeColor is not null) CodeColor = other.CodeColor;
            if (other.DarkHighlightColor is not null) DarkHighlightColor = other.DarkHighlightColor;
            if (other.DarkHighlightBg is not null) DarkHighlightBg = other.DarkHighlightBg;
            if (other.DarkBorderColor is not null) DarkBorderColor = other.DarkBorderColor;
            if (other.DarkBorderTranslucent is not null) DarkBorderTranslucent = other.DarkBorderTranslucent;
            if (other.DarkFormValidColor is not null) DarkFormValidColor = other.DarkFormValidColor;
            if (other.DarkFormValidBorderColor is not null) DarkFormValidBorderColor = other.DarkFormValidBorderColor;
            if (other.DarkFormInvalidColor is not null) DarkFormInvalidColor = other.DarkFormInvalidColor;
            if (other.DarkFormInvalidBorderColor is not null) DarkFormInvalidBorderColor = other.DarkFormInvalidBorderColor;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder sb = new(":root {");
            sb.AppendLine();
            sb = AppendColors(sb);
            sb.Append('}');
            sb.AppendLine();
            if (AdditionalCss is string css) sb.AppendLine(css);
            if ((Mode & BsThemeMode.Dark) == BsThemeMode.Dark && AdditionalDarkCss is string darkCss)
                sb.AppendLine(darkCss);
            return sb.ToString();
        }
    }
}
