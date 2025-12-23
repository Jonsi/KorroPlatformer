using Common;
using Common.Input;
using Common.MVP;
using Common.Update;
using KorroPlatformer.Character.States;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Creates and wires up player MVP components.
    /// </summary>
    public class PlayerFactory : MonoBehaviour, IFactory<PlayerPresenter, PlayerView, PlayerModel>
    {
        [SerializeField] private UpdateManager _UpdateManager;

        /// <summary>
        /// Instantiates and initializes the player presenter.
        /// </summary>
        /// <param name="prefab">Player view prefab.</param>
        /// <param name="model">Player model instance.</param>
        /// <param name="parent">Transform to parent the view under.</param>
        /// <returns>The initialized player presenter.</returns>
        public PlayerPresenter Create(PlayerView prefab, PlayerModel model, Transform parent)
        {
            PlayerView view = InstantiateView(prefab, parent);
            view.Initialize(model);
            
            IInputProvider inputProvider = CreateInputProvider(view);
            PlayerStateMachine stateMachine = CreateStateMachine(inputProvider, view);
            PlayerPresenter presenter = CreatePresenter(view, model, stateMachine, inputProvider);
            presenter.Initialize();
            
            return presenter;
        }

        private PlayerView InstantiateView(PlayerView prefab, Transform parent)
        {
            return Instantiate(prefab, parent);
        }

        private IInputProvider CreateInputProvider(PlayerView view)
        {
            InputAction action = view.MoveAction != null ? view.MoveAction.action : new InputAction();
            return new PCInputProvider(action);
        }

        private PlayerStateMachine CreateStateMachine(IInputProvider inputProvider, PlayerView view)
        {
            IdleState idleState = new IdleState(inputProvider);
            WalkState walkState = new WalkState(inputProvider, view);
            PlayerStateMachine stateMachine = new PlayerStateMachine(idleState, walkState);
            
            idleState.StateMachine = stateMachine;
            walkState.StateMachine = stateMachine;

            return stateMachine;
        }

        private PlayerPresenter CreatePresenter(
            PlayerView view,
            PlayerModel model,
            PlayerStateMachine stateMachine,
            IInputProvider inputProvider)
        {
            return new PlayerPresenter(view, model, stateMachine, inputProvider, _UpdateManager);
        }
    }
}
