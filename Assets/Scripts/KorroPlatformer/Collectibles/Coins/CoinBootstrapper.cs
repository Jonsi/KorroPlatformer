using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Collectibles.Coins
{
    /// <summary>
    /// Self-initializes a Coin when placed in the scene.
    /// Acts as the composition root for a single Coin entity.
    /// </summary>
    public class CoinBootstrapper : MonoBehaviour
    {
        [Tooltip("The visual view component.")]
        [SerializeField] private CoinView _View;
        
        [Tooltip("How much this coin is worth.")]
        [SerializeField] private int _Value = 1;
        
        [Header("Dependencies")]
        [SerializeField] private CollectibleCollectedEvent _CollectibleCollectedEvent;

        private CoinPresenter _Presenter;

        private void Start()
        {
            // 1. Create Model
            CoinModel model = new CoinModel(_Value);

            // 2. Initialize View
            if (_View == null) _View = GetComponent<CoinView>();
            _View.Initialize(model);

            // 3. Create Presenter (Wires everything together)
            _Presenter = new CoinPresenter(_View, model, _CollectibleCollectedEvent);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }
        
        private void Reset()
        {
            _View = GetComponent<CoinView>();
        }
    }
}

