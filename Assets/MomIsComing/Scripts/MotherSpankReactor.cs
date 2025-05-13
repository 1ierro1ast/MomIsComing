using System;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class MotherSpankReactor : MonoBehaviour
    {
        [SerializeField] private Animator _kidAnimator;

        public void Spank()
        {
            if (_kidAnimator == null)
            {
                throw new System.NotImplementedException();
            }
            else
            {
                _kidAnimator.SetTrigger("React");
            }
        }
    }
}