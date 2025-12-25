using Common.Events;
using Common.States;
using KorroPlatformer.Character.MVP;
using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Character.States
{
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

        public void Initialize(PlayerStateMachine stateMachine)
        {
            _StateMachine = stateMachine;
        }

        public void Prepare(int damage)
        {
            _PendingDamage = damage;
        }

        public void Enter()
        {
            _ElapsedTime = 0f;
            _PlayerMovement.MoveDirection = Vector2.zero; // Stop movement on hit
            _PlayerAnimator.PlayHit();
            ApplyDamage();
        }

        public void Exit()
        {
        }

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
