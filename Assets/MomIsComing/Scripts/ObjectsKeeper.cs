using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class ObjectsKeeper : MonoBehaviour
    {
        [SerializeField] private List<PlaceableObject> _placeableObjects;
        [SerializeField] private float _throwingCooldown = 0.3f;


        public float EvaluateOrder()
        {
            var marks = new List<float>();
            foreach (var placeableObject in _placeableObjects)
            {
                marks.Add(placeableObject.ComparePositionAndRotation());
            }

            var result = marks.Sum()/marks.Count;
            
            return result;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log($"evaluation: {EvaluateOrder()}");
            }
        }

        public void ThrowObjects()
        {
            StartCoroutine(ObjectsThrowing());
        }

        private IEnumerator ObjectsThrowing()
        {
            foreach (var placeableObject in _placeableObjects)
            {
                placeableObject.Throw();
                yield return new WaitForSeconds(_throwingCooldown);
            }
        }

        public void ShowPickupFX()
        {
            foreach (var placeableObject in _placeableObjects)
            {
                placeableObject.ShowPickupFX();
            }
        }       

        public void LockItems()
        {
            foreach (var placeableObject in _placeableObjects)
            {
                placeableObject.LockItem();
            }
        }
        
        public void UnlockItems()
        {
            foreach (var placeableObject in _placeableObjects)
            {
                placeableObject.UnlockItem();
            }
        }
    }
}