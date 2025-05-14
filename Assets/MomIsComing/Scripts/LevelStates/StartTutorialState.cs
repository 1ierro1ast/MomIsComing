using MomIsComing.Scripts.EasyStateMachine;
using MomIsComing.Scripts.Ui;

namespace MomIsComing.Scripts.LevelStates
{
    public class StartTutorialState : IState
    {
        private readonly LevelStateMachine _stateMachine;

        public StartTutorialState(LevelStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Exit()
        {
            RootCanvas.Instance.StartTutorPopup.TutorAccepted -= OnTutorAccepted;
            RootCanvas.Instance.StartTutorPopup.Hide();
        }

        public void Update()
        {
        }

        public void Enter()
        {
            RootCanvas.Instance.StartTutorPopup.TutorAccepted += OnTutorAccepted;
            RootCanvas.Instance.StartTutorPopup.HideButton();
            RootCanvas.Instance.StartTutorPopup.Show();
        }

        private void OnTutorAccepted()
        {
            _stateMachine.Enter<FriendsWaitingState>();
        }
    }
}