# wan24-Blazor

This Razor library contains Blazor (.NET 8) WebAssembly components and tools 
with Bootstrap 5 support for Blazor clients (not server side rendering).

**Included** is:

- Layout components
- Several inheritable components
- Bootstrap Icons version 1.11.3 SVG images (as generated C# code, from the 
referenced `wan24-Blazor-Shared` NuGet package)
- A bunch of validation attributes
- DOM manipulation helper
- File download helper (for sending a computed file download to the client 
browser) for the WebAssembly and JavaScript
- Stream helper (for sending a computed stream to any stream consumer) for the 
WebAssembly and JavaScript

**Excluded** is:

- Bootstrap Icons SVG files (the SVG XML accessable using the `Images` class 
only)
- The Bootstrap Icons `bootstrap.svg` file was excluded completely (also from 
the generated C# code in the `wan24-Blazor-Shared` NuGet package)
- Bootstrap 5 JS and CSS (reference the 
[`wan24-Blazor-Bootstrap` NuGet package](https://www.nuget.org/packages/wan24-Blazor-Bootstrap/))
- Bootstrap Icons fonts and CSS (reference the 
[`wan24-Blazor-BootstrapIcons` NuGet package](https://www.nuget.org/packages/wan24-Blazor-BootstrapIcons/))

## Usage

See the `src/wan24-Blazor Demo` project for an example. The release build of 
this example is hosted online 
[here](https://nd1012.github.io/wan24-Blazor/demo/).

### How to get it

This library is available as a 
[NuGet package](https://www.nuget.org/packages/wan24-Blazor/).

There's a library with shared types which you may use at the server side, for 
example: 
[`wan24-Blazor-Shared` NuGet package](https://www.nuget.org/packages/wan24-Blazor-Shared/)
This library doesn't reference any ASP.NET Core dependencies ('cause it's 
contents doesn't need Razor or Blazor in order to be able to work).

### Pre-requirements

The examples shwow the setup for a hybrid Blazor app (.NET MAUI) and a client 
Blazor WebAssembly app. Server side Razor rendering isn't supported at this 
time (however, it may work partial).

#### Modify your app startup

Minimal setup for a WebAssembly browser app (`Program.cs`):

```cs
// WebAssembly builder
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure wan24-Core
wan24.Core.Translation.Current = wan24.Core.Translation.Dummy;

// Initialize wan24-Blazor
wan24.Blazor.BuildType build = BuildType.Browser;
#if RELEASE
build |= BuildType.Release;
#else
build |= BuildType.Debug;
#endif
await wan24.Blazor.Startup.StartAsync(
	wan24.Blazor.GuiTypes.WASM, 
	build, 
	builder.Services
	);

// Other initializations

// Run the app
await builder.Build().RunAsync();
```

Minimal setup for a hybrid Blazor MAUI app (`MauiProgram.cs`):

```cs
// MAUI builder
var builder = MauiApp.CreateBuilder();

// Configure wan24-Core
wan24.Core.Translation.Current = wan24.Core.Translation.Dummy;

// Initialize wan24-Blazor
wan24.Blazor.BuildType build = 
#if WINDOWS
	wan24.Blazor.BuildType.Windows
#elif MACCATALYST
	wan24.Blazor.BuildType.MacCatalyst
#elif IOS
	wan24.Blazor.BuildType.IOS
#elif ANDROID
	wan24.Blazor.BuildType.Android
#else
	throw new InvalidProgramException("Unknown build")
#endif
	;
#if RELEASE
build |= wan24.Blazor.BuildType.Release;
#else
build |= wan24.Blazor.BuildType.Debug;
#endif
wan24.Blazor.Startup.Start(
	wan24.Blazor.GuiTypes.MAUI, 
	build, 
	builder.Services
	);

// Other initializations

// Build the app
return builder.Build();
```

#### Modify the `Components/_Imports.razor`

Optional imports which may be helpful:

```razor
// General
@using wan24.Blazor;// Some extensions
@using wan24.Blazor.Parameters;// Base parameters
@using wan24.Blazor.Parameters.Complex;// Complex parameters
@using wan24.Blazor.Components;// Base components
@using wan24.Blazor.Components.Layouts;// Layout components
@using wan24.Blazor.Components.Complex;// Complex components
@using wan24.Core;// Many .NET extensions
@using wan24.ObjectValidation;// Validation attributes

// Blazor tools
@using static wan24.Blazor.BlazorEnv;// WebAssembly environment
@using static wan24.Blazor.BlazorTools;// Blazor tools
@using static wan24.Blazor.GuiEnv;// GUI enironment
@using static wan24.Blazor.Helper;// Useful helper methods
@using static wan24.Blazor.ToastLogger;// Toast message helper

// i8n tools
@using static wan24.Core.Translation;// i8n
@using static wan24.Core.TranslationHelper;// i8n helper methods
@using static wan24.Core.TranslationHelper.Ext;// More i8n helper methods

// Logging tools
@using static wan24.Core.Logger;// Logging environment
@using static wan24.Core.Logging;// Logging helper
```

#### Modify the `wwwroot/index.html`

**NOTE**: You'll need to load Bootstrap version 5 CSS (and JS) in your 
`index.html` and you can remove the existing Bootstrap CSS which comes from 
the Visual Studio project template. Reference the 
[`wan24-Blazor-Bootstrap` NuGet package](https://www.nuget.org/packages/wan24-Blazor-Bootstrap/) 
to always use the latest Bootstrap version in your app, which is compatible 
with the latest `wan24-Blazor` (and `wan24-Blazor-BootstrapIcons`) package 
version.

A full example for a PWA app (similar for a non-PWA WebAssembly client app) 
with the minimum required setup:

```html
<!DOCTYPE html>
<html lang="en" class="vw-100 vh-100">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Your app</title>
    <base href="/" />
    <link rel="stylesheet" href="css/bootstrap/bootstrap5.min.css" />
    <link rel="stylesheet" href="css/app.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <link href="{ASSEMBLY}.styles.css" rel="stylesheet" />
    <link href="manifest.webmanifest" rel="manifest" />
    <link rel="apple-touch-icon" sizes="512x512" href="icon-512.png" />
    <link rel="apple-touch-icon" sizes="192x192" href="icon-192.png" />
</head>

<body class="vw-100 vh-100">

    <div id="app" class="vw-100 vh-100">
        <svg class="loading-progress">
            <circle r="40%" cx="50%" cy="50%" />
            <circle r="40%" cx="50%" cy="50%" />
        </svg>
        <div class="loading-progress-text"></div>
    </div>

    <div id="blazor-error-ui">
        An unhandled error has occurred.
        <a href="" class="reload">Reload</a>
        <a class="dismiss">🗙</a>
    </div>

    <script src="_framework/blazor.webassembly.js"></script>
    <script>navigator.serviceWorker.register('service-worker.js');</script>

</body>

</html>
```

A full example for a hybrid Blazor MAUI app with the minimum required setup:

```html
<!DOCTYPE html>
<html lang="en" class="vw-100 vh-100">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no, viewport-fit=cover" />
    <title>Your app</title>
    <base href="/" />
    <link rel="stylesheet" href="css/bootstrap5.min.css" />
    <link rel="stylesheet" href="css/app.css" />
    <link rel="stylesheet" href="{ASSEMBLY}.styles.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
</head>

<body class="vw-100 vh-100">

    <div class="status-bar-safe-area"></div>

    <div id="app" class="vw-100 vh-100">Loading...</div>

    <div id="blazor-error-ui">
        An unhandled error has occurred.
        <a href="" class="reload">Reload</a>
        <a class="dismiss">🗙</a>
    </div>

    <script src="_framework/blazor.webview.js" autostart="false"></script>

</body>

</html>
```

The CSS classes `vw-100 vh-100` ensure that the app uses the whole available 
space - which is optional, but recommended.

#### Modify the `Layout/MainLayout.razor`

Example:

```razor
@inherits FlexLayoutBase

@{
    base.BuildRenderTree(__builder);
}

@code {
    public MainLayout() : base()
    {
        // Configure the demo theme
        Theme = Bs5Theme.Demo;
        // Configure the sidebar
        Sidebar = typeof(NavMenu);
        ShowSidebarOnSmallLandscape = false;
        // Configure the body
        BodyParameters = new()
        {
            {nameof(Content.BackGroundGradient), true}
        };
        // Handle color mode changes (dark/light mode)
        HandleColorModeChange();
        ColorModeChangesState = true;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            // Attach to color mode change events
            BlazorEnv.OnColorModeChanged += HandleColorModeChange;
        }
        base.OnAfterRender(firstRender);
    }

    protected override void Dispose(bool disposing)
    {
        // Detach from color mode change events
        BlazorEnv.OnColorModeChanged -= HandleColorModeChange;
        base.Dispose(disposing);
    }

    protected override Task DisposeCore()
    {
        // Detach from color mode change events
        BlazorEnv.OnColorModeChanged -= HandleColorModeChange;
        return base.DisposeCore();
    }

    private void HandleColorModeChange()
    {
        // Set the body background color depending on the current color mode
        BodyParameters![nameof(Content.BackGroundColor)] = BlazorEnv.LightMode ? Colors.Light : Colors.Dark;
    }
}
```

#### Modify the `Layout/NavMenu.razor`

Example:

```razor
@inherits ComponentBase

<Bar Flex=@Orientation.ToFlexBoxType() BackGroundGradient ShowTextHorizontal="false">
    <BarBranding Href="/" Text="wan24-Blazor Demo" />
    <BarItem Href="/" Text="Home" IconParameters=@Images.Icon_house.AsImageParameters() />
    <BarItem Href="/counter" Text="Counter" IconParameters=@Images.Icon_123.AsImageParameters() />
    <BarItem Href="/weather" Text="Weather" IconParameters=@Images.Icon_cloud.AsImageParameters() />
</Bar>

@code {
    /// <summary>
    /// Orientation
    /// </summary>
    [CascadingParameter]
    public Orientations Orientation{ get; set; }
}
```

#### The resulting layout

Since we didn't change the pages to use the `wan24-Blazor` base components 
yet, we'll only get a responsive layout with an orange tone as primary color. 
The menu item text won't be visible on a portrait screen, and also the sidebar 
will be displayed at the bottom of the layout. When you switch your browser 
(your system settings) to dark/light mode, the colors of the layout should be 
switched, too. When you view the app on a small (smartphone) landscape screen, 
the sidebar won't be shown at all, because it's assumed that the user want to 
use all the space available for content display.

### Components

#### Layout

The `LayoutBase` is a layout base component, which is used by 
`FlexLayoutBase`. The `FlexLayoutBase` allows

| Element | Display | Type property | Parameters property | Overriding section property | Section component |
| ------- | ------- | ------------- | ------------------- | --------------------------- | ----------------- |
| top header | on top of the screen | `TopHeader` | `TopHeaderParameters` | `TopHeaderSection` | `FlexLayoutTopHeader` |
| sidebar | at the side of the content between top header and bottom footer | `Sidebar` | `SidebarParameters` | `SidebarSection` | `FlexLayoutSidebar` |
| header | on top of the body | `Header` | `HeaderParameters` | `HeaderSection` | `FlexLayoutHeader` |
| body header | on top of the body, scrolls with the body content | `BodyHeader` | `BodyHeaderParameters` | `BodyHeaderSection` | `FlexLayoutBodyHeader` |
| body footer | at the bottom of the body, scrolls with the body content | `BodyFooter` | `BodyFooterParameters` | `BodyFooterSection` | `FlexLayoutBodyFooter` |
| content sidebar | at the side of the content | `ContentSidebar` | `ContentSidebarParameters` | `ContentSidebarSection` | `FlexLayoutContentSidebar` |
| footer | at the bottom of the body | `Footer` | `FooterParameters` | `FooterSection` | `FlexLayoutFooter` |
| bottom footer | at the bottom of the screen | `BottomFooter` | `BottomFooterParameters` | `BottomFooterSection` | `FlexLayoutBottomFooter` |

`LayoutBase` cascades its instance, so you can access the active layout 
instance from any child component like this:

```razor
@code {
	[CascadingParameter]
	public MainLayout? Layout { get; set; }
}
```

The full layout can look like this:

```text
________________________________________________________________________________
| Top header                                                                   |
================================================================================
| Sidebar | Header                                                             |
|         |____________________________________________________________________|
|         | Body header                                              | Content |
|         |__________________________________________________________| sidebar |
|         | Body                                                     |         |
|         |                                                          |         |
|         |                                                          |         |
|         |                                                          |         |
|         |                                                          |         |
|         |                                                          |         |
|         |__________________________________________________________|         |
|         | Body footer                                              |         |
|         |====================================================================|
|         | Footer                                                             |
================================================================================
| Bottom footer                                                                |
--------------------------------------------------------------------------------
```

If you set `StretchContentSidebar` to `true`, it'd change to this instead:

```text
________________________________________________________________________________
| Top header                                                                   |
================================================================================
| Sidebar | Header                                                   | Content |
|         |__________________________________________________________| sidebar |
|         | Body header                                              |         |
|         |__________________________________________________________|         |
|         | Body                                                     |         |
|         |                                                          |         |
|         |                                                          |         |
|         |                                                          |         |
|         |                                                          |         |
|         |                                                          |         |
|         |__________________________________________________________|         |
|         | Body footer                                              |         |
|         |__________________________________________________________|         |
|         | Footer                                                   |         |
================================================================================
| Bottom footer                                                                |
--------------------------------------------------------------------------------
```

Body and content sidebar are scrollable, while other areas hide the overflow. 
The layout uses the whole space with the body as growing element. Other 
elements should only use the space that they need - however, you may specify a 
fixed width or height on them also.

The types (which inherit `ComponentBase`) that you want to use you can 
configure as parameters or from the constructor of your `MainLayout.razor`, as 
in the examples above.

You may also define the display and apperance behavior of any layout element 
for

- landscape
- portrait

display on

- small
- large

screens. A display change (landscape <-> portrait or small <-> large screen) 
will force re-rendering of the whole page, unless you set 
`DisplayChangesState` to `false`.

To design custom layouts, your layout should inherit `LayoutBase`. Many 
properties and methods are virtual.

**NOTE**: The layout does output comments in a debug build only - they won't 
appear in a relese build.

##### Override layout components per page / child content

A page which uses the flex layout (or any flex layout child content) may 
override any layout component using the section components (see the table 
above). Example:

```razor
@using Microsoft.AspNetCore.Components.Sections;
@page "/path"

<SectionContent SectionId="FlexLayoutBase.ContentSidebarSection">
	<!-- Overridden content of the content sidebar here -->
</SectionContent>

<!-- Page markup here -->
```

In case your flex layout based layout defined a content sidebar already, it'll 
be overridden by the child content of the `SectionContent`, if the URI `/path` 
is being displayed in the browser. This means: Your flex layout based layout 
may define default page components, which may be overriden by a page or its 
child content.

Anyway, your layout defines the display behavior (in landscape/portrait view 
on large/small screens), which can't be overridden. The flexibility is limited 
to the layout components only - but within these components you can of course 
control their display behavior as required.

#### Factory components

| Component | Description | Inherits | HTML tag | Section |
| --------- | ----------- | -------- | -------- | ------- |
| **General** |  |  |  |  |
| `Box` | Generic HTML element which may be a flex box | `ParentComponentBase` | `div` | `UseBoxSection` |
| `ColumnFlexBox` | Column direction flex box | `Box` | `div` | - |
| `RowFlexBox` | Row direction flex box | `Box` | `div` | - |
| `GrowBox` | Generic growing flex box content which may be a flex box, too | `Box` | `div` | - |
| `Content` | Content container with padding which may be a flex box | `Box` | `div` | - |
| `Divider` | Horizontal/vertical divider | `Box` | `div` | - |
| `Inline` | Inline container | `Box` | `span` | - |
| **Text** |  |  |  |  |
| `LeadText` | Lead text container | `BodyText` | `p` | - |
| `BodyText` | Text container | `Box` | `p` | - |
| `SmallText` | Small text container | `BodyText` | `small` | - |
| `PageHeading` | Page `h1` and title (of the browser window) | `ParentComponentBase` | `h1` | - |
| **Images** |  |  |  |  |
| `Image` | To display an image from an URI or SVG XML | `Box` | `img` or `span` (if SVG XML and no custom tag name was defined) | `UseImageSection` |
| **Clickable** |  |  |  |  |
| `Clickable` | Click handling generic HTML element (may navigate, if `Href` was set) | `Box` | `div` | - |
| `Link` | Link HTML element | `Clickable` | `a` | - |
| `HoverLink` | Link HTML element which shows an underline only when hovering | `Link` | `a` | - |
| `ClickButton` | Button with text and/or icon | `Clickable` | `button` | - |
| `MenuItem` | Generic menu item with text and/or icon | `ClickButton` | `div` | - |
| **Flex layout** |  |  |  |  |
| `FlexLayoutTopHeader` | Override the top header of the layout | `ComponentBase` | - | - |
| `FlexLayoutSidebar` | Override the sidebar of the layout | `ComponentBase` | - | - |
| `FlexLayoutHeader` | Override the header of the layout | `ComponentBase` | - | - |
| `FlexLayoutBodyHeader` | Override the body header of the layout | `ComponentBase` | - | - |
| `FlexLayoutBodyFoter` | Override the body footer of the layout | `ComponentBase` | - | - |
| `FlexLayoutContentSidebar` | Override the content sidebar of the layout | `ComponentBase` | - | - |
| `FlexLayoutFooter` | Override the footer of the layout | `ComponentBase` | - | - |
| `FlexLayoutBottomBooter` | Override the bottom footer of the layout | `ComponentBase` | - | - |
| **Complex** |  |  |  |  |
| `Bar` | A menu bar | `Box` | `div` | - |
| `BarItemBase` | An abstract base component for a menu bar item | `ParentComponentBase` | - | - |
| `BarItem` | A menu bar item | `BarItemBase` | - | - |
| `BarBranding` | A menu bar branding | `BarItem` | - | - |
| **Others** |  |  |  |  |
| `Theme` | For applying a `BsTheme` inline | `ComponentBase` | `style` | - |

All components inherit `BlazorComponentBase` and `ParentComponentBase`, so they

| Feature | Using | Bootstrap/CSS |
| ------- | ----- | ------------- |
| **HTML** | | |
| allow defining the HTML tag | parameter `TagName="..."` | - |
| allow adding an ID | parameter `Id="..."` | - |
| allow adding a title | parameter `Title="..."` | - |
| allow custom attributes | parameter `Attributes="..."` | - |
| **CSS** | | |
| allow CSS class customization | parameter `Class="..."` | - |
| allow CSS style customization | parameter `Style="..."` | - |
| may have rounded edges | parameter `Rounded` | `rounded` |
| may drop a shadow | parameter `Shadow="..."` | `shadow(-sm/lg)` |
| allow overflow behavior customization | parameter `Overflow(X/Y)="..."` | `overflow(-x/y)-hidden/visible/scroll` |
| allow setting a z-index (also set as attribute) | parameter `ZIndex="..."` | - |
| allow floating | parameter `Float="..."` | `float-start/end` |
| allow setting a background color | parameter `BackGroundColor="..."` | `bg-[COLOR]` |
| allow subtle background color | parameter `BackGroundSubtle` | `bg-[COLOR]-subtle` |
| allow background gradient color | parameter `BackGroundGradient` | `bg-gradient` |
| allow background opacity | parameter `BackGroundOpacity="..."` | `bg-opacity-[OPACITY]` |
| allow setting a text color | parameter `TextColor="..."` | `text-[COLOR]` |
| allow setting a background color with contrasting text color | parmeter `TextBackGroundColor="..."` | `text-bg-[COLOR]` |
| allow setting emphasis text color | parameter `TextEmphasis` | `text-[COLOR]-emphasis` |
| allow setting a text size | parameter `TextSize="..."` | `text-sm/lg/md-[ALIGN]` |
| allow setting a horizontal align | parameter `HAlign="..."` | `` |
| allow setting a vertical align | parameter `VAlign="..."` | `` |
| allow content wrapping | parameter `Wrap` | `wrap` |
| allow no content wrapping | parameter `NoWrap` | `no-wrap` |
| allow text truncation using ellipsis | paraeter `Truncate` | `text-truncate` |
| allow context selection behavior | parameter `Selection="..."` | `user-select-all/none/auto` |
| allow text opacity | parameter `TextOpacity="..."` | `--bs-text-opacity: [OPACITY]` |
| allow borders  | parameter `Border="..."` | `border(-top/bottom/start/end)` |
| allow border color | parameter `BorderColor="..."` | `border-[COLOR]` |
| allow border emphasis color | parameter `BorderColorEmphasis` | `border-[COLOR]-emphasis` |
| allow border opacity | parameter `BorderOpacity="..."` | `border-opacity-[OPACITY]` |
| allow a CSS color setting | parameter `Color="..."` | `color: [COLOR]` |
| allow disabled state (also set as attribute) | parameter `Disabled` | `disabled` |
| allow hidden state (set as attribute) | parameter `Hidden` | - |
| allow active state | parameter `IsActive` | `active` |
| **Flex box CSS** | | |
| allow flex column behavior | parameter `FlexBox` | `d-flex flex-column` |
| allow flex box behavior | parameter `Flex="..."` | `d-flex flex-row/column(-reverse)` |
| allow growing in a flex box | parameter `Grow` | `flex-grow-1` |
| can be an inline flex box | parameter `InlineFlex` (if any flex behavior was enabled) | `d-inline-flex` instead of `d-flex` |
| **Others** | | |
| include a protected click handler delegate template | protected method `OnClickAsync` | - |
| allow child elements | `ChildContent` | - |
| allow forcing rendering | method `Update` | - |
| **Configuration** | | |
| allow applying parameters on initialization | parameter `ApplyParameters` | - |
| allow exporting parameters | property `AllParameters` | - |
| allow getting default parameters | property `DefaultParameters` | - |
| allow getting current parameters | property `CurrentParameters` | - |
| allow getting object property names | property `ObjectProperties` | - |
| allow getting design property names | property `DesignProperties` | - |
| allow getting accessability property names | property `AccessabilityProperties` | - |
| allow applying parameters | method `ApplyToExcluding/Including` | - |

**NOTE**: The `TagName` parameter isn't part of `BlazorComponentBase` or 
`ParentComponentBase`, but all abstract components support defining the HTML 
tag to use with their base component (like `Box`).

When inheriting a component (base), use the `Factory*` properties for defining 
default (but overridable) configurations. Many properties and methods are 
virtual.

For disposable components, there are also `DisposableBlazorComponentBase`, 
`DisposableParentComponentBase` and `DisposableBoxBase` base classes.

##### Inheriting components

If you want to design own components by inheriting from the factory 
components, and your own component does have its own content to render, which 
should be rendered as child content of the inherited component, you'll have to 
work with `SectionContent` elements, enable using sections by the base 
component in your components constructor and render the `ChildContent` in your 
own components markup. Example for extending `Box`:

```razor
@inherits Box

<!-- The section content is going to be placed within the base markup instead of its usual content -->
<SectionContent SectionName=@UseBoxSection>
	<div class="...">
		<!-- When overriding, the child content needs to be rendered here instead -->
		@ChildContent
	</div>
</SectionContent>

@{
    base.BuildRenderTree(__builder);
}

@code {
	public YourComponent() : base() => UseBoxSection = CreateSectionId();
}
```

When a component supports `SectionContent` rendering, it has a property 
`Use*Section` to enable section rendering from your inheriting components 
constructor. Simply use the `BlazorTools.CreateSectionId` method to create 
a unique section ID (optional conditional).

**WARNING**: If you didn't enable section rendering of the base component, 
your components markup will override the base markup completely, unless you 
render the base components tree from your empty markup like this:

```razor
@{
    base.BuildRenderTree(__builder);
}
```

To override CSS classes, style and attributes of the parent component, use the 
`FactoryClass/Style/Attributes` property:

```cs
public override string? FactoryClass => $"{base.FactoryClass} your-class";

public override string? FactoryStyle => $"{base.FactoryStyle}; your: style;";

public override Dictionary<string, object>? FactoryAttributes
{
    get
    {
        Dictionary<string, object> res = base.FactoryAttributes ?? [];
        res["your"] = "attribute";
        return res;
    }
}
```

When the different values (factory and user values) are being combined, 
they'll be applied in this order:

1. Factory values
1. Property values (from the components specialized properties)
1. Attributes values (from `Attributes`)
1. User values

Each process can override the previous processes values.

### Icons

Using the `Images` class you can access all (2000+) Bootstrap Icons as data 
stream URI (for use in `<img src="..." />` in HTML or `url('...')` in CSS):

```razor
<Image Src=@Images.Icon_123 />
```

**WARNING**: Width, height and viewport attributes are removed from the 
original SVG XML! You should set a width and a height using the `Width` and 
`Height` properties.

**NOTE**: You can't access the Bootstrap Icons via http URI, because the files 
aren't included in the `wan24-Blazor` library. They're only accessable using 
the `Images` class.

**NOTE**: You can't access the Bootstrap Icons via http URI, because the files 
aren't included in the `wan24-Blazor` library. They're only accessable using 
the `Images` class.

**NOTE**: You DO NOT have to load the Bootstrap Icons fonts and CSS unless you 
want to use them. They're also not included in this library. Reference the 
[`wan24-Blazor-BootstrapIcons` NuGet package](https://www.nuget.org/packages/wan24-Blazor-BootstrapIcons/) 
to use the latest version.

#### Render SVG XML instead

The `Images.AsSvgXml` method is a helper to decode the raw SVG XML from any 
icon:

```cs
string svg = Images.Icon_123.AsSvgXml();
```

**WARNING**: Width, height and viewport attributes are removed from the 
original SVG XML! You should set a width and a height using the `Width` and 
`Height` properties (or use the `Style` property instead).

To display it in HTML (so you can apply CSS on it):

```razor
<Image SvgXml=@Images.Icon_123.AsSvgXml() Width="24" Height="24" />
```

Or render the SVG XML directly:

```razor
@((MarkupString)Images.Icon_123.AsSvgXml())
```

**WARNING**: Width, height and viewport attributes are removed from the 
original SVG XML! The SVG will use all available space. If you don't want 
that, surround the SVG markup with a size limiting container element.

### Tools

#### Static helper

With the imports (see above) you'll be able to use these static tools on all 
pages and components:

| Tool | Description |
| ---- | ----------- |
| **`GuiEnv`** | |
| `IsMAUI` | If this is a .NET MAUI app |
| `IsWASM` | If this is is a browser WebAssembly app |
| `IsDebug` | If this is a debug build |
| `IsRelease` | If this is a release build |
| `IsLocalApp` | If this is a local app (installed on the running system) |
| `IsBrowserApp` | If this is a browser app (WebAssembly running in a browser) |
| **`BlazorEnv`** | |
| `ScreenOrientation` | Current screen orientation |
| `IsLandscape` | If the current display mode is landscape |
| `IsPortrait` | If the current display mode is portrait |
| `WindowWidth` | Viewport width in pixel |
| `WindowHeight` | Viewport height in pixel |
| `IsSmallScreen` | If the display is small (mobile phone) |
| `IsLargeScreen` | If the display is large (tablet+) |
| `LightMode` | If we're in light color mode |
| `DarkMode` | If we're in Dark color mode |
| `DisplayChanged` | If rendering because of a display change (landscape <-> portrait or small <-> large) |
| `ColorModeChanged` | If rendering because of a color mode change (light <-> dark mode) |
| **`BlazorTools`** | |
| `IfLandscape(...(, ...))` | Return something in landscape mode (or something else in portrait mode) |
| `IfPortrait(...(, ...))` | Return something in portrait mode (or something else in landscape mode) |
| `IfSmallScreen(...(, ...))` | Return something with a small screen (or something else with a large screen) |
| `IfLargeScreen(...(, ...))` | Return something with a large screen (or something else with a small screen) |
| `InfoDialog(...)` | Display a modal information dialog |
| `WarningDialog(...)` | Display a modal warning dialog |
| `ErrorDialog(...)` | Display a modal error dialog |
| `CreateElementId()` | Create an unique ID for an element |
| `CreateSectionId()` | Create an unique section ID |
| `IsHrefMatch(...)` | Determine if an absolute URI path matches another absolute URI path (completely (with or without trailing slash) or as prefix) |
| `EqualsHrefExactlyOrIfTrailingSlashAdded(...)` | Determine if an absolute URI path matches another absolute URI path exactly (with or without trailing slash) |
| `IsHrefStrictlyPrefixWithSeparator(...)` | Determine if an absolute URI path is the prefix of another absolute URI path |
| `GetAbsoluteUriPathFromHref(...)` | Get the absolute URI path from a Href value (without parameters and anchor) |
| **`Logging`** | |
| `Trace` | If logging trace messages |
| `Debug` | If logging debug messages |
| `Info` | If logging informative messages |
| `Warning` | If logging warnung messages |
| `Error` | If logging error messages |
| `Critical` | If logging critical error messages |
| **`Logger`** | |
| `WriteTrace(...)` | Write a trace message |
| `WriteDebug(...)` | Write a debug message |
| `WriteInfo(...)` | Write an informative message |
| `WriteWarning(...)` | Write a warning message |
| `WriteError(...)` | Write an error message |
| `WriteCritical(...)` | Write a critical error message |
| **`ToastLogger`** | |
| `ShowInfo(...)` | Show an informative toast message |
| `ShowWarning(...)` | Show a warning toast message |
| `ShowError(...)` | Show an error toast message |
| `ShowCritical(...)` | Show a critical error toast message |
| **`TranslationHelper.Ext`** | |
| `_(...)` | Translate a text to the current language |
| **`Translationhelper`** | |
| `__(...)` | Mark a text as translatable (for later translation) |
| **`Translation`** | |
| `Translate(...)` | Translate a text (`_` is a shortcut for that method) |
| `TraslatePlural(...)` | Translate a plural text (`_` is a shortcut for that method) |
| **`Helper`** | |
| `CloakCreditCardNumber` | Show only the first and the last number block of a credit card number |
| `CloakPhoneNumber` | Show only the first 4 and the last 2 digits of a phone number |
| `CloakEmailAddress` | Show only a part of the alias and domain |

You can use these properties and methods as if they were defined in your 
current scope (because they are, by `using static...`).

#### DOM manipulation

Example:

```cs
using BlazorGateway gateway = await BlazorGateway.CreateAsync(jsRuntime);
using DomElement element = await gateway.GetElementByIdAsync('ID');
await element.RemoveAsync();
```

**NOTE**: `BlazorGateway` and `DomElement` implement `IAsyncDisposable`. You 
should prefer to dispose asynchronous (`await using(...)`)! You can set a 
`BlazorGateway` instance to the static `Instance` property for sharing it - or 
you can use it with singleton DI.

**WARNING**: `BlazorGateway` should be instanced only once - creating a 2nd 
instance would throw an exception!

You may get elements by

- ID
- HTML tag name
- CSS query selector

Things you can do with an element (except comment, text or CDATA):

- Remove
- Add/remove an event listener
- Add/modify/remove attributes
- Append/insert to another parent element
- Query child elements (using CSS query selector)

**NOTE**: All returned DOM elements will get an unique ID, if they didn't have 
one already (except comment, text or CDATA)!

You may also create new DOM elements (non-comment/CDATA/text) for a known 
existing parent element.

**CAUTION**: Usually all DOM manipulation should be done by the .NET 
WebAssembly rendering functionality of Razor. Use this kind of manual DOM 
manipulation only as an exception, if nothing else works!

#### Send a stream as file download

Example:

```cs
using BlazorGateway gateway = await BlazorGateway.CreateAsync(jsRuntime);
await gateway.SendFileDownloadAsync(sourceStream, "filename.ext");
```

**NOTE**: `BlazorGateway` implement `IAsyncDisposable`. You should prefer to 
dispose asynchronous (`await using(...)`)! You can set a `BlazorGateway` 
instance to the static `Instance` property for sharing it - or you can use it 
with singleton DI.

Of course this only makes sense when running in a WebAssembly context in a 
browser. Within a .NET MAUI app you should use a `FileStream` for saving a 
file.

The advantage of sending a stream is that the download doesn't have to be in 
memory completely and is served in small chunks instead.

### Using the JavaScript helpers

The JavaScript helpers module include all methods that are used from 
`BlazorGateway` and something more, which may be used from JavaScript:

| Export | Description |
| ------ | ----------- |
| `initAsync()` | Initialize (recommended to call before any other method) |
| `getExports()` | Get the `wan24-Blazor` exported methods |
| `startDownloadStream(...)` | Start a (file download) stream |
| `addDownloadStreamChunk(Array)(...)` | Add a data chunk to a running (file download) stream |
| `endDownloadStream(...)` | Finalize a (file download) stream |
| `DownloadStreams` | A map of all running download streams |
| `class DownloadStream` | Manages a (file download) stream |

For this simply import the `blazorGateway` module from the URI 
`_content/wan24-Blazor/js/minified/blazorGateway.min.js`. Sources of 
the script including DocComments can be found in `TypeScript/blazorGateway.ts` 
in the `wan24-Blazor` project in this repository.

#### Download stream

Example download stream usage:

```js
	// The ID of the download
const downloadId = startDownloadStream('filename.ext','application/octet-stream'),
	// The DownloadStream instance (may be fed from the Blazor WebAssembly also!)
	download = DownloadStreams.get(downloadId);
// Now feed the stream using download.addDataChunk(Array) as you like
download.finalize();// Signal the end of the stream and clean up
```

Sending a file download is optional (you can use `null` as filename), you may 
use the stream for any stream consumer. Using a MIME type is optional - per 
default `application/octet-stream` will be used.

By using the `BlazorGateway.AddDownloadStreamChunk` method you can feed a 
running stream from the Blazor WebAssembly also. Internal the 
`BlazorGateway.SendFileDownloadAsync` method uses a `DownloadStream`, too.

## Referenced NuGet packages

These non-default NuGet packages are referenced and included into the 
WebAssembly:

- **wan24-Core** - many .NET extensions and helpers ([GitHub](https://github.com/WAN-Solutions/wan24-Core))
- **ObjectValidation** - deep object validation ([GitHub](https://github.com/nd1012/ObjectValidation))
- **BlazorComponentUtilities** - helps with building CSS ([GitHub](https://github.com/EdCharbeneau/BlazorComponentUtilities))
- **BlazorPro.BlazorSize** - reports viewport size changes ([GitHub](https://github.com/EdCharbeneau/BlazorSize))

They're there already, so why not use them in your code, too, if applicable?
