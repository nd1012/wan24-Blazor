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
        None,
        /// <summary>
        /// Small shadow
        /// </summary>
        [DisplayText("Small shadow")]
        Small,
        /// <summary>
        /// Regular shadow
        /// </summary>
        [DisplayText("Regular shadow")]
        Regular,
        /// <summary>
        /// Large shadow
        /// </summary>
        [DisplayText("Large shadow")]
        Large
    }
}
