using UnityEngine;

namespace Common.States
{
    /// <summary>
    /// Simple state machine
    /// </summary>
    public abstract class StateMachine
    {
        /// <summary>
        /// Gets the current active state.
        /// </summary>
        public IState Current => CurrentState;

        protected IState CurrentState { get; private set; }

        /// <summary>
        /// Switches to the provided state, invoking exit/enter as needed.
        /// </summary>
        /// <param name="newState">Target state instance.</param>
        public async Awaitable SetState(IState newState)
        {
            if (newState == null || CurrentState == newState)
            {
                return;
            }

            await CurrentState?.Exit()!;
            CurrentState = newState;
            await CurrentState.Enter();
        }
    }
}

