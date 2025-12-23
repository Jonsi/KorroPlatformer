using Common.Update;

namespace Common.States
{
    /// <summary>
    /// Base state machine that handles state transitions and updates.
    /// </summary>
    public abstract class StateMachine : IUpdatable
    {
        public IState CurrentState { get; private set; }

        /// <summary>
        /// Sets the current state to a new state instance.
        /// </summary>
        /// <param name="newState">The state to transition to.</param>
        public virtual void SetState(IState newState)
        {
            if (newState == null || CurrentState == newState)
                return;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        /// <summary>
        /// Updates the current state and handles transitions to next states.
        /// </summary>
        public void Update()
        {
            if (CurrentState == null)
                return;

            IState nextState = CurrentState.Update();
            if (nextState != null)
            {
                SetState(nextState);
            }
        }
    }
}
