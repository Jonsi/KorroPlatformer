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
    public class WalkState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly IPlayerAnimator _PlayerAnimator;
        private readonly IEventChannel<int> _HitEvent;
        private PlayerStateMachine _StateMachine;
        private bool _JumpRequested;

        public WalkState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement,
            IPlayerAnimator playerAnimator,
            IEventChannel<int> hitEvent)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _PlayerAnimator = playerAnimator;
            _HitEvent = hitEvent;
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
            _PlayerAnimator.PlayWalk();
            
            if (_HitEvent != null)
            {
                _HitEvent.Subscribe(OnDamageReceived);
            }
        }

        /// <inheritdoc />
        public void Exit()
        {
            _InputProvider.JumpPerformed -= OnJump;
            
            if (_HitEvent != null)
            {
                _HitEvent.Unsubscribe(OnDamageReceived);
            }
        }

        /// <inheritdoc />
        public IState Update()
        {
            _PlayerMovement.MoveDirection = _InputProvider.MoveDirection;

            if (_JumpRequested || !_PlayerMovement.IsGrounded)
            { 
                return _StateMachine.JumpState;
            }
            
            return _InputProvider.MoveDirection == Vector2.zero ? _StateMachine.IdleState : null;
        }

        private void OnJump() => _JumpRequested = true;

        private void OnDamageReceived(int damage)
        {
             _StateMachine.HitState.Prepare(damage);
             _StateMachine.SetState(_StateMachine.HitState);
        }
    }
}
