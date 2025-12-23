using KorroPlatformer.Character.MVP;
using UnityEngine;

namespace KorroPlatformer
{
    /// <summary>
    /// Boots the game by spawning the player and managing its lifecycle.
    /// </summary>
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        private PlayerPresenter _playerPresenter;

        private void Start()
        {
            _playerPresenter = _playerFactory.Create(_playerPrefab, new PlayerModel(), _spawnPoint);
        }

        private void OnDestroy()
        {
            _playerPresenter?.Dispose();
        }
    }
}

