using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Bootstrap 5 color theme
    /// </summary>
    public partial record class Bs5Theme : IBsTheme
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static Bs5Theme()
        {
            Default = new()
            {
                // Colors
                Blue = Rgb.ParseHtml("#007bff"),
                Indigo = Rgb.ParseHtml("#6610f2"),
                Purple = Rgb.ParseHtml("#6f42c1"),
                Pink = Rgb.ParseHtml("#e83e8c"),
                Red = Rgb.ParseHtml("#dc3545"),
                Orange = Rgb.ParseHtml("#fd7e14"),
                Yellow = Rgb.ParseHtml("#ffc107"),
                Green = Rgb.ParseHtml("#28a745"),
                Teal = Rgb.ParseHtml("#20c997"),
                Cyan = Rgb.ParseHtml("#17a2b8"),
                White = Rgb.ParseHtml("#fff"),
                Gray = Rgb.ParseHtml("#6c757d"),
                GrayDark = Rgb.ParseHtml("#343a40"),
                Gray100 = Rgb.ParseHtml("#f8f9fa"),
                Gray200 = Rgb.ParseHtml("#e9ecef"),
                Gray300 = Rgb.ParseHtml("#dee2e6"),
                Gray400 = Rgb.ParseHtml("#ced4da"),
                Gray500 = Rgb.ParseHtml("#adb5bd"),
                Gray600 = Rgb.ParseHtml("#6c757d"),
                Gray700 = Rgb.ParseHtml("#495057"),
                Gray800 = Rgb.ParseHtml("#343a40"),
                Gray900 = Rgb.ParseHtml("#212529"),
                // Theme colors
                Primary = Rgb.ParseHtml("#0d6efd"),
                Secondary = Rgb.ParseHtml("#6c757d"),
                Success = Rgb.ParseHtml("#198754"),
                Info = Rgb.ParseHtml("#0dcaf0"),
                Warning = Rgb.ParseHtml("#ffc107"),
                Danger = Rgb.ParseHtml("#dc3545"),
                Light = Rgb.ParseHtml("#f8f9fa"),
                Dark = Rgb.ParseHtml("#212529"),
                // Fonts
                SansSerif = "-apple-system, BlinkMacSystemFont, \"Segoe UI\", Roboto, \"Helvetica Neue\", Arial, sans-serif, \"Apple Color Emoji\", \"Segoe UI Emoji\", \"Segoe UI Symbol\"",
                Monospace = "SFMono-Regular, Menlo, Monaco, Consolas, \"Liberation Mono\", \"Courier New\", monospace",
                // Body
                BodyFontFamily = "var(--bs-font-sans-serif)",
                BodyFontSize = "1rem",
                BodyFontWeight = "400",
                BodyLineHeight = "1.5",
                BodyColor = Rgb.ParseHtml("#212529"),
                BodyBg = Rgb.ParseHtml("#fff"),
                // Border
                BorderWidth = "1px",
                BorderStyle = "solid",
                BorderColor = Rgb.ParseHtml("#dee2e6"),
                BorderTranslucent = RgbA.ParseCss("rgba(0, 0, 0, 0.175)"),
                BorderRadius = "0.375rem",
                BorderRadiusSm = "0.25rem",
                BorderRadiusLg = "0.5rem",
                BorderRadiusXl = "1rem",
                BorderRadiusXxl = "2rem",
                BorderRadius2Xl = "var(--bs-border-radius-xxl)",
                BorderRadiusPill = "50rem",
                // Others
                Gradient = "linear-gradient(180deg, rgba(255, 255, 255, 0.15), rgba(255, 255, 255, 0))",
                Emphasis = Rgb.ParseHtml("#000"),
                SecondaryColor = RgbA.ParseCss("rgba(33, 37, 41, 0.75)"),
                SecondaryBg = Rgb.ParseHtml("#e9ecef"),
                TeritaryColor = RgbA.ParseCss("rgba(33, 37, 41, 0.5)"),
                TeritaryBg = Rgb.ParseHtml("#f8f9fa"),
                HeadingColor = CssRgbA.Inherited,
                LinkColor = Rgb.ParseHtml("#0d6efd"),
                LinkDecoration = "underline",
                LinkHoverColor = Rgb.ParseHtml("#0a58ca"),
                CodeColor = Rgb.ParseHtml("#d63384"),
                HighlightColor = Rgb.ParseHtml("#212529"),
                HighlightBg = Rgb.ParseHtml("#fff3cd"),
                BoxShadow = "0 0.5rem 1rem rgba(0, 0, 0, 0.15)",
                BoxShadowSm = "0 0.125rem 0.25rem rgba(0, 0, 0, 0.075)",
                BoxShadowLg = "0 1rem 3rem rgba(0, 0, 0, 0.175)",
                BoxShadowInset = "inset 0 1px 2px rgba(0, 0, 0, 0.075)",
                FocusRingWidth = "0.25rem",
                FocusRingOpacity = "0.25",
                FocusRingColor = RgbA.ParseCss("rgba(13, 110, 253, 0.25)"),
                FormValidColor = Rgb.ParseHtml("#198754"),
                FormValidBorderColor = Rgb.ParseHtml("#198754"),
                FormInvalidColor = Rgb.ParseHtml("#dc3545"),
                FormInvalidBorderColor = Rgb.ParseHtml("#dc3545"),
                // Dark
                DarkBodyColor = Rgb.ParseHtml("#dee2e6"),
                DarkBodyBg = Rgb.ParseHtml("#212529"),
                DarkEmphasis = Rgb.ParseHtml("#fff"),
                DarkSecondaryColor = RgbA.ParseCss("rgba(222, 226, 230, 0.75)"),
                DarkSecondaryBg = Rgb.ParseHtml("#343a40"),
                DarkTeritaryColor = RgbA.ParseCss("rgba(222, 226, 230, 0.5)"),
                DarkTeritaryBg = Rgb.ParseHtml("#2b3035"),
                DarkPrimaryTextEmphasis = Rgb.ParseHtml("#6ea8fe"),
                DarkSecondaryTextEmphasis = Rgb.ParseHtml("#a7acb1"),
                DarkSuccessTextEmphasis = Rgb.ParseHtml("#75b798"),
                DarkInfoTextEmphasis = Rgb.ParseHtml("#6edff6"),
                DarkWarningTextEmphasis = Rgb.ParseHtml("#ffda6a"),
                DarkDangerTextEmphasis = Rgb.ParseHtml("#ea868f"),
                DarkLightTextEmphasis = Rgb.ParseHtml("#f8f9fa"),
                DarkDarkTextEmphasis = Rgb.ParseHtml("#dee2e6"),
                DarkPrimaryBgSubtle = Rgb.ParseHtml("#031633"),
                DarkSecondaryBgSubtle = Rgb.ParseHtml("#161719"),
                DarkSuccessBgSubtle = Rgb.ParseHtml("#051b11"),
                DarkInfoBgSubtle = Rgb.ParseHtml("#032830"),
                DarkWarningBgSubtle = Rgb.ParseHtml("#332701"),
                DarkDangerBgSubtle = Rgb.ParseHtml("#2c0b0e"),
                DarkLightBgSubtle = Rgb.ParseHtml("#343a40"),
                DarkDarkBgSubtle = Rgb.ParseHtml("#1a1d20"),
                DarkPrimaryBorderSubtle = Rgb.ParseHtml("#084298"),
                DarkSecondaryBorderSubtle = Rgb.ParseHtml("#41464b"),
                DarkSuccessBorderSubtle = Rgb.ParseHtml("#0f5132"),
                DarkInfoBorderSubtle = Rgb.ParseHtml("#087990"),
                DarkWarningBorderSubtle = Rgb.ParseHtml("#997404"),
                DarkDangerBorderSubtle = Rgb.ParseHtml("#842029"),
                DarkLightBorderSubtle = Rgb.ParseHtml("#495057"),
                DarkDarkBorderSubtle = Rgb.ParseHtml("#343a40"),
                DarkHeadingColor = CssRgbA.Inherited,
                DarkLinkColor = Rgb.ParseHtml("#6ea8fe"),
                DarkLinkHoverColor = Rgb.ParseHtml("#8bb9fe"),
                DarkCodeColor = Rgb.ParseHtml("#e685b5"),
                DarkHighlightColor = Rgb.ParseHtml("#dee2e6"),
                DarkHighlightBg = Rgb.ParseHtml("#664d03"),
                DarkBorderColor = Rgb.ParseHtml("#495057"),
                DarkBorderTranslucent = RgbA.ParseCss("rgba(255, 255, 255, 0.15)"),
                DarkFormValidColor = Rgb.ParseHtml("#75b798"),
                DarkFormInvalidBorderColor = Rgb.ParseHtml("#75b798"),
                DarkFormInvalidColor = Rgb.ParseHtml("#ea868f"),
                DarkFormValidBorderColor = Rgb.ParseHtml("#ea868f")
            };
            Demo = new()
            {
                Primary = Rgb.ParseHtml("#ff6a1a"),
                Secondary = Rgb.ParseHtml("#5c5550"),
                Success = Rgb.ParseHtml("#5ba900"),
                Info = Rgb.ParseHtml("#009c5f"),
                Warning = Rgb.ParseHtml("#ffc168"),
                Danger = Rgb.ParseHtml("#f40064"),
                Light = Rgb.ParseHtml("#f2f2ed"),
                Dark = Rgb.ParseHtml("#272525")
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Bs5Theme() { }

        /// <summary>
        /// Default Bootstrap 5 color theme
        /// </summary>
        public static Bs5Theme Default { get; }

        /// <summary>
        /// Demo theme
        /// </summary>
        public static Bs5Theme Demo { get; }

        /// <inheritdoc/>
        public string? Name { get; set; }

        /// <inheritdoc/>
        public virtual BsThemeMode Mode { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Primary { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Secondary { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Success { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Danger { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Warning { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Info { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Light { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Dark { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Body { get; set; }
    }
}
