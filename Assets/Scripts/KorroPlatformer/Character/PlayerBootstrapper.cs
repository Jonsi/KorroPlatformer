using Common.Events;
using Common.Input;
using Common.Update;
using KorroPlatformer.Character.MVP;
using KorroPlatformer.Character.States;
using KorroPlatformer.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KorroPlatformer.Character
{
    /// <summary>
    /// Bootstrapper for the Player, initializing MVP components.
    /// </summary>
    public class PlayerBootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerView _View;
        [SerializeField] private UpdateManager _UpdateManager;
        
        [Header("Configuration")]
        [SerializeField] private PlayerConfiguration _Configuration;
        [SerializeField] private PlayerAnimationConfiguration _AnimConfiguration;
        [SerializeField] private InputActionReference _MoveAction;
        [SerializeField] private InputActionReference _JumpAction;

        [Header("Events")]
        [SerializeField] private HealthChangedEvent _HealthChangedEvent;
        [SerializeField] private VoidEventChannel _PlayerDiedEvent;
        [SerializeField] private VoidEventChannel _PlayerJumpEvent;
        [SerializeField] private IntEventChannel _HitEvent;

        private PlayerPresenter _Presenter;
        private InputProvider _InputProvider;

        private void Awake()
        {
            _InputProvider = CreateInputProvider();

            PlayerModel model = new PlayerModel(_Configuration.MaxHealth);
            
            if (_HealthChangedEvent != null)
            {
                _HealthChangedEvent.Raise(new HealthChangedPayload(model.CurrentHealth, model.MaxHealth));
            }

            _View.Initialize(_Configuration, _AnimConfiguration);

            PlayerStateMachine stateMachine = new PlayerStateMachine(
                new IdleState(_InputProvider, _View, _View),
                new WalkState(_InputProvider, _View, _View, _HitEvent),
                new JumpState(_InputProvider, _View, _View, _HitEvent, _PlayerJumpEvent),
                new HitState(model, _View, _View, _HealthChangedEvent, _PlayerDiedEvent, _AnimConfiguration.HitDuration),
                new DeathState()
            );

            _Presenter = new PlayerPresenter(_View, model, stateMachine, _UpdateManager);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
            _InputProvider?.Dispose();
        }

        private InputProvider CreateInputProvider()
        {
            InputAction moveAction = _MoveAction != null ? _MoveAction.action : new InputAction();
            InputAction jumpAction = _JumpAction != null ? _JumpAction.action : new InputAction();
            return new InputProvider(moveAction, jumpAction);
        }
    }
}

