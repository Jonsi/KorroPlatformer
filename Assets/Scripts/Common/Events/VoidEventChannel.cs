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
    public class VoidEventChannel : ScriptableObject, IEventChannel
    {
        private readonly Dictionary<object, Action> _Subscriptions = new();

        public void Raise()
        {
            var callbacks = _Subscriptions.Values.ToArray();
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
            _Subscriptions[owner] = handler;
        }

        public void Unsubscribe(Action handler)
        {
            if (handler == null)
            {
                return;
            }

            var owner = handler.Target;
            _Subscriptions.Remove(owner);
        }

        public void UnsubscribeAll()
        {
            _Subscriptions.Clear();
        }
    }
}


