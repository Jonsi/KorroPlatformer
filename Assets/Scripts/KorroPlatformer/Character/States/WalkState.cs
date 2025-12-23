using Common.Input;
using UnityEngine;
using Common.States;
using KorroPlatformer.Character.MVP;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// Handles player movement while walking.
    /// </summary>
    public class WalkState : IState
    {
        private readonly IInputProvider _InputProvider;
        private readonly IPlayerMovement _PlayerMovement;
        private const float MOVE_SPEED = 5f;

        /// <summary>
        /// Gets or sets the owning state machine.
        /// </summary>
        public PlayerStateMachine StateMachine { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WalkState"/> class.
        /// </summary>
        /// <param name="inputProvider">Input provider supplying movement direction.</param>
        /// <param name="playerMovement">Player movement handler.</param>
        public WalkState(IInputProvider inputProvider, IPlayerMovement playerMovement)
        {
            _InputProvider = inputProvider;
            _PlayerMovement = playerMovement;
        }

        /// <summary>
        /// Called when entering the walk state.
        /// </summary>
        public void Enter() { }

        /// <summary>
        /// Called when exiting the walk state.
        /// </summary>
        public void Exit() { }

        /// <summary>
        /// Updates movement and transitions to other states when needed.
        /// </summary>
        /// <returns>The next state, or null to remain walking.</returns>
        public IState Update()
        {
            Vector2 input = _InputProvider.MoveDirection;

            if (input == Vector2.zero)
                return StateMachine.IdleState;

            _PlayerMovement.Move(new Vector3(input.x, 0, input.y) * (MOVE_SPEED * Time.deltaTime));
            return null;
        }
    }
}
