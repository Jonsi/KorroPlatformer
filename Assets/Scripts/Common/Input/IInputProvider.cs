using UnityEngine;

namespace Common.Input
{
    /// <summary>
    /// Provides input data for character movement.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Gets the current movement direction.
        /// </summary>
        Vector2 MoveDirection { get; }
    }
}
