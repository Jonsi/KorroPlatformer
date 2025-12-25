using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "KorroPlatformer/Player Configuration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
        [field: SerializeField] public float RotationSpeed { get; private set; } = 10f;
        [field: SerializeField] public float JumpForce { get; private set; } = 8f;
        [field: SerializeField] public float Gravity { get; private set; } = -20f;
        [field: SerializeField] public int MaxHealth { get; private set; } = 3;
    }
}

