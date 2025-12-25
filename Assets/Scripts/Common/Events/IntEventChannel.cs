using UnityEngine;

namespace Common.Events
{
    /// <summary>
    /// Event channel for integer events.
    /// </summary>
    [CreateAssetMenu(fileName = "IntEventChannel", menuName = "KorroPlatformer/Events/Int Event Channel")]
    public class IntEventChannel : EventChannel<int>
    {
    }
}
