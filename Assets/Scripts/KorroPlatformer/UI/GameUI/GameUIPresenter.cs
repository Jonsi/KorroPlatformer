using Common.MVP;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Events;

namespace KorroPlatformer.UI.GameUI
{
    /// <summary>
    /// Presenter for the Game UI, mediating between the Model, View, and Events.
    /// </summary>
    public class GameUIPresenter : BasePresenter<GameUIView, GameUIModel>
    {
        private readonly HealthChangedEvent _HealthChangedEvent;
        private readonly CollectibleCollectedEvent _CollectibleEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameUIPresenter"/> class.
        /// </summary>
        /// <param name="view">The view instance.</param>
        /// <param name="model">The model instance.</param>
        /// <param name="healthChangedEvent">The health changed event channel.</param>
        /// <param name="collectibleEvent">The collectible event channel.</param>
        public GameUIPresenter(
            GameUIView view,
            GameUIModel model,
            HealthChangedEvent healthChangedEvent,
            CollectibleCollectedEvent collectibleEvent)
            : base(view, model)
        {
            _HealthChangedEvent = healthChangedEvent;
            _CollectibleEvent = collectibleEvent;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            if (_HealthChangedEvent != null)
                _HealthChangedEvent.Subscribe(HandleHealthChanged);

            if (_CollectibleEvent != null)
                _CollectibleEvent.Subscribe(HandleCollectibleCollected);
        }

        private void UnsubscribeFromEvents()
        {
            if (_HealthChangedEvent != null)
                _HealthChangedEvent.Unsubscribe(HandleHealthChanged);

            if (_CollectibleEvent != null)
                _CollectibleEvent.Unsubscribe(HandleCollectibleCollected);
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

        /// <inheritdoc />
        public override void Dispose()
        {
            UnsubscribeFromEvents();
        }
    }
}

