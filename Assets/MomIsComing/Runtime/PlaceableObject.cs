using UnityEngine;
using Random = UnityEngine.Random;

namespace MomIsComing.Scripts
{
    public class PlaceableObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _maxPositionDistance = 5;
        [SerializeField] private float _maxAngleDifference = 180;

        [SerializeField]
        [Range(0, 1)] private float _positionWeight = 0.5f;

        [Space]
        [SerializeField] 
        private GameObject _fxGameObject;

        [SerializeField] private Material _rimMaterial;
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Material _originalMaterial;
        private bool _isLocked;

        public bool IsLocked => _isLocked;

        private void Awake()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;
        }
        
        public float ComparePositionAndRotation()
        {
            Vector3 currentPosition = transform.position;
            Quaternion currentRotation = transform.rotation;
        
            float positionDifference = Vector3.Distance(currentPosition, _startPosition);
            float positionSimilarity = Mathf.Clamp01(1f - (positionDifference / _maxPositionDistance));
        
            float angleDifference = Quaternion.Angle(currentRotation, _startRotation);
            float rotationSimilarity = Mathf.Clamp01(1f - (angleDifference / _maxAngleDifference));
        
            float rotationWeight = 1f - _positionWeight;
            float totalSimilarity = (positionSimilarity * _positionWeight) + (rotationSimilarity * rotationWeight);
        
            return totalSimilarity;
        }

        public void Throw()
        {
            Vector3 direction = Random.insideUnitSphere.normalized;
            float force = Random.Range(10f, 20f);
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }

        public void DisableInteractable()
        {
            gameObject.layer = 0;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.isKinematic = true;
        }
        public void EnableInteractable()
        {
            gameObject.layer = 30;
            _rigidbody.isKinematic = false;
            HidePickupFX();
        }

        public void LockItem()
        {
            _isLocked = true;
        }
        
        public void UnlockItem()
        {
            _isLocked = false;
        }

        public void ShowPickupFX()
        {
            if (_meshRenderer != null && _rimMaterial != null)
            {
                _originalMaterial = _meshRenderer.material;
                _meshRenderer.material = _rimMaterial;
            }

            if(_fxGameObject == null) return;
            _fxGameObject.SetActive(true);
        }
        
        public void HidePickupFX()
        {
            if (_meshRenderer != null && _rimMaterial != null)
            {
                _meshRenderer.material = _originalMaterial;
            }
            
            if(_fxGameObject == null) return;

            _fxGameObject.SetActive(false);   
        }
    }
}