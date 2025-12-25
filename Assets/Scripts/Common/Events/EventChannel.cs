using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Events
{
    /// <summary>
    /// Very simple event channel where subscribers are stored by owner (handler.Target).
    /// No duplicate handlers per owner. Raise invokes all registered callbacks.
    /// </summary>
    public abstract class EventChannel<T> : ScriptableObject, IEventChannel<T>
    {
        private readonly Dictionary<object, Action<T>> _Subscriptions = new();

        /// <summary>
        /// Invokes the event for all subscribers with the provided data.
        /// </summary>
        /// <param name="data">Payload for the event.</param>
        public void Raise(T data)
        {
            var callbacks = _Subscriptions.Values.ToArray();
            foreach (var callback in callbacks)
            {
                callback?.Invoke(data);
            }
        }

        /// <summary>
        /// Adds or replaces the handler for the given owner.
        /// </summary>
        /// <param name="handler">Event handler to register.</param>
        public void Subscribe(Action<T> handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _Subscriptions[owner] = handler;
        }

        /// <summary>
        /// Removes the handler for the given delegate owner.
        /// </summary>
        /// <param name="handler">Event handler to remove.</param>
        public void Unsubscribe(Action<T> handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _Subscriptions.Remove(owner);
        }
    }
}
