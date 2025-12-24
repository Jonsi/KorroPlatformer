using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    [CreateAssetMenu(fileName = "PlayerAnimationConfiguration", menuName = "KorroPlatformer/Player Animation Configuration")]
    public class PlayerAnimationConfiguration : ScriptableObject
    {
        [field: SerializeField] public string IdleStateName { get; private set; } = "Idle";
        [field: SerializeField] public string WalkStateName { get; private set; } = "Walk";
        [field: SerializeField] public float CrossFadeDuration { get; private set; } = 0.1f;
    }
}

