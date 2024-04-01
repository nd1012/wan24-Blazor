using System.Numerics;
using System.Text;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Bootstrap theme CSS (setting theme colors is not required and won't affect the CSS output)
    /// </summary>
    public record class BsThemeVariables : IBsTheme
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BsThemeVariables() { }

        /// <inheritdoc/>
        public string? Name { get; set; }

        /// <inheritdoc/>
        public virtual BsThemeMode Mode { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Primary { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Secondary { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Success { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Danger { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Warning { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Info { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Light { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Dark { get; set; }

        /// <inheritdoc/>
        public virtual Rgb? Body { get; set; }

        /// <inheritdoc/>
        public virtual required Dictionary<string, string> LightVariables { get; set; }

        /// <inheritdoc/>
        public virtual required Dictionary<string, string> DarkVariables { get; set; }

        /// <summary>
        /// Current mode variables
        /// </summary>
        public virtual Dictionary<string, string> CurrentVariables
        {
            get
            {
                bool dark = (Mode & BsThemeMode.Dark) == BsThemeMode.Dark;
                Dictionary<string, string> res = dark ? new(LightVariables) : LightVariables;
                if (dark) res.Merge(DarkVariables);
                return res;
            }
        }

        /// <summary>
        /// Additional CSS
        /// </summary>
        public virtual string? AdditionalCss { get; set; }

        /// <summary>
        /// Additional CSS (dark mode)
        /// </summary>
        public virtual string? AdditionalDarkCss { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder sb = new(":root {");
            sb.AppendLine();
            foreach (var kvp in CurrentVariables)
                AppendCssVariable(sb, kvp.Key, kvp.Value);
            sb.Append('}');
            sb.AppendLine();
            if (AdditionalCss is string css) sb.AppendLine(css);
            if ((Mode & BsThemeMode.Dark) == BsThemeMode.Dark && AdditionalDarkCss is string darkCss)
                sb.AppendLine(darkCss);
            return sb.ToString();
        }

        /// <summary>
        /// Append a CSS variable
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="name">Bootstrap 5 CSS variable name</param>
        /// <param name="value">CSS value</param>
        /// <returns>String builder</returns>
        protected virtual StringBuilder AppendCssVariable(in StringBuilder sb, in string name, string? value)
        {
            if (value is not null)
            {
                sb.Append('\t');
                sb.Append(name);
                sb.Append(':');
                sb.Append(value);
                sb.Append(';');
                sb.AppendLine();
            }
            return sb;
        }
    }
}
