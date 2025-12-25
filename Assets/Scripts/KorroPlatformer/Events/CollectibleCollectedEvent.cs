using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Events
{
    /// <summary>
    /// Event channel triggered when a collectible is gathered by the player.
    /// </summary>
    [CreateAssetMenu(fileName = "CollectibleCollectedEvent", menuName = "KorroPlatformer/Events/Collectible Collected Event")]
    public class CollectibleCollectedEvent : EventChannel<CollectiblePayload>
    {
    }
}
