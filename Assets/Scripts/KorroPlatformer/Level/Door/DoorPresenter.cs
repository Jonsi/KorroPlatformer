using Common.Events;
using Common.MVP;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Inventory;

namespace KorroPlatformer.Level.Door
{
    /// <summary>
    /// Presenter for the Door, managing interaction logic and events.
    /// </summary>
    public class DoorPresenter : IPresenter<DoorView, DoorModel>
    {
        private readonly InventoryService _InventoryService;
        private readonly IEventChannel _LevelCompleteEvent;

        /// <inheritdoc />
        public DoorView View { get; }
        
        /// <inheritdoc />
        public DoorModel Model { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoorPresenter"/> class.
        /// </summary>
        /// <param name="view">The door view.</param>
        /// <param name="model">The door model.</param>
        /// <param name="inventoryService">The inventory service.</param>
        /// <param name="levelCompleteEvent">The event to raise when level is complete.</param>
        public DoorPresenter(
            DoorView view, 
            DoorModel model, 
            InventoryService inventoryService,
            IEventChannel levelCompleteEvent)
        {
            View = view;
            Model = model;
            _InventoryService = inventoryService;
            _LevelCompleteEvent = levelCompleteEvent;

            View.InteractionRequested += OnInteractionRequested;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (View != null)
            {
                View.InteractionRequested -= OnInteractionRequested;
            }
        }

        private void OnInteractionRequested()
        {
            if (Model.IsOpen) return;

            if (_InventoryService.HasItem(CollectibleType.Key))
            {
                Model.IsOpen = true;
                ((IDoorAnimator)View).PlayOpen();
                _LevelCompleteEvent?.Raise();
            }
        }
    }
}
