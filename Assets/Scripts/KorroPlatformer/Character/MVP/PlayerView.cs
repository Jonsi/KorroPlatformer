using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    public class PlayerView : MonoBehaviour, IView<PlayerModel>, IPlayerMovement
    {
        [SerializeField] private CharacterController _CharacterController;

        private PlayerConfiguration _Config;
        private PlayerModel _Model;
        private float _VerticalVelocity;

        public bool IsGrounded => _CharacterController.isGrounded;
        public Vector2 MoveDirection { get; set; }

        public void Initialize(PlayerConfiguration config, PlayerModel model)
        {
            _Config = config;
            _Model = model;
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

        private void Update()
        {
            if (IsGrounded && _VerticalVelocity < 0f)
                _VerticalVelocity = -1f;
            else
                _VerticalVelocity += _Config.Gravity * Time.deltaTime;

            Vector3 move = new Vector3(MoveDirection.x * _Config.MoveSpeed, _VerticalVelocity, MoveDirection.y * _Config.MoveSpeed);
            _CharacterController.Move(move * Time.deltaTime);
        }
    }
}
