﻿using System.Runtime.InteropServices;
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
        public readonly RgbA RGBA = default;
        /// <summary>
        /// If inherited
        /// </summary>
        public readonly bool Inherit = false;
        /// <summary>
        /// HTML color name (if not <see langword="null"/>, <see cref="RGBA"/> has the RGB color value of the HTML color)
        /// </summary>
        public readonly string? ColorName = null;
        /// <summary>
        /// CSS value
        /// </summary>
        public readonly string? CssValue = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public CssRgbA()
        {
            RGBA = RgbA.Black;
            ColorName = Colors.HTML.Black.ColorName;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rgb">RGBA</param>
        public CssRgbA(in RgbA rgb) => RGBA = rgb;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cssValue">CSS value</param>
        public CssRgbA(in string cssValue) => CssValue = cssValue;

        /// <summary>
        /// Constructor
        /// </summary>
        private CssRgbA(in bool inherit) => Inherit = inherit;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">HTML color name</param>
        /// <param name="rgb">RGBA</param>
        internal CssRgbA(in string name, in RgbA rgb)
        {
            RGBA = rgb;
            ColorName = name;
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
                if (CssValue is not null) return CssRgbATypes.CssValue;
                return CssRgbATypes.RGBA;
            }
        }

        /// <inheritdoc/>
        public override string ToString() => Inherit ? INHERIT_VALUE : CssValue ?? ColorName ?? (RGBA.Alpha == 1 ? RGBA.RGB.ToHtmlString() : RGBA.ToCssString());

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
        /// Parse from a string (HTML color name or value or CSS RGB(A) value)
        /// </summary>
        /// <param name="str">String</param>
        /// <returns><see cref="CssRgbA"/></returns>
        public static CssRgbA Parse(in string str)
        {
            if (str.Equals(INHERIT_VALUE, StringComparison.OrdinalIgnoreCase)) return Inherited;
            else if (Colors.HTML.TryGetByName(str, out CssRgbA res)) return res;
            else if (RgbA.RX_CSS.IsMatch(str)) return new(RgbA.Parse(str));
            else if (Rgb.RX_CSS.IsMatch(str)) return new(new RgbA(Rgb.Parse(str)));
            return new(str);
        }

        /// <summary>
        /// Try parsing a string (HTML color name or value or CSS RGB(A) value)
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="result">Result</param>
        /// <returns>If succeed</returns>
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
                if (RgbA.RX_CSS.IsMatch(str))
                    if (RgbA.TryParse(str, out RgbA rgba))
                    {
                        result = new(rgba);
                        return true;
                    }
                    else
                    {
                        if (Logging.Trace) Logging.WriteTrace($"{typeof(CssRgbA)} string parsing failed: Invalid RGBA CSS value");
                        return false;
                    }
                if (Rgb.RX_CSS.IsMatch(str))
                    if (Rgb.TryParse(str, out Rgb rgb))
                    {
                        result = new(new RgbA(rgb));
                        return true;
                    }
                    else
                    {
                        if (Logging.Trace) Logging.WriteTrace($"{typeof(CssRgbA)} string parsing failed: Invalid RGB CSS value");
                        return false;
                    }
            }
            catch (Exception ex)
            {
                if (Logging.Debug) Logging.WriteDebug($"{typeof(CssRgbA)} string parsing failed with an exception: ({ex.GetType()}) {ex.Message}");
            }
            result = new(str);
            return true;
        }
    }
}
