using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player jumping or being in the air.
    /// </summary>
    public class JumpState : PlayerBaseState
    {
        private readonly Common.Events.IEventChannel _JumpEvent;

        public JumpState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement,
            IPlayerAnimator playerAnimator,
            Common.Events.IEventChannel<int> hitEvent,
            Common.Events.IEventChannel jumpEvent = null) : base(inputProvider, playerMovement, playerAnimator, hitEvent)
        {
            _JumpEvent = jumpEvent;
        }

        /// <inheritdoc />
        public override void Enter()
        {
            base.Enter();
            if (_PlayerMovement.IsGrounded)
                _PlayerMovement.Jump();
                
            _PlayerAnimator.PlayJump();

            if (_JumpEvent != null)
            {
                _JumpEvent.Raise();
            }
        }

        /// <inheritdoc />
        public override IState Update()
        {
            _PlayerMovement.MoveDirection = _InputProvider.MoveDirection;

            if (_PlayerMovement.IsGrounded)
            {
                return _InputProvider.MoveDirection == Vector2.zero ? _StateMachine.IdleState : _StateMachine.WalkState;
            }
            
            return null;
        }
    }
}
