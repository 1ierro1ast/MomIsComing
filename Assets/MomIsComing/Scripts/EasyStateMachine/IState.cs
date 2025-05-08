namespace MomIsComing.Scripts.EasyStateMachine
{
    public interface IExitableState
    {
        void Exit();
        void Update();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}