﻿using Microsoft.AspNetCore.Components;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a component which serves child content
    /// </summary>
    public interface IServeChildContent : IComponent, IHandleEvent, IHandleAfterRender
    {
        /// <summary>
        /// Child content
        /// </summary>
        RenderFragment? ChildContent { get; set; }
    }
}
