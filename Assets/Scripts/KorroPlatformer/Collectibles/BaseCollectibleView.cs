using Common.Interaction;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Collectibles
{
    /// <summary>
    /// Base class for all collectibles (Coins, Keys, etc.).
    /// Implements IInteractable to handle collision-based interaction.
    /// </summary>
    public abstract class BaseCollectibleView : MonoBehaviour, IInteractable
    {
        /// <inheritdoc />
        public abstract void Interact();
    }
}
