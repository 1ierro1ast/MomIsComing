using UnityEngine;

namespace MomIsComing.Scripts.UsefulExtensions.Runtime
{
    public static class BoundsExtensions
    {
        public static bool IsVolumeWithinBounds(this Bounds bounds, float maxVolume)
        {
            float boundsVolume = bounds.size.x * bounds.size.y * bounds.size.z;
            return boundsVolume <= maxVolume;
        }
        
        public static Bounds IsVolumeWithinBounds(this Bounds bounds, float maxVolume,out bool result)
        {
            float boundsVolume = bounds.size.x * bounds.size.y * bounds.size.z;
            result = boundsVolume <= maxVolume;
            return bounds;
        }
    }
}