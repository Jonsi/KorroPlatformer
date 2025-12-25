using Common.Events;
using Common.States;
using KorroPlatformer.Character.MVP;
using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player taking damage.
    /// </summary>
    public class HitState : IState
    {
        private PlayerStateMachine _StateMachine;
        private readonly PlayerModel _Model;
        private readonly IPlayerMovement _PlayerMovement;
        private readonly IPlayerAnimator _PlayerAnimator;
        private readonly IEventChannel<HealthChangedPayload> _HealthChangedEvent;
        private readonly IEventChannel _PlayerDiedEvent;
        private readonly float _Duration;
        
        private float _ElapsedTime;
        private int _PendingDamage;

        public HitState(
            PlayerModel model,
            IPlayerMovement playerMovement,
            IPlayerAnimator playerAnimator,
            IEventChannel<HealthChangedPayload> healthChangedEvent,
            IEventChannel playerDiedEvent,
            float duration)
        {
            _Model = model;
            _PlayerMovement = playerMovement;
            _PlayerAnimator = playerAnimator;
            _HealthChangedEvent = healthChangedEvent;
            _PlayerDiedEvent = playerDiedEvent;
            _Duration = duration;
        }

        /// <summary>
        /// Initializes the state with the state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance.</param>
        public void Initialize(PlayerStateMachine stateMachine)
        {
            _StateMachine = stateMachine;
        }

        /// <summary>
        /// Prepares the state with the damage to apply on entry.
        /// </summary>
        /// <param name="damage">The damage amount.</param>
        public void Prepare(int damage)
        {
            _PendingDamage = damage;
        }

        /// <inheritdoc />
        public void Enter()
        {
            _ElapsedTime = 0f;
            _PlayerMovement.MoveDirection = Vector2.zero; 
            _PlayerAnimator.PlayHit();
            ApplyDamage();
        }

        /// <inheritdoc />
        public void Exit()
        {
        }

        /// <inheritdoc />
        public IState Update()
        {
            _ElapsedTime += Time.deltaTime;
            if (_ElapsedTime >= _Duration)
            {
                return _StateMachine.IdleState;
            }
            return null;
        }

        private void ApplyDamage()
        {
            int newHealth = _Model.CurrentHealth - _PendingDamage;
            _Model.SetHealth(newHealth);
            
            if (_HealthChangedEvent != null)
            {
                _HealthChangedEvent.Raise(new HealthChangedPayload(_Model.CurrentHealth, _Model.MaxHealth));
            }

            if (_Model.IsDead)
            {
                _PlayerDiedEvent?.Raise();
                _StateMachine.SetState(_StateMachine.DeathState);
            }
        }
    }
}
