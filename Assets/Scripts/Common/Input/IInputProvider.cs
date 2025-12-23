using System;
using UnityEngine;

namespace Common.Input
{
    /// <summary>
    /// Provides raw input data.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Gets the current movement direction.
        /// </summary>
        Vector2 MoveDirection { get; }

        /// <summary>
        /// Raised when jump input is performed.
        /// </summary>
        event Action JumpPerformed;
    }
}
