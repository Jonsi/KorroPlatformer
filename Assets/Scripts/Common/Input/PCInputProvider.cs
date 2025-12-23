using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Input
{
    public class PCInputProvider : IInputProvider, IDisposable
    {
        private readonly InputAction _MoveAction;

        public PCInputProvider(InputAction moveAction)
        {
            _MoveAction = moveAction;
            _MoveAction.Enable();
        }

        public Vector2 MoveDirection => _MoveAction.ReadValue<Vector2>();

        public void Dispose()
        {
            _MoveAction.Disable();
        }
    }
}
