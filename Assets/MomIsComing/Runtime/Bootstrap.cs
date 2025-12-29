using UnityEngine;

namespace MomIsComing.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            var sceneLoader = new SceneLoader();
            _ = sceneLoader.LoadScene("MenuScene");
        }
    }
}
