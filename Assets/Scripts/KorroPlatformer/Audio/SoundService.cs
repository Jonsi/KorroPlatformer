using Common.Events;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Audio
{
    /// <summary>
    /// Service responsible for playing sound effects in response to game events.
    /// </summary>
    public class SoundService : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField, Tooltip("Configuration asset for sound clips.")] 
        private SoundConfiguration _Configuration;
        
        [SerializeField, Tooltip("AudioSource used to play the sounds.")] 
        private AudioSource _AudioSource;

        [Header("Events")]
        [SerializeField, Tooltip("Event raised when a level is completed.")] 
        private VoidEventChannel _LevelCompletedEvent;
        
        [SerializeField, Tooltip("Event raised when the player jumps.")] 
        private VoidEventChannel _PlayerJumpEvent;
        
        [SerializeField, Tooltip("Event raised when the player dies.")] 
        private VoidEventChannel _PlayerDiedEvent;
        
        [SerializeField, Tooltip("Event raised when the player is hit.")] 
        private IntEventChannel _PlayerHitEvent;
        
        [SerializeField, Tooltip("Event raised when a collectible is collected.")] 
        private CollectibleCollectedEvent _CollectibleCollectedEvent;
        
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
