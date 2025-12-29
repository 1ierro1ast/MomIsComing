using UnityEngine;

namespace MomIsComing.Scripts
{
    public class StepsHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _leftStep;
        [SerializeField] private AudioSource _rightStep;

        public void LeftStep()
        {
            _leftStep.PlayOneShot(_leftStep.clip);
        }
    
        public void RightStep()
        {
            _rightStep.PlayOneShot(_rightStep.clip);
        }
    }
}
