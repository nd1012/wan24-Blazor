using System.Runtime.InteropServices;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// CSS RGBA
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public readonly record struct CssRgbA
    {
        /// <summary>
        /// Inherit value
        /// </summary>
        public const string INHERIT_VALUE = "inherit";

        /// <summary>
        /// Inherited
        /// </summary>
        public static readonly CssRgbA Inherited = new(inherit: true);
        /// <summary>
        /// Black
        /// </summary>
        public static readonly CssRgbA Black = Colors.HTML.Black;
        /// <summary>
        /// White
        /// </summary>
        public static readonly CssRgbA White = Colors.HTML.White;

        /// <summary>
        /// RGBA
        /// </summary>
        public readonly RgbA RGBA;
        /// <summary>
        /// If inherited
        /// </summary>
        public readonly bool Inherit;
        /// <summary>
        /// HTML color name (if not <see langword="null"/>, <see cref="RGBA"/> has the RGB color value of the HTML color)
        /// </summary>
        public readonly string? ColorName;

        /// <summary>
        /// Constructor
        /// </summary>
        public CssRgbA()
        {
            RGBA = RgbA.Black;
            ColorName = Colors.HTML.Black.ColorName;
            Inherit = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rgb">RGBA</param>
        public CssRgbA(in RgbA rgb)
        {
            RGBA = rgb;
            ColorName = null;
            Inherit = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private CssRgbA(in bool inherit)
        {
            RGBA = default;
            ColorName = null;
            Inherit = inherit;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">HTML color name</param>
        /// <param name="rgb">RGBA</param>
        internal CssRgbA(in string name, in RgbA rgb)
        {
            RGBA = rgb;
            ColorName = name;
            Inherit = false;
        }

        /// <summary>
        /// Value type
        /// </summary>
        public CssRgbATypes Type
        {
            get
            {
                if (Inherit) return CssRgbATypes.Inherit;
                if (ColorName is not null) return CssRgbATypes.ColorName;
                return CssRgbATypes.RGBA;
            }
        }

        /// <inheritdoc/>
        public override string ToString() => Inherit ? INHERIT_VALUE : ColorName ?? (RGBA.Alpha == 1 ? RGBA.RGB.ToHtmlString() : RGBA.ToCssString());

        /// <summary>
        /// Cast as <see cref="RgbA"/>
        /// </summary>
        /// <param name="value"><see cref="CssRgbA"/></param>
        public static implicit operator RgbA(in CssRgbA value) => value.RGBA;

        /// <summary>
        /// Cast as <see cref="Rgb"/>
        /// </summary>
        /// <param name="value"><see cref="CssRgbA"/></param>
        public static implicit operator Rgb(in CssRgbA value) => value.RGBA.RGB;

        /// <summary>
        /// Cast as <see cref="string"/>
        /// </summary>
        /// <param name="value"><see cref="CssRgbA"/></param>
        public static implicit operator string(in CssRgbA value) => value.ToString();

        /// <summary>
        /// Cast from <see cref="RgbA"/>
        /// </summary>
        /// <param name="value"><see cref="RgbA"/></param>
        public static implicit operator CssRgbA(in RgbA value) => new(value);

        /// <summary>
        /// Cast from <see cref="Rgb"/>
        /// </summary>
        /// <param name="value"><see cref="Rgb"/></param>
        public static implicit operator CssRgbA(in Rgb value) => new(new RgbA(value));

        /// <summary>
        /// Cast from <see cref="string"/>
        /// </summary>
        /// <param name="value"><see cref="string"/></param>
        public static implicit operator CssRgbA(in string value) => Parse(value);

        /// <summary>
        /// Parse from a string
        /// </summary>
        /// <param name="str">String</param>
        /// <returns><see cref="CssRgbA"/></returns>
        public static CssRgbA Parse(in string str)
        {
            if (str.Equals(INHERIT_VALUE, StringComparison.OrdinalIgnoreCase)) return Inherited;
            else if (Colors.HTML.TryGetByName(str, out CssRgbA res)) return res;
            else if (RgbA.RX_CSS.IsMatch(str)) return new(RgbA.Parse(str));
            else if (Rgb.RX_CSS.IsMatch(str)) return new(new RgbA(Rgb.Parse(str)));
            throw new ArgumentException("Invalid color value", nameof(str));
        }

        /// <summary>
        /// Try parsing a string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="result">Result</param>
        /// <returns>If succeed (should always succeed)</returns>
        public static bool TryParse(in string str, out CssRgbA result)
        {
            if (str.Equals(INHERIT_VALUE, StringComparison.OrdinalIgnoreCase))
            {
                result = Inherited;
                return true;
            }
            try
            {
                if (Colors.HTML.TryGetByName(str, out result)) return true;
                if (RgbA.TryParse(str, out RgbA rgba))
                {
                    result = new(rgba);
                    return true;
                }
                if (Rgb.TryParse(str, out Rgb rgb))
                {
                    result = new(new RgbA(rgb));
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (Logging.Debug) Logging.WriteDebug($"{typeof(CssRgbA)} string parsing failed with an exception: ({ex.GetType()}) {ex.Message}");
            }
            result = default;
            return false;
        }
    }
}
