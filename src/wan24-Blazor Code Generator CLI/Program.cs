using wan24.Blazor;
using wan24.CLI;
using wan24.Core;

await Bootstrap.Async().DynamicContext();
Translation.Current = Translation.Dummy;
Logging.Logger = new VividConsoleLogger();
return await CliApi.RunAsync(args, exportedApis: [typeof(CliHelpApi), typeof(CodeGeneratorApi)]).DynamicContext();
