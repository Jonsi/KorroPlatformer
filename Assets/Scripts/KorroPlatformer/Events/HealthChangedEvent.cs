using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Events
{
    [CreateAssetMenu(fileName = "HealthChangedEvent", menuName = "KorroPlatformer/Events/Health Changed Event")]
    public class HealthChangedEvent : EventChannel<HealthChangedPayload>
    {
    }
}

