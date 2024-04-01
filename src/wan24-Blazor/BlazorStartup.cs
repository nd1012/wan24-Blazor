﻿using BlazorPro.BlazorSize;
using Microsoft.Extensions.DependencyInjection;
using wan24.Core;

namespace wan24.Blazor
{
    /// <summary>
    /// Razor startup
    /// </summary>
    public static class BlazorStartup
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <param name="guiType">GUI type</param>
        /// <param name="build">Build type</param>
        /// <param name="services">Services</param>
        public static void Start(in GuiType guiType, in BuildTypes build, in IServiceCollection services)
        {
            Startup.Start(guiType, build);
            SyncStart(services);
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="guiType">GUI type</param>
        /// <param name="build">Build type</param>
        /// <param name="services">Services</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public static async Task StartAsync(GuiType guiType, BuildTypes build, IServiceCollection services, CancellationToken cancellationToken = default)
        {
            await Startup.StartAsync(guiType, build, cancellationToken).DynamicContext();
            SyncStart(services);
        }

        /// <summary>
        /// Synchronous start
        /// </summary>
        /// <param name="services">Services</param>
        private static void SyncStart(in IServiceCollection services)
        {
            services.AddMediaQueryService();
            services.AddResizeListener(options =>
            {
                options.ReportRate = 300;
                options.SuppressInitEvent = false;
                if (GuiEnv.IsDebug) options.EnableLogging = true;
            });
        }
    }
}