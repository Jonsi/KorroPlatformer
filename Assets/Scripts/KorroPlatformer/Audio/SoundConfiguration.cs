using UnityEngine;
using KorroPlatformer.Collectibles;

namespace KorroPlatformer.Audio
{
    /// <summary>
    /// Configuration for game sound effects.
    /// </summary>
    [CreateAssetMenu(fileName = "SoundConfiguration", menuName = "KorroPlatformer/Config/Sound Configuration")]
    public class SoundConfiguration : ScriptableObject
    {
        [Header("Level")]
        [field: SerializeField, Tooltip("Sound played when a level is completed.")]
        public AudioClip LevelComplete { get; private set; }

        [Header("Player")]
        [field: SerializeField, Tooltip("Sound played when the player jumps.")]
        public AudioClip PlayerJump { get; private set; }

        [field: SerializeField, Tooltip("Sound played when the player is hit.")]
        public AudioClip PlayerHit { get; private set; }

        [field: SerializeField, Tooltip("Sound played when the player dies.")]
        public AudioClip PlayerDeath { get; private set; }

        [Header("Collectibles")]
        [field: SerializeField, Tooltip("Sound played when a coin is collected.")]
        public AudioClip CollectCoin { get; private set; }

        [field: SerializeField, Tooltip("Sound played when a key is collected.")]
        public AudioClip CollectKey { get; private set; }

        /// <summary>
        /// Retrieves the sound clip for a specific collectible type.
        /// </summary>
        /// <param name="type">The type of collectible.</param>
        /// <returns>The corresponding AudioClip.</returns>
        public AudioClip GetCollectibleSound(CollectibleType type)
        {
            return type switch
            {
                CollectibleType.Coin => CollectCoin,
                CollectibleType.Key => CollectKey,
                _ => null
            };
        }
    }
}
