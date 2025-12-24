using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.UI.GameUI
{
    /// <summary>
    /// Bootstrapper for the Game UI, initializing the MVP components.
    /// </summary>
    public class GameUIBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameUIView _View;
        [SerializeField] private HealthChangedEvent _HealthChangedEvent;
        [SerializeField] private CollectibleCollectedEvent _CollectibleEvent;

        private GameUIPresenter _Presenter;

        private void Awake()
        {
            var model = new GameUIModel();
            
            // Initialize model with default values if needed, 
            // though actual values will likely come from initial events or separate data source.
            // For now, we assume 0/defaults until first event update or explicitly set.
            
            _Presenter = new GameUIPresenter(
                _View, 
                model, 
                _HealthChangedEvent, 
                _CollectibleEvent);
            
            _View.Initialize(model);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }
    }
}

