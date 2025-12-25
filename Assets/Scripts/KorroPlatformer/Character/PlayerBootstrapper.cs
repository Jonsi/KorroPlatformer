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
        [SerializeField, Tooltip("Reference to the Player View.")] 
        private PlayerView _View;
        
        [SerializeField, Tooltip("UpdateManager to register the player.")] 
        private UpdateManager _UpdateManager;
        
        [Header("Configuration")]
        [SerializeField, Tooltip("Player configuration asset.")] 
        private PlayerConfiguration _Configuration;
        
        [SerializeField, Tooltip("Player animation configuration asset.")] 
        private PlayerAnimationConfiguration _AnimConfiguration;
        
        [SerializeField, Tooltip("Input action for movement.")] 
        private InputActionReference _MoveAction;
        
        [SerializeField, Tooltip("Input action for jumping.")] 
        private InputActionReference _JumpAction;

        [Header("Events")]
        [SerializeField, Tooltip("Event raised when health changes.")] 
        private HealthChangedEvent _HealthChangedEvent;
        
        [SerializeField, Tooltip("Event raised when the player dies.")] 
        private VoidEventChannel _PlayerDiedEvent;
        
        [SerializeField, Tooltip("Event raised when the player jumps.")] 
        private VoidEventChannel _PlayerJumpEvent;
        
        [SerializeField, Tooltip("Event raised when the player is hit.")] 
        private IntEventChannel _HitEvent;

        private PlayerPresenter _Presenter;
        private InputProvider _InputProvider;

        private void Awake()
        {
            _InputProvider = CreateInputProvider();
            PlayerModel model = CreateModel();
            InitializeView();
            PlayerStateMachine stateMachine = CreateStateMachine(model);
            _Presenter = CreatePresenter(model, stateMachine);
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

        private PlayerModel CreateModel()
        {
            PlayerModel model = new PlayerModel(_Configuration.MaxHealth);
            
            if (_HealthChangedEvent != null)
            {
                _HealthChangedEvent.Raise(new HealthChangedPayload(model.CurrentHealth, model.MaxHealth));
            }
            return model;
        }

        private void InitializeView()
        {
            _View.Initialize(_Configuration, _AnimConfiguration);
        }

        private PlayerStateMachine CreateStateMachine(PlayerModel model)
        {
            return new PlayerStateMachine(
                new IdleState(_InputProvider, _View, _View),
                new WalkState(_InputProvider, _View, _View, _HitEvent),
                new JumpState(_InputProvider, _View, _View, _HitEvent, _PlayerJumpEvent),
                new HitState(model, _View, _View, _HealthChangedEvent, _PlayerDiedEvent, _AnimConfiguration.HitDuration),
                new DeathState()
            );
        }

        private PlayerPresenter CreatePresenter(PlayerModel model, PlayerStateMachine stateMachine)
        {
            return new PlayerPresenter(_View, model, stateMachine, _UpdateManager);
        }
    }
}
