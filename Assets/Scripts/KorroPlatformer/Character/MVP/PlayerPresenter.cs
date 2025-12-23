using Common.MVP;
using Common.Update;
using KorroPlatformer.Character.States;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Coordinates player state transitions and update flow.
    /// </summary>
    public class PlayerPresenter : IPresenter<PlayerView, PlayerModel>, IUpdatable
    {
        private readonly PlayerStateMachine _StateMachine;
        private readonly UpdateManager _UpdateManager;

        /// <summary>
        /// Gets the view associated with this presenter.
        /// </summary>
        public PlayerView View { get; }

        /// <summary>
        /// Gets the model associated with this presenter.
        /// </summary>
        public PlayerModel Model { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerPresenter"/> class.
        /// </summary>
        /// <param name="view">The player view.</param>
        /// <param name="model">The player model.</param>
        /// <param name="stateMachine">State machine controlling player states.</param>
        /// <param name="updateManager">Manager used to register for updates.</param>
        public PlayerPresenter(
            PlayerView view,
            PlayerModel model,
            PlayerStateMachine stateMachine,
            UpdateManager updateManager)
        {
            View = view;
            Model = model;
            _StateMachine = stateMachine;
            _UpdateManager = updateManager;
            
            _UpdateManager.Register(this);
            _StateMachine.SetState(_StateMachine.IdleState);
        }

        /// <summary>
        /// Updates the player each frame.
        /// </summary>
        public void Update()
        {
            _StateMachine.Update();
        }

        /// <summary>
        /// Unregisters from the update manager.
        /// </summary>
        public void Dispose()
        {
            _UpdateManager.Unregister(this);
        }
    }
}
