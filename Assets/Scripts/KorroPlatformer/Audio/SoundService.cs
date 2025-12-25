using Common.Events;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Audio
{
    public class SoundService : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private SoundConfiguration _Configuration;
        [SerializeField] private AudioSource _AudioSource;

        [Header("Events")]
        [SerializeField] private VoidEventChannel _LevelCompletedEvent;
        [SerializeField] private VoidEventChannel _PlayerJumpEvent;
        [SerializeField] private VoidEventChannel _PlayerDiedEvent;
        [SerializeField] private IntEventChannel _PlayerHitEvent;
        [SerializeField] private CollectibleCollectedEvent _CollectibleCollectedEvent;

        private void Awake()
        {
            if (_AudioSource == null)
            {
                _AudioSource = GetComponent<AudioSource>();
                if (_AudioSource == null)
                {
                    _AudioSource = gameObject.AddComponent<AudioSource>();
                }
            }
        }

        private void OnEnable()
        {
            if (_LevelCompletedEvent != null) _LevelCompletedEvent.Subscribe(OnLevelComplete);
            if (_PlayerJumpEvent != null) _PlayerJumpEvent.Subscribe(OnPlayerJump);
            if (_PlayerDiedEvent != null) _PlayerDiedEvent.Subscribe(OnPlayerDied);
            if (_PlayerHitEvent != null) _PlayerHitEvent.Subscribe(OnPlayerHit);
            if (_CollectibleCollectedEvent != null) _CollectibleCollectedEvent.Subscribe(OnCollectibleCollected);
        }

        private void OnDisable()
        {
            if (_LevelCompletedEvent != null) _LevelCompletedEvent.Unsubscribe(OnLevelComplete);
            if (_PlayerJumpEvent != null) _PlayerJumpEvent.Unsubscribe(OnPlayerJump);
            if (_PlayerDiedEvent != null) _PlayerDiedEvent.Unsubscribe(OnPlayerDied);
            if (_PlayerHitEvent != null) _PlayerHitEvent.Unsubscribe(OnPlayerHit);
            if (_CollectibleCollectedEvent != null) _CollectibleCollectedEvent.Unsubscribe(OnCollectibleCollected);
        }

        private void OnLevelComplete() => PlaySound(_Configuration.LevelComplete);
        private void OnPlayerJump() => PlaySound(_Configuration.PlayerJump);
        private void OnPlayerDied() => PlaySound(_Configuration.PlayerDeath);
        private void OnPlayerHit(int damage) => PlaySound(_Configuration.PlayerHit);
        
        private void OnCollectibleCollected(CollectiblePayload payload)
        {
            var clip = _Configuration.GetCollectibleSound(payload.Type);
            PlaySound(clip);
        }

        private void PlaySound(AudioClip clip)
        {
            if (clip != null && _AudioSource != null)
            {
                _AudioSource.PlayOneShot(clip);
            }
        }
    }
}

