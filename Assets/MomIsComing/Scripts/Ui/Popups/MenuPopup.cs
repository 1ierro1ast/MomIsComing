using MomIsComing.Scripts.EasyDebugger.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace MomIsComing.Scripts.Ui.Popups
{
    public class MenuPopup : BasePopup, ICoroutineRunner
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        private SceneLoader _sceneLoader;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _sceneLoader = new SceneLoader(this);
        }

        protected override void OnShownCallback()
        {
            Debugger.Message("On shown callback");
            _playButton.onClick.AddListener(OnPlayButton);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        protected override void OnHideCallback()
        {
            _playButton.onClick.RemoveListener(OnPlayButton);
            _exitButton.onClick.RemoveListener(OnExitButton);
        }

        private void OnExitButton()
        {
            Application.Quit();
        }

        private void OnPlayButton()
        {
            Debugger.Message("Play button clicked");
            Hide();
            var levelLoader = LevelLoader.Instance;
            RootCanvas.Instance.LoadingScreen.SetCallback(() =>
            {
                _sceneLoader.LoadScene(levelLoader.GetCurrentScene(), onLoaded: OnLoaded);
            });
            RootCanvas.Instance.LoadingScreen.Show();
            
        }

        private void OnLoaded(string obj)
        {
            RootCanvas.Instance.LoadingScreen.Hide();
        }
    }
}