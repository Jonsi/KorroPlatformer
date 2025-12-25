using Common;
using Common.Events;
using Common.Interaction;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// View component for the Player, handling input, animation, and physics.
    /// </summary>
    public class PlayerView : MonoBehaviour, IView<PlayerModel>, IPlayerMovement, IHitable, IPlayerAnimator
    {
        [SerializeField, Tooltip("Reference to the CharacterController component.")]
        private CharacterController _CharacterController;

        [SerializeField, Tooltip("Reference to the Animator component.")]
        private Animator _Animator;

        [SerializeField, Tooltip("Event raised when the player is hit.")]
        private IntEventChannel _HitEvent;

        private PlayerConfiguration _Config;
        private PlayerAnimationConfiguration _AnimConfig;
        private float _VerticalVelocity;

        private int _IdleStateHash;
        private int _WalkStateHash;
        private int _JumpStateHash;
        private int _HitStateHash;

        /// <inheritdoc />
        public bool IsGrounded => _CharacterController.isGrounded;

        /// <inheritdoc />
        public Vector2 MoveDirection { get; set; }

        /// <summary>
        /// Initializes the player view with configuration.
        /// </summary>
        /// <param name="config">The player configuration.</param>
        /// <param name="animConfig">The animation configuration.</param>
        public void Initialize(PlayerConfiguration config, PlayerAnimationConfiguration animConfig)
        {
            _Config = config;
            _AnimConfig = animConfig;

            _IdleStateHash = Animator.StringToHash(_AnimConfig.IdleStateName);
            _WalkStateHash = Animator.StringToHash(_AnimConfig.WalkStateName);
            _JumpStateHash = Animator.StringToHash(_AnimConfig.JumpStateName);
            _HitStateHash = Animator.StringToHash(_AnimConfig.HitStateName);
        }

        void IView<PlayerModel>.Initialize(PlayerModel model)
        {
        }

        /// <inheritdoc />
        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        /// <inheritdoc />
        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        /// <inheritdoc />
        public void Jump() => _VerticalVelocity = _Config.JumpForce;

        /// <inheritdoc />
        public void PlayIdle() => _Animator.CrossFade(_IdleStateHash, _AnimConfig.CrossFadeDuration);
        /// <inheritdoc />
        public void PlayWalk() => _Animator.CrossFade(_WalkStateHash, _AnimConfig.CrossFadeDuration);
        /// <inheritdoc />
        public void PlayJump() => _Animator.CrossFade(_JumpStateHash, _AnimConfig.CrossFadeDuration);
        /// <inheritdoc />
        public void PlayHit() => _Animator.CrossFade(_HitStateHash, _AnimConfig.CrossFadeDuration);

        /// <inheritdoc />
        public void TakeDamage(int damage)
        {
            if (_HitEvent != null)
            {
                _HitEvent.Raise(damage);
                Debug.Log("hit " + damage);
            }
        }

        private void Update()
        {
            ApplyGravity();
            UpdateRotation();
            ApplyMovement();
        }

        private void ApplyGravity()
        {
            if (IsGrounded && _VerticalVelocity < 0f)
                _VerticalVelocity = -1f;
            else
                _VerticalVelocity += _Config.Gravity * Time.deltaTime;
        }

        private void UpdateRotation()
        {
            Vector3 horizontalDirection = new Vector3(MoveDirection.x, 0f, MoveDirection.y);
            if (horizontalDirection.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(horizontalDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _Config.RotationSpeed * Time.deltaTime);
            }
        }

        private void ApplyMovement()
        {
            Vector3 move = new Vector3(MoveDirection.x * _Config.MoveSpeed, _VerticalVelocity, MoveDirection.y * _Config.MoveSpeed);
            _CharacterController.Move(move * Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
