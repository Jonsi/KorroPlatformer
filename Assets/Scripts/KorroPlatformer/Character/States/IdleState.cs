using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    public class IdleState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly PlayerStateMachine _StateMachine;
        private bool _JumpRequested;

        public IdleState(IInputProvider inputProvider, IPlayerMovement playerMovement, PlayerStateMachine stateMachine)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _StateMachine = stateMachine;
        }

        public void Enter()
        {
            _JumpRequested = false;
            _InputProvider.JumpPerformed += OnJump;
        }

        public void Exit()
        {
            _InputProvider.JumpPerformed -= OnJump;
        }

        public IState Update()
        {
            _PlayerMovement.MoveDirection = Vector2.zero;

            if (_JumpRequested || !_PlayerMovement.IsGrounded)
            {
                return _StateMachine.JumpState;
            }

            return _InputProvider.MoveDirection != Vector2.zero ? _StateMachine.WalkState : null;
        }

        private void OnJump() => _JumpRequested = true;
    }
}
