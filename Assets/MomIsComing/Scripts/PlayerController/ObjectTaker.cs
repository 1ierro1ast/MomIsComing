using System;
using UnityEngine;

namespace MomIsComing.Scripts.PlayerController
{
    public class ObjectTaker : MonoBehaviour
    {
        [SerializeField] private float _takeDistance;
        [SerializeField] private Transform _eyes;
        [SerializeField] private LayerMask _interactableLayer;
        
        
        private void Update()
        {
            if (Physics.Raycast(_eyes.position, _eyes.forward, out RaycastHit hit, _takeDistance, _interactableLayer))
            {
                
            }
        }
    }
}