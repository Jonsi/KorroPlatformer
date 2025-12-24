using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    public class JumpState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly IPlayerAnimator _PlayerAnimator;
        private readonly Common.Events.IntEventChannel _HitEvent;
        private PlayerStateMachine _StateMachine;

        public JumpState(
            IInputProvider inputProvider, 
            IPlayerMovement playerMovement,
            IPlayerAnimator playerAnimator,
            Common.Events.IntEventChannel hitEvent)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _PlayerAnimator = playerAnimator;
            _HitEvent = hitEvent;
        }

        public void Initialize(PlayerStateMachine stateMachine)
        {
            _StateMachine = stateMachine;
        }

        public void Enter()
        {
            if (_PlayerMovement.IsGrounded)
                _PlayerMovement.Jump();
                
            _PlayerAnimator.PlayJump();

            if (_HitEvent != null)
                _HitEvent.Subscribe(OnDamageReceived);
        }

        public void Exit()
        {
            if (_HitEvent != null)
                _HitEvent.Unsubscribe(OnDamageReceived);
        }

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
