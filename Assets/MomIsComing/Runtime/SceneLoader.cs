using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MomIsComing.Scripts
{
    public class SceneLoader
    {
        public async Task LoadScene(string name, bool validateSceneName = true, Action<string> onLoaded = null)
        {
            if (validateSceneName && SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke(name);
                return;
            }

            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(name);
            await loadOperation;
            onLoaded?.Invoke(name);
        }
    }
}
