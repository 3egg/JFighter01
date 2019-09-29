using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Controller
{
    public class LoadSceneController : MonoBehaviour
    {
        private AsyncOperation _operation;

        public float progress
        {
            get { return _operation.progress; }
        }

        public async void allowSwitchScene()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _operation.allowSceneActivation = true;
        }

        public IEnumerator loadSceneAsync(string sceneName)
        {
            _operation = SceneManager.LoadSceneAsync(sceneName);
            _operation.allowSceneActivation = false;
            yield return _operation;
        }
    }
}