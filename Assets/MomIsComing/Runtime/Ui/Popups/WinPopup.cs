using MomIsComing.Scripts.StoredData.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace MomIsComing.Scripts.Ui.Popups
{
    public class WinPopup : BasePopup
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
            //todo сделать нормально перематывание уровня
            
            var currentLevel = new StoredInt("CurrentLevel", 0);
            currentLevel.Value++;
            
            var sceneLoader = new SceneLoader();
            _ = sceneLoader.LoadScene("MenuScene");
        }
    }
}
