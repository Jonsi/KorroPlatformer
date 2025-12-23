using UnityEngine;

namespace Common.States
{
    /// <summary>
    /// Generic state contract for state machine-driven logic.
    /// </summary>
    public interface IState
    {
        Awaitable Enter();
        Awaitable Exit();
    }
}

