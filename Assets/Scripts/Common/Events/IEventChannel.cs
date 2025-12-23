using System;

namespace Common.Events
{
    /// <summary>
    /// Interface for event channels that enable decoupled communication between systems.
    /// </summary>
    /// <typeparam name="TData">The type of data passed with the event.</typeparam>
    public interface IEventChannel<TData>
    {
        /// <summary>
        /// Raises the event with the specified data.
        /// </summary>
        /// <param name="data">The data to pass with the event.</param>
        void Raise(TData data);

        /// <summary>
        /// Subscribes to the event.
        /// </summary>
        /// <param name="handler">The event handler to subscribe.</param>
        void Subscribe(Action<TData> handler);

        /// <summary>
        /// Unsubscribes from the event.
        /// </summary>
        /// <param name="handler">The event handler to unsubscribe.</param>
        void Unsubscribe(Action<TData> handler);
    }

    /// <summary>
    /// Interface for event channels that pass no data (void events).
    /// </summary>
    public interface IEventChannel
    {
        /// <summary>
        /// Raises the event.
        /// </summary>
        void Raise();

        /// <summary>
        /// Subscribes to the event.
        /// </summary>
        /// <param name="handler">The event handler to subscribe.</param>
        void Subscribe(Action handler);

        /// <summary>
        /// Unsubscribes from the event.
        /// </summary>
        /// <param name="handler">The event handler to unsubscribe.</param>
        void Unsubscribe(Action handler);
    }
}
