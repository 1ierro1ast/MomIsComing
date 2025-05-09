using UnityEngine;

namespace MomIsComing.Scripts
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private float _playerWalkSpeed = 3;
        [SerializeField] private float _playerRunSpeed = 6;
        [SerializeField] private string _waitingFriendsLabel = "Friends are coming in {0}";
        [SerializeField] private string _waitingMomLabel = "Mom is coming in {0}";

        public float PlayerWalkSpeed => _playerWalkSpeed;

        public float PlayerRunSpeed => _playerRunSpeed;

        public string WaitingFriendsLabel => _waitingFriendsLabel;

        public string WaitingMomLabel => _waitingMomLabel;
    }
}
