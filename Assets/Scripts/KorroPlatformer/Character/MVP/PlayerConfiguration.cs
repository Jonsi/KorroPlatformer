using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Configuration for player movement and stats.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "KorroPlatformer/Config/Player Configuration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [field: SerializeField, Tooltip("Movement speed of the player.")]
        public float MoveSpeed { get; private set; } = 5f;

        [field: SerializeField, Tooltip("Rotation speed when turning.")]
        public float RotationSpeed { get; private set; } = 10f;

        [field: SerializeField, Tooltip("Force applied when jumping.")]
        public float JumpForce { get; private set; } = 8f;

        [field: SerializeField, Tooltip("Gravity force applied to the player.")]
        public float Gravity { get; private set; } = -20f;

        [field: SerializeField, Tooltip("Maximum health of the player.")]
        public int MaxHealth { get; private set; } = 3;
    }
}
