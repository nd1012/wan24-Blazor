using System.Diagnostics.CodeAnalysis;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// CSS RGBA
    /// </summary>
    public sealed record class CssRgbA
    {
        /// <summary>
        /// Inherit value
        /// </summary>
        public const string INHERIT_VALUE = "inherit";

        /// <summary>
        /// Inherited
        /// </summary>
        public static readonly CssRgbA Inherited = new() { Inherit = true };

        /// <summary>
        /// Constructor
        /// </summary>
        public CssRgbA() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public CssRgbA(in string name, in RgbA rgb)
        {
            RGBA = rgb;
            ColorName = name;
        }

        /// <summary>
        /// RGBA
        /// </summary>
        public RgbA RGBA { get; init; }

        /// <summary>
        /// HTML color name
        /// </summary>
        public string? ColorName { get; init; }

        /// <summary>
        /// If inherited
        /// </summary>
        public bool Inherit { get; init; }

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
        public override string ToString() => Inherit ? INHERIT_VALUE : ColorName ?? RGBA.ToCssString();

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
        public static implicit operator CssRgbA(in RgbA value) => new() { RGBA = value };

        /// <summary>
        /// Cast from <see cref="Rgb"/>
        /// </summary>
        /// <param name="value"><see cref="Rgb"/></param>
        public static implicit operator CssRgbA(in Rgb value) => new() { RGBA = new(value) };

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
            if (str == INHERIT_VALUE) return new() { Inherit = true };
            else if (RgbA.RX_CSS.IsMatch(str)) return new() { RGBA = RgbA.Parse(str) };
            else if (Rgb.RX_CSS.IsMatch(str)) return new() { RGBA = new(Rgb.Parse(str)) };
            return new() { ColorName = str };
        }

        /// <summary>
        /// Try parsing a string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="result">Result</param>
        /// <returns>If succeed (should always succeed)</returns>
        public static bool TryParse(in string str, [NotNullWhen(returnValue: true)] out CssRgbA? result)
        {
            if (str == INHERIT_VALUE)
            {
                result = new() { Inherit = true };
                return true;
            }
            try
            {
                if (RgbA.TryParse(str, out RgbA rgba))
                {
                    result = new() { RGBA = rgba };
                    return true;
                }
                if (Rgb.TryParse(str, out Rgb rgb))
                {
                    result = new() { RGBA = new(rgb) };
                    return true;
                }
            }
            catch(Exception ex)
            {
                if (Logging.Debug) Logging.WriteDebug($"{typeof(CssRgbA)} string parsing failed with an exception: ({ex.GetType()}) {ex.Message}");
            }
            result = new() { ColorName = str };
            return true;
        }
    }
}
