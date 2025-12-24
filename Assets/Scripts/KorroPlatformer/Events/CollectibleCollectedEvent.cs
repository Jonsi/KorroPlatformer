using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Events
{
    [CreateAssetMenu(fileName = "CollectibleCollectedEvent", menuName = "KorroPlatformer/Events/Collectible Collected Event")]
    public class CollectibleCollectedEvent : EventChannel<CollectiblePayload>
    {
    }
}
