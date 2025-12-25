using Common.States;

namespace KorroPlatformer.Character.States
{
    /// <summary>
    /// State representing the player's death.
    /// </summary>
    public class DeathState : IState
    {
        /// <inheritdoc />
        public void Enter()
        {
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
