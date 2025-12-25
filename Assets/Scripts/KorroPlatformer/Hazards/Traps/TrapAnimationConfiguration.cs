using UnityEngine;

namespace KorroPlatformer.Hazards.Traps
{
    /// <summary>
    /// Configuration for trap animation states and durations.
    /// </summary>
    [CreateAssetMenu(fileName = "TrapAnimationConfiguration", menuName = "KorroPlatformer/Config/Trap Animation Configuration")]
    public class TrapAnimationConfiguration : ScriptableObject
    {
        [Header("State Names")]
        [Tooltip("The name of the Open state in the Animator.")]
        [field: SerializeField] public string OpenStateName { get; private set; } = "Open";

        [Tooltip("The name of the Closed state in the Animator.")]
        [field: SerializeField] public string ClosedStateName { get; private set; } = "Closed";

        [Header("Settings")]
        [Tooltip("Duration of the crossfade between states.")]
        [field: SerializeField] public float CrossFadeDuration { get; private set; } = 0.1f;

        [Tooltip("Duration to stay closed before opening again.")]
        [field: SerializeField] public float StayClosedDuration { get; private set; } = 2.0f;
    }
}

