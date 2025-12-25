using UnityEngine;
using KorroPlatformer.Collectibles;

namespace KorroPlatformer.Audio
{
    [CreateAssetMenu(fileName = "SoundConfiguration", menuName = "KorroPlatformer/Config/Sound Configuration")]
    public class SoundConfiguration : ScriptableObject
    {
        [Header("Level")]
        [field: SerializeField] public AudioClip LevelComplete { get; private set; }

        [Header("Player")]
        [field: SerializeField] public AudioClip PlayerJump { get; private set; }
        [field: SerializeField] public AudioClip PlayerHit { get; private set; }
        [field: SerializeField] public AudioClip PlayerDeath { get; private set; }

        [Header("Collectibles")]
        [field: SerializeField] public AudioClip CollectCoin { get; private set; }
        [field: SerializeField] public AudioClip CollectKey { get; private set; }

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
