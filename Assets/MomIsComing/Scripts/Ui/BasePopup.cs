using System;
using DG.Tweening;
using MomIsComing.Scripts.PlayerController;
using UnityEngine;
using UnityEngine.UI;

namespace MomIsComing.Scripts.Ui
{
    public class BasePopup : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _closeButton;
        [SerializeField] private bool _openOnAwake;
        [SerializeField] private bool _focusOnUi;
        
        
        protected bool _isActive;

        private void Awake()
        {
            if (_openOnAwake)
            {
                ShowInstantly();
            }
            else
            {
                HideInstantly();
            }
            
            OnInitialize();
        }

        public void ShowInstantly()
        {
            if (_focusOnUi)
            {
                FocusOnUi();
            }
            
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
            _isActive = true;
            OnShownCallback();
        }
        public void HideInstantly()
        {
            if (_focusOnUi)
            {
                FocusOnGameplay();
            }
            
            _canvasGroup.gameObject.SetActive(false);
            _canvasGroup.alpha = 0;
            _isActive = false;
            OnHideCallback();
        }

        public void Show(Action onShown = null)
        {
            if(_closeButton != null) _closeButton.onClick.AddListener(HidePopup);
            
            if (_focusOnUi)
            {
                FocusOnUi();
            }
            
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup
                .DOFade(1, 0.25f)
                .OnComplete(() =>
            {
                onShown?.Invoke();
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
                
                OnShownCallback();
            });
        }

        public void Hide(Action onHide = null)
        {
            if(_closeButton != null) _closeButton.onClick.RemoveListener(HidePopup);
            
            if (_focusOnUi)
            {
                FocusOnGameplay();
            }
            
            _canvasGroup.DOFade(0, 0.25f).OnComplete(() =>
            {
                onHide?.Invoke();
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.gameObject.SetActive(false);
                OnHideCallback();
            });
        }
        
        
        protected void FocusOnUi()
        {
            if(FirstPersonController.Instance != null)
                FirstPersonController.Instance.LockControl();
            
            /*if(!EasyContext.Instance.IsInitialized) return;

            EasyContext.Instance.Get<Player>().LockControl();
            EasyContext.Instance.Get<InterfaceService>().EnableCursor();*/
        }
        
        protected void FocusOnGameplay()
        {
            if(FirstPersonController.Instance != null)
                FirstPersonController.Instance.UnlockControl();

            /*if(!EasyContext.Instance.IsInitialized) return;
            
            EasyContext.Instance.Get<Player>().UnlockControl();
            EasyContext.Instance.Get<InterfaceService>().DisableCursor();*/
        }

        private void HidePopup()
        {
            Hide();
        }

        protected virtual void OnInitialize()
        {
            
        }

        protected virtual void OnHideCallback()
        {
        
        }

        protected virtual void OnShownCallback()
        {
            
        }

    }
}