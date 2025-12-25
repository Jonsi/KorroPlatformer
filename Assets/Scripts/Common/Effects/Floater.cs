using UnityEngine;

namespace Common.Effects
{
    /// <summary>
    /// Makes a GameObject float up and down and optionally rotate.
    /// </summary>
    public class Floater : MonoBehaviour
    {
        [Header("Floating Settings")]
        [SerializeField, Tooltip("Amplitude of the sine wave (height).")]
        private float _Amplitude = 0.5f;

        [SerializeField, Tooltip("Frequency of the sine wave (speed).")]
        private float _Frequency = 1f;

        [Header("Rotation Settings")]
        [SerializeField, Tooltip("Rotation speed in degrees per second.")]
        private float _RotationSpeed = 30f;

        [SerializeField, Tooltip("Axis to rotate around.")]
        private Vector3 _RotationAxis = Vector3.up;
        
        [SerializeField, Tooltip("Whether to enable rotation.")]
        private bool _EnableRotation = true;

        private Vector3 _StartPosition;

        private void Start()
        {
            _StartPosition = transform.position;
        }

        private void Update()
        {
            // Floating
            float newY = _StartPosition.y + Mathf.Sin(Time.time * _Frequency) * _Amplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Rotation
            if (_EnableRotation)
            {
                transform.Rotate(_RotationAxis, _RotationSpeed * Time.deltaTime);
            }
        }
    }
}

