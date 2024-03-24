# wan24-Blazor-BootstrapIcons

This library contains the Bootstrap Icons 1.11.3 fonts and CSS for a .NET 8 
Razor environment. In a debug build all CSS files are accessable via 
`./content/wan24BlazorBootstrapIcons/...`, a release build contains the 
minified files only.

This library is available as a 
[NuGet package](https://www.nuget.org/packages/wan24-Blazor-BootstrapIcons/).

After referencing the NuGet package or the project, you can include Bootstrap 
Icons in your `index.html` files `<head>` section like this:

```html
<link rel="stylesheet" href="./_content/wan24-Blazor-BootstrapIcons/css/bootstrap-icons.min.css" />
```

`wan24-Blazor-BootstrapIcons` was built as extension library for 
`wan24-Blazor-Bootstrap`, but it contains no foreign dependencies, except for 
the mandatory `Microsoft.AspNetCore.Components.Web` reference.
