using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
             _game = new Game();
             _game._stateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }

    public class SceneLoader
    {
        public void LoadScene(string name, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
            
            
        }
    }
}