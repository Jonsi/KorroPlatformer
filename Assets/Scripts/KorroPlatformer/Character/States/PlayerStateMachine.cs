using Common.States;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// Manages player-specific state transitions.
    /// </summary>
    public class PlayerStateMachine : StateMachine
    {
        /// <summary>
        /// Gets the idle state instance.
        /// </summary>
        public IdleState IdleState { get; }

        /// <summary>
        /// Gets the walk state instance.
        /// </summary>
        public WalkState WalkState { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStateMachine"/> class.
        /// </summary>
        /// <param name="idleState">The idle state instance.</param>
        /// <param name="walkState">The walk state instance.</param>
        public PlayerStateMachine(IdleState idleState, WalkState walkState)
        {
            IdleState = idleState;
            WalkState = walkState;
        }
    }
}
