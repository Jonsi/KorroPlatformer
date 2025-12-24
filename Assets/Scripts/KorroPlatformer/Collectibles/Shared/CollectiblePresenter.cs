using Common.MVP;
using KorroPlatformer.Events;

namespace KorroPlatformer.Collectibles.Shared
{
    public class CollectiblePresenter : BasePresenter<CollectibleView, CollectibleModel>
    {
        private readonly CollectibleCollectedEvent _CollectibleCollectedEvent;

        public CollectiblePresenter(CollectibleView view, CollectibleModel model, CollectibleCollectedEvent collectibleCollectedEvent) 
            : base(view, model)
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
                var payload = new CollectiblePayload(Model.Type, Model.Amount);
                _CollectibleCollectedEvent.Raise(payload);
            }
            
            View.DestroySelf();
            Dispose();
        }
    }
}

