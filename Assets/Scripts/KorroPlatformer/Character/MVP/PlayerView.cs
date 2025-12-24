using Common;
using Common.Events;
using Common.Interaction;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    public class PlayerView : MonoBehaviour, IView<PlayerModel>, IPlayerMovement, IHitable, IPlayerAnimator
    {
        [SerializeField] private CharacterController _CharacterController;
        [SerializeField] private Animator _Animator;
        [SerializeField] private IntEventChannel _HitEvent;

        private PlayerConfiguration _Config;
        private PlayerAnimationConfiguration _AnimConfig;
        private PlayerModel _Model;
        private float _VerticalVelocity;

        private int _IdleStateHash;
        private int _WalkStateHash;
        private int _JumpStateHash;
        private int _HitStateHash;

        public bool IsGrounded => _CharacterController.isGrounded;
        public Vector2 MoveDirection { get; set; }

        public void Initialize(PlayerConfiguration config, PlayerAnimationConfiguration animConfig, PlayerModel model)
        {
            _Config = config;
            _AnimConfig = animConfig;
            _Model = model;

            _IdleStateHash = Animator.StringToHash(_AnimConfig.IdleStateName);
            _WalkStateHash = Animator.StringToHash(_AnimConfig.WalkStateName);
            _JumpStateHash = Animator.StringToHash(_AnimConfig.JumpStateName);
            _HitStateHash = Animator.StringToHash(_AnimConfig.HitStateName);
        }

        void IView<PlayerModel>.Initialize(PlayerModel model) => _Model = model;

        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        public void Jump() => _VerticalVelocity = _Config.JumpForce;

        public void PlayIdle() => _Animator.CrossFade(_IdleStateHash, _AnimConfig.CrossFadeDuration);
        public void PlayWalk() => _Animator.CrossFade(_WalkStateHash, _AnimConfig.CrossFadeDuration);
        public void PlayJump() => _Animator.CrossFade(_JumpStateHash, _AnimConfig.CrossFadeDuration);
        public void PlayHit() => _Animator.CrossFade(_HitStateHash, _AnimConfig.CrossFadeDuration);

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
            if (IsGrounded && _VerticalVelocity < 0f)
                _VerticalVelocity = -1f;
            else
                _VerticalVelocity += _Config.Gravity * Time.deltaTime;

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
