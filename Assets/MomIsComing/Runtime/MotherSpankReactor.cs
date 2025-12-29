using UnityEngine;

namespace MomIsComing.Scripts
{
    public class MotherSpankReactor : MonoBehaviour
    {
        private static readonly int React = Animator.StringToHash("React");
        [SerializeField] private Animator _kidAnimator;

        public void Spank()
        {
            if (_kidAnimator == null)
            {
                Debug.LogWarning("Kid animator is missing");
                return;
            }
            _kidAnimator?.SetTrigger(React);
            
        }
    }
}