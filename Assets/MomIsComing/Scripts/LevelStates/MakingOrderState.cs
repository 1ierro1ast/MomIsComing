using MomIsComing.Scripts.EasyDebugger.Runtime;
using MomIsComing.Scripts.EasyStateMachine;
using UnityEngine;

namespace MomIsComing.Scripts.LevelStates
{
    public class MakingOrderState : IState
    {
        private readonly LevelStateMachine _stateMachine;
        private readonly float _time;
        private float _timer;
        private bool _isTimerStarted;

        public MakingOrderState(LevelStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _time = 60;
        }
        public void Exit()
        {
            _isTimerStarted = false;
        }

        public void Update()
        {
            if(!_isTimerStarted) return;
            _timer += Time.deltaTime;
            if (_timer >= _time)
            {
                _isTimerStarted = false;
                NextState();
            }
        }

        private void NextState()
        {
            _stateMachine.Enter<MomState>();
        }

        public void Enter()
        {
            Debugger.Message(nameof(MakingOrderState));
            _isTimerStarted = true;
        }
    }
}