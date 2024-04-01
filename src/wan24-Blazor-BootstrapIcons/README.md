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
<link rel="stylesheet" href="_content/wan24-Blazor-BootstrapIcons/css/bootstrap-icons.min.css" />
```

`wan24-Blazor-BootstrapIcons` was built as extension library for 
`wan24-Blazor-Bootstrap`, but it contains no foreign dependencies, except for 
the mandatory `Microsoft.AspNetCore.Components.Web` reference.

## Package version number

The package version number reflects the used Bootstrap Icons version. NuGet 
allows to use a 4th component, which `wan24-Blazor-BootstrapIcons` does build 
like this:

It contains two elements:

1. .NET version (1 byte)
1. Build version (2 byte)

These bytes are appended to a 24 bit integer value:

	[.NET byte][Build bytes]

Assumed the .NET version is 8, and the build version is 1, this will result in 
3 bytes:

	8	0	1

As 24 bit integer this is the value `524289`:

	8 * 65535 + 1 = 524289
	(8 << 16) + 1 = 524289

To reverse the version number to the .NET and the build version:

	net = (version & ~65535) >> 16
	build = version & 65535

This is required to support an updated Bootstrap Icons version for different 
.NET targets of `wan24-Blazor-BootstrapIcons`.
