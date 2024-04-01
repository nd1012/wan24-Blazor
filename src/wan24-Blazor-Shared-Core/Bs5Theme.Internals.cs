using System.Text;
using wan24.Core;

namespace wan24.Blazor
{
    // Internals
    public partial record class Bs5Theme
    {
        /// <summary>
        /// Append the colors of this theme
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <returns>String builder</returns>
        protected virtual StringBuilder AppendColors(StringBuilder sb)
        {
            sb = AppendColorVariable(sb, "--bs-blue", Blue);
            sb = AppendColorVariable(sb, "--bs-indigo", Indigo);
            sb = AppendColorVariable(sb, "--bs-purple", Purple);
            sb = AppendColorVariable(sb, "--bs-pink", Pink);
            sb = AppendColorVariable(sb, "--bs-red", Red);
            sb = AppendColorVariable(sb, "--bs-orange", Orange);
            sb = AppendColorVariable(sb, "--bs-yellow", Yellow);
            sb = AppendColorVariable(sb, "--bs-green", Green);
            sb = AppendColorVariable(sb, "--bs-teal", Teal);
            sb = AppendColorVariable(sb, "--bs-cyan", Cyan);
            sb = AppendColorVariable(sb, "--bs-black", Black);
            sb = AppendColorVariable(sb, "--bs-white", White);
            sb = AppendColorVariable(sb, "--bs-gray", Gray);
            sb = AppendColorVariable(sb, "--bs-gray-dark", GrayDark);
            sb = AppendColorVariable(sb, "--bs-gray-100", Gray100);
            sb = AppendColorVariable(sb, "--bs-gray-200", Gray200);
            sb = AppendColorVariable(sb, "--bs-gray-300", Gray300);
            sb = AppendColorVariable(sb, "--bs-gray-400", Gray400);
            sb = AppendColorVariable(sb, "--bs-gray-500", Gray500);
            sb = AppendColorVariable(sb, "--bs-gray-600", Gray600);
            sb = AppendColorVariable(sb, "--bs-gray-700", Gray700);
            sb = AppendColorVariable(sb, "--bs-gray-800", Gray800);
            sb = AppendColorVariable(sb, "--bs-gray-900", Gray900);
            sb = AppendColorVariable(sb, "--bs-primary", Primary);
            sb = AppendColorVariable(sb, "--bs-secondary", Secondary);
            sb = AppendColorVariable(sb, "--bs-success", Success);
            sb = AppendColorVariable(sb, "--bs-danger", Danger);
            sb = AppendColorVariable(sb, "--bs-warning", Warning);
            sb = AppendColorVariable(sb, "--bs-info", Info);
            sb = AppendColorVariable(sb, "--bs-light", Light);
            sb = AppendColorVariable(sb, "--bs-dark", Dark);
            sb = AppendCssVariable(sb, "--bs-font-family-sans-serif", SansSerif);
            sb = AppendCssVariable(sb, "--bs-font-family-monospace", Monospace);
            sb = AppendCssVariable(sb, "--bs-gradient", Gradient);
            sb = AppendCssVariable(sb, "--bs-body-font-family", BodyFontFamily);
            sb = AppendCssVariable(sb, "--bs-body-font-size", BodyFontSize);
            sb = AppendCssVariable(sb, "--bs-body-font-weight", BodyFontWeight);
            sb = AppendCssVariable(sb, "--bs-body-line-height", BodyLineHeight);
            if ((Mode & BsThemeMode.Light) == BsThemeMode.Light)
            {
                sb = AppendColorVariable(sb, "--bs-body-color", BodyColor);
                sb = AppendColorVariable(sb, "--bs-body-bg", BodyBg);
                sb = AppendColorVariable(sb, "--bs-emphasis-color", Emphasis);
                sb = AppendColorVariable(sb, "--bs-secondary-color", SecondaryColor);
                sb = AppendColorVariable(sb, "--bs-secondary-bg", SecondaryBg);
                sb = AppendColorVariable(sb, "--bs-tertiary-color", TeritaryColor);
                sb = AppendColorVariable(sb, "--bs-tertiary-bg", TeritaryBg);
                sb = AppendColorVariable(sb, "--bs-heading-color", HeadingColor);
                sb = AppendColorVariable(sb, "--bs-link-color", LinkColor);
                sb = AppendColorVariable(sb, "--bs-link-hover-color", LinkHoverColor);
                sb = AppendColorVariable(sb, "--bs-code-color", CodeColor);
                sb = AppendColorVariable(sb, "--bs-highlight-color", HighlightColor);
                sb = AppendColorVariable(sb, "--bs-highlight-bg", HighlightBg);
                sb = AppendColorVariable(sb, "--bs-border-color", BorderColor);
                sb = AppendColorVariable(sb, "--bs-border-color-translucent", BorderTranslucent);
                sb = AppendColorVariable(sb, "--bs-form-valid-color", FormValidColor);
                sb = AppendColorVariable(sb, "--bs-form-valid-border-color", FormValidBorderColor);
                sb = AppendColorVariable(sb, "--bs-form-invalid-color", FormInvalidColor);
                sb = AppendColorVariable(sb, "--bs-form-invalid-border-color", FormInvalidBorderColor);
            }
            else
            {
                sb = AppendColorVariable(sb, "--bs-body-color", DarkBodyColor);
                sb = AppendColorVariable(sb, "--bs-body-bg", DarkBodyBg);
                sb = AppendColorVariable(sb, "--bs-emphasis-color", DarkEmphasis);
                sb = AppendColorVariable(sb, "--bs-secondary-color", DarkSecondaryColor);
                sb = AppendColorVariable(sb, "--bs-secondary-bg", DarkSecondaryBg);
                sb = AppendColorVariable(sb, "--bs-tertiary-color", DarkTeritaryColor);
                sb = AppendColorVariable(sb, "--bs-tertiary-bg", DarkTeritaryBg);
                sb = AppendColorVariable(sb, "--bs-heading-color", DarkHeadingColor);
                sb = AppendColorVariable(sb, "--bs-link-color", DarkLinkColor);
                sb = AppendColorVariable(sb, "--bs-link-hover-color", DarkLinkHoverColor);
                sb = AppendColorVariable(sb, "--bs-code-color", DarkCodeColor);
                sb = AppendColorVariable(sb, "--bs-highlight-color", DarkHighlightColor);
                sb = AppendColorVariable(sb, "--bs-highlight-bg", DarkHighlightBg);
                sb = AppendColorVariable(sb, "--bs-border-color", DarkBorderColor);
                sb = AppendColorVariable(sb, "--bs-border-color-translucent", DarkBorderTranslucent);
                sb = AppendColorVariable(sb, "--bs-form-valid-color", DarkFormValidColor);
                sb = AppendColorVariable(sb, "--bs-form-valid-border-color", DarkFormValidBorderColor);
                sb = AppendColorVariable(sb, "--bs-form-invalid-color", DarkFormInvalidColor);
                sb = AppendColorVariable(sb, "--bs-form-invalid-border-color", DarkFormInvalidBorderColor);
            }
            sb = AppendCssVariable(sb, "--bs-link-decoration", LinkDecoration);
            sb = AppendCssVariable(sb, "--bs-border-width", BorderWidth);
            sb = AppendCssVariable(sb, "--bs-border-style", BorderStyle);
            sb = AppendCssVariable(sb, "--bs-border-radius", BorderRadius);
            sb = AppendCssVariable(sb, "--bs-border-radius-sm", BorderRadiusSm);
            sb = AppendCssVariable(sb, "--bs-border-radius-lg", BorderRadiusLg);
            sb = AppendCssVariable(sb, "--bs-border-radius-xl", BorderRadiusXl);
            sb = AppendCssVariable(sb, "--bs-border-radius-xxl", BorderRadiusXxl);
            sb = AppendCssVariable(sb, "--bs-border-radius-2xl", BorderRadius2Xl);
            sb = AppendCssVariable(sb, "--bs-border-radius-pill", BorderRadiusPill);
            sb = AppendCssVariable(sb, "--bs-box-shadow", BoxShadow);
            sb = AppendCssVariable(sb, "--bs-box-shadow-sm", BoxShadowSm);
            sb = AppendCssVariable(sb, "--bs-box-shadow-lg", BoxShadowLg);
            sb = AppendCssVariable(sb, "--bs-box-shadow-inset", BoxShadowInset);
            sb = AppendCssVariable(sb, "--bs-focus-ring-width", FocusRingWidth);
            sb = AppendCssVariable(sb, "--bs-focus-ring-opacity", FocusRingOpacity);
            sb = AppendColorVariable(sb, "--bs-focus-ring-color", FocusRingColor);
            if ((Mode & BsThemeMode.Dark) == BsThemeMode.Dark)
            {
                sb = AppendColorVariable(sb, "--bs-primary-text-emphasis", DarkPrimaryTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-secondary-text-emphasis", DarkSecondaryTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-success-text-emphasis", DarkSuccessTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-info-text-emphasis", DarkInfoTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-warning-text-emphasis", DarkWarningTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-danger-text-emphasis", DarkDangerTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-light-text-emphasis", DarkLightTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-dark-text-emphasis", DarkDarkTextEmphasis);
                sb = AppendColorVariable(sb, "--bs-primary-bg-subtle", DarkPrimaryBgSubtle);
                sb = AppendColorVariable(sb, "--bs-secondary-bg-subtle", DarkSecondaryBgSubtle);
                sb = AppendColorVariable(sb, "--bs-success-bg-subtle", DarkSuccessBgSubtle);
                sb = AppendColorVariable(sb, "--bs-info-bg-subtle", DarkInfoBgSubtle);
                sb = AppendColorVariable(sb, "--bs-warning-bg-subtle", DarkWarningBgSubtle);
                sb = AppendColorVariable(sb, "--bs-danger-bg-subtle", DarkDangerBgSubtle);
                sb = AppendColorVariable(sb, "--bs-light-bg-subtle", DarkLightBgSubtle);
                sb = AppendColorVariable(sb, "--bs-dark-bg-subtle", DarkDarkBgSubtle);
                sb = AppendColorVariable(sb, "--bs-primary-border-subtle", DarkPrimaryBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-secondary-border-subtle", DarkSecondaryBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-success-border-subtle", DarkSuccessBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-info-border-subtle", DarkInfoBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-warning-border-subtle", DarkWarningBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-danger-border-subtle", DarkDangerBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-light-border-subtle", DarkLightBorderSubtle);
                sb = AppendColorVariable(sb, "--bs-dark-border-subtle", DarkDarkBorderSubtle);
            }
            return sb;
        }

        /// <summary>
        /// Append a color variable
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Bootstrap 5 CSS variable name</param>
        /// <param name="rgb">RGB</param>
        /// <param name="hasRgb">Has a RGB value, too?</param>
        /// <returns>String builder</returns>
        protected virtual StringBuilder AppendColorVariable(in StringBuilder sb, in string name, in Rgb? rgb, in bool hasRgb = true)
        {
            if (rgb.HasValue)
            {
                sb.Append('\t');
                sb.Append(name);
                sb.Append(':');
                sb.Append(rgb.Value.ToHtmlString());
                sb.Append(';');
                sb.AppendLine();
                if (hasRgb)
                {
                    sb.Append('\t');
                    sb.Append(name);
                    sb.Append("-rgb:");
                    sb.Append(rgb.Value.ToString());
                    sb.Append(';');
                    sb.AppendLine();
                }
            }
            return sb;
        }

        /// <summary>
        /// Append a color variable
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Bootstrap 5 CSS variable name</param>
        /// <param name="rgba">RGBA</param>
        /// <param name="hasRgb">Has a RGB value?, too?</param>
        /// <returns>String builder</returns>
        protected virtual StringBuilder AppendColorVariable(in StringBuilder sb, in string name, in RgbA? rgba, in bool hasRgb = true)
        {
            if (rgba.HasValue)
            {
                sb.Append('\t');
                sb.Append(name);
                sb.Append(rgba.Value.ToCssString());
                sb.Append(';');
                sb.AppendLine();
                if (hasRgb)
                {
                    sb.Append('\t');
                    sb.Append(name);
                    sb.Append("-rgb:");
                    sb.Append(rgba.Value.RGB.ToString());
                    sb.Append(';');
                    sb.AppendLine();
                }
            }
            return sb;
        }

        /// <summary>
        /// Append a color variable
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Bootstrap 5 CSS variable name</param>
        /// <param name="rgba">CSS RGBA</param>
        /// <returns>String builder</returns>
        protected virtual StringBuilder AppendColorVariable(in StringBuilder sb, in string name, in CssRgbA? rgba)
        {
            if (rgba is not null)
            {
                sb.Append('\t');
                sb.Append(name);
                sb.Append(rgba.ToString());
                sb.Append(';');
                sb.AppendLine();
            }
            return sb;
        }

        /// <summary>
        /// Append a CSS variable
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Bootstrap 5 CSS variable name</param>
        /// <param name="value">CSS value</param>
        /// <returns>String builder</returns>
        protected virtual StringBuilder AppendCssVariable(in StringBuilder sb, in string name, string? value)
        {
            if (value is not null)
            {
                sb.Append('\t');
                sb.Append(name);
                sb.Append(':');
                sb.Append(value);
                sb.Append(';');
                sb.AppendLine();
            }
            return sb;
        }
    }
}
