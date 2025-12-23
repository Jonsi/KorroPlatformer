using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    public interface IPlayerMovement
    {
        bool IsGrounded { get; }
        Vector2 MoveDirection { get; set; }
        void Jump();
    }
}
