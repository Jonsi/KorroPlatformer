using Common.Update;

namespace Common.States
{
    public abstract class StateMachine : IUpdatable
    {
        private IState Current { get; set; }

        public void SetState(IState newState)
        {
            if (newState == null || Current == newState)
                return;

            Current?.Exit();
            Current = newState;
            Current.Enter();
        }

        public void Update()
        {
            if (Current == null)
                return;

            var nextState = Current.Update();
            if (nextState != null && nextState != Current)
            {
                SetState(nextState);
            }
        }
    }
}
