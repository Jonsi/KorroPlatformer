using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player being idle (not moving).
    /// </summary>
    public class IdleState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly IPlayerAnimator _PlayerAnimator;
        private PlayerStateMachine _StateMachine;
        private bool _JumpRequested;

        public IdleState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement, 
            IPlayerAnimator playerAnimator)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _PlayerAnimator = playerAnimator;
        }

        /// <summary>
        /// Initializes the state with the state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance.</param>
        public void Initialize(PlayerStateMachine stateMachine)
        {
            _StateMachine = stateMachine;
        }

        /// <inheritdoc />
        public void Enter()
        {
            _JumpRequested = false;
            _InputProvider.JumpPerformed += OnJump;
            _PlayerAnimator.PlayIdle();
        }

        /// <inheritdoc />
        public void Exit()
        {
            _InputProvider.JumpPerformed -= OnJump;
        }

        /// <inheritdoc />
        public IState Update()
        {
            _PlayerMovement.MoveDirection = Vector2.zero;

            if (_JumpRequested || !_PlayerMovement.IsGrounded)
            {
                return _StateMachine.JumpState;
            }

            if (_InputProvider.MoveDirection != Vector2.zero)
            {
                return _StateMachine.WalkState;
            }

            return null;
        }

        private void OnJump() => _JumpRequested = true;
    }
}
