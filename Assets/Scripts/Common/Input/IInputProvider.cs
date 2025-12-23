using UnityEngine;

namespace Common.Input
{
    public interface IInputProvider
    {
        Vector2 MoveDirection { get; }
    }
}
