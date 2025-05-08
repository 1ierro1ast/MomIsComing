using MomIsComing.Scripts.EasyStateMachine;
using MomIsComing.Scripts.LevelStates;
using MomIsComing.Scripts.Ui;

namespace MomIsComing.Scripts
{
    public class LevelStateMachine : BaseStateMachine
    {
        public LevelStateMachine(ObjectsKeeper objectsKeeper)
        {
            RegisterState(new FriendsWaitingState(this));
            RegisterState(new FriendsCutsceneState(this, objectsKeeper));
            RegisterState(new MakingOrderState(this));
            RegisterState(new MomState(this, objectsKeeper));
        }
    }
}