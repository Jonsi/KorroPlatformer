using Common;
using Common.Events;
using Common.Input;
using Common.Update;
using KorroPlatformer.Character.MVP;
using KorroPlatformer.Events;
using KorroPlatformer.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KorroPlatformer
{
    /// <summary>
    /// Boots the game by spawning the player and managing its lifecycle.
    /// </summary>
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private UpdateManager _UpdateManager;
        [SerializeField] private PlayerConfiguration _PlayerConfiguration;
        [SerializeField] private PlayerAnimationConfiguration _PlayerAnimationConfiguration;
        [SerializeField] private PlayerView _PlayerPrefab;
        [SerializeField] private Transform _SpawnPoint;
        [SerializeField] private InputActionReference _MoveAction;
        [SerializeField] private InputActionReference _JumpAction;
        
        [Header("Events")]
        [SerializeField] private HealthChangedEvent _HealthChangedEvent;
        [SerializeField] private VoidEventChannel _PlayerDiedEvent;
        [SerializeField] private IntEventChannel _HitEvent;
        [SerializeField] private CollectibleCollectedEvent _CollectibleCollectedEvent;

        private PlayerPresenter _PlayerPresenter;
        private InventoryService _InventoryService;
        private InputProvider _InputProvider;

        private void Start()
        {
            _InputProvider = CreateInputProvider();
            
            // Create Player
            PlayerFactory factory = new PlayerFactory(
                _UpdateManager, 
                _InputProvider, 
                _PlayerConfiguration, 
                _PlayerAnimationConfiguration,
                _HealthChangedEvent, 
                _PlayerDiedEvent,
                _HitEvent);
            
            _PlayerPresenter = factory.Create(_PlayerPrefab, _SpawnPoint);
            
            // Create Inventory Service
            _InventoryService = new InventoryService(_CollectibleCollectedEvent);
        }

        private void Update()
        {
            // DEBUG: Press T to take damage
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                TestTakeDamage();
            }
        }

        private void OnDestroy()
        {
            _PlayerPresenter?.Dispose();
            _InventoryService?.Dispose();
            _InputProvider?.Dispose();
        }

        private InputProvider CreateInputProvider()
        {
            InputAction moveAction = _MoveAction != null ? _MoveAction.action : new InputAction();
            InputAction jumpAction = _JumpAction != null ? _JumpAction.action : new InputAction();
            return new InputProvider(moveAction, jumpAction);
        }

        [ContextMenu("Test Take Damage")]
        private void TestTakeDamage()
        {
            if (Application.isPlaying)
            {
                if (_PlayerPresenter != null && _PlayerPresenter.View != null)
                {
                    Debug.Log("Test: Applying 1 Damage to View...");
                    ((IHitable)_PlayerPresenter.View).TakeDamage(1);
                }
            }
            else
            {
                Debug.LogWarning("Can only test damage in Play Mode.");
            }
        }
    }
}
