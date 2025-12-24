using Common.Events;
using Common.Input;
using Common.Update;
using KorroPlatformer.Character.States;
using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    public class PlayerFactory
    {
        private readonly UpdateManager _UpdateManager;
        private readonly IInputProvider _InputProvider;
        private readonly PlayerConfiguration _Configuration;
        private readonly PlayerAnimationConfiguration _AnimConfiguration;
        private readonly HealthChangedEvent _HealthChangedEvent;
        private readonly VoidEventChannel _PlayerDiedEvent;
        private readonly IntEventChannel _HitEvent;

        public PlayerFactory(
            UpdateManager updateManager, 
            IInputProvider inputProvider, 
            PlayerConfiguration configuration,
            PlayerAnimationConfiguration animConfiguration,
            HealthChangedEvent healthChangedEvent,
            VoidEventChannel playerDiedEvent,
            IntEventChannel hitEvent)
        {
            _UpdateManager = updateManager;
            _InputProvider = inputProvider;
            _Configuration = configuration;
            _AnimConfiguration = animConfiguration;
            _HealthChangedEvent = healthChangedEvent;
            _PlayerDiedEvent = playerDiedEvent;
            _HitEvent = hitEvent;
        }

        public PlayerPresenter Create(PlayerView prefab, Transform parent)
        {
            PlayerModel model = new PlayerModel(_Configuration.MaxHealth);

            if (_HealthChangedEvent != null)
            {
                _HealthChangedEvent.Raise(new HealthChangedPayload(model.CurrentHealth, model.MaxHealth));
            }

            PlayerView view = Object.Instantiate(prefab, parent);
            view.Initialize(_Configuration, _AnimConfiguration, model);
            PlayerStateMachine stateMachine = CreateStateMachine(view, model);
            
            return new PlayerPresenter(view, model, stateMachine, _UpdateManager);
        }

        private PlayerStateMachine CreateStateMachine(PlayerView view, PlayerModel model)
        {
            return new PlayerStateMachine(
                new IdleState(_InputProvider, view, view),
                new WalkState(_InputProvider, view, view, _HitEvent),
                new JumpState(_InputProvider, view, view, _HitEvent),
                new HitState(model, view, view, _HealthChangedEvent, _PlayerDiedEvent, _AnimConfiguration.HitDuration),
                new DeathState()
            );
        }
    }
}
