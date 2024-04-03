namespace wan24.Blazor.Parameters.Complex
{
    /// <summary>
    /// Interface for bar parameters
    /// </summary>
    public interface IBarParameters : IBoxParameters
    {
        /// <summary>
        /// Menu item parameters property names
        /// </summary>
        IEnumerable<string> MenuItemProperties { get; }
        /// <summary>
        /// Menu item accessability parameters property names
        /// </summary>
        IEnumerable<string> MenuItemAccessabilityProperties { get; }
        /// <summary>
        /// Icon parameters
        /// </summary>
        IImageParameters? IconParameters { get; set; }
        /// <summary>
        /// Icon parameters
        /// </summary>
        IImageParameters? ActiveIconParameters { get; set; }
        /// <summary>
        /// Text parameters
        /// </summary>
        IBodyTextParameters? TextParameters { get; set; }
        /// <summary>
        /// Component parameters
        /// </summary>
        IParameters? ComponentParameters { get; set; }
        /// <summary>
        /// Component type
        /// </summary>
        Type? ComponentType { get; set; }
        /// <summary>
        /// Show item text in horizontal bar display mode?
        /// </summary>
        bool ShowTextHorizontal { get; set; }
        /// <summary>
        /// Show item text in vertical bar display mode?
        /// </summary>
        bool ShowTextVertical { get; set; }
        /// <summary>
        /// Show item text on landscape display?
        /// </summary>
        bool ShowTextOnLandscape { get; set; }
        /// <summary>
        /// Show item text on portrait display?
        /// </summary>
        bool ShowTextOnPortrait { get; set; }
        /// <summary>
        /// Show item text on small landscape display?
        /// </summary>
        bool ShowTextOnSmallLandscape { get; set; }
        /// <summary>
        /// Show item text on small portrait display?
        /// </summary>
        bool ShowTextOnSmallPortrait { get; set; }
        /// <summary>
        /// Show the active menu item?
        /// </summary>
        bool ShowActive { get; set; }
        /// <summary>
        /// Show all menu items from the active menu item to its root as active?
        /// </summary>
        bool ShowActivePath { get; set; }
    }
}
