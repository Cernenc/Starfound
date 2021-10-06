using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Scenes
{
    public class Loader
    {
        public IEnumerator LoadLevelAsync()
        {
            var actualSceneAsyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            actualSceneAsyncOperation.allowSceneActivation = false;

            while (actualSceneAsyncOperation.progress < 0.9f)
            {
                yield return null;
            }

            actualSceneAsyncOperation.allowSceneActivation = true;

            yield return new WaitUntil(() => actualSceneAsyncOperation.isDone);
            UnloadLevelAsync();
        }

        private void ActualSceneAsyncOperation_completed(AsyncOperation obj)
        {
            throw new System.NotImplementedException();
        }

        public void UnloadLevelAsync()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.None);
        }
    }
}
