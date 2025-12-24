using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Collectibles.Shared
{
    public class CollectibleBootstrapper : MonoBehaviour
    {
        [SerializeField] private CollectibleView _View;
        
        [Tooltip("The type of collectible this object represents.")]
        [SerializeField] private CollectibleType _Type;
        
        [Tooltip("The amount this collectible adds.")]
        [SerializeField] private int _Amount = 1;
        
        [Header("Dependencies")]
        [SerializeField] private CollectibleCollectedEvent _CollectibleCollectedEvent;

        private CollectiblePresenter _Presenter;

        private void Start()
        {
            CollectibleModel model = new CollectibleModel(_Type, _Amount);

            if (_View == null) _View = GetComponent<CollectibleView>();
            _View.Initialize(model);

            _Presenter = new CollectiblePresenter(_View, model, _CollectibleCollectedEvent);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }

        private void Reset()
        {
            _View = GetComponent<CollectibleView>();
        }
    }
}

