using Microsoft.Extensions.Logging;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Common startup
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <param name="guiType">GUI type</param>
        /// <param name="build">Build type</param>
        public static void Start(in GuiType guiType, in BuildTypes build)
        {
            Bootstrap.Async().Wait();
            SyncStart(guiType, build);
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="guiType">GUI type</param>
        /// <param name="build">Build type</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public static async Task StartAsync(GuiType guiType, BuildTypes build, CancellationToken cancellationToken = default)
        {
            await Bootstrap.Async(cancellationToken: cancellationToken).DynamicContext();
            SyncStart(guiType, build);
        }

        /// <summary>
        /// Synchronous startup
        /// </summary>
        /// <param name="guiType">GUI type</param>
        /// <param name="build">Build type</param>
        private static void SyncStart(in GuiType guiType, in BuildTypes build)
        {
            GuiEnv.AppType = guiType;
            GuiEnv.AppBuild = build;
            Logging.Logger = GuiEnv.IsDebug
                ? new ConsoleLogger(LogLevel.Debug, new DebugLogger(LogLevel.Trace))
                : new ConsoleLogger();
            if (GuiEnv.IsDebug && Settings.LogLevel > LogLevel.Debug)
                Settings.LogLevel = LogLevel.Debug;
            ENV.IsBrowserApp = guiType == GuiType.WASM;
            ErrorHandling.ErrorHandler = (info) => Logging.WriteError(info);
            Translation.Current = Translation.Dummy;
        }
    }
}
