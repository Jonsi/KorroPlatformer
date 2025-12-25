    using Common.Events;
    using Common.Input;
    using Common.States;
    using KorroPlatformer.Character.MVP;
    using UnityEngine;

    namespace KorroPlatformer.Character.States
    {
        /// <summary>
        /// State representing the player being idle (not moving).
        /// </summary>
        public class IdleState : PlayerBaseState
        {
            private bool _JumpRequested;

            public IdleState(
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
                _PlayerAnimator.PlayIdle();
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
