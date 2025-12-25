using Common;
using Common.Events;
using Common.MVP;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Events;
using KorroPlatformer.Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KorroPlatformer.UI.GameUI
{
    /// <summary>
    /// Presenter for the Game UI, mediating between the Model, View, and Events.
    /// </summary>
    public class GameUIPresenter : BasePresenter<GameUIView, GameUIModel>
    {
        private readonly HealthChangedEvent _HealthChangedEvent;
        private readonly CollectibleCollectedEvent _CollectibleEvent;
        private readonly VoidEventChannel _PlayerDiedEvent;
        private readonly VoidEventChannel _LevelCompleteEvent;
        private readonly ILevelProvider _LevelProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameUIPresenter"/> class.
        /// </summary>
        public GameUIPresenter(
            GameUIView view,
            GameUIModel model,
            HealthChangedEvent healthChangedEvent,
            CollectibleCollectedEvent collectibleEvent,
            VoidEventChannel playerDiedEvent,
            VoidEventChannel levelCompleteEvent,
            ILevelProvider levelProvider)
            : base(view, model)
        {
            _HealthChangedEvent = healthChangedEvent;
            _CollectibleEvent = collectibleEvent;
            _PlayerDiedEvent = playerDiedEvent;
            _LevelCompleteEvent = levelCompleteEvent;
            _LevelProvider = levelProvider;

            SubscribeToEvents();
            
            if (View != null)
            {
                View.OnBackToMenuRequested += HandleBackToMenuRequested;
            }
        }

        private void SubscribeToEvents()
        {
            if (_HealthChangedEvent != null)
                _HealthChangedEvent.Subscribe(HandleHealthChanged);

            if (_CollectibleEvent != null)
                _CollectibleEvent.Subscribe(HandleCollectibleCollected);
                
            if (_PlayerDiedEvent != null)
                _PlayerDiedEvent.Subscribe(HandleGameEnd);

            if (_LevelCompleteEvent != null)
                _LevelCompleteEvent.Subscribe(HandleGameEnd);
        }

        private void UnsubscribeFromEvents()
        {
            if (_HealthChangedEvent != null)
                _HealthChangedEvent.Unsubscribe(HandleHealthChanged);

            if (_CollectibleEvent != null)
                _CollectibleEvent.Unsubscribe(HandleCollectibleCollected);
                
            if (_PlayerDiedEvent != null)
                _PlayerDiedEvent.Unsubscribe(HandleGameEnd);

            if (_LevelCompleteEvent != null)
                _LevelCompleteEvent.Unsubscribe(HandleGameEnd);
        }

        private void HandleHealthChanged(HealthChangedPayload payload)
        {
            Model.CurrentHealth = payload.CurrentHealth;
            Model.MaxHealth = payload.MaxHealth;
            View.UpdateHealth(Model.CurrentHealth, Model.MaxHealth);
        }

        private void HandleCollectibleCollected(CollectiblePayload payload)
        {
            switch (payload.Type)
            {
                case CollectibleType.Coin:
                    Model.CoinCount += payload.Amount;
                    View.UpdateCoinCount(Model.CoinCount);
                    break;
                case CollectibleType.Key:
                    Model.HasKey = true;
                    View.UpdateKeyStatus(Model.HasKey);
                    break;
            }
        }
        
        private void HandleGameEnd()
        {
            // View.ShowBackToMenu();
        }

        private async Awaitable HandleBackToMenuRequesteAsync()
        {
            if (_LevelProvider != null && !string.IsNullOrEmpty(_LevelProvider.MainMenuSceneName))
            {
                await SceneManager.LoadSceneAsync(_LevelProvider.MainMenuSceneName);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            UnsubscribeFromEvents();
            if (View != null)
            {
                View.OnBackToMenuRequested -= HandleBackToMenuRequested;
            }
        }

        private void HandleBackToMenuRequested()
        {
            _ = HandleBackToMenuRequesteAsync();
        }
    }
}
