using Common.Input;
using Common.Update;
using KorroPlatformer.Character.States;
using UnityEngine;

namespace KorroPlatformer.Character.MVP
{
    public class PlayerFactory
    {
        private readonly UpdateManager _UpdateManager;
        private readonly IInputProvider _InputProvider;
        private readonly PlayerConfiguration _Configuration;

        public PlayerFactory(UpdateManager updateManager, IInputProvider inputProvider, PlayerConfiguration configuration)
        {
            _UpdateManager = updateManager;
            _InputProvider = inputProvider;
            _Configuration = configuration;
        }

        public PlayerPresenter Create(PlayerView prefab, Transform parent)
        {
            PlayerModel model = new PlayerModel();
            PlayerView view = Object.Instantiate(prefab, parent);
            view.Initialize(_Configuration, model);
            PlayerStateMachine stateMachine = CreateStateMachine(view);
            
            return new PlayerPresenter(view, model, stateMachine, _UpdateManager);
        }

        private PlayerStateMachine CreateStateMachine(PlayerView view)
        {
            return new PlayerStateMachine(
                machine => new IdleState(_InputProvider, view, machine),
                machine => new WalkState(_InputProvider, view, machine),
                machine => new JumpState(_InputProvider, view, machine));
        }
    }
}
