using Common.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KorroPlatformer.Level
{
    /// <summary>
    /// Manages the flow of the level as a ScriptableObject service.
    /// </summary>
    [CreateAssetMenu(fileName = "LevelFlowManager", menuName = "KorroPlatformer/Services/Level Flow Manager")]
    public class LevelFlowManager : ScriptableObject, ILevelFlowManager
    {
        [SerializeField, Tooltip("Configuration for level data.")]
        private LevelConfiguration _LevelConfiguration;

        [SerializeField, Tooltip("Event raised when the player dies.")]
        private VoidEventChannel _PlayerDiedEvent;

        [SerializeField, Tooltip("Event raised when the level is completed.")]
        private VoidEventChannel _LevelCompleteEvent;

        /// <summary>
        /// Initializes the manager and subscribes to events.
        /// </summary>
        public void Initialize()
        {
            SubscribeToEvents();
        }

        /// <summary>
        /// Cleans up subscriptions and resets time scale.
        /// </summary>
        public void Cleanup()
        {
            UnsubscribeFromEvents();
            Time.timeScale = 1f;
        }

        private void SubscribeToEvents()
        {
            if (_PlayerDiedEvent != null)
                _PlayerDiedEvent.Subscribe(HandleGameEnd);

            if (_LevelCompleteEvent != null)
                _LevelCompleteEvent.Subscribe(HandleGameEnd);
        }

        private void UnsubscribeFromEvents()
        {
            if (_PlayerDiedEvent != null)
                _PlayerDiedEvent.Unsubscribe(HandleGameEnd);

            if (_LevelCompleteEvent != null)
                _LevelCompleteEvent.Unsubscribe(HandleGameEnd);
        }

        private void HandleGameEnd()
        {
            Time.timeScale = 0f;
        }

        /// <summary>
        /// Reloads the current level.
        /// </summary>
        public async Awaitable RetryLevel()
        {
            Time.timeScale = 1f;
            await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// Loads the main menu scene.
        /// </summary>
        public async Awaitable GoToMainMenu()
        {
            Time.timeScale = 1f;
            if (_LevelConfiguration != null && !string.IsNullOrEmpty(_LevelConfiguration.MainMenuSceneName))
            {
                await SceneManager.LoadSceneAsync(_LevelConfiguration.MainMenuSceneName);
            }
        }
    }
}
