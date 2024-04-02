using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Colors
    /// </summary>
    public static class Colors
    {
        /// <summary>
        /// Primary
        /// </summary>
        public const string Primary = "primary";
        /// <summary>
        /// Secondary
        /// </summary>
        public const string Secondary = "secondary";
        /// <summary>
        /// Tertiary (light text)
        /// </summary>
        public const string Tertiary = "tertiary";
        /// <summary>
        /// Emphasis (higher contrast text)
        /// </summary>
        public const string Emphasis = "emphasis";
        /// <summary>
        /// Border (borders and dividers)
        /// </summary>
        public const string Border = "border";
        /// <summary>
        /// Success
        /// </summary>
        public const string Success = "success";
        /// <summary>
        /// Danger
        /// </summary>
        public const string Danger = "danger";
        /// <summary>
        /// Warning
        /// </summary>
        public const string Warning = "warning";
        /// <summary>
        /// Info
        /// </summary>
        public const string Info = "info";
        /// <summary>
        /// Light
        /// </summary>
        public const string Light = "light";
        /// <summary>
        /// Dark
        /// </summary>
        public const string Dark = "dark";
        /// <summary>
        /// Body
        /// </summary>
        public const string Body = "body";
        /// <summary>
        /// Black (not as background/border color)
        /// </summary>
        public const string Black = "black";
        /// <summary>
        /// White
        /// </summary>
        public const string White = "white";
        /// <summary>
        /// Transparent (only as background color)
        /// </summary>
        public const string Transparent = "transparent";
        /// <summary>
        /// HTML colors
        /// </summary>
        public static class HTML
        {
            /// <summary>
            /// All HTML colors (key is the name)
            /// </summary>
            private static readonly Dictionary<string, CssRgbA> All;
            /// <summary>
            /// IndianRed
            /// </summary>
            public static readonly CssRgbA IndianRed = new("IndianRed", new(new Rgb(205, 92, 92)));
            /// <summary>
            /// LightCoral
            /// </summary>
            public static readonly CssRgbA LightCoral = new("LightCoral", new(new Rgb(240, 128, 128)));
            /// <summary>
            /// Salmon
            /// </summary>
            public static readonly CssRgbA Salmon = new("Salmon", new(new Rgb(250, 128, 114)));
            /// <summary>
            /// DarkSalmon
            /// </summary>
            public static readonly CssRgbA DarkSalmon = new("DarkSalmon", new(new Rgb(233, 150, 122)));
            /// <summary>
            /// LightSalmon
            /// </summary>
            public static readonly CssRgbA LightSalmon = new("LightSalmon", new(new Rgb(255, 160, 122)));
            /// <summary>
            /// Crimson
            /// </summary>
            public static readonly CssRgbA Crimson = new("Crimson", new(new Rgb(220, 20, 60)));
            /// <summary>
            /// Red
            /// </summary>
            public static readonly CssRgbA Red = new("Red", new(new Rgb(255, 0, 0)));
            /// <summary>
            /// FireBrick
            /// </summary>
            public static readonly CssRgbA FireBrick = new("FireBrick", new(new Rgb(178, 34, 34)));
            /// <summary>
            /// DarkRed
            /// </summary>
            public static readonly CssRgbA DarkRed = new("DarkRed", new(new Rgb(139, 0, 0)));
            /// <summary>
            /// Pink
            /// </summary>
            public static readonly CssRgbA Pink = new("Pink", new(new Rgb(255, 192, 203)));
            /// <summary>
            /// LightPink
            /// </summary>
            public static readonly CssRgbA LightPink = new("LightPink", new(new Rgb(255, 182, 193)));
            /// <summary>
            /// HotPink
            /// </summary>
            public static readonly CssRgbA HotPink = new("HotPink", new(new Rgb(255, 105, 180)));
            /// <summary>
            /// DeepPink
            /// </summary>
            public static readonly CssRgbA DeepPink = new("DeepPink", new(new Rgb(255, 20, 147)));
            /// <summary>
            /// MediumVioletRed
            /// </summary>
            public static readonly CssRgbA MediumVioletRed = new("MediumVioletRed", new(new Rgb(199, 21, 133)));
            /// <summary>
            /// PaleVioletRed
            /// </summary>
            public static readonly CssRgbA PaleVioletRed = new("PaleVioletRed", new(new Rgb(219, 112, 147)));
            /// <summary>
            /// Coral
            /// </summary>
            public static readonly CssRgbA Coral = new("Coral", new(new Rgb(255, 127, 80)));
            /// <summary>
            /// Tomato
            /// </summary>
            public static readonly CssRgbA Tomato = new("Tomato", new(new Rgb(255, 99, 71)));
            /// <summary>
            /// OrangeRed
            /// </summary>
            public static readonly CssRgbA OrangeRed = new("OrangeRed", new(new Rgb(255, 69, 0)));
            /// <summary>
            /// DarkOrange
            /// </summary>
            public static readonly CssRgbA DarkOrange = new("DarkOrange", new(new Rgb(255, 140, 0)));
            /// <summary>
            /// Orange
            /// </summary>
            public static readonly CssRgbA Orange = new("Orange", new(new Rgb(255, 165, 0)));
            /// <summary>
            /// Gold
            /// </summary>
            public static readonly CssRgbA Gold = new("Gold", new(new Rgb(255, 215, 0)));
            /// <summary>
            /// Yellow
            /// </summary>
            public static readonly CssRgbA Yellow = new("Yellow", new(new Rgb(255, 255, 0)));
            /// <summary>
            /// LightYellow
            /// </summary>
            public static readonly CssRgbA LightYellow = new("LightYellow", new(new Rgb(255, 255, 224)));
            /// <summary>
            /// LemonChiffon
            /// </summary>
            public static readonly CssRgbA LemonChiffon = new("LemonChiffon", new(new Rgb(255, 250, 205)));
            /// <summary>
            /// LightGoldenrodYellow
            /// </summary>
            public static readonly CssRgbA LightGoldenrodYellow = new("LightGoldenrodYellow", new(new Rgb(250, 250, 210)));
            /// <summary>
            /// PapayaWhip
            /// </summary>
            public static readonly CssRgbA PapayaWhip = new("PapayaWhip", new(new Rgb(255, 239, 213)));
            /// <summary>
            /// Moccasin
            /// </summary>
            public static readonly CssRgbA Moccasin = new("Moccasin", new(new Rgb(255, 228, 181)));
            /// <summary>
            /// PeachPuff
            /// </summary>
            public static readonly CssRgbA PeachPuff = new("PeachPuff", new(new Rgb(255, 218, 185)));
            /// <summary>
            /// PaleGoldenrod
            /// </summary>
            public static readonly CssRgbA PaleGoldenrod = new("PaleGoldenrod", new(new Rgb(238, 232, 170)));
            /// <summary>
            /// Khaki
            /// </summary>
            public static readonly CssRgbA Khaki = new("Khaki", new(new Rgb(240, 230, 140)));
            /// <summary>
            /// DarkKhaki
            /// </summary>
            public static readonly CssRgbA DarkKhaki = new("DarkKhaki", new(new Rgb(189, 183, 107)));
            /// <summary>
            /// Lavender
            /// </summary>
            public static readonly CssRgbA Lavender = new("Lavender", new(new Rgb(230, 230, 250)));
            /// <summary>
            /// Thistle
            /// </summary>
            public static readonly CssRgbA Thistle = new("Thistle", new(new Rgb(216, 191, 216)));
            /// <summary>
            /// Plum
            /// </summary>
            public static readonly CssRgbA Plum = new("Plum", new(new Rgb(221, 160, 221)));
            /// <summary>
            /// Violet
            /// </summary>
            public static readonly CssRgbA Violet = new("Violet", new(new Rgb(238, 130, 238)));
            /// <summary>
            /// Orchid
            /// </summary>
            public static readonly CssRgbA Orchid = new("Orchid", new(new Rgb(218, 112, 214)));
            /// <summary>
            /// Fuchsia
            /// </summary>
            public static readonly CssRgbA Fuchsia = new("Fuchsia", new(new Rgb(255, 0, 255)));
            /// <summary>
            /// Magenta
            /// </summary>
            public static readonly CssRgbA Magenta = new("Magenta", new(new Rgb(255, 0, 255)));
            /// <summary>
            /// MediumOrchid
            /// </summary>
            public static readonly CssRgbA MediumOrchid = new("MediumOrchid", new(new Rgb(186, 85, 211)));
            /// <summary>
            /// MediumPurple
            /// </summary>
            public static readonly CssRgbA MediumPurple = new("MediumPurple", new(new Rgb(147, 112, 219)));
            /// <summary>
            /// RebeccaPurple
            /// </summary>
            public static readonly CssRgbA RebeccaPurple = new("RebeccaPurple", new(new Rgb(102, 51, 153)));
            /// <summary>
            /// BlueViolet
            /// </summary>
            public static readonly CssRgbA BlueViolet = new("BlueViolet", new(new Rgb(138, 43, 226)));
            /// <summary>
            /// DarkViolet
            /// </summary>
            public static readonly CssRgbA DarkViolet = new("DarkViolet", new(new Rgb(148, 0, 211)));
            /// <summary>
            /// DarkOrchid
            /// </summary>
            public static readonly CssRgbA DarkOrchid = new("DarkOrchid", new(new Rgb(153, 50, 204)));
            /// <summary>
            /// DarkMagenta
            /// </summary>
            public static readonly CssRgbA DarkMagenta = new("DarkMagenta", new(new Rgb(139, 0, 139)));
            /// <summary>
            /// Purple
            /// </summary>
            public static readonly CssRgbA Purple = new("Purple", new(new Rgb(128, 0, 128)));
            /// <summary>
            /// Indigo
            /// </summary>
            public static readonly CssRgbA Indigo = new("Indigo", new(new Rgb(75, 0, 130)));
            /// <summary>
            /// SlateBlue
            /// </summary>
            public static readonly CssRgbA SlateBlue = new("SlateBlue", new(new Rgb(106, 90, 205)));
            /// <summary>
            /// DarkSlateBlue
            /// </summary>
            public static readonly CssRgbA DarkSlateBlue = new("DarkSlateBlue", new(new Rgb(72, 61, 139)));
            /// <summary>
            /// MediumSlateBlue
            /// </summary>
            public static readonly CssRgbA MediumSlateBlue = new("MediumSlateBlue", new(new Rgb(123, 104, 238)));
            /// <summary>
            /// GreenYellow
            /// </summary>
            public static readonly CssRgbA GreenYellow = new("GreenYellow", new(new Rgb(173, 255, 47)));
            /// <summary>
            /// Chartreuse
            /// </summary>
            public static readonly CssRgbA Chartreuse = new("Chartreuse", new(new Rgb(127, 255, 0)));
            /// <summary>
            /// LawnGreen
            /// </summary>
            public static readonly CssRgbA LawnGreen = new("LawnGreen", new(new Rgb(124, 252, 0)));
            /// <summary>
            /// Lime
            /// </summary>
            public static readonly CssRgbA Lime = new("Lime", new(new Rgb(0, 255, 0)));
            /// <summary>
            /// LimeGreen
            /// </summary>
            public static readonly CssRgbA LimeGreen = new("LimeGreen", new(new Rgb(50, 205, 50)));
            /// <summary>
            /// PaleGreen
            /// </summary>
            public static readonly CssRgbA PaleGreen = new("PaleGreen", new(new Rgb(152, 251, 152)));
            /// <summary>
            /// LightGreen
            /// </summary>
            public static readonly CssRgbA LightGreen = new("LightGreen", new(new Rgb(144, 238, 144)));
            /// <summary>
            /// MediumSpringGreen
            /// </summary>
            public static readonly CssRgbA MediumSpringGreen = new("MediumSpringGreen", new(new Rgb(0, 250, 154)));
            /// <summary>
            /// SpringGreen
            /// </summary>
            public static readonly CssRgbA SpringGreen = new("SpringGreen", new(new Rgb(0, 255, 127)));
            /// <summary>
            /// MediumSeaGreen
            /// </summary>
            public static readonly CssRgbA MediumSeaGreen = new("MediumSeaGreen", new(new Rgb(60, 179, 113)));
            /// <summary>
            /// SeaGreen
            /// </summary>
            public static readonly CssRgbA SeaGreen = new("SeaGreen", new(new Rgb(46, 139, 87)));
            /// <summary>
            /// ForestGreen
            /// </summary>
            public static readonly CssRgbA ForestGreen = new("ForestGreen", new(new Rgb(34, 139, 34)));
            /// <summary>
            /// Green
            /// </summary>
            public static readonly CssRgbA Green = new("Green", new(new Rgb(0, 128, 0)));
            /// <summary>
            /// DarkGreen
            /// </summary>
            public static readonly CssRgbA DarkGreen = new("DarkGreen", new(new Rgb(0, 100, 0)));
            /// <summary>
            /// YellowGreen
            /// </summary>
            public static readonly CssRgbA YellowGreen = new("YellowGreen", new(new Rgb(154, 205, 50)));
            /// <summary>
            /// OliveDrab
            /// </summary>
            public static readonly CssRgbA OliveDrab = new("OliveDrab", new(new Rgb(107, 142, 35)));
            /// <summary>
            /// Olive
            /// </summary>
            public static readonly CssRgbA Olive = new("Olive", new(new Rgb(128, 128, 0)));
            /// <summary>
            /// DarkOliveGreen
            /// </summary>
            public static readonly CssRgbA DarkOliveGreen = new("DarkOliveGreen", new(new Rgb(85, 107, 47)));
            /// <summary>
            /// MediumAquamarine
            /// </summary>
            public static readonly CssRgbA MediumAquamarine = new("MediumAquamarine", new(new Rgb(102, 205, 170)));
            /// <summary>
            /// DarkSeaGreen
            /// </summary>
            public static readonly CssRgbA DarkSeaGreen = new("DarkSeaGreen", new(new Rgb(143, 188, 139)));
            /// <summary>
            /// LightSeaGreen
            /// </summary>
            public static readonly CssRgbA LightSeaGreen = new("LightSeaGreen", new(new Rgb(32, 178, 170)));
            /// <summary>
            /// DarkCyan
            /// </summary>
            public static readonly CssRgbA DarkCyan = new("DarkCyan", new(new Rgb(0, 139, 139)));
            /// <summary>
            /// Teal
            /// </summary>
            public static readonly CssRgbA Teal = new("Teal", new(new Rgb(0, 128, 128)));
            /// <summary>
            /// Aqua
            /// </summary>
            public static readonly CssRgbA Aqua = new("Aqua", new(new Rgb(0, 255, 255)));
            /// <summary>
            /// Cyan
            /// </summary>
            public static readonly CssRgbA Cyan = new("Cyan", new(new Rgb(0, 255, 255)));
            /// <summary>
            /// LightCyan
            /// </summary>
            public static readonly CssRgbA LightCyan = new("LightCyan", new(new Rgb(224, 255, 255)));
            /// <summary>
            /// PaleTurquoise
            /// </summary>
            public static readonly CssRgbA PaleTurquoise = new("PaleTurquoise", new(new Rgb(175, 238, 238)));
            /// <summary>
            /// Aquamarine
            /// </summary>
            public static readonly CssRgbA Aquamarine = new("Aquamarine", new(new Rgb(127, 255, 212)));
            /// <summary>
            /// Turquoise
            /// </summary>
            public static readonly CssRgbA Turquoise = new("Turquoise", new(new Rgb(64, 224, 208)));
            /// <summary>
            /// MediumTurquoise
            /// </summary>
            public static readonly CssRgbA MediumTurquoise = new("MediumTurquoise", new(new Rgb(72, 209, 204)));
            /// <summary>
            /// CadetBlue
            /// </summary>
            public static readonly CssRgbA CadetBlue = new("CadetBlue", new(new Rgb(95, 158, 160)));
            /// <summary>
            /// SteelBlue
            /// </summary>
            public static readonly CssRgbA SteelBlue = new("SteelBlue", new(new Rgb(70, 130, 180)));
            /// <summary>
            /// LightSteelBlue
            /// </summary>
            public static readonly CssRgbA LightSteelBlue = new("LightSteelBlue", new(new Rgb(176, 196, 222)));
            /// <summary>
            /// PowderBlue
            /// </summary>
            public static readonly CssRgbA PowderBlue = new("PowderBlue", new(new Rgb(176, 224, 230)));
            /// <summary>
            /// LightBlue
            /// </summary>
            public static readonly CssRgbA LightBlue = new("LightBlue", new(new Rgb(173, 216, 230)));
            /// <summary>
            /// SkyBlue
            /// </summary>
            public static readonly CssRgbA SkyBlue = new("SkyBlue", new(new Rgb(135, 206, 235)));
            /// <summary>
            /// LightSkyBlue
            /// </summary>
            public static readonly CssRgbA LightSkyBlue = new("LightSkyBlue", new(new Rgb(135, 206, 250)));
            /// <summary>
            /// DeepSkyBlue
            /// </summary>
            public static readonly CssRgbA DeepSkyBlue = new("DeepSkyBlue", new(new Rgb(0, 191, 255)));
            /// <summary>
            /// DodgerBlue
            /// </summary>
            public static readonly CssRgbA DodgerBlue = new("DodgerBlue", new(new Rgb(30, 144, 255)));
            /// <summary>
            /// CornflowerBlue
            /// </summary>
            public static readonly CssRgbA CornflowerBlue = new("CornflowerBlue", new(new Rgb(100, 149, 237)));
            /// <summary>
            /// RoyalBlue
            /// </summary>
            public static readonly CssRgbA RoyalBlue = new("RoyalBlue", new(new Rgb(65, 105, 225)));
            /// <summary>
            /// Blue
            /// </summary>
            public static readonly CssRgbA Blue = new("Blue", new(new Rgb(0, 0, 255)));
            /// <summary>
            /// MediumBlue
            /// </summary>
            public static readonly CssRgbA MediumBlue = new("MediumBlue", new(new Rgb(0, 0, 205)));
            /// <summary>
            /// DarkBlue
            /// </summary>
            public static readonly CssRgbA DarkBlue = new("DarkBlue", new(new Rgb(0, 0, 139)));
            /// <summary>
            /// Navy
            /// </summary>
            public static readonly CssRgbA Navy = new("Navy", new(new Rgb(0, 0, 128)));
            /// <summary>
            /// MidnightBlue
            /// </summary>
            public static readonly CssRgbA MidnightBlue = new("MidnightBlue", new(new Rgb(25, 25, 112)));
            /// <summary>
            /// Cornsilk
            /// </summary>
            public static readonly CssRgbA Cornsilk = new("Cornsilk", new(new Rgb(255, 248, 220)));
            /// <summary>
            /// BlanchedAlmond
            /// </summary>
            public static readonly CssRgbA BlanchedAlmond = new("BlanchedAlmond", new(new Rgb(255, 235, 205)));
            /// <summary>
            /// Bisque
            /// </summary>
            public static readonly CssRgbA Bisque = new("Bisque", new(new Rgb(255, 228, 196)));
            /// <summary>
            /// NavajoWhite
            /// </summary>
            public static readonly CssRgbA NavajoWhite = new("NavajoWhite", new(new Rgb(255, 222, 173)));
            /// <summary>
            /// Wheat
            /// </summary>
            public static readonly CssRgbA Wheat = new("Wheat", new(new Rgb(245, 222, 179)));
            /// <summary>
            /// BurlyWood
            /// </summary>
            public static readonly CssRgbA BurlyWood = new("BurlyWood", new(new Rgb(222, 184, 135)));
            /// <summary>
            /// Tan
            /// </summary>
            public static readonly CssRgbA Tan = new("Tan", new(new Rgb(210, 180, 140)));
            /// <summary>
            /// RosyBrown
            /// </summary>
            public static readonly CssRgbA RosyBrown = new("RosyBrown", new(new Rgb(188, 143, 143)));
            /// <summary>
            /// SandyBrown
            /// </summary>
            public static readonly CssRgbA SandyBrown = new("SandyBrown", new(new Rgb(244, 164, 96)));
            /// <summary>
            /// Goldenrod
            /// </summary>
            public static readonly CssRgbA Goldenrod = new("Goldenrod", new(new Rgb(218, 165, 32)));
            /// <summary>
            /// DarkGoldenrod
            /// </summary>
            public static readonly CssRgbA DarkGoldenrod = new("DarkGoldenrod", new(new Rgb(184, 134, 11)));
            /// <summary>
            /// Peru
            /// </summary>
            public static readonly CssRgbA Peru = new("Peru", new(new Rgb(205, 133, 63)));
            /// <summary>
            /// Chocolate
            /// </summary>
            public static readonly CssRgbA Chocolate = new("Chocolate", new(new Rgb(210, 105, 30)));
            /// <summary>
            /// SaddleBrown
            /// </summary>
            public static readonly CssRgbA SaddleBrown = new("SaddleBrown", new(new Rgb(160, 82, 45)));
            /// <summary>
            /// Sienna
            /// </summary>
            public static readonly CssRgbA Sienna = new("Sienna", new(new Rgb(205, 92, 92)));
            /// <summary>
            /// Brown
            /// </summary>
            public static readonly CssRgbA Brown = new("Brown", new(new Rgb(165, 42, 42)));
            /// <summary>
            /// Maroon
            /// </summary>
            public static readonly CssRgbA Maroon = new("Maroon", new(new Rgb(128, 0, 0)));
            /// <summary>
            /// White
            /// </summary>
            public static readonly CssRgbA White = new("White", new(new Rgb(255, 255, 255)));
            /// <summary>
            /// Snow
            /// </summary>
            public static readonly CssRgbA Snow = new("Snow", new(new Rgb(255, 250, 250)));
            /// <summary>
            /// HoneyDew
            /// </summary>
            public static readonly CssRgbA HoneyDew = new("HoneyDew", new(new Rgb(240, 255, 240)));
            /// <summary>
            /// MintCream
            /// </summary>
            public static readonly CssRgbA MintCream = new("MintCream", new(new Rgb(245, 255, 250)));
            /// <summary>
            /// Azure
            /// </summary>
            public static readonly CssRgbA Azure = new("Azure", new(new Rgb(240, 255, 255)));
            /// <summary>
            /// AliceBlue
            /// </summary>
            public static readonly CssRgbA AliceBlue = new("AliceBlue", new(new Rgb(240, 248, 255)));
            /// <summary>
            /// GhostWhite
            /// </summary>
            public static readonly CssRgbA GhostWhite = new("GhostWhite", new(new Rgb(248, 248, 255)));
            /// <summary>
            /// WhiteSmoke
            /// </summary>
            public static readonly CssRgbA WhiteSmoke = new("WhiteSmoke", new(new Rgb(245, 245, 245)));
            /// <summary>
            /// SeaShell
            /// </summary>
            public static readonly CssRgbA SeaShell = new("SeaShell", new(new Rgb(255, 245, 238)));
            /// <summary>
            /// Beige
            /// </summary>
            public static readonly CssRgbA Beige = new("Beige", new(new Rgb(245, 245, 220)));
            /// <summary>
            /// OldLace
            /// </summary>
            public static readonly CssRgbA OldLace = new("OldLace", new(new Rgb(253, 245, 230)));
            /// <summary>
            /// FloralWhite
            /// </summary>
            public static readonly CssRgbA FloralWhite = new("FloralWhite", new(new Rgb(255, 250, 240)));
            /// <summary>
            /// Ivory
            /// </summary>
            public static readonly CssRgbA Ivory = new("Ivory", new(new Rgb(255, 255, 240)));
            /// <summary>
            /// AntiqueWhite
            /// </summary>
            public static readonly CssRgbA AntiqueWhite = new("AntiqueWhite", new(new Rgb(250, 235, 215)));
            /// <summary>
            /// Linen
            /// </summary>
            public static readonly CssRgbA Linen = new("Linen", new(new Rgb(250, 240, 230)));
            /// <summary>
            /// LavenderBlush
            /// </summary>
            public static readonly CssRgbA LavenderBlush = new("LavenderBlush", new(new Rgb(255, 240, 245)));
            /// <summary>
            /// MistyRose
            /// </summary>
            public static readonly CssRgbA MistyRose = new("MistyRose", new(new Rgb(255, 228, 225)));
            /// <summary>
            /// Gainsboro
            /// </summary>
            public static readonly CssRgbA Gainsboro = new("Gainsboro", new(new Rgb(220, 220, 220)));
            /// <summary>
            /// LightGray
            /// </summary>
            public static readonly CssRgbA LightGray = new("LightGray", new(new Rgb(211, 211, 211)));
            /// <summary>
            /// Silver
            /// </summary>
            public static readonly CssRgbA Silver = new("Silver", new(new Rgb(192, 192, 192)));
            /// <summary>
            /// DarkGray
            /// </summary>
            public static readonly CssRgbA DarkGray = new("DarkGray", new(new Rgb(169, 169, 169)));
            /// <summary>
            /// Gray
            /// </summary>
            public static readonly CssRgbA Gray = new("Gray", new(new Rgb(128, 128, 128)));
            /// <summary>
            /// DimGray
            /// </summary>
            public static readonly CssRgbA DimGray = new("DimGray", new(new Rgb(105, 105, 105)));
            /// <summary>
            /// LightSlateGray
            /// </summary>
            public static readonly CssRgbA LightSlateGray = new("LightSlateGray", new(new Rgb(119, 136, 153)));
            /// <summary>
            /// SlateGray
            /// </summary>
            public static readonly CssRgbA SlateGray = new("SlateGray", new(new Rgb(112, 128, 144)));
            /// <summary>
            /// DarkSlateGray
            /// </summary>
            public static readonly CssRgbA DarkSlateGray = new("DarkSlateGray", new(new Rgb(47, 79, 79)));
            /// <summary>
            /// Black
            /// </summary>
            public static readonly CssRgbA Black = new("Black", new(new Rgb()));

            /// <summary>
            /// Constructor
            /// </summary>
            static HTML()
            {
                All = [];
                foreach (FieldInfo fi in typeof(HTML).GetFields())
                    All[fi.Name] = (CssRgbA)fi.GetValue(obj: null)!;
            }

            /// <summary>
            /// All color names
            /// </summary>
            public static IEnumerable<string> Names => All.Keys;

            /// <summary>
            /// Get a HTML color by its name
            /// </summary>
            /// <param name="name">Name</param>
            /// <returns>Color</returns>
            public static CssRgbA GetByName(string name)
            {
                string? key = All.Keys.FirstOrDefault(k => k.Equals(name, StringComparison.OrdinalIgnoreCase));
                return key is null ? default : All[key];
            }

            /// <summary>
            /// Get a HTML color by its name
            /// </summary>
            /// <param name="name">Name</param>
            /// <param name="result">Result</param>
            /// <returns>If succeed</returns>
            public static bool TryGetByName(string name, out CssRgbA result)
            {
                string? key = All.Keys.FirstOrDefault(k => k.Equals(name, StringComparison.OrdinalIgnoreCase));
                result = key is null ? default : All[key];
                return key is not null;
            }

        }
    }
}
