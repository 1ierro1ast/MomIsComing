using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MomIsComing.Scripts.Ui.Popups
{
    public class StartTutorPopup : BasePopup
    {
        [SerializeField] private Button _okButton;

        public event Action TutorAccepted;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _okButton.onClick.AddListener(OkButtonClicked);
        }

        protected override void OnShownCallback()
        {
            base.OnShownCallback();
            DOVirtual.DelayedCall(1, () =>
            {
                _okButton.transform.DOScale(Vector3.one * 1.2f, 0.3f).OnComplete((() =>
                {
                    _okButton.transform.DOScale(Vector3.one, 0.1f);
                }));
            });
        }

        private void OkButtonClicked()
        {
            TutorAccepted?.Invoke();
        }

        public void HideButton()
        {
            _okButton.transform.localScale = Vector3.zero;
        }
    }
}