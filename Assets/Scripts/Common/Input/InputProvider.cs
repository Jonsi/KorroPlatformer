using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
    /// <summary>
    /// Reads raw input from Unity input actions.
    /// </summary>
    public class InputProvider : IInputProvider, IDisposable
    {
        private readonly InputAction _MoveAction;
        private readonly InputAction _JumpAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputProvider"/> class.
        /// </summary>
        /// <param name="moveAction">The input action used to read movement.</param>
        /// <param name="jumpAction">The input action used to detect jumps.</param>
        public InputProvider(InputAction moveAction, InputAction jumpAction)
        {
            _MoveAction = moveAction;
            _JumpAction = jumpAction;
            _MoveAction.Enable();
            _JumpAction.Enable();
            _JumpAction.performed += OnJumpPerformed;
        }

        /// <summary>
        /// Gets the current movement direction from the input action.
        /// </summary>
        public Vector2 MoveDirection => _MoveAction.ReadValue<Vector2>();

        /// <summary>
        /// Raised when jump input is performed.
        /// </summary>
        public event Action JumpPerformed;

        /// <summary>
        /// Disables the input actions and releases resources.
        /// </summary>
        public void Dispose()
        {
            _JumpAction.performed -= OnJumpPerformed;
            _MoveAction.Disable();
            _JumpAction.Disable();
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            JumpPerformed?.Invoke();
        }
    }
}
