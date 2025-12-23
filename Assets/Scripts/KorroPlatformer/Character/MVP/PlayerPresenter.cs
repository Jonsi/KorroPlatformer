using System;
using Common;
using Common.Input;
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
        private readonly IInputProvider _InputProvider;
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
        /// <param name="inputProvider">Input provider for player movement.</param>
        /// <param name="updateManager">Manager used to register for updates.</param>
        public PlayerPresenter(
            PlayerView view,
            PlayerModel model,
            PlayerStateMachine stateMachine,
            IInputProvider inputProvider,
            UpdateManager updateManager)
        {
            View = view;
            Model = model;
            _StateMachine = stateMachine;
            _InputProvider = inputProvider;
            _UpdateManager = updateManager;
            
            _UpdateManager.Register(this);
        }

        /// <summary>
        /// Initializes the player by setting the starting state.
        /// </summary>
        public void Initialize()
        {
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
        /// Unregisters updates and disposes owned resources.
        /// </summary>
        public void Dispose()
        {
            _UpdateManager.Unregister(this);
            
            if (_InputProvider is IDisposable disposableInput)
            {
                disposableInput.Dispose();
            }
        }
    }
}
