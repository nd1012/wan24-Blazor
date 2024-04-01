using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Shadow types enumeration
    /// </summary>
    public enum ShadowTypes
    {
        /// <summary>
        /// No shadow
        /// </summary>
        [DisplayText("No shadow")]
        None = 0,
        /// <summary>
        /// Small shadow
        /// </summary>
        [DisplayText("Small shadow")]
        Small = 1,
        /// <summary>
        /// Regular shadow
        /// </summary>
        [DisplayText("Regular shadow")]
        Regular = 2,
        /// <summary>
        /// Large shadow
        /// </summary>
        [DisplayText("Large shadow")]
        Large = 3
    }
}
