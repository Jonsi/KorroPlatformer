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
        [SerializeField, Tooltip("Reference to the Game UI View.")] 
        private GameUIView _View;
        
        [Header("Events")]
        [SerializeField, Tooltip("Event raised when player health changes.")] 
        private HealthChangedEvent _HealthChangedEvent;
        
        [SerializeField, Tooltip("Event raised when a collectible is collected.")] 
        private CollectibleCollectedEvent _CollectibleEvent;
        
        [SerializeField, Tooltip("Event raised when the player dies.")] 
        private VoidEventChannel _PlayerDiedEvent;
        
        [SerializeField, Tooltip("Event raised when the level is completed.")] 
        private VoidEventChannel _LevelCompleteEvent;
        
        [Header("Configuration")]
        [SerializeField, Tooltip("Configuration for the current level.")] 
        private LevelConfiguration _LevelConfiguration;
        
        [SerializeField, Tooltip("Configuration for player stats.")] 
        private Character.MVP.PlayerConfiguration _PlayerConfiguration;

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
