using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Events
{
    /// <summary>
    /// Event channel for void events (no data passed).
    /// </summary>
    [CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Knife Toss/Events/Void Event Channel")]
    public class VoidEventChannel : ScriptableObject, IEventChannel
    {
        private readonly Dictionary<object, Action> _subscriptions = new();

        public void Raise()
        {
            var callbacks = _subscriptions.Values.ToArray();
            foreach (var callback in callbacks)
            {
                callback?.Invoke();
            }
        }

        public void Subscribe(Action handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _subscriptions[owner] = handler;
        }

        public void Unsubscribe(Action handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _subscriptions.Remove(owner);
        }

        public void UnsubscribeAll()
        {
            _subscriptions.Clear();
        }
    }
}


