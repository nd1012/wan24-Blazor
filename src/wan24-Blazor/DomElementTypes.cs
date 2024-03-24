using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// DOM element types enumeration
    /// </summary>
    public enum DomElementTypes
    {
        /// <summary>
        /// Node
        /// </summary>
        [DisplayText("HTML node")]
        Node,
        /// <summary>
        /// Text node
        /// </summary>
        [DisplayText("Text node")]
        Text,
        /// <summary>
        /// Comment node
        /// </summary>
        [DisplayText("Comment node")]
        Comment,
        /// <summary>
        /// CDATA
        /// </summary>
        [DisplayText("CDATA node")]
        CDATA
    }
}
