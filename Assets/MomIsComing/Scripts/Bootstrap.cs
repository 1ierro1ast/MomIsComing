using UnityEngine;

namespace MomIsComing.Scripts
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private void Start()
        {
            var sceneLoader = new SceneLoader(this);
            sceneLoader.LoadScene("MenuScene");
        }
    }
}