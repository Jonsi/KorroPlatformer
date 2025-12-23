using Common;
using Common.MVP;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Represents the player in the scene and executes movement.
    /// </summary>
    public class PlayerView : MonoBehaviour, IView<PlayerModel>, IPlayerMovement
    {
        [SerializeField] private CharacterController _CharacterController;
        [SerializeField] private InputActionReference _MoveAction;

        /// <summary>
        /// Gets the input action reference used for movement.
        /// </summary>
        public InputActionReference MoveAction => _MoveAction;

        /// <summary>
        /// Initializes the view with the specified model.
        /// </summary>
        /// <param name="model">The player model to initialize the view with.</param>
        public void Initialize(PlayerModel model)
        {
        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <returns>An awaitable representing the show operation.</returns>
        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <returns>An awaitable representing the hide operation.</returns>
        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        /// <summary>
        /// Moves the character controller by the given direction.
        /// </summary>
        /// <param name="direction">World-space movement vector.</param>
        public void Move(Vector3 direction)
        {
            _CharacterController.Move(direction);
        }

        /// <summary>
        /// Gets a value indicating whether the character controller is grounded.
        /// </summary>
        public bool IsGrounded => _CharacterController.isGrounded;
    }
}
