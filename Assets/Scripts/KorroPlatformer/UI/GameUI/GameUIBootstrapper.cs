using Common.Events;
using KorroPlatformer.Events;
using KorroPlatformer.Level;
using UnityEngine;

namespace KorroPlatformer.UI.GameUI
{
    /// <summary>
    /// Bootstrapper for the Game UI, initializing the MVP components.
    /// </summary>
    public class GameUIBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameUIView _View;
        [Header("Events")]
        [SerializeField] private HealthChangedEvent _HealthChangedEvent;
        [SerializeField] private CollectibleCollectedEvent _CollectibleEvent;
        [SerializeField] private VoidEventChannel _PlayerDiedEvent;
        [SerializeField] private VoidEventChannel _LevelCompleteEvent;
        
        [Header("Configuration")]
        [SerializeField] private LevelConfiguration _LevelConfiguration;
        [SerializeField] private Character.MVP.PlayerConfiguration _PlayerConfiguration;

        private GameUIPresenter _Presenter;

        private void Awake()
        {
            var model = new GameUIModel();
            
            _Presenter = new GameUIPresenter(
                _View, 
                model, 
                _HealthChangedEvent, 
                _CollectibleEvent,
                _PlayerDiedEvent,
                _LevelCompleteEvent,
                _LevelConfiguration,
                _PlayerConfiguration);
            
            _View.Initialize(model);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }
    }
}
