using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Configuration for player animations.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerAnimationConfiguration", menuName = "KorroPlatformer/Config/Player Animation Configuration")]
    public class PlayerAnimationConfiguration : ScriptableObject
    {
        [field: SerializeField, Tooltip("Name of the idle state in the Animator.")]
        public string IdleStateName { get; private set; } = "Idle";

        [field: SerializeField, Tooltip("Name of the walk state in the Animator.")]
        public string WalkStateName { get; private set; } = "Walk";

        [field: SerializeField, Tooltip("Name of the jump state in the Animator.")]
        public string JumpStateName { get; private set; } = "Jump";

        [field: SerializeField, Tooltip("Name of the hit state in the Animator.")]
        public string HitStateName { get; private set; } = "Hit";

        [field: SerializeField, Tooltip("Name of the death state in the Animator.")]
        public string DeathStateName { get; private set; } = "Death";

        [field: SerializeField, Tooltip("Duration of the cross-fade between animations.")]
        public float CrossFadeDuration { get; private set; } = 0.1f;

        [field: SerializeField, Tooltip("Duration of the hit animation state.")]
        public float HitDuration { get; private set; } = 0.5f;
    }
}
