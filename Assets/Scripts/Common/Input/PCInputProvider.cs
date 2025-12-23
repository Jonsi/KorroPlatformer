using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
    /// <summary>
    /// Reads movement input from a Unity input action.
    /// </summary>
    public class PCInputProvider : IInputProvider, IDisposable
    {
        private readonly InputAction _MoveAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="PCInputProvider"/> class.
        /// </summary>
        /// <param name="moveAction">The input action used to read movement.</param>
        public PCInputProvider(InputAction moveAction)
        {
            _MoveAction = moveAction;
            _MoveAction.Enable();
        }

        /// <summary>
        /// Gets the current movement direction from the input action.
        /// </summary>
        public Vector2 MoveDirection => _MoveAction.ReadValue<Vector2>();

        /// <summary>
        /// Disables the input action and releases resources.
        /// </summary>
        public void Dispose()
        {
            _MoveAction.Disable();
        }
    }
}
