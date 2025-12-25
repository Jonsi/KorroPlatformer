using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player jumping or being in the air.
    /// </summary>
    public class JumpState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly IPlayerAnimator _PlayerAnimator;
        private readonly Common.Events.IEventChannel<int> _HitEvent;
        private readonly Common.Events.IEventChannel _JumpEvent;
        private PlayerStateMachine _StateMachine;

        public JumpState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement,
            IPlayerAnimator playerAnimator,
            Common.Events.IEventChannel<int> hitEvent,
            Common.Events.IEventChannel jumpEvent = null)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _PlayerAnimator = playerAnimator;
            _HitEvent = hitEvent;
            _JumpEvent = jumpEvent;
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
            if (_PlayerMovement.IsGrounded)
                _PlayerMovement.Jump();
                
            _PlayerAnimator.PlayJump();

            if (_JumpEvent != null)
            {
                _JumpEvent.Raise();
            }

            if (_HitEvent != null)
                _HitEvent.Subscribe(OnDamageReceived);
        }

        /// <inheritdoc />
        public void Exit()
        {
            if (_HitEvent != null)
                _HitEvent.Unsubscribe(OnDamageReceived);
        }

        /// <inheritdoc />
        public IState Update()
        {
            _PlayerMovement.MoveDirection = _InputProvider.MoveDirection;

            if (_PlayerMovement.IsGrounded)
            {
                return _InputProvider.MoveDirection == Vector2.zero ? _StateMachine.IdleState : _StateMachine.WalkState;
            }
            
            return null;
        }

        private void OnDamageReceived(int damage)
        {
             _StateMachine.HitState.Prepare(damage);
             _StateMachine.SetState(_StateMachine.HitState);
        }
    }
}
