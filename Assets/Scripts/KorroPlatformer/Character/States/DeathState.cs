using Common.States;
using KorroPlatformer.Character.MVP;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player's death.
    /// </summary>
    public class DeathState : IState
    {
        private readonly IPlayerAnimator _PlayerAnimator;
        private PlayerStateMachine _StateMachine;

        public DeathState(IPlayerAnimator playerAnimator)
        {
            _PlayerAnimator = playerAnimator;
        }

        /// <summary>
        /// Initializes the state with the state machine.
        /// </summary>
        /// <param name="stateMachine">The state machine instance.</param>
        public void Initialize(PlayerStateMachine stateMachine)
        {
            _StateMachine = stateMachine;
        }

        /// <inheritdoc />
        public void Enter()
        {
            _PlayerAnimator?.PlayDeath();
        }

        /// <inheritdoc />
        public void Exit()
        {
        }

        /// <inheritdoc />
        public IState Update()
        {
            return null;
        }
    }
}
