using wan24.Blazor.Parameters;

namespace wan24.Blazor
{
    /// <summary>
    /// Shared extensions
    /// </summary>
    public static class SharedExtensions
    {
        /// <summary>
        /// Make the first character a lower case character
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String</returns>
        public static string FirstToLower(this string str) => str.Length < 1 ? str : new([char.ToLower(str[0]), .. str[1..]]);

        /// <summary>
        /// Make the first character an upper case character
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>String</returns>
        public static string FirstToUpper(this string str) => str.Length < 1 ? str : new([char.ToUpper(str[0]), .. str[1..]]);

        /// <summary>
        /// Flip
        /// </summary>
        /// <param name="orientation">Screen orientation</param>
        /// <returns>Flipped orientation</returns>
        public static ScreenOrientations Flip(this ScreenOrientations orientation) => orientation switch
        {
            ScreenOrientations.Landscape => ScreenOrientations.Portrait,
            _ => ScreenOrientations.Landscape
        };

        /// <summary>
        /// Flip
        /// </summary>
        /// <param name="orientation">Orientation</param>
        /// <returns>Flipped orientation</returns>
        public static Orientations Flip(this Orientations orientation) => orientation switch
        {
            Orientations.Horizontal => Orientations.Vertical,
            _ => Orientations.Horizontal
        };

        /// <summary>
        /// Flip
        /// </summary>
        /// <param name="type">Flex box type</param>
        /// <returns>Flipped flex box type</returns>
        public static FlexBoxTypes Flip(this FlexBoxTypes type) => type switch
        {
            FlexBoxTypes.Column => FlexBoxTypes.Row,
            FlexBoxTypes.Row => FlexBoxTypes.Column,
            FlexBoxTypes.ColumnReverse => FlexBoxTypes.RowReverse,
            FlexBoxTypes.RowReverse => FlexBoxTypes.ColumnReverse,
            _ => type
        };

        /// <summary>
        /// Get as screen orientation
        /// </summary>
        /// <param name="orientation">Orientation</param>
        /// <returns>Screen orientation</returns>
        public static ScreenOrientations ToScreenOrientation(this Orientations orientation) => orientation switch
        {
            Orientations.Horizontal => ScreenOrientations.Portrait,
            _ => ScreenOrientations.Landscape
        };

        /// <summary>
        /// Get as orientation
        /// </summary>
        /// <param name="orientation">Screen orientation</param>
        /// <returns>Orientation</returns>
        public static Orientations ToOrientation(this ScreenOrientations orientation) => orientation switch
        {
            ScreenOrientations.Portrait => Orientations.Horizontal,
            _ => Orientations.Vertical
        };

        /// <summary>
        /// Get as orientation
        /// </summary>
        /// <param name="type">Flex box type</param>
        /// <returns>Orientation</returns>
        public static Orientations ToOrientation(this FlexBoxTypes type) => type switch
        {
            FlexBoxTypes.Column => Orientations.Horizontal,
            FlexBoxTypes.ColumnReverse => Orientations.Horizontal,
            FlexBoxTypes.Row => Orientations.Vertical,
            FlexBoxTypes.RowReverse => Orientations.Vertical,
            _ => throw new ArgumentException($"Can't convert flex box type {type} to orientation", nameof(type))
        };

        /// <summary>
        /// Get as flex box type
        /// </summary>
        /// <param name="orientation">Orientation</param>
        /// <returns>Flex box type</returns>
        public static FlexBoxTypes ToFlexBoxType(this Orientations orientation) => orientation switch
        {
            Orientations.Horizontal => FlexBoxTypes.Column,
            _ => FlexBoxTypes.Row
        };

        /// <summary>
        /// Inverse the order
        /// </summary>
        /// <param name="type">Flex box type</param>
        /// <returns>Inversed order flex box type</returns>
        public static FlexBoxTypes InverseOrder(this FlexBoxTypes type) => type switch
        {
            FlexBoxTypes.Column => FlexBoxTypes.ColumnReverse,
            FlexBoxTypes.Row => FlexBoxTypes.RowReverse,
            FlexBoxTypes.ColumnReverse => FlexBoxTypes.Column,
            FlexBoxTypes.RowReverse => FlexBoxTypes.Row,
            _ => type
        };

        /// <summary>
        /// Get CSS from large/small size
        /// </summary>
        /// <param name="size">Size</param>
        /// <returns>CSS</returns>
        public static string ToCss(this Sizes size) => size switch
        {
            Sizes.Large => "lg",
            Sizes.Small => "sm",
            _ => throw new ArgumentException("Only large/small sizes are supported", nameof(size))
        };

        /// <summary>
        /// Get a copy of these parameters
        /// </summary>
        /// <typeparam name="T">Parameters type</typeparam>
        /// <param name="parameters">Parameters</param>
        /// <returns>Copy of the parameters</returns>
        public static T GetCopy<T>(this T parameters) where T : class, IParameters, new()
        {
            T res = new();
            parameters.ApplyToExcluding(res);
            return res;
        }
    }
}
