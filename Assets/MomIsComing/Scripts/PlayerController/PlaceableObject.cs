using UnityEngine;

namespace MomIsComing.Scripts.PlayerController
{
    public class PlaceableObject : MonoBehaviour
    {
        
        public void DisableInteractable()
        {
            gameObject.layer = 0;
        }
        public void EnableInteractable()
        {
            gameObject.layer = 30;
        }
    }
}