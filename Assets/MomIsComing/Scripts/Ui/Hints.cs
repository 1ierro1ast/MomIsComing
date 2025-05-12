using UnityEngine;

namespace MomIsComing.Scripts.Ui
{
    public class Hints : MonoBehaviour
    {
        [SerializeField] private GameObject _pickupHintBody;
        [SerializeField] private GameObject _placeHintBody;
        
        public static Hints Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void ShowPickupHint()
        {
            if(_pickupHintBody.activeSelf) return;
            HidePlaceHint();
            _pickupHintBody.SetActive(true);
        }
        
        public void HidePickupHint()
        {
            if(!_pickupHintBody.activeSelf) return;
            _pickupHintBody.SetActive(false);
        }
        
        
        public void ShowPlaceHint()
        {
            if(_placeHintBody.activeSelf) return;
            HidePickupHint();
            _placeHintBody.SetActive(true);
        }
        
        public void HidePlaceHint()
        {
            if(!_placeHintBody.activeSelf) return;
            _placeHintBody.SetActive(false);
        }
    }
}