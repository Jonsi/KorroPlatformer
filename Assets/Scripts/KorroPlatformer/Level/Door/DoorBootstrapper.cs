using Common.Events;
using KorroPlatformer.Inventory;
using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    public class DoorBootstrapper : MonoBehaviour
    {
        [SerializeField] private DoorView _View;
        [SerializeField] private VoidEventChannel _LevelCompleteEvent;
        [SerializeField] private InventoryService _InventoryService;
        [SerializeField] private DoorAnimationConfiguration _AnimationConfiguration;

        private DoorPresenter _Presenter;

        private void Start()
        {
            var model = new DoorModel();

            if (_View == null) _View = GetComponent<DoorView>();
            _View.Initialize(model, _AnimationConfiguration);

            _Presenter = new DoorPresenter(_View, model, _InventoryService, _LevelCompleteEvent);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }

        private void Reset()
        {
            _View = GetComponent<DoorView>();
        }
    }
}

