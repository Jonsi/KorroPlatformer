using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
    /// <summary>
    /// Reads raw input from Unity input actions.
    /// </summary>
    public class PCInputProvider : IInputProvider, IDisposable
    {
        private readonly InputAction _moveAction;
        private readonly InputAction _jumpAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="PCInputProvider"/> class.
        /// </summary>
        /// <param name="moveAction">The input action used to read movement.</param>
        /// <param name="jumpAction">The input action used to detect jumps.</param>
        public PCInputProvider(InputAction moveAction, InputAction jumpAction)
        {
            _moveAction = moveAction;
            _jumpAction = jumpAction;
            _moveAction.Enable();
            _jumpAction.Enable();
            _jumpAction.performed += OnJumpPerformed;
        }

        /// <summary>
        /// Gets the current movement direction from the input action.
        /// </summary>
        public Vector2 MoveDirection => _moveAction.ReadValue<Vector2>();

        /// <summary>
        /// Raised when jump input is performed.
        /// </summary>
        public event Action JumpPerformed;

        /// <summary>
        /// Disables the input actions and releases resources.
        /// </summary>
        public void Dispose()
        {
            _jumpAction.performed -= OnJumpPerformed;
            _moveAction.Disable();
            _jumpAction.Disable();
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            JumpPerformed?.Invoke();
        }
    }
}
