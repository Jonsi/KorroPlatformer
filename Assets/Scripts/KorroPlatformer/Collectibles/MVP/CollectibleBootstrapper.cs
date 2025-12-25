using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Collectibles.MVP
{
    /// <summary>
    /// Bootstrapper for collectibles.
    /// </summary>
    public class CollectibleBootstrapper : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the Collectible View.")]
        private CollectibleView _View;
        
        [Tooltip("The type of collectible this object represents.")]
        [SerializeField] private CollectibleType _Type;
        
        [Tooltip("The amount this collectible adds.")]
        [SerializeField] private int _Amount = 1;
        
        [Header("Dependencies")]
        [SerializeField, Tooltip("Event raised when collected.")] 
        private CollectibleCollectedEvent _CollectibleCollectedEvent;

        private CollectiblePresenter _Presenter;

        private void Start()
        {
            CollectibleModel model = new CollectibleModel(_Type, _Amount);
            _View.Initialize(model);
            _Presenter = new CollectiblePresenter(_View, model, _CollectibleCollectedEvent);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }
    }
}
