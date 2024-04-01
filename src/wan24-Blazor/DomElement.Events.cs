using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using wan24.Core;

namespace wan24.Blazor
{
    // Events
#pragma warning disable CS8774 // ID must not be NULL when leaving the method
    public partial record class DomElement
    {
        /// <summary>
        /// DOM elements with event handlers
        /// </summary>
        protected static readonly ConcurrentDictionary<string, DomElement> Elements = [];

        /// <summary>
        /// Event handlers
        /// </summary>
        protected readonly ConcurrentDictionary<string, HashSet<EventHandler_Delegate>> EventHandlers = [];

        /// <summary>
        /// Add an event listener
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="handler">Handler</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If the event handler was added</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> AddEventListenerAsync(string eventName, EventHandler_Delegate handler, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            EnsureNode();
            Elements.TryAdd(ID!, this);
            HashSet<EventHandler_Delegate> handlers = EventHandlers.GetOrAdd(eventName, e => []);
            lock (handlers) if (!handlers.Add(handler)) return false;
            if (handlers.Count > 1 || await Gateway.Gateway.InvokeAsync<bool>("addEventListener", cancellationToken, [ID, eventName]).DynamicContext()) return true;
            throw new InvalidOperationException("Adding an event listener failed");
        }

        /// <summary>
        /// Remove an event listener
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="handler">Handler</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If the event handler was removed</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> RemoveEventListenerAsync(string eventName, EventHandler_Delegate handler, CancellationToken cancellationToken = default)
        {
            EnsureUndisposed();
            EnsureNode();
            if (!Elements.ContainsKey(ID!)) return false;
            if (!EventHandlers.TryGetValue(eventName, out HashSet<EventHandler_Delegate>? handlers)) return false;
            lock (handlers) if (!handlers.Remove(handler)) return false;
            bool res = true;
            if (handlers.Count < 1)
            {
                res = await Gateway.Gateway.InvokeAsync<bool>("removeEventListener", cancellationToken, [ID, eventName]).DynamicContext();
                EventHandlers.TryRemove(eventName, out _);
            }
            if (EventHandlers.IsEmpty) Elements.TryRemove(ID!, out _);
            return res;
        }

        /// <summary>
        /// Clear all event listeners
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>If cleared</returns>
        [MemberNotNull(nameof(ID))]
        public virtual async Task<bool> ClearEventListenersAsync(CancellationToken cancellationToken = default)
        {
            EnsureUndisposed(allowDisposing: true);
            if (!EnsureNode(throwOnError: false) || Gateway is null) return false;
            EventHandlers.Clear();
            Elements.TryRemove(ID!, out _);
            return await Gateway.Gateway.InvokeAsync<bool>("clearEventListeners", cancellationToken, [ID]).DynamicContext();
        }

        /// <summary>
        /// Delegate for an event handler
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="e">Arguments</param>
        public delegate void EventHandler_Delegate(DomElement element, JsEventArgs e);

        /// <summary>
        /// Raise an event
        /// </summary>
        /// <param name="id">DOM element ID</param>
        /// <param name="eventName">Event name</param>
        /// <param name="data">Event data</param>
#pragma warning disable CA1416 // Browser only
        [JSExport]
#pragma warning restore CA1416 // Browser only
        public static void RaiseEvent(string id, string eventName, string data)
        {
            if (!Elements.TryGetValue(id, out DomElement? element)) return;
            if (!element.EnsureUndisposed(allowDisposing: false, throwException: false)) return;
            if (!element.EventHandlers.TryGetValue(eventName, out HashSet<EventHandler_Delegate>? handlers)) return;
            JsEventArgs e = new(JsonHelper.Decode<Dictionary<string, object?>>(data) ?? throw new ArgumentException("Failed to deserialize event data", nameof(data)));
            EventHandler_Delegate[] handlerDelegates;
            lock (handlers) handlerDelegates = [.. handlers];
            foreach (EventHandler_Delegate handler in handlerDelegates) handler(element, e);
        }

        /// <summary>
        /// JS event arguments
        /// </summary>
        /// <remarks>
        /// Constructor
        /// </remarks>
        /// <param name="data">Event data</param>
        public sealed class JsEventArgs(in Dictionary<string, object?> data) : EventArgs()
        {
            /// <summary>
            /// Event data
            /// </summary>
            public Dictionary<string, object?> Data { get; } = data;
        }
    }
#pragma warning restore CS8774 // ID must not be NULL when leaving the method
}
