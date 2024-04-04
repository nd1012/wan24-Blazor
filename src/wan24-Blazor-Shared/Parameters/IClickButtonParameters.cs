namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Interface for click button parameters
    /// </summary>
    public interface IClickButtonParameters : IClickableParameters
    {
        /// <summary>
        /// Text
        /// </summary>
        string? Text { get; set; }
        /// <summary>
        /// Text parameters
        /// </summary>
        IBoxParameters? TextParameters { get; set; }
        /// <summary>
        /// Icon parameters
        /// </summary>
        IImageParameters? IconParameters { get; set; }
        /// <summary>
        /// Active icon parameters
        /// </summary>
        IImageParameters? ActiveIconParameters { get; set; }
        /// <summary>
        /// Display an outline button?
        /// </summary>
        bool Outline { get; set; }
        /// <summary>
        /// Button size
        /// </summary>
        Sizes Size { get; set; }
    }
}
