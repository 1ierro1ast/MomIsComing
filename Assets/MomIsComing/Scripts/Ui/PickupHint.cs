using UnityEngine;

namespace MomIsComing.Scripts.Ui
{
    public class PickupHint : MonoBehaviour
    {
        [SerializeField] private GameObject _hintBody;
        
        public static PickupHint Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void ShowHint()
        {
            if(gameObject.activeSelf) return;
            gameObject.SetActive(true);
        }
        
        public void HideHint()
        {
            if(!gameObject.activeSelf) return;
            gameObject.SetActive(false);
        }
    }
}