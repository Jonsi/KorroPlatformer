using Common.Input;
using Common.States;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// Represents the player idling with no movement input.
    /// </summary>
    public class IdleState : IState
    {
        private readonly IInputProvider _InputProvider;
        
        /// <summary>
        /// Gets or sets the owning state machine.
        /// </summary>
        public PlayerStateMachine StateMachine { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdleState"/> class.
        /// </summary>
        /// <param name="inputProvider">Input provider supplying movement direction.</param>
        public IdleState(IInputProvider inputProvider)
        {
            _InputProvider = inputProvider;
        }

        /// <summary>
        /// Called when entering the idle state.
        /// </summary>
        public void Enter() { }

        /// <summary>
        /// Called when exiting the idle state.
        /// </summary>
        public void Exit() { }

        /// <summary>
        /// Checks for movement input and transitions when necessary.
        /// </summary>
        /// <returns>The next state, or null to remain idle.</returns>
        public IState Update()
        {
            return _InputProvider.MoveDirection != UnityEngine.Vector2.zero ? StateMachine.WalkState : null;
        }
    }
}
