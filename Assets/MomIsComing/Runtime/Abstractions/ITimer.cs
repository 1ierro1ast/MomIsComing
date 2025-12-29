using System;

namespace MomIsComing.Scripts.Abstractions
{
    public interface ITimer
    {
        void Initialize(Action<float, float> updatedCallback);
        void Deinitialize();
        
    }
}