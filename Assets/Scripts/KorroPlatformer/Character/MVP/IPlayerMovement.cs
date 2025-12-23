using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Defines movement behavior for a player character.
    /// </summary>
    public interface IPlayerMovement
    {
        /// <summary>
        /// Moves the character using the given direction vector.
        /// </summary>
        /// <param name="direction">World-space movement vector.</param>
        void Move(Vector3 direction);

        /// <summary>
        /// Gets a value indicating whether the character is grounded.
        /// </summary>
        bool IsGrounded { get; }
    }
}
