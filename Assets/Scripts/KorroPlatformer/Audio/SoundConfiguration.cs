using UnityEngine;
using KorroPlatformer.Collectibles;

namespace KorroPlatformer.Audio
{
    [CreateAssetMenu(fileName = "SoundConfiguration", menuName = "KorroPlatformer/Audio/Sound Configuration")]
    public class SoundConfiguration : ScriptableObject
    {
        [Header("Level")]
        public AudioClip LevelComplete;

        [Header("Player")]
        public AudioClip PlayerJump;
        public AudioClip PlayerHit;
        public AudioClip PlayerDeath;

        [Header("Collectibles")]
        public AudioClip CollectCoin;
        public AudioClip CollectKey;

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

