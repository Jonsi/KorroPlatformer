using Common.Input;
using Common.Update;
using KorroPlatformer.Character.MVP;
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
        [SerializeField] private PlayerView _PlayerPrefab;
        [SerializeField] private Transform _SpawnPoint;
        [SerializeField] private InputActionReference _MoveAction;
        [SerializeField] private InputActionReference _JumpAction;

        private PlayerPresenter _PlayerPresenter;
        private PCInputProvider _InputProvider;

        private void Start()
        {
            _InputProvider = CreateInputProvider();
            PlayerFactory factory = new PlayerFactory(_UpdateManager, _InputProvider, _PlayerConfiguration);
            _PlayerPresenter = factory.Create(_PlayerPrefab, _SpawnPoint);
        }

        private void OnDestroy()
        {
            _PlayerPresenter?.Dispose();
            _InputProvider?.Dispose();
        }

        private PCInputProvider CreateInputProvider()
        {
            InputAction moveAction = _MoveAction != null ? _MoveAction.action : new InputAction();
            InputAction jumpAction = _JumpAction != null ? _JumpAction.action : new InputAction();
            return new PCInputProvider(moveAction, jumpAction);
        }
    }
}
