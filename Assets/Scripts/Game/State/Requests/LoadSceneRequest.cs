using SilentPartyGames.Tools.Request;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SilentPartyGames.Game.State
{
    public class LoadSceneRequest : Request
    {
        private readonly int _sceneId;
        private AsyncOperation _asyncOperation;

        public LoadSceneRequest(int sceneId)
        {
            _sceneId = sceneId;
        }

        protected override void CompleteInternal()
        {
            if (_asyncOperation != null) _asyncOperation.completed -= OnSceneLoaded;
        }

        protected override void StartInternal()
        {
            _asyncOperation = SceneManager.LoadSceneAsync(_sceneId);
            _asyncOperation.completed += OnSceneLoaded;
            if (_asyncOperation.isDone)
            {
                OnSceneLoaded(_asyncOperation);
            }
        }

        private void OnSceneLoaded(AsyncOperation obj)
        {
            Complete(true);
        }
    }
}