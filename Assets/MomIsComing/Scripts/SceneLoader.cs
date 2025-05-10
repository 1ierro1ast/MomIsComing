using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MomIsComing.Scripts
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string name, bool validateSceneName = true, Action<string> onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(name, validateSceneName, onLoaded));
        }

        private IEnumerator LoadSceneCoroutine(string name, bool validateSceneName, Action<string> onLoaded = null)
        {
            if (validateSceneName && SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke(name);
                yield break;
            }

            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(name);

            loadOperation.allowSceneActivation = false;

            loadOperation.allowSceneActivation = true;
            while (!loadOperation.isDone)
            {

                yield return null;
            }

            onLoaded?.Invoke(name);
        }
    }
}