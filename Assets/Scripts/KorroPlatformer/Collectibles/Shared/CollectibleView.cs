using System;
using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Collectibles.Shared
{
    /// <summary>
    /// View for a specific collectible instance.
    /// </summary>
    public class CollectibleView : BaseCollectibleView, IView<CollectibleModel>
    {
        /// <summary>
        /// Event triggered when the collectible is interacted with.
        /// </summary>
        public event Action OnInteract;
        
        private CollectibleModel _Model;

        /// <summary>
        /// Initializes the view with the model.
        /// </summary>
        /// <param name="model">The collectible model.</param>
        public void Initialize(CollectibleModel model)
        {
            _Model = model;
        }

        /// <inheritdoc />
        public override void Interact()
        {
            OnInteract?.Invoke();
        }

        /// <inheritdoc />
        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        /// <inheritdoc />
        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        /// <summary>
        /// Destroys the collectible game object.
        /// </summary>
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
