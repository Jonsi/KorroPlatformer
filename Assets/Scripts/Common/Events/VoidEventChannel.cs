using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Events
{
    /// <summary>
    /// Event channel for void events (no data passed).
    /// </summary>
    [CreateAssetMenu(fileName = "VoidEventChannel", menuName = "KorroPlatformer/Events/Void Event Channel")]
    public sealed class VoidEventChannel : ScriptableObject, IEventChannel
    {
        private readonly Dictionary<object, Action> _Subscriptions = new();

        /// <summary>
        /// Raises the event to all subscribers.
        /// </summary>
        public void Raise()
        {
            var callbacks = _Subscriptions.Values.ToArray();
            foreach (var callback in callbacks)
            {
                callback?.Invoke();
            }
        }

        /// <summary>
        /// Subscribes a handler to the event.
        /// </summary>
        /// <param name="handler">The action to invoke when the event is raised.</param>
        public void Subscribe(Action handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _Subscriptions[owner] = handler;
        }

        /// <summary>
        /// Unsubscribes a handler from the event.
        /// </summary>
        /// <param name="handler">The action to remove.</param>
        public void Unsubscribe(Action handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _Subscriptions.Remove(owner);
        }

        /// <summary>
        /// Unsubscribes all handlers from the event.
        /// </summary>
        public void UnsubscribeAll()
        {
            _Subscriptions.Clear();
        }
    }
}
