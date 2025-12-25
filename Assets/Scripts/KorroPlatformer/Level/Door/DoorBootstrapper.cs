using Common.Events;
using KorroPlatformer.Inventory;
using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    /// <summary>
    /// Bootstrapper for the Door component, wiring up MVP dependencies.
    /// </summary>
    public class DoorBootstrapper : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the Door View component.")] 
        private DoorView _View;
        
        [SerializeField, Tooltip("Event raised when the level is completed.")] 
        private VoidEventChannel _LevelCompleteEvent;
        
        [SerializeField, Tooltip("Service for checking inventory items.")] 
        private InventoryService _InventoryService;
        
        [SerializeField, Tooltip("Configuration for door animations.")] 
        private DoorAnimationConfiguration _AnimationConfiguration;

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
