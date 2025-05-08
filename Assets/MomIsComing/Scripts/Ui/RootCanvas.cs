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
        
        /*[SerializeField] private DebugPopup _debugPopup;
        [SerializeField] private MenuPopup _menuPopup;*/
        
        
        /*public DebugPopup DebugPopup => _debugPopup;
        public MenuPopup MenuPopup => _menuPopup;*/
        
    }
}