using System.Text;
using System.Text.RegularExpressions;
using wan24.CLI;
using wan24.Core;

namespace wan24.Blazor
{
    [CliApi("code")]
    public sealed partial class CodeGeneratorApi
    {
        private static readonly Regex RX_ATTRS = RX_ATTRS_Generator();

        public CodeGeneratorApi() { }

        [CliApi("generate", IsDefault = true)]
        public static async Task GenerateAsync(
            [CliApi]
            string? folder = null,
            [CliApi]
            string? template = null,
            [CliApi]
            string? output = null
            )
        {
            folder ??= "../../../../../bootstrap-icons-1.11.3";
            template ??= "Images.cs";
            output ??= "../../../../wan24-Blazor-Shared/Images.cs";
            string[] outputTemplate = (await File.ReadAllTextAsync(template).DynamicContext()).Replace("\r", string.Empty).Split("#define CONTENT\n", 2);
            if (outputTemplate.Length != 2) throw new InvalidDataException("Invalid template");
            FileStream outputFile = FsHelper.CreateFileStream(output, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, overwrite: true);
            await using (outputFile.DynamicContext())
            {
                using StreamWriter writer = new(outputFile, leaveOpen: true);
                await writer.WriteAsync(outputTemplate[0].Replace("\n", "\r\n")).DynamicContext();
                bool first = true;
                foreach (string fn in FsHelper.FindFiles(folder, searchPattern: "*.svg", recursive: false))
                {
                    Logging.WriteInfo(fn);
                    string name = Path.GetFileNameWithoutExtension(fn);
                    if (name == "bootstrap-icons") continue;
                    string svg = await File.ReadAllTextAsync(fn).DynamicContext();
                    while (RX_ATTRS.IsMatch(svg)) svg = RX_ATTRS.Replace(svg, "$1$4");
                    StringBuilder sb = new(256 + (svg.Length << 1));
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                    sb.AppendLine("\t\t/// <summary>");
                    sb.AppendLine($"\t\t/// {name} ({Path.GetFileName(fn)})");
                    sb.AppendLine("\t\t/// </summary>");
                    sb.AppendLine($"\t\tpublic static string Icon_{name.Replace('-', '_')} {{ get; }} = \"data:image/svg+xml;base64, {Convert.ToBase64String(svg.GetBytes())}\";");
                    await writer.WriteAsync(sb.ToString()).DynamicContext();
                }
                await writer.WriteAsync(outputTemplate[1].Replace("\n", "\r\n")).DynamicContext();
            }
        }

        [GeneratedRegex(@"^(.*)(\s+(width|height)\=\""[\s\d]*\"")(.*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline, "de-DE")]
        private static partial Regex RX_ATTRS_Generator();
    }
}
