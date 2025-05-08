using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;

namespace MomIsComing.Scripts.PlayerController
{
    public class ObjectInteractor : MonoBehaviour
    {
        [SerializeField] private FirstPersonController _firstPersonController;
        [SerializeField] private float _takeDistance = 3f;
        [SerializeField] private Transform _eyes;
        [SerializeField] private LayerMask _interactableLayer;
        [SerializeField] private Transform _parent;
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private float _placementOffset = 0.00f;
        [SerializeField] private Transform _target;
        [SerializeField] private Rig _rig;
        
        private bool _isInteractPressed;
        private bool _isRotatingObject;
        private PlaceableObject _availablePlaceableObject;
        private PlaceableObject _takenObject;
        private RaycastHit _hitPoint;
        private Vector3 _lastValidHitPoint;
        private float _lerpTarget;
        private bool _lerpWeight;

        private void Update()
        {
            UpdateInteractionRay();
            HandleInput();
            HandleInteraction();

            _rig.weight = Mathf.Lerp(_rig.weight, _lerpTarget, 10 * Time.deltaTime);

            _target.position = _eyes.position + _eyes.forward;

            if (_takenObject != null && !_isRotatingObject)
            {
                _takenObject.transform.rotation = transform.rotation * Quaternion.identity;
            }

        }

        private void UpdateInteractionRay()
        {
            if (Physics.Raycast(_eyes.position, _eyes.forward, out _hitPoint, _takeDistance, _interactableLayer))
            {
                Debug.DrawRay(_eyes.position, _eyes.forward * _takeDistance, Color.green);
                if(!_isRotatingObject) _lastValidHitPoint = _hitPoint.point;
                TryInteractWith(_hitPoint.transform);
            }
            else
            {
                Debug.DrawRay(_eyes.position, _eyes.forward * _takeDistance, Color.red);
            }
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isInteractPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                if (_isRotatingObject && _takenObject != null)
                {
                    CompleteObjectPlacement();
                }
                _isInteractPressed = false;
            }
        }

        private void HandleInteraction()
        {
            if (!_isInteractPressed) return;

            if (_availablePlaceableObject != null && _takenObject == null)
            {
                GrabObject();
            }
            else if (_takenObject != null)
            {
                TryPlaceOrRotateObject();
            }
        }

        private void GrabObject()
        {
            _lerpTarget = 1;
            _takenObject = _availablePlaceableObject;
            _takenObject.transform.SetParent(_parent);
            _takenObject.transform.localPosition = Vector3.zero;
            _takenObject.DisableInteractable();
            _isInteractPressed = false;
        }

        private void TryPlaceOrRotateObject()
        {
            float dot = Vector3.Dot(_hitPoint.normal.normalized, Vector3.up);

            if (dot > 0.99f)
            {
                if (!_isRotatingObject)
                {
                    StartObjectRotation();
                }
                else
                {
                    RotateObject();
                }
            }
        }

        private void StartObjectRotation()
        {
            _firstPersonController.LockRotation();
            
            _takenObject.transform.SetParent(null);
            _takenObject.transform.position = _lastValidHitPoint + Vector3.up * _placementOffset;
            _takenObject.transform.rotation = Quaternion.identity;
            _isRotatingObject = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void RotateObject()
        {
            float rotation = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            _takenObject.transform.Rotate(Vector3.up, -rotation, Space.World);
        }

        private void CompleteObjectPlacement()
        {
            _lerpTarget = 0;
            _takenObject.transform.position = _lastValidHitPoint + Vector3.up * _placementOffset;
            _takenObject.EnableInteractable();
            _takenObject = null;
            _isRotatingObject = false;
            _firstPersonController.UnlockRotation();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void TryInteractWith(Transform hitTransform)
        {
            _availablePlaceableObject = hitTransform.GetComponent<PlaceableObject>();
        }
    }
}