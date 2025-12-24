using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    [CreateAssetMenu(fileName = "DoorAnimationConfiguration", menuName = "KorroPlatformer/Animation/Door Animation Configuration")]
    public class DoorAnimationConfiguration : ScriptableObject
    {
        [Header("State Names")]
        [Tooltip("The name of the Open state in the Animator.")]
        public string OpenStateName = "Open";

        [Tooltip("The name of the Closed state in the Animator.")]
        public string ClosedStateName = "Closed";

        [Header("Settings")]
        [Tooltip("Duration of the crossfade between states.")]
        public float CrossFadeDuration = 0.1f;
    }
}

