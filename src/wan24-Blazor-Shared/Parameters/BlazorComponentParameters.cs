namespace wan24.Blazor.Parameters
{
    /// <summary>
    /// Blazor component parameters
    /// </summary>
    public record class BlazorComponentParameters : ParametersBase, IBlazorComponentParameters
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BlazorComponentParameters() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="original">Original</param>
        public BlazorComponentParameters(in IBlazorComponentParameters original) : base()
        {
            Id = original.Id;
            Title = original.Title;
            Role = original.Role;
            Flex = original.Flex;
            InlineFlex = original.InlineFlex;
            Grow = original.Grow;
            Rounded = original.Rounded;
            Shadow = original.Shadow;
            Overflow = original.Overflow;
            OverflowX = original.OverflowX;
            OverflowY = original.OverflowY;
            Float = original.Float;
            BackGround = original.BackGround;
            MixBlendMode = original.MixBlendMode;
            BackGroundColor = original.BackGroundColor;
            BackGroundSubtle = original.BackGroundSubtle;
            BackGroundOpacity = original.BackGroundOpacity;
            BackGroundGradient = original.BackGroundGradient;
            TextColor = original.TextColor;
            TextBackGroundColor = original.TextBackGroundColor;
            TextEmphasis = original.TextEmphasis;
            TextSize = original.TextSize;
            FontStyle = original.FontStyle;
            HAlign = original.HAlign;
            VAlign = original.VAlign;
            Wrap = original.Wrap;
            NoWrap = original.NoWrap;
            Truncate = original.Truncate;
            Muted = original.Muted;
            Selection = original.Selection;
            Border = original.Border;
            BorderColor = original.BorderColor;
            BorderEmphasis = original.BorderEmphasis;
            BorderOpacity = original.BorderOpacity;
            Style = original.Style;
            Color = original.Color;
            TextOpacity = original.TextOpacity;
            ZIndex = original.ZIndex;
            Attributes = original.Attributes;
            ShowOnLandscape = original.ShowOnLandscape;
            ShowOnSmallLandscape = original.ShowOnSmallLandscape;
            ShowOnPortrait = original.ShowOnPortrait;
            ShowOnSmallPortrait = original.ShowOnPortrait;
            EnableOnLandscape = original.EnableOnLandscape;
            EnableOnSmallLandscape = original.EnableOnSmallLandscape;
            EnableOnPortrait = original.EnableOnPortrait;
            EnableOnSmallPortrait = original.EnableOnPortrait;
            IsActive = original.IsActive;
            Disabled = original.Disabled;
            Hidden = original.Hidden;
            ForcedColorMode = original.ForcedColorMode;
        }

        /// <inheritdoc/>
        public override Dictionary<string, object> AllParameters
        {
            get
            {
                Dictionary<string, object> res = [];
                if (Id is not null) res[nameof(Id)] = Id;
                if (Title is not null) res[nameof(Title)] = Title;
                if(Role is not null) res[nameof(Role)] = Role;
                res[nameof(Flex)] = Flex;
                res[nameof(InlineFlex)] = InlineFlex;
                res[nameof(Grow)] = Grow;
                res[nameof(Rounded)] = Rounded;
                res[nameof(Shadow)] = Shadow;
                res[nameof(Overflow)] = Overflow;
                res[nameof(OverflowX)] = OverflowX;
                res[nameof(OverflowY)] = OverflowY;
                res[nameof(Float)] = Float;
                if (BackGround is not null) res[nameof(BackGround)] = BackGround;
                if (MixBlendMode != BlendModes.None) res[nameof(MixBlendMode)] = MixBlendMode;
                if (BackGroundColor is not null) res[nameof(BackGroundColor)] = BackGroundColor;
                res[nameof(BackGroundSubtle)] = BackGroundSubtle;
                res[nameof(BackGroundGradient)] = BackGroundGradient;
                res[nameof(BackGroundOpacity)] = BackGroundOpacity;
                if (TextColor is not null) res[nameof(TextColor)] = TextColor;
                if (TextBackGroundColor is not null) res[nameof(TextBackGroundColor)] = TextBackGroundColor;
                res[nameof(TextEmphasis)] = TextEmphasis;
                if (TextSize.HasValue) res[nameof(TextSize)] = TextSize.Value;
                if (FontStyle.HasValue) res[nameof(FontStyle)] = FontStyle.Value;
                if (HAlign.HasValue) res[nameof(HAlign)] = HAlign.Value;
                if (VAlign.HasValue) res[nameof(VAlign)] = VAlign.Value;
                res[nameof(Wrap)] = Wrap;
                res[nameof(NoWrap)] = NoWrap;
                res[nameof(Truncate)] = Truncate;
                res[nameof(Muted)] = Muted;
                if (Selection.HasValue) res[nameof(Selection)] = Selection.Value;
                res[nameof(Border)] = Border;
                if (BorderColor is not null) res[nameof(BorderColor)] = BorderColor;
                res[nameof(BorderEmphasis)] = BorderEmphasis;
                res[nameof(BorderOpacity)] = BorderOpacity;
                if (Style is not null) res[nameof(Style)] = Style;
                if (Color is not null) res[nameof(Color)] = Color;
                res[nameof(TextOpacity)] = TextOpacity;
                if (ZIndex.HasValue) res[nameof(ZIndex)] = ZIndex.Value;
                if (Attributes is not null) res[nameof(Attributes)] = Attributes;
                res[nameof(ShowOnLandscape)] = ShowOnLandscape;
                res[nameof(ShowOnSmallLandscape)] = ShowOnSmallLandscape;
                res[nameof(ShowOnPortrait)] = ShowOnPortrait;
                res[nameof(ShowOnSmallPortrait)] = ShowOnSmallPortrait;
                res[nameof(EnableOnLandscape)] = EnableOnLandscape;
                res[nameof(EnableOnSmallLandscape)] = EnableOnSmallLandscape;
                res[nameof(EnableOnPortrait)] = EnableOnPortrait;
                res[nameof(EnableOnSmallPortrait)] = EnableOnSmallPortrait;
                res[nameof(IsActive)] = IsActive;
                res[nameof(Disabled)] = Disabled;
                res[nameof(Hidden)] = Hidden;
                if (ForcedColorMode.HasValue) res[nameof(ForcedColorMode)] = ForcedColorMode;
                return res;
            }
        }

        /// <inheritdoc/>
        public virtual IEnumerable<string> ObjectProperties => [nameof(Id), nameof(Title), nameof(Role)];

        /// <inheritdoc/>
        public virtual IEnumerable<string> DesignProperties => [
            nameof(Flex),
            nameof(InlineFlex),
            nameof(Grow),
            nameof(Rounded),
            nameof(Shadow),
            nameof(Overflow),
            nameof(OverflowX),
            nameof(OverflowY),
            nameof(Float),
            nameof(BackGround),
            nameof(MixBlendMode),
            nameof(BackGroundColor),
            nameof(BackGroundSubtle),
            nameof(BackGroundGradient),
            nameof(BackGroundOpacity),
            nameof(TextColor),
            nameof(TextBackGroundColor),
            nameof(TextEmphasis),
            nameof(TextSize),
            nameof(FontStyle),
            nameof(HAlign),
            nameof(VAlign),
            nameof(Wrap),
            nameof(NoWrap),
            nameof(Truncate),
            nameof(Muted),
            nameof(Selection),
            nameof(Border),
            nameof(BorderColor),
            nameof(BorderEmphasis),
            nameof(BorderOpacity),
            nameof(Style),
            nameof(Color),
            nameof(TextOpacity),
            nameof(ZIndex),
            nameof(Attributes),
            nameof(ForcedColorMode)
            ];

        /// <inheritdoc/>
        public virtual IEnumerable<string> AccessabilityProperties => [
            nameof(ShowOnLandscape),
            nameof(ShowOnSmallLandscape),
            nameof(ShowOnPortrait),
            nameof(ShowOnSmallPortrait),
            nameof(EnableOnLandscape),
            nameof(EnableOnSmallLandscape),
            nameof(EnableOnPortrait),
            nameof(EnableOnSmallPortrait),
            nameof(IsActive),
            nameof(Disabled),
            nameof(Hidden)
            ];

        /// <inheritdoc/>
        public virtual string? Id { get; set; }

        /// <inheritdoc/>
        public virtual string? Title { get; set; }

        /// <inheritdoc/>
        public virtual string? Role { get; set; }

        /// <inheritdoc/>
        public virtual string? Class { get; set; }

        /// <inheritdoc/>
        public virtual FlexBoxTypes Flex { get; set; }

        /// <inheritdoc/>
        public virtual bool InlineFlex { get; set; }

        /// <inheritdoc/>
        public virtual bool Grow { get; set; }

        /// <inheritdoc/>
        public virtual bool Rounded { get; set; }

        /// <inheritdoc/>
        public virtual ShadowTypes Shadow { get; set; }

        /// <inheritdoc/>
        public virtual OverflowTypes Overflow { get; set; }

        /// <inheritdoc/>
        public virtual OverflowTypes OverflowX { get; set; }

        /// <inheritdoc/>
        public virtual OverflowTypes OverflowY { get; set; }

        /// <inheritdoc/>
        public virtual HorizontalAligns Float { get; set; } = HorizontalAligns.Center;

        /// <inheritdoc/>
        public BackGroundParameters? BackGround { get; set; }

        /// <inheritdoc/>
        public BlendModes MixBlendMode { get; set; }

        /// <inheritdoc/>
        public virtual string? BackGroundColor { get; set; }

        /// <inheritdoc/>
        public virtual bool BackGroundSubtle { get; set; }

        /// <inheritdoc/>
        public virtual bool BackGroundGradient { get; set; }

        /// <inheritdoc/>
        public virtual Opacities BackGroundOpacity { get; set; }

        /// <inheritdoc/>
        public virtual string? TextColor { get; set; }

        /// <inheritdoc/>
        public virtual string? TextBackGroundColor { get; set; }

        /// <inheritdoc/>
        public virtual bool TextEmphasis { get; set; }

        /// <inheritdoc/>
        public virtual Sizes? TextSize { get; set; }

        /// <inheritdoc/>
        public virtual FontStyles? FontStyle { get; set; }

        /// <inheritdoc/>
        public virtual HorizontalAligns? HAlign { get; set; }

        /// <inheritdoc/>
        public virtual VerticalAligns? VAlign { get; set; }

        /// <inheritdoc/>
        public virtual bool Wrap { get; set; }

        /// <inheritdoc/>
        public virtual bool NoWrap { get; set; }

        /// <inheritdoc/>
        public virtual bool Truncate { get; set; }

        /// <inheritdoc/>
        public virtual bool Muted { get; set; }

        /// <inheritdoc/>
        public virtual TextSelections? Selection { get; set; }

        /// <inheritdoc/>
        public virtual Borders Border { get; set; }

        /// <inheritdoc/>
        public virtual string? BorderColor { get; set; }

        /// <inheritdoc/>
        public virtual bool BorderEmphasis { get; set; }

        /// <inheritdoc/>
        public virtual Opacities BorderOpacity { get; set; }

        /// <inheritdoc/>
        public virtual bool IsActive { get; set; }

        /// <inheritdoc/>
        public virtual string? Style { get; set; }

        /// <inheritdoc/>
        public virtual string? Color { get; set; }

        /// <inheritdoc/>
        public virtual Opacities TextOpacity { get; set; }

        /// <inheritdoc/>
        public virtual int? ZIndex { get; set; }

        /// <inheritdoc/>
        public virtual Dictionary<string, object>? Attributes { get; set; }

        /// <inheritdoc/>
        public virtual bool Disabled { get; set; }

        /// <inheritdoc/>
        public virtual bool Hidden { get; set; }

        /// <inheritdoc/>
        public virtual bool ShowOnLandscape { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowOnSmallLandscape { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowOnPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool ShowOnSmallPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool EnableOnLandscape { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool EnableOnSmallLandscape { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool EnableOnPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual bool EnableOnSmallPortrait { get; set; } = true;

        /// <inheritdoc/>
        public virtual BsThemeMode? ForcedColorMode { get; set; }

        /// <inheritdoc/>
        public override void ApplyToExcluding(in IParameters other, params string[] excludeProperties)
        {
            if (other is IBlazorComponentParameters blazor)
            {
                if (Id is not null && !excludeProperties.Contains(nameof(Id))) blazor.Id = Id;
                if (Title is not null && !excludeProperties.Contains(nameof(Title))) blazor.Title = Title;
                if (Role is not null && !excludeProperties.Contains(nameof(Role))) blazor.Role = Role;
                if (Class is not null && !excludeProperties.Contains(nameof(Class))) blazor.Class = Class;
                if (!excludeProperties.Contains(nameof(Flex))) blazor.Flex = Flex;
                if (!excludeProperties.Contains(nameof(InlineFlex))) blazor.InlineFlex = InlineFlex;
                if (!excludeProperties.Contains(nameof(Grow))) blazor.Grow = Grow;
                if (!excludeProperties.Contains(nameof(Rounded))) blazor.Rounded = Rounded;
                if (!excludeProperties.Contains(nameof(Shadow))) blazor.Shadow = Shadow;
                if (!excludeProperties.Contains(nameof(Overflow))) blazor.Overflow = Overflow;
                if (!excludeProperties.Contains(nameof(OverflowX))) blazor.OverflowX = OverflowX;
                if (!excludeProperties.Contains(nameof(OverflowY))) blazor.OverflowY = OverflowY;
                if (!excludeProperties.Contains(nameof(Float))) blazor.Float = Float;
                if (BackGround is not null && !excludeProperties.Contains(nameof(BackGround))) blazor.BackGround = BackGround;
                if (MixBlendMode != BlendModes.None && !excludeProperties.Contains(nameof(MixBlendMode))) blazor.MixBlendMode = MixBlendMode;
                if (BackGroundColor is not null && !excludeProperties.Contains(nameof(BackGroundColor))) blazor.BackGroundColor = BackGroundColor;
                if (!excludeProperties.Contains(nameof(BackGroundSubtle))) blazor.BackGroundSubtle = BackGroundSubtle;
                if (!excludeProperties.Contains(nameof(BackGroundGradient))) blazor.BackGroundGradient = BackGroundGradient;
                if (!excludeProperties.Contains(nameof(BackGroundOpacity))) blazor.BackGroundOpacity = BackGroundOpacity;
                if (TextColor is not null && !excludeProperties.Contains(nameof(TextColor))) blazor.TextColor = TextColor;
                if (TextBackGroundColor is not null && !excludeProperties.Contains(nameof(TextBackGroundColor))) blazor.TextBackGroundColor = TextBackGroundColor;
                if (TextSize.HasValue && !excludeProperties.Contains(nameof(TextSize))) blazor.TextSize = TextSize.Value;
                if (FontStyle.HasValue && !excludeProperties.Contains(nameof(FontStyle))) blazor.FontStyle = FontStyle.Value;
                if (HAlign.HasValue && !excludeProperties.Contains(nameof(HAlign))) blazor.HAlign = HAlign.Value;
                if (VAlign.HasValue && !excludeProperties.Contains(nameof(VAlign))) blazor.VAlign = VAlign.Value;
                if (!excludeProperties.Contains(nameof(Wrap))) blazor.Wrap = Wrap;
                if (!excludeProperties.Contains(nameof(NoWrap))) blazor.NoWrap = NoWrap;
                if (!excludeProperties.Contains(nameof(Truncate))) blazor.Truncate = Truncate;
                if (!excludeProperties.Contains(nameof(Muted))) blazor.Muted = Muted;
                if (Selection.HasValue && !excludeProperties.Contains(nameof(Selection))) blazor.Selection = Selection.Value;
                if (!excludeProperties.Contains(nameof(Border))) blazor.Border = Border;
                if (BorderColor is not null && !excludeProperties.Contains(nameof(BorderColor))) blazor.BorderColor = BorderColor;
                if (!excludeProperties.Contains(nameof(BorderEmphasis))) blazor.BorderEmphasis = BorderEmphasis;
                if (!excludeProperties.Contains(nameof(BorderOpacity))) blazor.BorderOpacity = BorderOpacity;
                if (!excludeProperties.Contains(nameof(IsActive))) blazor.IsActive = IsActive;
                if (Style is not null && !excludeProperties.Contains(nameof(Style))) blazor.Style = Style;
                if (Color is not null && !excludeProperties.Contains(nameof(Color))) blazor.Color = Color;
                if (!excludeProperties.Contains(nameof(TextOpacity))) blazor.TextOpacity = TextOpacity;
                if (ZIndex.HasValue && !excludeProperties.Contains(nameof(ZIndex))) blazor.ZIndex = ZIndex.Value;
                if (Attributes is not null && !excludeProperties.Contains(nameof(Attributes))) blazor.Attributes = Attributes;
                if (!excludeProperties.Contains(nameof(Disabled))) blazor.Disabled = Disabled;
                if (!excludeProperties.Contains(nameof(Hidden))) blazor.Hidden = Hidden;
                if (!excludeProperties.Contains(nameof(ShowOnLandscape))) blazor.ShowOnLandscape = ShowOnLandscape;
                if (!excludeProperties.Contains(nameof(ShowOnSmallLandscape))) blazor.ShowOnSmallLandscape = ShowOnSmallLandscape;
                if (!excludeProperties.Contains(nameof(ShowOnPortrait))) blazor.ShowOnPortrait = ShowOnPortrait;
                if (!excludeProperties.Contains(nameof(ShowOnSmallPortrait))) blazor.ShowOnSmallPortrait = ShowOnSmallPortrait;
                if (!excludeProperties.Contains(nameof(EnableOnLandscape))) blazor.EnableOnLandscape = EnableOnLandscape;
                if (!excludeProperties.Contains(nameof(EnableOnSmallLandscape))) blazor.EnableOnSmallLandscape = EnableOnSmallLandscape;
                if (!excludeProperties.Contains(nameof(EnableOnPortrait))) blazor.EnableOnPortrait = EnableOnPortrait;
                if (!excludeProperties.Contains(nameof(EnableOnSmallPortrait))) blazor.EnableOnSmallPortrait = EnableOnSmallPortrait;
                if (ForcedColorMode.HasValue && !excludeProperties.Contains(nameof(ForcedColorMode))) blazor.ForcedColorMode = ForcedColorMode.Value;
            }
        }

        /// <inheritdoc/>
        public override void ApplyToIncluding(in IParameters other, params string[] includeProperties)
        {
            if (other is IBlazorComponentParameters blazor)
            {
                if (Id is not null && includeProperties.Contains(nameof(Id))) blazor.Id = Id;
                if (Title is not null && includeProperties.Contains(nameof(Title))) blazor.Title = Title;
                if (Role is not null && includeProperties.Contains(nameof(Role))) blazor.Role = Role;
                if (Class is not null && includeProperties.Contains(nameof(Class))) blazor.Class = Class;
                if (includeProperties.Contains(nameof(Flex))) blazor.Flex = Flex;
                if (includeProperties.Contains(nameof(InlineFlex))) blazor.InlineFlex = InlineFlex;
                if (includeProperties.Contains(nameof(Grow))) blazor.Grow = Grow;
                if (includeProperties.Contains(nameof(Rounded))) blazor.Rounded = Rounded;
                if (includeProperties.Contains(nameof(Shadow))) blazor.Shadow = Shadow;
                if (includeProperties.Contains(nameof(Overflow))) blazor.Overflow = Overflow;
                if (includeProperties.Contains(nameof(OverflowX))) blazor.OverflowX = OverflowX;
                if (includeProperties.Contains(nameof(OverflowY))) blazor.OverflowY = OverflowY;
                if (includeProperties.Contains(nameof(Float))) blazor.Float = Float;
                if (BackGround is not null && includeProperties.Contains(nameof(BackGround))) blazor.BackGround = BackGround;
                if (MixBlendMode != BlendModes.None && includeProperties.Contains(nameof(MixBlendMode))) blazor.MixBlendMode = MixBlendMode;
                if (BackGroundColor is not null && includeProperties.Contains(nameof(BackGroundColor))) blazor.BackGroundColor = BackGroundColor;
                if (includeProperties.Contains(nameof(BackGroundSubtle))) blazor.BackGroundSubtle = BackGroundSubtle;
                if (includeProperties.Contains(nameof(BackGroundGradient))) blazor.BackGroundGradient = BackGroundGradient;
                if (includeProperties.Contains(nameof(BackGroundOpacity))) blazor.BackGroundOpacity = BackGroundOpacity;
                if (TextColor is not null && includeProperties.Contains(nameof(TextColor))) blazor.TextColor = TextColor;
                if (TextBackGroundColor is not null && includeProperties.Contains(nameof(TextBackGroundColor))) blazor.TextBackGroundColor = TextBackGroundColor;
                if (TextSize.HasValue && includeProperties.Contains(nameof(TextSize))) blazor.TextSize = TextSize.Value;
                if (FontStyle.HasValue && includeProperties.Contains(nameof(FontStyle))) blazor.FontStyle = FontStyle.Value;
                if (HAlign.HasValue && includeProperties.Contains(nameof(HAlign))) blazor.HAlign = HAlign.Value;
                if (VAlign.HasValue && includeProperties.Contains(nameof(VAlign))) blazor.VAlign = VAlign.Value;
                if (includeProperties.Contains(nameof(Wrap))) blazor.Wrap = Wrap;
                if (includeProperties.Contains(nameof(NoWrap))) blazor.NoWrap = NoWrap;
                if (includeProperties.Contains(nameof(Truncate))) blazor.Truncate = Truncate;
                if (includeProperties.Contains(nameof(Muted))) blazor.Muted = Muted;
                if (Selection.HasValue && includeProperties.Contains(nameof(Selection))) blazor.Selection = Selection.Value;
                if (includeProperties.Contains(nameof(Border))) blazor.Border = Border;
                if (BorderColor is not null && includeProperties.Contains(nameof(BorderColor))) blazor.BorderColor = BorderColor;
                if (includeProperties.Contains(nameof(BorderEmphasis))) blazor.BorderEmphasis = BorderEmphasis;
                if (includeProperties.Contains(nameof(BorderOpacity))) blazor.BorderOpacity = BorderOpacity;
                if (includeProperties.Contains(nameof(IsActive))) blazor.IsActive = IsActive;
                if (Style is not null && includeProperties.Contains(nameof(Style))) blazor.Style = Style;
                if (Color is not null && includeProperties.Contains(nameof(Color))) blazor.Color = Color;
                if (includeProperties.Contains(nameof(TextOpacity))) blazor.TextOpacity = TextOpacity;
                if (ZIndex.HasValue && includeProperties.Contains(nameof(ZIndex))) blazor.ZIndex = ZIndex.Value;
                if (Attributes is not null && includeProperties.Contains(nameof(Attributes))) blazor.Attributes = Attributes;
                if (includeProperties.Contains(nameof(Disabled))) blazor.Disabled = Disabled;
                if (includeProperties.Contains(nameof(Hidden))) blazor.Hidden = Hidden;
                if (includeProperties.Contains(nameof(ShowOnLandscape))) blazor.ShowOnLandscape = ShowOnLandscape;
                if (includeProperties.Contains(nameof(ShowOnSmallLandscape))) blazor.ShowOnSmallLandscape = ShowOnSmallLandscape;
                if (includeProperties.Contains(nameof(ShowOnPortrait))) blazor.ShowOnPortrait = ShowOnPortrait;
                if (includeProperties.Contains(nameof(ShowOnSmallPortrait))) blazor.ShowOnSmallPortrait = ShowOnSmallPortrait;
                if (includeProperties.Contains(nameof(EnableOnLandscape))) blazor.EnableOnLandscape = EnableOnLandscape;
                if (includeProperties.Contains(nameof(EnableOnSmallLandscape))) blazor.EnableOnSmallLandscape = EnableOnSmallLandscape;
                if (includeProperties.Contains(nameof(EnableOnPortrait))) blazor.EnableOnPortrait = EnableOnPortrait;
                if (includeProperties.Contains(nameof(EnableOnSmallPortrait))) blazor.EnableOnSmallPortrait = EnableOnSmallPortrait;
                if (ForcedColorMode.HasValue && includeProperties.Contains(nameof(ForcedColorMode))) blazor.ForcedColorMode = ForcedColorMode.Value;
            }
        }
    }
}
