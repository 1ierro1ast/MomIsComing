using MomIsComing.Scripts.EasyDebugger.Runtime;
using MomIsComing.Scripts.EasyStateMachine;
using UnityEngine;

namespace MomIsComing.Scripts.LevelStates
{
    public class FriendsCutsceneState : IState
    {
        private LevelStateMachine _stateMachine;
        private ObjectsKeeper _objectsKeeper;
        private float _timer;
        private bool _waitingCutscene;

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
            if(_waitingCutscene)
            {
                _timer += Time.deltaTime;
                if (_timer >= 2)
                {
                    _waitingCutscene = false;
                    _stateMachine.Enter<MakingOrderState>();
                }
            }
        }

        public void Enter()
        {
            Debugger.Message(nameof(FriendsCutsceneState));
            _objectsKeeper.ThrowObjects();
            _waitingCutscene = true;
        }
    }
}