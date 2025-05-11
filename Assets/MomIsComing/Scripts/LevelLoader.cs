using MomIsComing.Scripts.StoredData.Runtime;
using MomIsComing.Scripts.UsefulExtensions.Runtime;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private StoredInt _currentLevel;
        [SerializeField] private string[] _scenePaths;
        
        public static LevelLoader Instance;

        private void Awake()
        {
            Instance = this;
            _currentLevel = new StoredInt("CurrentLevel", 0);
        }
        
        public string GetCurrentScene()
        {
            if (_currentLevel.Value >= _scenePaths.Length)
            {
                return _scenePaths.GetRandom();
            }
            
            return _scenePaths[_currentLevel.Value];
        }
    }
}