using Common.Events;
using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    public class WalkState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly IntEventChannel _HitEvent;
        private PlayerStateMachine _StateMachine;
        private bool _JumpRequested;

        public WalkState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement,
            IntEventChannel hitEvent)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _HitEvent = hitEvent;
        }

        public void Initialize(PlayerStateMachine stateMachine)
        {
            _StateMachine = stateMachine;
        }

        public void Enter()
        {
            _JumpRequested = false;
            _InputProvider.JumpPerformed += OnJump;
            
            if (_HitEvent != null)
            {
                _HitEvent.Subscribe(OnDamageReceived);
            }
        }

        public void Exit()
        {
            _InputProvider.JumpPerformed -= OnJump;
            
            // Do NOT reset MoveDirection here, as it kills jump momentum.
            // Resetting movement on Hit should be handled by the HitState/Transition logic if needed.
            
            if (_HitEvent != null)
            {
                _HitEvent.Unsubscribe(OnDamageReceived);
            }
        }

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
