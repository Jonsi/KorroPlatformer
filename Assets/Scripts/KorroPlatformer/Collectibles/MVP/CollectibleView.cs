using System;
using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Collectibles.MVP
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

        /// <summary>
        /// Initializes the view with the model.
        /// </summary>
        /// <param name="model">The collectible model.</param>
        public void Initialize(CollectibleModel model)
        {
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
