using MomIsComing.Scripts.EasyDebugger.Runtime;
using MomIsComing.Scripts.EasyStateMachine;

namespace MomIsComing.Scripts.LevelStates
{
    public class FriendsCutsceneState : IState
    {
        private LevelStateMachine _stateMachine;
        private ObjectsKeeper _objectsKeeper;

        public FriendsCutsceneState(LevelStateMachine stateMachine, ObjectsKeeper objectsKeeper)
        {
            _objectsKeeper = objectsKeeper;
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }

        public void Enter()
        {
            Debugger.Message(nameof(FriendsCutsceneState));
            _objectsKeeper.ThrowObjects();
            _stateMachine.Enter<MakingOrderState>();
        }
    }
}