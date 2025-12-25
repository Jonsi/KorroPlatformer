using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    [CreateAssetMenu(fileName = "PlayerAnimationConfiguration", menuName = "KorroPlatformer/Config/Player Animation Configuration")]
    public class PlayerAnimationConfiguration : ScriptableObject
    {
        [field: SerializeField] public string IdleStateName { get; private set; } = "Idle";
        [field: SerializeField] public string WalkStateName { get; private set; } = "Walk";
        [field: SerializeField] public string JumpStateName { get; private set; } = "Jump";
        [field: SerializeField] public string HitStateName { get; private set; } = "Hit";
        [field: SerializeField] public float CrossFadeDuration { get; private set; } = 0.1f;
        [field: SerializeField] public float HitDuration { get; private set; } = 0.5f;
    }
}

