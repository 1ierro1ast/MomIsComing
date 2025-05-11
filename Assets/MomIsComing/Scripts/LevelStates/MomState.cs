using MomIsComing.Scripts.EasyDebugger.Runtime;
using MomIsComing.Scripts.EasyStateMachine;
using MomIsComing.Scripts.Ui;

namespace MomIsComing.Scripts.LevelStates
{
    public class MomState : IState
    {
        private LevelStateMachine _stateMachine;
        private ObjectsKeeper _objectsKeeper;
        private MomCutscene _momCutscene;


        public MomState(LevelStateMachine stateMachine, ObjectsKeeper objectsKeeper, MomCutscene momCutscene)
        {
            _momCutscene = momCutscene;
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
            
            //Todo:запускаем мамку
            _momCutscene.MomEnter(evaluationResult);
            //катсцена мамки
            
        }
    }
}