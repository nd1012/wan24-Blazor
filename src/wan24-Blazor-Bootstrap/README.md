# wan24-Blazor-Bootstrap

This library contains the Bootstrap 5.3.3 JS and CSS for a .NET 8 Razor 
environment. In a debug build all JS and CSS files are accessable via 
`./content/wan24BlazorBootstrap/...`, a release build contains the minified 
files only.

This library is available as a 
[NuGet package](https://www.nuget.org/packages/wan24-Blazor-Bootstrap/).

After referencing the NuGet package or the project, you can include Bootstrap 
JS (optional) and CSS in your `index.html` files `<head>` section like this:

```html
<link rel="stylesheet" href="_content/wan24-Blazor-Bootstrap/css/bootstrap.min.css" />
<link rel="stylesheet" href="_content/wan24-Blazor-Bootstrap/css/bootstrap-grid.min.css" /><!-- optional -->
<link rel="stylesheet" href="_content/wan24-Blazor-Bootstrap/css/bootstrap-reboot.min.css" /><!-- optional -->
<link rel="stylesheet" href="_content/wan24-Blazor-Bootstrap/css/bootstrap-utilities.min.css" /><!-- optional -->
<script src="_content/wan24-Blazor-Bootstrap/js/bootstrap.min.js"></script><!-- optional -->
```

`wan24-Blazor-Bootstrap` was built as extension library for `wan24-Blazor`, 
but it contains no foreign dependencies, except for the mandatory 
`Microsoft.AspNetCore.Components.Web` reference.

**NOTE**: In case you'd like to use the module JavaScript, you can also load 
the `bootstrap.esm.js` file.

## Package version number

The package version number reflects the used Bootstrap version. NuGet allows 
to use a 4th component, which `wan24-Blazor-Bootstrap` does build like this:

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

This is required to support an updated Bootstrap version for different .NET 
targets of `wan24-Blazor-Bootstrap`.
