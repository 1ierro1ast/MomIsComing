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
        private PartyStarter _partyStarter;

        public FriendsCutsceneState(LevelStateMachine stateMachine, ObjectsKeeper objectsKeeper,
            PartyStarter partyStarter)
        {
            _partyStarter = partyStarter;
            _objectsKeeper = objectsKeeper;
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
            _partyStarter.StopCutscene();
        }

        public void Update()
        {
            if(_waitingCutscene)
            {
                _timer += Time.deltaTime;
                if (_timer >= _partyStarter.CutsceneLength)
                {
                    _waitingCutscene = false;
                    _stateMachine.Enter<MakingOrderState>();
                }
            }
        }

        public void Enter()
        {
            Debugger.Message(nameof(FriendsCutsceneState));
            _partyStarter.StartCutscene();
            _objectsKeeper.ThrowObjects();
            _waitingCutscene = true;
        }
    }
}