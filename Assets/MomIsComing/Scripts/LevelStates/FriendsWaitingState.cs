using System;
using MomIsComing.Scripts.Abstractions;
using MomIsComing.Scripts.EasyDebugger.Runtime;
using MomIsComing.Scripts.EasyStateMachine;
using MomIsComing.Scripts.Ui;
using UnityEngine;

namespace MomIsComing.Scripts.LevelStates
{
    public class FriendsWaitingState : IState, ITimer
    {
        private readonly LevelStateMachine _stateMachine;
        private readonly float _time;
        private float _timer; 
        private bool _isTimerStarted;
        private string _label;
        private Action<float,float> _updatedCallback;
        private ObjectsKeeper _objectsKeeper;

        public FriendsWaitingState(LevelStateMachine stateMachine, GameConfig gameConfig,
            float waitingFriendsTime, ObjectsKeeper objectsKeeper)
        {
            _objectsKeeper = objectsKeeper;
            _stateMachine = stateMachine;
            _time = waitingFriendsTime;
            _label = gameConfig.WaitingFriendsLabel;
        }
        public void Exit()
        {
            _isTimerStarted = false;
            
            var timerPopup = RootCanvas.Instance.TimerPopup;
            timerPopup.Hide();
        }

        public void Update()
        {
            if(!_isTimerStarted) return;
            _timer += Time.deltaTime;
            
            _updatedCallback?.Invoke(_timer, _time);
            
            if (_timer >= _time)
            {
                _isTimerStarted = false;
                NextState();
            }
        }

        public void Enter()
        {
            Debugger.Message(nameof(FriendsWaitingState));
            _objectsKeeper.LockItems();
            _isTimerStarted = true;
            var timerPopup = RootCanvas.Instance.TimerPopup;
            timerPopup.Construct(this, _label);
            timerPopup.Show();
        }

        private void NextState()
        {
            _stateMachine.Enter<FriendsCutsceneState>();
        }

        public void Initialize(Action<float, float> updatedCallback)
        {
            _updatedCallback = updatedCallback;
        }

        public void Deinitialize()
        {
            _updatedCallback = null;
        }
    }
}