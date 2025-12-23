namespace Common.States
{
    /// <summary>
    /// Represents a state that can be entered, updated, and exited.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Called when the state becomes active.
        /// </summary>
        void Enter();

        /// <summary>
        /// Called when the state is left.
        /// </summary>
        void Exit();

        /// <summary>
        /// Performs per-frame logic and optionally returns a new state to transition to.
        /// </summary>
        /// <returns>The next state, or null to stay in the current state.</returns>
        IState Update();
    }
}
