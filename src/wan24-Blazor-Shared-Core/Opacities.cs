using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Opacities enumeration
    /// </summary>
    public enum Opacities
    {
        /// <summary>
        /// 100% visible
        /// </summary>
        [DisplayText("100% visibility")]
        Op100 = 0,
        /// <summary>
        /// 75% visible
        /// </summary>
        [DisplayText("75% visibility")]
        Op75 = 1,
        /// <summary>
        /// 50% visible
        /// </summary>
        [DisplayText("50% visibility")]
        Op50 = 2,
        /// <summary>
        /// 25% visible
        /// </summary>
        [DisplayText("25% visibility")]
        Op25 = 3,
        /// <summary>
        /// 10% visible
        /// </summary>
        [DisplayText("10% visibility")]
        Op10 = 4
    }
}
