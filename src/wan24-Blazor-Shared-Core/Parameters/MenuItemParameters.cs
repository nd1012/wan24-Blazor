namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Menu item parameters
    /// </summary>
    public record class MenuItemParameters : ClickButtonParameters, IMenuItemParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuItemParameters() : base()
        {
            TagName = "div";
            InlineFlex = false;
            BackGroundColor = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original"></param>
        public MenuItemParameters(in IClickButtonParameters original) : base(original) { }
    }
}
