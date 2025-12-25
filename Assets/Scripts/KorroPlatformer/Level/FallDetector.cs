using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Level
{
    /// <summary>
    /// Detects when the player falls below a certain Y threshold and raises the death event.
    /// </summary>
    public class FallDetector : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the player's transform to track.")]
        private Transform _PlayerTransform;

        [SerializeField, Tooltip("Transform defining the Y threshold. If player drops below this transform's Y, they die.")]
        private Transform _ThresholdTransform;

        [SerializeField, Tooltip("Event raised when the player dies.")]
        private VoidEventChannel _PlayerDiedEvent;

        private bool _HasFallen;

        private void Update()
        {
            if (_HasFallen)
            {
                return;
            }

            if (_PlayerTransform.position.y < _ThresholdTransform.position.y)
            {
                HandleFall();
            }
        }

        private void HandleFall()
        {
            _HasFallen = true;
            _PlayerDiedEvent?.Raise();
        }
    }
}