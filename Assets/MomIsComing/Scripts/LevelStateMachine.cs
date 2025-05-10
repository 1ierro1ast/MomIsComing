using MomIsComing.Scripts.EasyStateMachine;
using MomIsComing.Scripts.LevelStates;

namespace MomIsComing.Scripts
{
    public class LevelStateMachine : BaseStateMachine
    {
        public LevelStateMachine(ObjectsKeeper objectsKeeper, GameConfig gameConfig, LevelConfig levelConfig)
        {
            RegisterState(new FriendsWaitingState(this, gameConfig, levelConfig.WaitingFriendsTime));
            RegisterState(new FriendsCutsceneState(this, objectsKeeper));
            RegisterState(new MakingOrderState(this, gameConfig, levelConfig.WaitingMomTime));
            RegisterState(new MomState(this, objectsKeeper));
        }
    }
}