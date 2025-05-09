using System.Collections;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine logicLoop);
    }
}