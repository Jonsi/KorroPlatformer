using Common.Events;
using Common.Input;
using Common.States;
using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// Base state for player states that handles common dependencies and behavior.
    /// </summary>
    public abstract class PlayerBaseState : IState
    {
        protected readonly IInputProvider _InputProvider;
        protected readonly IPlayerMovement _PlayerMovement;
        protected readonly IPlayerAnimator _PlayerAnimator;
        protected readonly IEventChannel<int> _HitEvent;
        protected PlayerStateMachine _StateMachine;

        protected PlayerBaseState(
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
        public virtual void Enter()
        {
            if (_HitEvent != null)
            {
                _HitEvent.Subscribe(OnDamageReceived);
            }
        }

        /// <inheritdoc />
        public virtual void Exit()
        {
            if (_HitEvent != null)
            {
                _HitEvent.Unsubscribe(OnDamageReceived);
            }
        }

        /// <inheritdoc />
        public abstract IState Update();

        private void OnDamageReceived(int damage)
        {
            _StateMachine.HitState.Prepare(damage);
            _StateMachine.SetState(_StateMachine.HitState);
        }
    }
}

