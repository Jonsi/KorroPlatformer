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
        private readonly PlayerStateMachine _StateMachine;

        public JumpState(IInputProvider inputProvider, IPlayerMovement playerMovement, PlayerStateMachine stateMachine)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
            _StateMachine = stateMachine;
        }

        public void Enter()
        {
            if (_PlayerMovement.IsGrounded)
                _PlayerMovement.Jump();
        }

        public void Exit() { }

        public IState Update()
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
