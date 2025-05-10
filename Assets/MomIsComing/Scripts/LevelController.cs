using System;
using MomIsComing.Scripts.LevelStates;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ObjectsKeeper _objectsKeeper;
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private PartyStarter _partyStarter;
        
        
        private LevelStateMachine _levelStateMachine;

        private void Awake()
        {
            var gameConfig = Resources.Load<GameConfig>("GameConfig");

            _levelStateMachine = new LevelStateMachine(_objectsKeeper, gameConfig, _levelConfig, _partyStarter);
            
            _levelStateMachine.Enter<FriendsWaitingState>();
        }

        private void Update()
        {
            _levelStateMachine.Update();
        }
    }

    [Serializable]
    public struct LevelConfig
    {
        public float WaitingFriendsTime;
        public float WaitingMomTime;

        public LevelConfig(float waitingFriendsTime = 20, float waitingMomTime = 30)
        {
            WaitingFriendsTime = waitingFriendsTime;
            WaitingMomTime = waitingMomTime;
        }
    }
}