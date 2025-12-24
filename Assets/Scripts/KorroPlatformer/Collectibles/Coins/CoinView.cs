using System;
using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Collectibles.Coins
{
    /// <summary>
    /// View component for a Coin collectible.
    /// </summary>
    public class CoinView : BaseCollectibleView, IView<CoinModel>
    {
        public event Action OnInteract;
        
        private CoinModel _Model;
        
        public int Value => _Model != null ? _Model.Value : 0;
        
        public void Initialize(CoinModel model)
        {
            _Model = model;
        }

        public override void Interact()
        {
            OnInteract?.Invoke();
        }

        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
