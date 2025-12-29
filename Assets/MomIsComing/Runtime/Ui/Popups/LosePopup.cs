using UnityEngine;
using UnityEngine.UI;

namespace MomIsComing.Scripts.Ui.Popups
{
    public class LosePopup : BasePopup
    {
        [SerializeField] private Button _nextButton;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _nextButton.onClick.AddListener(OnNextButton);
        }

        private void OnNextButton()
        {
            Hide();
            var sceneLoader = new SceneLoader();
            _ = sceneLoader.LoadScene("MenuScene");
        }
    }
}
