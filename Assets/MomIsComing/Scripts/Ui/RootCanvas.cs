using System;
using MomIsComing.Scripts.Ui.Popups;
using UnityEngine;

namespace MomIsComing.Scripts.Ui
{
    public class RootCanvas : MonoBehaviour
    {
        private static RootCanvas _instance;

        public static RootCanvas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<RootCanvas>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }
        
        [SerializeField] private MenuPopup _menuPopup;
        [SerializeField] private TimerPopup _timerPopup;
        [SerializeField] private WinPopup _winPopup;
        [SerializeField] private LosePopup _losePopup;
        
        public MenuPopup MenuPopup => _menuPopup;

        public TimerPopup TimerPopup => _timerPopup;

        public WinPopup WinPopup => _winPopup;

        public LosePopup LosePopup => _losePopup;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(_instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}