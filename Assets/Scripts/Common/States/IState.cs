namespace Common.States
{
    public interface IState
    {
        void Enter();
        void Exit();
        IState Update();
    }
}
