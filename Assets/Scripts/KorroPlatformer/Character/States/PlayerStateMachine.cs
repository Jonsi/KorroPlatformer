using System;
using Common.States;
using UnityEngine;

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
        /// Gets the hit state instance.
        /// </summary>
        public HitState HitState { get; }

        /// <summary>
        /// Gets the death state instance.
        /// </summary>
        public DeathState DeathState { get; }

        /// <summary>
        /// Creates the state machine and initializes its states.
        /// </summary>
        public PlayerStateMachine(
            IdleState idleState,
            WalkState walkState,
            JumpState jumpState,
            HitState hitState,
            DeathState deathState)
        {
            IdleState = idleState;
            WalkState = walkState;
            JumpState = jumpState;
            HitState = hitState;
            DeathState = deathState;

            IdleState.Initialize(this);
            WalkState.Initialize(this);
            JumpState.Initialize(this);
            HitState.Initialize(this);
            // DeathState doesn't need references to other states to transition
        }

        /// <inheritdoc />
        public override void SetState(IState newState)
        {
            if (newState == null || CurrentState == newState)
                return;

            string oldStateName = CurrentState?.GetType().Name ?? "None";
            string newStateName = newState.GetType().Name;
            
            Debug.Log($"[PlayerStateMachine] Transitioning from {oldStateName} to {newStateName}");

            base.SetState(newState);
        }
    }
}
