using Common.MVP;
using KorroPlatformer.Events;

namespace KorroPlatformer.Collectibles.Coins
{
    public class CoinPresenter : BasePresenter<CoinView, CoinModel>
    {
        private readonly CollectibleCollectedEvent _CollectibleCollectedEvent;

        public CoinPresenter(CoinView view, CoinModel model, CollectibleCollectedEvent collectibleCollectedEvent) : base(view, model)
        {
            _CollectibleCollectedEvent = collectibleCollectedEvent;
            
            View.OnInteract += HandleInteraction;
        }

        public override void Dispose()
        {
            View.OnInteract -= HandleInteraction;
        }

        private void HandleInteraction()
        {
            if (_CollectibleCollectedEvent != null)
            {
                // Raise event with Payload instead of View
                var payload = new CollectiblePayload(CollectibleType.Coin, Model.Value);
                _CollectibleCollectedEvent.Raise(payload);
            }
            
            View.DestroySelf();
            Dispose();
        }
    }
}
