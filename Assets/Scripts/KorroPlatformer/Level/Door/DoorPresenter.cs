using Common.Events;
using Common.MVP;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Inventory;

namespace KorroPlatformer.Level.Door
{
    public class DoorPresenter : IPresenter<DoorView, DoorModel>
    {
        private readonly InventoryService _InventoryService;
        private readonly VoidEventChannel _LevelCompleteEvent;

        public DoorView View { get; }
        public DoorModel Model { get; }

        public DoorPresenter(
            DoorView view, 
            DoorModel model, 
            InventoryService inventoryService,
            VoidEventChannel levelCompleteEvent)
        {
            View = view;
            Model = model;
            _InventoryService = inventoryService;
            _LevelCompleteEvent = levelCompleteEvent;

            View.InteractionRequested += OnInteractionRequested;
        }

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

