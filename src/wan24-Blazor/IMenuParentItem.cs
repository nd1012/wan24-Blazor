namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a menu item which can host sub items
    /// </summary>
    public interface IMenuParentItem : IMenuItem
    {
        /// <summary>
        /// Sub menu items
        /// </summary>
        IEnumerable<IMenuItem> Items { get; }
        /// <summary>
        /// Add a sub menu item (top level only!)
        /// </summary>
        /// <param name="item">Item</param>
        void AddMenuItem(IMenuItem item);
    }
}
