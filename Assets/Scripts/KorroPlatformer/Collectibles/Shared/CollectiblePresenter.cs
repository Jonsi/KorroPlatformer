using Common.MVP;
using KorroPlatformer.Events;

namespace KorroPlatformer.Collectibles.Shared
{
    /// <summary>
    /// Presenter for collectibles, handling interaction and firing events.
    /// </summary>
    public class CollectiblePresenter : BasePresenter<CollectibleView, CollectibleModel>
    {
        private readonly CollectibleCollectedEvent _CollectibleCollectedEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectiblePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="model">The model.</param>
        /// <param name="collectibleCollectedEvent">The event to fire on collection.</param>
        public CollectiblePresenter(CollectibleView view, CollectibleModel model, CollectibleCollectedEvent collectibleCollectedEvent) 
            : base(view, model)
        {
            _CollectibleCollectedEvent = collectibleCollectedEvent;
            View.OnInteract += HandleInteraction;
        }

        /// <inheritdoc />
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
