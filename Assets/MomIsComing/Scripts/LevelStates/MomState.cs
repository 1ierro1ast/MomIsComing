using MomIsComing.Scripts.EasyDebugger.Runtime;
using MomIsComing.Scripts.EasyStateMachine;

namespace MomIsComing.Scripts.LevelStates
{
    public class MomState : IState
    {
        private LevelStateMachine _stateMachine;
        private ObjectsKeeper _objectsKeeper;

        public MomState(LevelStateMachine stateMachine, ObjectsKeeper objectsKeeper)
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
            Debugger.Message(nameof(MomState));

            float evaluationResult = _objectsKeeper.EvaluateOrder();
            string result = evaluationResult >= 0.85f ? "WIN" : "LOSE";
            Debugger.Message($"Level finished! You are {result}! EvaluationResult: {evaluationResult}");
            Debugger.Message($"Restart game manually please :)");
        }
    }
}