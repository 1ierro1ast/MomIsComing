using MomIsComing.Scripts.LevelStates;
using MomIsComing.Scripts.Ui;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ObjectsKeeper _objectsKeeper;
        
        private LevelStateMachine _levelStateMachine;

        private void Awake()
        {
            _levelStateMachine = new LevelStateMachine(_objectsKeeper);
            
            _levelStateMachine.Enter<FriendsWaitingState>();
        }

        private void Update()
        {
            _levelStateMachine.Update();
        }
    }
}