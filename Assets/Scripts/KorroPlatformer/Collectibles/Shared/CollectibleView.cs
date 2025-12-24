using System;
using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Collectibles.Shared
{
    public class CollectibleView : BaseCollectibleView, IView<CollectibleModel>
    {
        public event Action OnInteract;
        private CollectibleModel _Model;

        public void Initialize(CollectibleModel model)
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

