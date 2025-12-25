using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Interface for controlling player movement capabilities.
    /// </summary>
    public interface IPlayerMovement
    {
        /// <summary>
        /// Gets a value indicating whether the player is grounded.
        /// </summary>
        bool IsGrounded { get; }

        /// <summary>
        /// Gets or sets the current movement direction.
        /// </summary>
        Vector2 MoveDirection { get; set; }

        /// <summary>
        /// Triggers a jump action.
        /// </summary>
        void Jump();
    }
}
