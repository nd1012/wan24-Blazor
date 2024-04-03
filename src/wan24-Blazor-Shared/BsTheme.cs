namespace wan24.Blazor
{
    /// <summary>
    /// Bootstrap theme
    /// </summary>
    public static class BsTheme
    {
        /// <summary>
        /// Current theme
        /// </summary>
        public static IBsTheme Current { get; set; } = new Bs5Theme().Merge(Bs5Theme.Default);
    }
}
