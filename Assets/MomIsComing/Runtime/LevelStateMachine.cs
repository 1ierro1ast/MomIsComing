using MomIsComing.Scripts.EasyStateMachine;
using MomIsComing.Scripts.LevelStates;

namespace MomIsComing.Scripts
{
    public class LevelStateMachine : BaseStateMachine
    {
        public LevelStateMachine(ObjectsKeeper objectsKeeper, GameConfig gameConfig, LevelConfig levelConfig,
            PartyStarter partyStarter, MomCutscene momCutscene)
        {
            RegisterState(new StartTutorialState(this));
            RegisterState(new FriendsWaitingState(this, gameConfig, levelConfig.WaitingFriendsTime, objectsKeeper));
            RegisterState(new FriendsCutsceneState(this, objectsKeeper, partyStarter));
            RegisterState(new MakingOrderState(this, gameConfig, levelConfig.WaitingMomTime, objectsKeeper));
            RegisterState(new MomState(this, objectsKeeper, momCutscene));
        }
    }
}