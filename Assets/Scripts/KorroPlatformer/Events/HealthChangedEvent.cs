using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Events
{
    /// <summary>
    /// Event channel triggered when the player's health changes.
    /// </summary>
    [CreateAssetMenu(fileName = "HealthChangedEvent", menuName = "KorroPlatformer/Events/Health Changed Event")]
    public class HealthChangedEvent : EventChannel<HealthChangedPayload>
    {
    }
}
