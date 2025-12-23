using Common.Update;

namespace Common.States
{
    /// <summary>
    /// Base state machine that handles state transitions and updates.
    /// </summary>
    public abstract class StateMachine : IUpdatable
    {
        private IState Current { get; set; }

        /// <summary>
        /// Sets the current state to a new state instance.
        /// </summary>
        /// <param name="newState">The state to transition to.</param>
        public void SetState(IState newState)
        {
            if (newState == null || Current == newState)
                return;

            Current?.Exit();
            Current = newState;
            Current.Enter();
        }

        /// <summary>
        /// Updates the current state and handles transitions to next states.
        /// </summary>
        public void Update()
        {
            if (Current == null)
                return;

            var nextState = Current.Update();
            if (nextState != null && nextState != Current)
            {
                SetState(nextState);
            }
        }
    }
}
