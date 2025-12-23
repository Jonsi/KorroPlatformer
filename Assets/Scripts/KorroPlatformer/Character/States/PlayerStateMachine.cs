using System;
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
        /// Gets the jump state instance.
        /// </summary>
        public JumpState JumpState { get; }

        /// <summary>
        /// Creates the state machine and its states.
        /// </summary>
        public PlayerStateMachine(
            Func<PlayerStateMachine, IdleState> createIdleState,
            Func<PlayerStateMachine, WalkState> createWalkState,
            Func<PlayerStateMachine, JumpState> createJumpState)
        {
            IdleState = createIdleState(this);
            WalkState = createWalkState(this);
            JumpState = createJumpState(this);
        }
    }
}
