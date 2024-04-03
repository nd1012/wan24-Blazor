using System.Text;

namespace wan24.Blazor
{
    /// <summary>
    /// Background parameters
    /// </summary>
    public sealed record class BackGroundParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BackGroundParameters() { }

        /// <summary>
        /// Source (data) URI (may be any valid <c>background-image</c> CSS value also)
        /// </summary>
        public string? Src { get; init; }

        /// <summary>
        /// Determine if the <see cref="Src"/> value (if any) is a (data) URI
        /// </summary>
        public bool SrcIsUri => Src is not null && (Uri.TryCreate(Src, UriKind.Absolute, out _) || Src.StartsWith("data:"));

        /// <summary>
        /// CSS color value
        /// </summary>
        public CssRgbA? Color { get; init; }

        /// <summary>
        /// Repeat type (1st (X) or single value)
        /// </summary>
        public BackGroundRepeatTypes Repeat { get; init; }

        /// <summary>
        /// 2nd (Y) repeat type
        /// </summary>
        public BackGroundRepeatTypes? RepeatY { get; init; }

        /// <summary>
        /// Attachment type
        /// </summary>
        public BackGroundAttachmentTypes Attachment { get; init; }

        /// <summary>
        /// Blend mode
        /// </summary>
        public BlendModes BlendMode { get; init; }

        /// <summary>
        /// Origin
        /// </summary>
        public BackGroundOriginTypes Origin { get; init; }

        /// <summary>
        /// Position CSS value
        /// </summary>
        public string? Position { get; init; }

        /// <summary>
        /// Size CSS value
        /// </summary>
        public string? Size { get; init; }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder sb = new();
            if (Src is not null)
                if (SrcIsUri)
                {
                    sb.Append("background-image:uri('");
                    sb.Append(Src);
                    sb.Append("');");
                }
                else
                {
                    sb.Append("background-image:");
                    sb.Append(Src);
                    sb.Append(';');
                }
            if (Color.HasValue)
            {
                sb.Append("background-color:");
                sb.Append(Color.Value.ToString());
                sb.Append(';');
            }
            if (Repeat != BackGroundRepeatTypes.None)
                if (RepeatY.HasValue)
                {
                    sb.Append("background-repeat:");
                    sb.Append(Repeat switch
                    {
                        BackGroundRepeatTypes.Repeat => "repeat",
                        BackGroundRepeatTypes.Space => "space",
                        BackGroundRepeatTypes.Round => "round",
                        BackGroundRepeatTypes.Revert => "revert",
                        BackGroundRepeatTypes.Unset => "unset",
                        _ => throw new InvalidProgramException($"Invalid background repeat X value {Repeat}")
                    });
                    sb.Append(' ');
                    sb.Append(RepeatY.Value switch
                    {
                        BackGroundRepeatTypes.Repeat => "repeat",
                        BackGroundRepeatTypes.Space => "space",
                        BackGroundRepeatTypes.Round => "round",
                        BackGroundRepeatTypes.Revert => "revert",
                        BackGroundRepeatTypes.Unset => "unset",
                        _ => throw new InvalidProgramException($"Invalid background repeat Y value {Repeat}")
                    });
                }
                else
                {
                    sb.Append("background-repeat:");
                    sb.Append(Repeat switch
                    {
                        BackGroundRepeatTypes.Repeat => "repeat",
                        BackGroundRepeatTypes.RepeatX => "repeat-x",
                        BackGroundRepeatTypes.RepeatY => "repeat-y",
                        BackGroundRepeatTypes.Space => "space",
                        BackGroundRepeatTypes.Round => "round",
                        BackGroundRepeatTypes.Revert => "revert",
                        BackGroundRepeatTypes.Unset => "unset",
                        _ => throw new InvalidProgramException($"Invalid background repeat value {Repeat}")
                    });
                    sb.Append(';');
                }
            if (Attachment != BackGroundAttachmentTypes.None)
            {
                sb.Append("background-attachment:");
                sb.Append(Attachment switch
                {
                    BackGroundAttachmentTypes.Scroll => "scroll",
                    BackGroundAttachmentTypes.Fixed => "fixed",
                    BackGroundAttachmentTypes.Local => "local",
                    BackGroundAttachmentTypes.Revert => "revert",
                    BackGroundAttachmentTypes.RevertLayer => "revert-layer",
                    BackGroundAttachmentTypes.Unset => "unset",
                    _ => throw new InvalidProgramException($"Invalid background attachment value {Attachment}")
                });
                sb.Append(';');
            }
            if (BlendMode != BlendModes.None)
            {
                sb.Append("background-blend-mode:");
                sb.Append(string.Join(",", BlendMode.GetBlendModes()));
                sb.Append(';');
            }
            if (Origin != BackGroundOriginTypes.None)
            {
                sb.Append("background-origin:");
                sb.Append(Origin switch
                {
                    BackGroundOriginTypes.BorderBox => "border-box",
                    BackGroundOriginTypes.PaddingBox => "padding-box",
                    BackGroundOriginTypes.ContentBox => "content-box",
                    BackGroundOriginTypes.Revert => "revert",
                    BackGroundOriginTypes.RevertLayer => "revert-layer",
                    BackGroundOriginTypes.Unset => "unset",
                    _ => throw new InvalidProgramException($"Invalid background origin value {Origin}")
                });
                sb.Append(';');
            }
            if(Position is not null)
            {
                sb.Append("background-position:");
                sb.Append(Position);
                sb.Append(';');
            }
            if (Size is not null)
            {
                sb.Append("background-size:");
                sb.Append(Size);
                sb.Append(';');
            }
            return sb.ToString();
        }
    }
}
