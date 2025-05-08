using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace MomIsComing.Scripts.PlayerController
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _mouseSensitivity = 2f;
        
        [Header("Running Settings")]
        [SerializeField] private float _maxRunTime = 5f;
        [SerializeField] private float _runCooldown = 3f;
        [SerializeField] private float _staminaRecoveryRate = 1f;
        
        [Header("References")]
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        [SerializeField] private Transform _cameraRoot;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundDistance = 0.4f;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private Animator _animator;

        private CharacterController _controller;
        private Vector3 _velocity;
        private bool _isGrounded;

        private float _currentRunTime;
        private float _currentCooldown;
        private bool _canRun = true;
        private bool _canRotate = true;

        private float _xRotation = 0f;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _currentRunTime = _maxRunTime;
        
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void LockRotation()
        {
            _canRotate = false;
        }
        
        public void UnlockRotation()
        {
            _canRotate = true;
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
            HandleRunning();
        }

        private void HandleMovement()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) && _canRun ? _runSpeed : _walkSpeed;
            _animator.SetBool(IsMoving, currentSpeed > 0f);
            _controller.Move(move * currentSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }

            _velocity.y += _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

        private void HandleRotation()
        {
            if(!_canRotate) return;
            
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _cameraRoot.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        
            transform.Rotate(Vector3.up * mouseX);
        }

        private void HandleRunning()
        {
            bool tryingToRun = Input.GetKey(KeyCode.LeftShift) && _canRun;
            bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

            if (tryingToRun && isMoving)
            {
                _currentRunTime -= Time.deltaTime;
                if (_currentRunTime <= 0)
                {
                    _canRun = false;
                    _currentCooldown = _runCooldown;
                }
            }
            else if (!_canRun)
            {
                _currentCooldown -= Time.deltaTime;
                if (_currentCooldown <= 0)
                {
                    _canRun = true;
                }
            }

            if (!tryingToRun && _currentRunTime < _maxRunTime)
            {
                _currentRunTime += Time.deltaTime * _staminaRecoveryRate;
                _currentRunTime = Mathf.Clamp(_currentRunTime, 0, _maxRunTime);
            }
        }

        public float GetStaminaNormalized()
        {
            return _currentRunTime / _maxRunTime;
        }

        public bool CanRun()
        {
            return _canRun;
        }
    }
}