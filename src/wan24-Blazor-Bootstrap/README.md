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
<link rel="stylesheet" href="./_content/wan24-Blazor-Bootstrap/css/bootstrap.min.css" />
<link rel="stylesheet" href="./_content/wan24-Blazor-Bootstrap/css/bootstrap-grid.min.css" /><!-- optional -->
<link rel="stylesheet" href="./_content/wan24-Blazor-Bootstrap/css/bootstrap-reboot.min.css" /><!-- optional -->
<link rel="stylesheet" href="./_content/wan24-Blazor-Bootstrap/css/bootstrap-utilities.min.css" /><!-- optional -->
<script src="./_content/wan24-Blazor-Bootstrap/js/bootstrap.min.js"></script><!-- optional -->
```

`wan24-Blazor-Bootstrap` was built as extension library for `wan24-Blazor`, 
but it contains no foreign dependencies, except for the mandatory 
`Microsoft.AspNetCore.Components.Web` reference.
