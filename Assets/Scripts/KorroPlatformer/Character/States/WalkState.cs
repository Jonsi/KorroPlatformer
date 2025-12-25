using Common.Events;
using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player walking.
    /// </summary>
    public class WalkState : PlayerBaseState
    {
        private bool _JumpRequested;

        public WalkState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement,
            IPlayerAnimator playerAnimator,
            IEventChannel<int> hitEvent) : base(inputProvider, playerMovement, playerAnimator, hitEvent)
        {
        }

        /// <inheritdoc />
        public override void Enter()
        {
            base.Enter();
            _JumpRequested = false;
            _InputProvider.JumpPerformed += OnJump;
            _PlayerAnimator.PlayWalk();
        }

        /// <inheritdoc />
        public override void Exit()
        {
            base.Exit();
            _InputProvider.JumpPerformed -= OnJump;
        }

        /// <inheritdoc />
        public override IState Update()
        {
            _PlayerMovement.MoveDirection = _InputProvider.MoveDirection;

            if (_JumpRequested || !_PlayerMovement.IsGrounded)
            { 
                return _StateMachine.JumpState;
            }
            
            return _InputProvider.MoveDirection == Vector2.zero ? _StateMachine.IdleState : null;
        }

        private void OnJump() => _JumpRequested = true;
    }
}
