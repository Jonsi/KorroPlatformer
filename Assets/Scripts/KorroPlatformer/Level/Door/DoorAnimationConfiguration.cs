using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    /// <summary>
    /// Configuration for door animation states.
    /// </summary>
    [CreateAssetMenu(fileName = "DoorAnimationConfiguration", menuName = "KorroPlatformer/Config/Door Animation Configuration")]
    public class DoorAnimationConfiguration : ScriptableObject
    {
        [Header("State Names")]
        [Tooltip("The name of the Open state in the Animator.")]
        [field: SerializeField] public string OpenStateName { get; private set; } = "Open";

        [Tooltip("The name of the Closed state in the Animator.")]
        [field: SerializeField] public string ClosedStateName { get; private set; } = "Closed";

        [Header("Settings")]
        [Tooltip("Duration of the crossfade between states.")]
        [field: SerializeField] public float CrossFadeDuration { get; private set; } = 0.1f;
    }
}
